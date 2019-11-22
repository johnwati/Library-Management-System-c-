using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;
namespace School_Software
{
    class clsFunc
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        public void LogFunc(string st1, DateTime st2, string st3)
        {
            con = new SqlConnection(cs.DBcon);
            con.Open();
            string cb = "insert into Logs(UserID,Date,Operation) VALUES (@d1,@d2,@d3)";
            cmd = new SqlCommand(cb);
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@d1", st1);
            cmd.Parameters.AddWithValue("@d2", st2);
            cmd.Parameters.AddWithValue("@d3", st3);
            cmd.ExecuteReader();
            con.Close();
        }


    }
}
