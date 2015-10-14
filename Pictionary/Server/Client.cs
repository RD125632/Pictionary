using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;
using System.IO;

namespace Server
{
    public class Client
    {
        TcpClient client;
        NetworkStream networkStream;
        private readonly AppGlobal _global;
        private string name;
        private bool isActive;


        public Client(TcpClient socket)
        {
            client = socket;
            networkStream = client.GetStream();
            _global = AppGlobal.Instance;
            Console.WriteLine("New client connected");
            Thread t = new Thread(recieve);
            t.Start();

            name = "";
            isActive = false;
        }

        public void recieve()
        {
            while (true)
            {
                byte[] bytesFrom = new byte[(int)client.ReceiveBufferSize];
                networkStream.Read(bytesFrom, 0, (int)client.ReceiveBufferSize);

                if (bytesFrom[0] == 48)
                {
                    foreach (Client c in _global.GetClients())
                    {
                        if (!c.Equals(this))
                        {
                            networkStream.Write(bytesFrom, 0, bytesFrom.Length);
                            networkStream.Flush();
                        }
                    }
                }
                else
                {
                    String response = Encoding.ASCII.GetString(bytesFrom);
                    String[] response_parts = response.Split('|');
                    if (response_parts.Length > 0)
                    {
                        switch (response_parts[0])
                        {
                            case "1":   //Set user name
                                name = response_parts[1];
                                break;
                            case "2":   //Recieve Chat
                                _global.AddChatMessage(name, response_parts[1]);

                                foreach(Client c in _global.GetClients())
                                {
                                    c.sendString("2|" + JsonConverter.GetChatInJson(_global) + "|");
                                }
                                
                                break;
                            case "4":   //Ask Word
                                if(!_global.GetClients().Any(c => c.isActive == true))
                                {
                                    sendString("4|" + _global.GetWord() + "|");
                                    isActive = true;
                                }

                                break;
                            case "9":   //ImagePoints
                                _global.pixelPoints.Add(JsonConvert.DeserializeObject<ImagePoint>(response_parts[1]));

                                foreach (Client c in _global.GetClients())
                                {
                                    //c.sendString("9|" + response_parts[1] + 
                                    c.sendString("9|" + JsonConvert.SerializeObject(_global.pixelPoints) + "|");
                                }

                                break;
                        }
                    }
                }
            }
        }

        public void sendString(string s)
        {
            byte[] b = Encoding.ASCII.GetBytes(s);
            networkStream.Write(b, 0, b.Length);
            networkStream.Flush();
        }
    }
}
