using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Model
{
    class Result
    {
        public Result(int id, int userId)
        {
            this.Id = id;
            this.UserId = userId;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
