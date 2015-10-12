using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server gestart");
            AppGlobal.Instance.ToString();
            TcpListener serverSocket = new TcpListener(1288);
            serverSocket.Start();

            while (true)
            {
                Console.WriteLine("Waiting for clients..");
                AppGlobal.Instance.AddUser(new Client(serverSocket.AcceptTcpClient()));
            }
        }
    }
}
