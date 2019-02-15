using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGame.Model;
using MySql.Data.MySqlClient;
namespace MyGame.DAO
{
    class ResultDAO
    {
        public void UpdateOrAddResult(MySqlConnection conn, Result res)
        {
            try
            {
                MySqlCommand cmd = null;

                if (res.Id <= -1)
                {
                    cmd = new MySqlCommand("insert into result set totalcount=@totalcount,wincount=@wincount,userid=@userid", conn);
                }
                else
                {
                    cmd = new MySqlCommand("update result set totalcount=@totalcount,wincount=@wincount where userid=@userid ", conn);
                }
                cmd.Parameters.AddWithValue("userid", res.UserId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("在UpdateOrAddResult的时候出现异常：" + e);
            }
        }
    }
}
