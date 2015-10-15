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
            isActive = false;
            client = socket;
            networkStream = client.GetStream();
            _global = AppGlobal.Instance;
            Console.WriteLine("New client connected");
            Thread t = new Thread(recieve);
            t.Start();

            name = "";
        }

        public void recieve()
        {
            while (true)
            {
                byte[] bytesFrom = new byte[(int)client.ReceiveBufferSize];
                networkStream.Read(bytesFrom, 0, (int)client.ReceiveBufferSize);

                    String response = Encoding.ASCII.GetString(bytesFrom);
                    String[] response_parts = response.Split('|');
                    if (response_parts.Length > 0)
                    {
                        switch (response_parts[0])
                        {
                            case "1":   //Set user name
                                name = response_parts[1];

                                if(_global.GetClients().Count > 1)
                                {
                                    askWord();
                                }

                                broadcastString("2|" + "Server" + "|" + response_parts[1] + " joined" + "|");
                                break;
                            case "2":   //Recieve Chat
                                if (response_parts[1].ToLower() == _global.supersecretword.ToLower() && this.isActive == false)
                                {
                                    broadcastString("3|" + name + "|" + response_parts[1] + "|");
                                }
                                else
                                {
                                    broadcastString("2|" + name + "|" + response_parts[1] + "|");
                                }
                                break;
                            case "4":   //Ask Word
                                askWord();
                                break;
                            case "6":   //Clear Image
                                broadcastString("6|");
                                break;
                            case "9":   //ImagePoints
                                _global.pixelPoints.Add(JsonConvert.DeserializeObject<ImagePoint>(response_parts[1]));
                                broadcastString("9|" + response_parts[1] + "|");
                                break;
                            case "10":   //Reset Game
                                broadcastString("10|");
                                isActive = false;
                                int activeCount = 0;

                                foreach (Client c in _global.GetClients())
                                {
                                    if (c.isActive == true)
                                    {
                                        activeCount++;
                                    }
                                }

                                if(activeCount == 0)
                                {
                                    askWord();
                                }

                                break;
                        }
                    
                }
            }
        }

        private void askWord()
        {
            int index = new Random().Next(_global.GetClients().Count);
            _global.supersecretword = _global.GetWord();
            _global.GetClients().ElementAt(index).sendString("4|" + _global.supersecretword + "|");
            _global.GetClients().ElementAt(index).isActive = true;
        }

        public void broadcastString(string s)
        {
            foreach (Client c in _global.GetClients())
            {
                c.sendString(s);
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
