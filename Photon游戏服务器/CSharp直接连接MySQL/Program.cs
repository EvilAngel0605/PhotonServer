using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace CSharp直接连接MySQL
{
    class Program
    {
        static void Main(string[] args)
        {

            //Read();
            //Insert();
            //Update();
            //Delete();
            //ExcuteScale();
            Console.WriteLine(VerifyUser("zcc1", "zcc"));
            Console.ReadLine();
        }
        static void Read()
        {
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);//并没有连接数据库
            try
            {
                conn.Open();//开始连接
                string sqlCmd = "select * from users";// sql命令
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                //cmd.ExecuteReader();//执行一些查询
                //cmd.ExecuteNonQuery();//插入 删除
                //cmd.ExecuteScalar();//执行查询，返回一个单个值
                MySqlDataReader reader = cmd.ExecuteReader();
                //reader.Read();读取下一页数据，如果读取成功，返回true,如果没有下一页了，读取失败，返回false
                while (reader.Read())
                {
                    //Console.WriteLine("{0};{1};{2}", reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
                    //Console.WriteLine("{0};{1};{2}", reader.GetInt32(0),reader.GetString(1),reader.GetString(2));
                    Console.WriteLine("{0} {1} {2}", reader.GetInt32("id"), reader.GetString("username"), reader.GetString("password"));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        static void Insert()
        {
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);//并没有连接数据库
            try
            {
                conn.Open();//开始连接
                string sqlCmd = "insert into users(username,password,registerdate) values('zcc','zcc','"+DateTime.Now+"')";// sql命令
                Console.WriteLine(sqlCmd);
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                int result = cmd.ExecuteNonQuery();//返回的是数据库表中受影响的行数
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        static void Update()
        {
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);//并没有连接数据库
            try
            {
                conn.Open();//开始连接
                string sqlCmd = "update users set username='EvilAngel',password='EvilAngel',registerdate='"+
                    DateTime.Now+"' where id=2";
                Console.WriteLine(sqlCmd);
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                int result = cmd.ExecuteNonQuery();//返回的是数据库表中受影响的行数
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        static void Delete()
        {
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);//并没有连接数据库
            try
            {
                conn.Open();//开始连接
                string sqlCmd = "delete from users where id=3";
                Console.WriteLine(sqlCmd);
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                int result = cmd.ExecuteNonQuery();//返回的是数据库表中受影响的行数
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        static void ExcuteScale()
        {
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);//并没有连接数据库
            try
            {
                conn.Open();//开始连接
                string sqlCmd = "select count(*) from users";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                object obj=cmd.ExecuteScalar();
                Console.WriteLine(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        static bool VerifyUser(string username,string password)
        {
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);//并没有连接数据库
            try
            {
                conn.Open();//开始连接
                //string sqlCmd = "select * from users where username='"+username
                //                +"'and password='"+password+"'";// sql命令
                string sqlCmd = "select * from users where username =@v1 and password =@v2";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.Parameters.AddWithValue("v1", username);
                cmd.Parameters.AddWithValue("v2", password);
                MySqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
    }
}
