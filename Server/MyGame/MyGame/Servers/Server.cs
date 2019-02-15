using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using common;
using MyGame.Controller;
namespace MyGame.Servers
{
    class Server
    {
            private IPEndPoint ipEndPoint;
            private Socket serverSocket;
            private List<Client> clientList=new List<Client>();
            private ControllerManager controllerManager;
            public Server() { }
            public Server(string ipStr, int port)
            {
                controllerManager = new ControllerManager(this);
                SetIpAndPort(ipStr, port);
            }

            public void SetIpAndPort(string ipStr, int port)
            {
                ipEndPoint = new IPEndPoint(IPAddress.Parse(ipStr), port);
            }

            public void Start()
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(ipEndPoint);
                serverSocket.Listen(0);
                Console.WriteLine("服务器开启成功");
                serverSocket.BeginAccept(AcceptCallBack, null);
            }
            private void AcceptCallBack(IAsyncResult ar)
            {
                Socket clientSocket = serverSocket.EndAccept(ar);
                Client client = new Client(clientSocket, this);
                client.Start();
                Console.WriteLine("客户端进入");
                if(client!=null)
                     clientList.Add(client);
                serverSocket.BeginAccept(AcceptCallBack, null);
            }
            public void RemoveClient(Client client)
            {
                lock (clientList)
                {
                    clientList.Remove(client);
                }
            }
            public void SendResponse(Client client, ActionCode actionCode, string data)
            {
                client.Send(actionCode, data);
            }
            public void HandleRequest(RequestCode requestCode, ActionCode actionCode, string data, Client client)
            {
                controllerManager.HandleRequest(requestCode, actionCode, data, client);
            }

        }
}
