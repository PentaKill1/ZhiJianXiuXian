using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGame.Servers;
namespace MyGame.Manager
{
    class RoomManager
    {
        //单例模式
        private static RoomManager instance;
        public static RoomManager Instance
        {
            get
            {
                if(instance==null)
                {
                    instance=new RoomManager();
                }
                return instance;
            }
        }
        //房间列表
        public Dictionary<string, List<Client>> roomList=new Dictionary<string,List<Client>>(); 

    }
}
