using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Collections;

namespace Not_Alone_Server.Class
{
    class HandleClinet
    {
        TcpClient tcpClient;
        string name = "";
        public void StartClient(TcpClient tcpClient, string messege)
        {

            this.tcpClient = tcpClient;
            string[] clientCommand = messege.Split();
            name = clientCommand[1];
            Console.WriteLine($"{DateTime.Now} {messege}");
            Thread thread = new Thread(ThreadClient);
            thread.Start();
        }

        private void ThreadClient()
        {
            string dataFromClient = null;
            NetworkStream networkStream = null;
            DateTime time;
            try
            {
                // Отсыллать clientsList без this
                while (true)
                {
                    networkStream = tcpClient.GetStream();
                    time = DateTime.Now;
                    dataFromClient = Program.GetMessage(networkStream);
                    Console.WriteLine($"{time} {name} {dataFromClient}");
                    if (dataFromClient.Length == 0)
                    {
                        networkStream.Close();
                        tcpClient.Close();
                        Program.clientsList.Remove(name);
                        break;
                    }
                    string[] clientCommand = dataFromClient.Split();
                    if (clientCommand[0].Equals("/disconnect"))
                    {
                        networkStream.Close();
                        tcpClient.Close();
                        Program.clientsList.Remove(name);
                        break;
                    }
                    else if (clientCommand[0].Equals("/link"))
                    {
                        Hashtable clients = new Hashtable(Program.clientsList);
                        clients.Remove(name);

                        Program.Broadcast("/link " + clientCommand[1], clients);
                    }
                    else if (clientCommand[0].Equals("/play"))
                    {
                        Hashtable clients = new Hashtable(Program.clientsList);
                        clients.Remove(name);
                        Program.Broadcast("/play "+ clientCommand[1], clients);
                        //Program.Broadcast("/play", clients);
                    }
                    else if (clientCommand[0].Equals("/pause"))
                    {
                        Hashtable clients = new Hashtable(Program.clientsList);
                        clients.Remove(name);
                        Program.Broadcast("/pause " + clientCommand[1], clients);
                        //Program.Broadcast("/stop", clients);
                    }
                }
            }
            catch (Exception ex)
            {
                networkStream.Close();
                tcpClient.Close();
                Program.clientsList.Remove(name);
                Console.WriteLine(ex.ToString());
            }
        }


    }
}
