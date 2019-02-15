using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGame.Servers;
using MyGame.DAO;
using common;
using MyGame.Model;
using MyGame.Manager;
namespace MyGame.Controller
{
    class UserController : BaseController
    {
        private UserDAO userDAO = new UserDAO();
        private ResultDAO resultDAO = new ResultDAO();
        public UserController()
        {
            requestCode = RequestCode.User;
        }
        public string Login(string data, Client client, Server server)
        {
            //登录成功之后设置当前accountMgr
            string[] strs = data.Split(',');
            User user = userDAO.VerifyUser(client.MySQLConn, strs[0], strs[1]);
            if (user == null)
            {
                //Enum.GetName(typeof(ReturnCode), ReturnCode.Fail);
                Console.WriteLine("登录失败");
                return string.Format("{0}", ((int)ReturnCode.Fail).ToString());
            }
            else
            {
                string datas = userDAO.GetUserInfoByUsername(client.MySQLConn, strs[0]);
                //Result res = resultDAO.GetResultByUserid(client.MySQLConn, user.Id);
                //client.SetUserData(user, res);
                Console.WriteLine("登录chenggong");
                return string.Format("{0},{1}", ((int)ReturnCode.Success).ToString(),datas);
            }
        }
        public string Register(string data, Client client, Server server)
        {
            string[] strs = data.Split(',');
            string username = strs[0]; string password = strs[1];
            bool res = userDAO.GetUserByUsername(client.MySQLConn, username);
            if (res)
            {
                return ((int)ReturnCode.Fail).ToString();
            }
            userDAO.AddUser(client.MySQLConn,data);
            return ((int)ReturnCode.Success).ToString();
        }
        //创建房间
        public string Create(string data, Client client, Server server)
        {
            string[] strs = data.Split(',');
            string roomName = strs[0];
            Console.Write("房间名字为" + roomName);
            //判断房间是否存在
            //存在
            if (RoomManager.Instance.roomList.ContainsKey(roomName))
            {
                RoomManager.Instance.roomList[roomName].Add(client);
                Console.WriteLine("存在房间");
            }
            else
            {
                //如果不包含房间就创建
                List<Client> temp=new List<Client>();
                temp.Add(client);
                RoomManager.Instance.roomList.Add(roomName, temp);
                Console.WriteLine("不存在房间");
            }
            return "";
        }
        //房间内聊天
        public string Chat(string data, Client client, Server server)
        {
            string[] strs = data.Split(',');
            string username = strs[0]; 
            string roomName = strs[1];
            string Message = strs[2];
            //收到消息之后告诉房间内的所有人
            Console.WriteLine("收到消息者" + username + "房间名：" + roomName + "消息" + Message);
            Console.WriteLine("当前房间人数" + RoomManager.Instance.roomList[roomName].Count);
            if(RoomManager.Instance.roomList.ContainsKey(roomName))
            {
                Console.WriteLine("发送数据");
                    for(int i=0;i<RoomManager.Instance.roomList[roomName].Count;i++)
                    {
                        //Client clien = new Client();
                        Client clien = RoomManager.Instance.roomList[roomName][i];
                        server.SendResponse(clien,ActionCode.Chat,data);
                    }
            }
           
            return ((int)ReturnCode.Success).ToString();
        }
    }
}
