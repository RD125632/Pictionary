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

                string response = Encoding.ASCII.GetString(bytesFrom);
                string[] response_parts = response.Split('|');

                if (response_parts.Length > 0)
                {
                        switch (response_parts[0])
                        {
                            case "2": //Receive Chat
                                activeForm.Invoke((MethodInvoker)delegate ()
                                {
                                    activeForm.chatMessagesLocal.Add(new Tuple<string, string>(response_parts[1], response_parts[2]));
                                    activeForm.repopulateChat();
                                });
                                break;
                            case "3": //Last word was correct
                                activeForm.Invoke((MethodInvoker)delegate ()
                                {
                                    activeForm.chatMessagesLocal.Add(new Tuple<string, string>(response_parts[1], response_parts[2]));
                                    activeForm.setAnswer();
                                });
                                break;
                            case "4": //Receive the super secret word
                                isActiveClient = true;

                               activeForm.Invoke((MethodInvoker)delegate ()
                               {
                                   activeForm.setWord(response_parts[1]);
                               });
                            break;
                            case "6": //Recieve Clear image command

                                activeForm.Invoke((MethodInvoker)delegate ()
                                {
                                    activeForm.clearImage();
                                });
                            break;
                        case "9": //Receive Image Point

                                activeForm.Invoke((MethodInvoker)delegate ()
                                {
                                    activeForm.addToImage(JsonConvert.DeserializeObject<ImagePoint>(response_parts[1]));
                                });
                                break;
                        case "10": //Receive Image Point

                            activeForm.Invoke((MethodInvoker)delegate ()
                            {
                                isActiveClient = false;
                                activeForm.clearImage();
                            });

                            break;
                    }
                }
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