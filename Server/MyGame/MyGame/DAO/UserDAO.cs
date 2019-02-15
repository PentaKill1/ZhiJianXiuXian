using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MyGame.DAO;
using MyGame.Model;
using common;
namespace MyGame.DAO
{
    class UserDAO
    {
        public User VerifyUser(MySqlConnection conn, string userid, string password)
        {
            MySqlDataReader reader = null;
            try
            {
                string mysql = string.Format(@"select * from userinfo where userid = '{0}' and password = '{1}'", userid, password);
                MySqlCommand cmd = new MySqlCommand(mysql, conn);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string id = reader.GetString("userid");
                    User user = new User(id, userid, password);
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("在VerifyUser的时候出现异常：" + e);
            }
            finally
            {
                if (reader != null) reader.Close();
            }
            return null;
        }

        public bool GetUserByUsername(MySqlConnection conn, string userid)
        {
            MySqlDataReader reader = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from userinfo where userid = @userid", conn);
                cmd.Parameters.AddWithValue("userid", userid);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("在GetUserByUsername的时候出现异常：" + e);
            }
            finally
            {
                if (reader != null) reader.Close();
            }
            return false;
        }
        public string GetUserInfoByUsername(MySqlConnection conn, string userid)
        {
            MySqlDataReader reader = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from userinfo where userid = @userid", conn);
                cmd.Parameters.AddWithValue("userid", userid);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string userids = reader.GetString("userid");
                    string password = reader.GetString("password");
                    string nickname = reader.GetString("nickname");
                    string sex = reader.GetString("sex");
                    string age = reader.GetString("age");
                    string qianming = reader.GetString("qianming");
                    return string.Format("{0},{1},{2},{3},{4},{5}", userids, password, nickname, sex, age, qianming);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("在GetUserByUsername的时候出现异常：" + e);
            }
            finally
            {
                if (reader != null) reader.Close();
            }
            return "";
        }

        public void AddUser(MySqlConnection conn, string data)
        {
            string[] strs = data.Split(',');
            string userid = strs[0];
            string password = strs[1];
            string nickname = strs[2];
            string age = strs[3];
            string sex = strs[4];
            string qianming = strs[5];
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into userinfo set userid = @userid , password = @password,nickname=@nickname,age=@age,sex=@sex,qianming=@qianming", conn);
                cmd.Parameters.AddWithValue("userid", userid);
                cmd.Parameters.AddWithValue("password", password);
                cmd.Parameters.AddWithValue("nickname", nickname);
                cmd.Parameters.AddWithValue("age", age);
                cmd.Parameters.AddWithValue("sex", sex);
                cmd.Parameters.AddWithValue("qianming", qianming);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("在AddUser的时候出现异常：" + e);
            }
        }



    }
}
