using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Pictionary.UserControls;

namespace Pictionary
{
    public class TcpConnection
    {
        public TcpClient client;
        public bool isConnectedFlag { private set; get; }
        private NetworkStream serverStream;
        private Thread receiveThread;
        public bool isActiveClient = false;
        private MainForm activeForm;
        private int chunks = 0;

        public TcpConnection(MainForm form)
        {
            activeForm = form;
            client = new TcpClient();
            connect();
        }

        public bool isConnected()
        {
            return isConnectedFlag;
        }

        public void connect()
        {
            try
            {
                client.Connect("127.0.0.1", 1288);

                // create streams
                serverStream = client.GetStream();
                receiveThread = new Thread(receive);
                receiveThread.Start();
                isConnectedFlag = true;

                activeForm.setConnectLBL();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Thread.Sleep(1000);
                isConnectedFlag = false;

                
            }
        }

        public void disconnect()
        {
            receiveThread.Abort();
            serverStream.Close();
            client.Close();
            isConnectedFlag = false;
        }

        public void receive()
        {
            byte[] newImage = new byte[1723446];

            while (true)
            {
                byte[] bytesFrom = new byte[(int) client.ReceiveBufferSize];
                serverStream.Read(bytesFrom, 0, (int) client.ReceiveBufferSize);


                if (bytesFrom[0] == 48)
                {
                    if (chunks < 27)
                    {
                        Buffer.BlockCopy(bytesFrom, 2, newImage, (chunks * 65533), ((chunks * 65533) < newImage.Length) ? 65533 : (newImage.Length - ((chunks - 1) * 65533)));
                        chunks++;
                    }
                    else
                    {
                        activeForm.Invoke((MethodInvoker)delegate ()
                        {
                            activeForm.setImage(newImage);
                        });
                        chunks = 0;
                    }
                }
                else
                {
                    string response = Encoding.ASCII.GetString(bytesFrom);
                    string[] response_parts = response.Split('|');
                    if (response_parts.Length > 0)
                    {
                        switch (response_parts[0])
                        {
                            case "2": //Receive Chat
                                activeForm.Invoke((MethodInvoker)delegate ()
                                {
                                    activeForm.chatMessagesRecieved = JsonConvert.DeserializeObject<List<Tuple<string, string>>>(response_parts[1]);
                                    activeForm.repopulateChat();
                                });
                                break;
                            case "4": //Receive the super secret word
                                isActiveClient = true;

                                activeForm.Invoke((MethodInvoker)delegate ()
                               {
                                   activeForm.setWord(response_parts[1]);
                               });
                            break;
                            
                        }
                    }
                }
            } 
        }

        public void SendImage(string s, byte[] img ,string b)
        {
            // Image is 1723446 
            // Buffersize is 65536
            // 3 Bytes are needed for the IDs

            byte[] a1 = Encoding.ASCII.GetBytes(s);
            byte[] a3 = Encoding.ASCII.GetBytes(b);
            int lastIMGBYTE = 0;
            byte[] chunkPackage = new byte[65536];
            chunks = 0;

            while (chunks < 27)
            {
                Buffer.BlockCopy(a1, 0, chunkPackage, 0, a1.Length);
                Buffer.BlockCopy(img, lastIMGBYTE, chunkPackage, a1.Length, ((img.Length - lastIMGBYTE) > 65533) ? 65533 : (img.Length - lastIMGBYTE));
                Buffer.BlockCopy(a3, 0, chunkPackage, a1.Length + 65533, a3.Length);

                serverStream.Write(chunkPackage, 0, chunkPackage.Length);
                serverStream.Flush();
                lastIMGBYTE += 65536;
                chunks++;
                Array.Clear(chunkPackage, 0, chunkPackage.Length);
            }
            
        }

        public void SendString(string s)
        {
            byte[] b = Encoding.ASCII.GetBytes(s);
            serverStream.Write(b, 0, b.Length);
            serverStream.Flush();
        }
    }
}