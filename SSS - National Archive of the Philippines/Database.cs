using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using MySql.Data.MySqlClient;

namespace National_Archive_of_the_Philippines_Project
{
    internal class Database
    {
        const string DB_HOST = "127.0.0.1";
        const string DB_USER = "root";
        const string DB_PWD = "";
        const string DB_NAME = "nap-sss";

        const string CNString = @"SERVER=" + DB_HOST + ";" +
                                "UID=" + DB_USER + ";" +
                                "PWD=" + DB_PWD + ";" +
                                "DATABASE=" + DB_NAME + ";";

        public DataTable LoadData(string sql)
        {
            using (MySqlConnection _cn = new MySqlConnection(CNString))
            {
                try
                {
                    _cn.Open();

                    MySqlCommand _cmd = new MySqlCommand();

                    _cmd.Connection = _cn;
                    _cmd.CommandType = CommandType.Text;
                    _cmd.CommandText = sql;

                    using (MySqlDataReader _dr = _cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(_dr);
                        return dt;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Data not match " + e, "Invalid Input",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                    return null;
                }
            }
        }

        public bool QueryAUD(string sql)
        {
            MySqlConnection _cn = new MySqlConnection(CNString);

            try
            {
                _cn.Open();
                try
                {
                    MySqlCommand _cmd = new MySqlCommand();

                    _cmd.Connection = _cn;
                    _cmd.CommandType = CommandType.Text;
                    _cmd.CommandText = sql;

                    _cmd.ExecuteNonQuery();
                }
                catch (Exception Err)
                {
                    MessageBox.Show("Error: " + Err, "Data INSERT/UPDATE/DELETE fails",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Connection Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
    }
}
