using System;
//using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Connection.Model
{
    public class ConnectToDB
    {
        private MySqlConnection conn;
        private MySqlCommand cmd;
        private DateTime now = DateTime.Now;
        private MySqlDataReader sqlread;

        public ConnectToDB()
        {
            try {
                string sqlstring = "server=cpsrv13.misshosting.com;uid=uwxjeglm;pwd=xVBfWxTs12;database=uwxjeglm_db;SslMode=none";
			    conn = new MySqlConnection(sqlstring);
                conn.Open();
                cmd = conn.CreateCommand();
                Console.WriteLine("Connceted!");
            } catch(Exception e) {
                Console.WriteLine(e + "FEL FEL!");
            }
        }

        public List<Items> GetDataFromDB(string Query)
        {
            if(Query.Contains("SELECT")) 
            {
                cmd.CommandText = Query; // "SELECT * FROM Fotostudio"; 
                sqlread = cmd.ExecuteReader();

                List<Items> str = new List<Items>();

                while (sqlread.Read())
                {  
                    Items item = new Items();
                    item.ID = sqlread.GetValue(0).ToString();
                    item.HEADER = sqlread.GetValue(1).ToString();
                    item.CONTENT = sqlread.GetValue(2).ToString();
                    item.PRIZE = sqlread.GetValue(3).ToString();
                    item.STANDARDPRIZE = sqlread.GetValue(4).ToString();
                    str.Add(item);
                }
                sqlread.Close();
                conn.Close();
                return str;
            }

            if(Query.Contains("INSERT"))
            {
                cmd.CommandText = Query;
                cmd.ExecuteNonQuery(); 
                conn.Close(); 
                Console.WriteLine("INSERT SUCCESS");
                return null;         
            } 
            return null;           
        }

    }
}