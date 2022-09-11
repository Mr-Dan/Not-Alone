using Not_Alone_Server.Class;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Not_Alone_Server
{       /* 
         * /connect name  
         * /disconnect name
         * /link link
         * /play time
         * /stop time
        */ 
    class Program
    {
        public static Hashtable clientsList = new Hashtable();
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ip");
            string ip= Console.ReadLine();
            Console.WriteLine("Введите port");
            string port = Console.ReadLine();
            TcpListener server = new TcpListener(IPAddress.Parse(ip), Convert.ToInt32(port));
            TcpClient clientSocket = default;
            NetworkStream networkStream;
            HandleClinet client;
           
            server.Start();
            Console.WriteLine("Server Started");
            try
            {
                while (true)
                {
                    string dataFromClient = null;
                    clientSocket = server.AcceptTcpClient();
                    networkStream = clientSocket.GetStream();
                    dataFromClient = GetMessage(networkStream);

                    string[] clientCommand = dataFromClient.Split();
                    bool success = true;
                    foreach (string name in clientsList.Keys)
                    { 
                        if(name == clientCommand[1])
                        {
                            success = false;
                        }
                    }
                    if (success)
                    {
                        clientsList.Add(clientCommand[1], clientSocket);
                        Broadcast("/connect", new Hashtable() { { clientCommand[1], clientSocket } });
                        client = new HandleClinet();
                        client.StartClient(clientSocket, "/connect " + clientCommand[1]);
                    }
                    else
                    {
                        Broadcast("/disconnect", new Hashtable() { { dataFromClient, clientSocket } });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static string GetMessage(NetworkStream networkStream)
        {
            string message = "";
            byte[] bytesFrom = new byte[4];
            networkStream.Read(bytesFrom, 0, 4);
            string size = Encoding.UTF8.GetString(bytesFrom);
            int size_message = 0;
            int sizeResidue = 0;
            if (int.TryParse(size, out size_message))
            {
                sizeResidue = size_message;
                while (Encoding.UTF8.GetByteCount(message) != size_message)
                {
                    string messageRead = "";
                    bytesFrom = new byte[sizeResidue];
                    networkStream.Read(bytesFrom, 0, sizeResidue);
                    messageRead += Encoding.UTF8.GetString(bytesFrom);
                    sizeResidue -= message.Length;
                    message += messageRead;
                }
            }
            return message;
        }
        public static void Broadcast(string msg, Hashtable clientsList)
        {
            int size_auth = Encoding.UTF8.GetByteCount(msg);
            foreach (DictionaryEntry Item in clientsList)
            {
                /*Object obj = new Object();
                obj = Item.Key;
                string _id = obj.ToString();
                if (_id == id.ToString()) ;

                string[] clientCommand = msg.Split();*/
                //Console.WriteLine(Item.Key);       
                TcpClient broadcastSocket;
                broadcastSocket = (TcpClient)Item.Value;
                NetworkStream broadcastStream = broadcastSocket.GetStream();

                string size_str = "0";
                if (size_auth.ToString().Length == 1) size_str = "000" + size_auth;
                if (size_auth.ToString().Length == 2) size_str = "00" + size_auth;
                if (size_auth.ToString().Length == 3) size_str = "0" + size_auth;
                if (size_auth.ToString().Length == 4) size_str = size_auth.ToString();

                byte[] broadcastBytes = new byte[4];
                broadcastBytes = Encoding.UTF8.GetBytes(size_str);
                broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                broadcastBytes = new byte[size_auth];
                broadcastBytes = Encoding.UTF8.GetBytes(msg);
                broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
            }
        }
    }

}
