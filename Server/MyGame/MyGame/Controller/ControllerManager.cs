using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common;
using MyGame.Servers;
using System.Reflection;
using common;
using MyGame.Manager;
namespace MyGame.Controller
{
    class ControllerManager
    {
        private Dictionary<RequestCode, BaseController> controllerDict = new Dictionary<RequestCode, BaseController>();
        private Server server;

        public ControllerManager(Server server)
        {
            this.server = server;
            InitController();
        }

        void InitController()
        {
            DefaultController defaultController = new DefaultController();
            controllerDict.Add(defaultController.RequestCode, defaultController);
            controllerDict.Add(RequestCode.User, new UserController());
        }

        public void HandleRequest(RequestCode requestCode, ActionCode actionCode, string data, Client client)
        {
            if (actionCode == ActionCode.Chat)
            {
                string[] strs = data.Split(',');
                string username = strs[0];
                string roomName = strs[1];
                string Message = strs[2];
                //收到消息之后告诉房间内的所有人
                Console.WriteLine("收到消息者" + username + "房间名：" + roomName + "消息" + Message);
                Console.WriteLine("当前房间人数" + RoomManager.Instance.roomList[roomName].Count);
                if (RoomManager.Instance.roomList.ContainsKey(roomName))
                {
                    Console.WriteLine("发送数据");
                    for (int i = 0; i < RoomManager.Instance.roomList[roomName].Count; i++)
                    {
                        //Client clien = new Client();
                        Client clien = RoomManager.Instance.roomList[roomName][i];
                        server.SendResponse(clien, ActionCode.Chat, data);
                    }
                }
            }
            else
            {
                BaseController controller;
                bool isGet = controllerDict.TryGetValue(requestCode, out controller);
                if (isGet == false)
                {
                    Console.WriteLine("无法得到[" + requestCode + "]所对应的Controller,无法处理请求"); return;
                }
                string methodName = Enum.GetName(typeof(ActionCode), actionCode);
                MethodInfo mi = controller.GetType().GetMethod(methodName);
                if (mi == null)
                {
                    Console.WriteLine("[警告]在Controller[" + controller.GetType() + "]中没有对应的处理方法:[" + methodName + "]"); return;
                }
                object[] parameters = new object[] { data, client, server };
                object o = mi.Invoke(controller, parameters);
                if (o == null || string.IsNullOrEmpty(o as string))
                {
                    return;
                }
                Console.Write("返回action" + actionCode);
                server.SendResponse(client, actionCode, o as string);
            }
        }

    }
}
