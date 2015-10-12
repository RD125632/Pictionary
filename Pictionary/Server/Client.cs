using System;
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
                String response = Encoding.ASCII.GetString(bytesFrom);
                String[] response_parts = response.Split('|');
                if (response_parts.Length > 0)
                {
                    switch (response_parts[0])
                    {
                        case "0":   //Set user name
                            name = response_parts[1];

                            if (_global.GetClients().Count() < 2)
                            {
                                sendString("1|" + _global.GetWord() + "|");
                                isActive = true;
                            }

                            break;
                            
                        case "2":   //Recieve Chat
                            _global.AddChatMessage(name, response_parts[1]);
                            break;
                        case "3":   //Send Chat
                            sendString("3|" + JsonConverter.GetChatInJson(_global) + "|"); 
                            break;
                        case "4" : //Recieve Image
                            
                            foreach(Client c in _global.GetClients())
                            {
                                if (!c.Equals(this))
                                {
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        sendString("4|" + response_parts[1] + "|");
                                    }
                                }
                            }

                            break;
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
