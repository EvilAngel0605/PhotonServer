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
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);//并没有连接数据库
            try
            {
                conn.Open();//开始连接
                string sqlCmd="select * from users";// sql命令
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                //cmd.ExecuteReader();//执行一些查询
                //cmd.ExecuteNonQuery();//插入 删除
                //cmd.ExecuteScalar();//执行查询，返回一个单个值
                MySqlDataReader reader = cmd.ExecuteReader();
                //reader.Read();读取下一页数据，如果读取成功，返回true,如果没有下一页了，读取失败，返回false
                while(reader.Read())
                {
                    Console.WriteLine("{0};{1};{2}", reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
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
            Console.ReadLine();
        }
    }
}
