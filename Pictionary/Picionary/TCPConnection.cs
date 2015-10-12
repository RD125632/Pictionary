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

        public TcpConnection()
        {
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
                client.Connect("localhost", 1288);

                // create streams
                serverStream = client.GetStream();
                receiveThread = new Thread(receive);
                receiveThread.Start();
                isConnectedFlag = true;
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
            MainForm activeForm = (MainForm)Form.ActiveForm;

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
                        case "1":
                            
                            activeForm.Invoke((MethodInvoker) delegate()
                            {
                                activeForm.setWord(response_parts[1]);
                            });
                            break;
                        case "2":
                            activeForm.Invoke((MethodInvoker)delegate ()
                            {
                                activeForm.setImage(Encoding.ASCII.GetBytes(response_parts[1]));
                            });
                            break;
                    }
                }
            } 
        }

        public void SendImage(string s, byte[] img ,string b)
        {
            byte[] a1 = Encoding.ASCII.GetBytes(s);
            byte[] a3 = Encoding.ASCII.GetBytes(b);
            byte[] rv = new byte[a1.Length + img.Length + a3.Length];
            System.Buffer.BlockCopy(a1, 0, rv, 0, a1.Length);
            System.Buffer.BlockCopy(img, 0, rv, a1.Length, img.Length);
            System.Buffer.BlockCopy(a3, 0, rv, a1.Length + img.Length, a3.Length);

            serverStream.Write(rv, 0, rv.Length);
            serverStream.Flush();
        }

        public void SendString(string s)
        {
            byte[] b = Encoding.ASCII.GetBytes(s);
            serverStream.Write(b, 0, b.Length);
            serverStream.Flush();
        }
    }
}