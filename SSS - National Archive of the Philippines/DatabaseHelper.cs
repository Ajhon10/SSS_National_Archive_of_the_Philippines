using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SSS___National_Archive_of_the_Philippines
{
    public class DatabaseHelper
    {
        const string DB_HOST = "127.0.0.1";
        const string DB_USER = "root";
        const string DB_PWD = "";
        const string DB_NAME = "nap-sss";

        // Database connection string
        private readonly string connectionString = "Server=" + DB_HOST + ";Uid=" + DB_USER + ";Pwd=" + DB_PWD + ";Database=" + DB_NAME + ";";

        // -------------Methods For Managing in Dashboard---------------------

        // Method/Function to count data from tbl_records
        public int GetTableCount()
        {
            int rowCount = 0;
            string query = "SELECT COUNT(*) FROM tbl_records ";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        rowCount = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            return rowCount;
        }

        // Method/Function for adding file description
        public bool InsertFileDescription(string reference_number, string date_received, string code, string file_descript, string category, string title, string subtitle, string description, string subdescription, string retention_period)
        {
            bool isSuccess = false;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO tbl_records (reference_number, date_received, code, file_descript, category, title, subtitle, description, subdescription, retention_period)" +
                                                    "VALUES(@reference_num, @date_received, @code, @file_description, @category, @title, @subtitle, @description, @subdescription, @retention_period)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Use parameters to prevent SQL Injection
                        cmd.Parameters.AddWithValue("@reference_num", reference_number);
                        cmd.Parameters.AddWithValue("@date_received", date_received);
                        cmd.Parameters.AddWithValue("@code", code);
                        cmd.Parameters.AddWithValue("@file_description", file_descript);
                        cmd.Parameters.AddWithValue("@category", category);
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@subtitle", subtitle);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@subdescription", subdescription);
                        cmd.Parameters.AddWithValue("@retention_period", retention_period);

                        int rowsAffected = cmd.ExecuteNonQuery(); // Execute query
                        isSuccess = rowsAffected > 0; // Check if insert was successful
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return isSuccess; // Return success status
        }

        // Method/Function for updating exisitng file description
        public bool UpdateFileDescription(string reference_number, string date_received, string code, string file_descript, string category, string title, string subtitle, string description, string subdescription, string retention_period)
        {
            bool isSuccess = false;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE tbl_records SET " +
                                   "date_received = @date_received, " +
                                   "code = @code, " +
                                   "file_descript = @file_description, " +
                                   "category = @category, " +
                                   "title = @title, " +
                                   "subtitle = @subtitle, " +
                                   "description = @description, " +
                                   "subdescription = @subdescription, " +
                                   "retention_period = @retention_period " +
                                   "WHERE reference_number = @reference_num";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Use parameters to prevent SQL Injection
                        cmd.Parameters.AddWithValue("@date_received", date_received);
                        cmd.Parameters.AddWithValue("@code", code);
                        cmd.Parameters.AddWithValue("@file_description", file_descript);
                        cmd.Parameters.AddWithValue("@category", category);
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@subtitle", subtitle);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@subdescription", subdescription);
                        cmd.Parameters.AddWithValue("@retention_period", retention_period);
                        cmd.Parameters.AddWithValue("@reference_num", reference_number); // Condition for updating

                        int rowsAffected = cmd.ExecuteNonQuery(); // Execute query
                        isSuccess = rowsAffected > 0; // Check if update was successful
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return isSuccess; // Return success status
        }

        // -------------Methods For Managing Branch Code---------------------

        // Method/ Function that retrieve the Active Brnach Code
        public string GetActiveBranchCode()
        {
            string branchCode = "";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT branch_code FROM tbl_branch_code WHERE status = 'Active' LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            branchCode = result.ToString(); // Store the active branch code in the variable
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return branchCode;
        }

        // Function that Add Branch
        public bool InsertBranch(string branchCode, string branchName, string status)
        {
            bool isSuccess = false;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO tbl_branch_code (branch_code, branch_name, status) VALUES (@code, @name, @status)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Use parameters to prevent SQL Injection
                        cmd.Parameters.AddWithValue("@code", branchCode);
                        cmd.Parameters.AddWithValue("@name", branchName);
                        cmd.Parameters.AddWithValue("@status", status);

                        int rowsAffected = cmd.ExecuteNonQuery(); // Execute query
                        isSuccess = rowsAffected > 0; // Check if insert was successful
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return isSuccess; // Return success status
        }

        // Function that Update Branch
        public bool UpdateBranch(string branchCode, string branchName, string status)
        {
            bool isSuccess = false;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE tbl_branch_code " +
                        "SET " +
                        "branch_name = @name, " +
                        "status = @status " +
                        "WHERE branch_code = @code;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Use parameters to prevent SQL Injection
                        cmd.Parameters.AddWithValue("@code", branchCode);
                        cmd.Parameters.AddWithValue("@name", branchName);
                        cmd.Parameters.AddWithValue("@status", status);

                        int rowsAffected = cmd.ExecuteNonQuery(); // Execute query
                        isSuccess = rowsAffected > 0; // Check if insert was successful
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return isSuccess; // Return success status
        }

        // Set the status of the Branch to Incative
        public bool SetAllStatusToInactive()
        {
            bool isSuccess = false;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE tbl_branch_code SET status = 'Inactive';";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        int rowsAffected = cmd.ExecuteNonQuery(); // Execute query
                        isSuccess = rowsAffected > 0; // Check if insert was successful
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return isSuccess; // Return success status
        }

        // -------------Methods For Managing Categories---------------------
        public bool InsertCategory(string category_name) 
        {
            bool isSuccess = false;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO tbl_record_category (category_name) VALUES (@category_name)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Use parameters to prevent SQL Injection
                        cmd.Parameters.AddWithValue("@category_name", category_name);

                        int rowsAffected = cmd.ExecuteNonQuery(); // Execute query
                        isSuccess = rowsAffected > 0; // Check if insert was successful
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return isSuccess; // Return success status
        }

        public bool UpdateCategory(int id, string category_name)
        {
            bool isSuccess = false;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE tbl_record_category SET category_name = @category_name WHERE id = @id;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Use parameters to prevent SQL Injection
                        cmd.Parameters.AddWithValue("@category_name", category_name);
                        cmd.Parameters.AddWithValue("@id", id);

                        int rowsAffected = cmd.ExecuteNonQuery(); // Execute query
                        isSuccess = rowsAffected > 0; // Check if insert was successful
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return isSuccess; // Return success status
        }

        // -------------Methods For Managing Titles---------------------
        public bool InsertTitle(string title, string retention_period, string code, int cat_id)
        {
            bool isSuccess = false;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO tbl_record_title (title, retention_period, code, cat_id) VALUES (@title, @retention_period, @code, @cat_id)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Use parameters to prevent SQL Injection
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@retention_period", retention_period);
                        cmd.Parameters.AddWithValue("@code", code);
                        cmd.Parameters.AddWithValue("@cat_id", cat_id);

                        int rowsAffected = cmd.ExecuteNonQuery(); // Execute query
                        isSuccess = rowsAffected > 0; // Check if insert was successful
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return isSuccess; // Return success status
        }

        public bool UpdateTitle(int id, string title, string retention_period, string code, int cat_id)
        {
            bool isSuccess = false;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE tbl_record_title " +
                                    "SET " +
                                        "title = @title, " +
                                        "retention_period = @retention_period, " +
                                        "code = @code, " +
                                        "cat_id = @cat_id " +
                                    "WHERE id = @id;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Use parameters to prevent SQL Injection
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@retention_period", retention_period);
                        cmd.Parameters.AddWithValue("@code", code);
                        cmd.Parameters.AddWithValue("@cat_id", cat_id);

                        int rowsAffected = cmd.ExecuteNonQuery(); // Execute query
                        isSuccess = rowsAffected > 0; // Check if insert was successful
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return isSuccess; // Return success status
        }

        // -------------Methods For Managing Sub-titles---------------------
        public bool InsertSubtitle(string subtitle, string retention_period, string code, int title_id)
        {
            bool isSuccess = false;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO tbl_record_subtitle (subtitle, retention_period, code, title_id) VALUES (@subtitle, @retention_period, @code, @title_id)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Use parameters to prevent SQL Injection
                        cmd.Parameters.AddWithValue("@subtitle", subtitle);
                        cmd.Parameters.AddWithValue("@retention_period", retention_period);
                        cmd.Parameters.AddWithValue("@code", code);
                        cmd.Parameters.AddWithValue("@title_id", title_id);

                        int rowsAffected = cmd.ExecuteNonQuery(); // Execute query
                        isSuccess = rowsAffected > 0; // Check if insert was successful
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return isSuccess; // Return success status
        }

        public bool UpdateSubtitle(int id, string subtitle, string retention_period, string code, int title_id)
        {
            bool isSuccess = false;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE tbl_record_subtitle " +
                                    "SET " +
                                        "subtitle = @subtitle, " +
                                        "retention_period = @retention_period, " +
                                        "code = @code, " +
                                        "title_id = @title_id " +
                                    "WHERE id = @id;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Use parameters to prevent SQL Injection
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@subtitle", subtitle);
                        cmd.Parameters.AddWithValue("@retention_period", retention_period);
                        cmd.Parameters.AddWithValue("@code", code);
                        cmd.Parameters.AddWithValue("@title_id", title_id);

                        int rowsAffected = cmd.ExecuteNonQuery(); // Execute query
                        isSuccess = rowsAffected > 0; // Check if insert was successful
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return isSuccess; // Return success status
        }

        // -------------Methods For Managing Description---------------------
        public bool InsertDescription(string description, string retention_period, string code, int subtitle_id)
        {
            bool isSuccess = false;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO tbl_record_description (description, retention_period, code, subtitle_id) VALUES (@description, @retention_period, @code, @subtitle_id)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Use parameters to prevent SQL Injection
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@retention_period", retention_period);
                        cmd.Parameters.AddWithValue("@code", code);
                        cmd.Parameters.AddWithValue("@subtitle_id", subtitle_id);

                        int rowsAffected = cmd.ExecuteNonQuery(); // Execute query
                        isSuccess = rowsAffected > 0; // Check if insert was successful
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return isSuccess; // Return success status
        }

        public bool UpdateDescription(int id, string description, string retention_period, string code, int subtitle_id)
        {
            bool isSuccess = false;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE tbl_record_description " +
                                    "SET " +
                                        "description = @description, " +
                                        "retention_period = @retention_period, " +
                                        "code = @code, " +
                                        "subtitle_id = @subtitle_id " +
                                    "WHERE id = @id;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Use parameters to prevent SQL Injection
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@retention_period", retention_period);
                        cmd.Parameters.AddWithValue("@code", code);
                        cmd.Parameters.AddWithValue("@subtitle_id", subtitle_id);

                        int rowsAffected = cmd.ExecuteNonQuery(); // Execute query
                        isSuccess = rowsAffected > 0; // Check if insert was successful
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return isSuccess; // Return success status
        }

        // -------------Methods For Managing Sub-description---------------------
        public bool InsertSubdescription(string subdescription, string retention_period, string code, int descripiton_id)
        {
            bool isSuccess = false;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO tbl_record_subdescription (sub_description, retention_period, code, description_id) VALUES (@subdescription, @retention_period, @code, @descripiton_id)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Use parameters to prevent SQL Injection
                        cmd.Parameters.AddWithValue("@subdescription", subdescription);
                        cmd.Parameters.AddWithValue("@retention_period", retention_period);
                        cmd.Parameters.AddWithValue("@code", code);
                        cmd.Parameters.AddWithValue("@descripiton_id", descripiton_id);

                        int rowsAffected = cmd.ExecuteNonQuery(); // Execute query
                        isSuccess = rowsAffected > 0; // Check if insert was successful
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return isSuccess; // Return success status
        }

        public bool UpdateSubdescription(int id, string subdescription, string retention_period, string code, int descripiton_id)
        {
            bool isSuccess = false;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE tbl_record_subdescription " +
                                    "SET " +
                                        "sub_description = @subdescription, " +
                                        "retention_period = @retention_period, " +
                                        "code = @code, " +
                                        "description_id = @descripiton_id " +
                                    "WHERE id = @id;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Use parameters to prevent SQL Injection
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@subdescription", subdescription);
                        cmd.Parameters.AddWithValue("@retention_period", retention_period);
                        cmd.Parameters.AddWithValue("@code", code);
                        cmd.Parameters.AddWithValue("@descripiton_id", descripiton_id);

                        int rowsAffected = cmd.ExecuteNonQuery(); // Execute query
                        isSuccess = rowsAffected > 0; // Check if insert was successful
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return isSuccess; // Return success status
        }

        // Method/Function to count data from tbl_record_title based on category ID
        public int CountConnectedCategoryIdFromTitle(int id)
        {
            int rowCount = 0;
            string query = "SELECT COUNT(*) FROM tbl_record_title WHERE cat_id = @id"; // Add a parameter

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        // Add the parameter to prevent SQL injection
                        command.Parameters.AddWithValue("@id", id);

                        object result = command.ExecuteScalar();
                        rowCount = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            return rowCount;
        }

        // Method/Function to count data from tbl_record_subtitle based on title ID
        public int CountConnectedTitleIdFromSubtitle(int id)
        {
            int rowCount = 0;
            string query = "SELECT COUNT(*) FROM tbl_record_subtitle WHERE title_id = @id"; // Add a parameter

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        // Add the parameter to prevent SQL injection
                        command.Parameters.AddWithValue("@id", id);

                        object result = command.ExecuteScalar();
                        rowCount = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            return rowCount;
        }

        // Method/Function to count data from tbl_record_description based on subtitle ID
        public int CountConnectedSubtitleIdFromDescription(int id)
        {
            int rowCount = 0;
            string query = "SELECT COUNT(*) FROM tbl_record_description WHERE subtitle_id = @id"; // Add a parameter

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        // Add the parameter to prevent SQL injection
                        command.Parameters.AddWithValue("@id", id);

                        object result = command.ExecuteScalar();
                        rowCount = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            return rowCount;
        }

        // Method/Function to count data from tbl_record_subdescription based on description ID
        public int CountConnectedDescriptionIdFromSubdescription(int id)
        {
            int rowCount = 0;
            string query = "SELECT COUNT(*) FROM tbl_record_subdescription WHERE description_id = @id"; // Add a parameter

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        // Add the parameter to prevent SQL injection
                        command.Parameters.AddWithValue("@id", id);

                        object result = command.ExecuteScalar();
                        rowCount = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            return rowCount;
        }
    }
}
