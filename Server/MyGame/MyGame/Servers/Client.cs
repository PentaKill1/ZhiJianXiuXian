using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using MySql.Data.MySqlClient;
using MyGame.Tools;
using MyGame.DAO;
using MyGame.Model;
using common;
using MyGame.Manager;
namespace MyGame.Servers
{
    class Client
    {
            private Socket clientSocket;
            private Server server;
            private Message msg = new Message();
            private MySqlConnection mysqlConn;
            private User user;
            private Result result;
        //Manager

            private AccountManager accountMgr = new AccountManager();
            public Client() { }
            public Client(Socket clientSocket, Server server)
            {
                this.clientSocket = clientSocket;
                this.server = server;
                mysqlConn = ConnHelper.Connect();
            }
            public void Start()
            {
                if (clientSocket == null || clientSocket.Connected == false) return;
                clientSocket.BeginReceive(msg.Data, msg.StartIndex, msg.RemainSize, SocketFlags.None, ReceiveCallback, null);
            }

            private void ReceiveCallback(IAsyncResult ar)
            {
                try
                {
                    if (clientSocket == null || clientSocket.Connected == false) return;
                    int count = clientSocket.EndReceive(ar);
                    if (count == 0)
                    {
                        Close();
                    }
                    msg.ReadMessage(count, OnProcessMessage);
                    Start();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Close();
                }
            }
            private void OnProcessMessage(RequestCode requestCode, ActionCode actionCode, string data)
            {
                server.HandleRequest(requestCode, actionCode, data, this);
            }
            public MySqlConnection MySQLConn
            {
                get { return mysqlConn; }
            }
            private void Close()
            {
                ConnHelper.CloseConnection(mysqlConn);
                if (clientSocket != null)
                    clientSocket.Close();
                server.RemoveClient(this);
            }
            public void Send(ActionCode actionCode, string data)
            {
                try
                {
                    byte[] bytes = Message.PackData(actionCode, data);
                    clientSocket.Send(bytes);
                }
                catch (Exception e)
                {
                    Console.WriteLine("无法发送消息:" + e);
                }
            }
            public void SetUserData(User user, Result result)
            {
                this.user = user;
                this.result = result;
            }
            public User GetUser()
            {
                return this.user;
            }


        }
}
