using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGame.Servers;
namespace MyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server("127.0.0.1", 6688);
            server.Start();

            Console.ReadKey();
        }
    }
}
