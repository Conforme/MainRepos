using Microsoft.AspNetCore.Mvc.RazorPages;
using DocumentFormat.OpenXml.Packaging;
using MySqlConnector;

namespace Conforme.Pages
{
    public class NavigateModel : PageModel
    {
        public string? SuccessMessage { get; set; }
        public string? FileNamePath { get; set; }
        public WordprocessingDocument? wordDocument = null;


        public void OnGet()
        {
            try
            {
                if (GetFileName())
                {
                    wordDocument = WordprocessingDocument.CreateFromTemplate(FileNamePath);
                    
                }
            }
            finally
            {
                ShowStatus();
                if (wordDocument != null) { wordDocument.Dispose(); }
            }
        }

        public bool GetFileName()
        {
            object? fileName;
            TempData.TryGetValue("FileName", out fileName);
            if (fileName != null)
            {
                FileNamePath = fileName.ToString();
                return true;
            }
            else
            { return false; }
        }

        public void ShowStatus()
        {
            object? successMessage;
            TempData.TryGetValue("SuccessMessage", out successMessage);
            if (successMessage != null)
            {
                SuccessMessage = successMessage.ToString();
            }
        }
        
        public void FillFieldSideBar()
        {
            //access the database and fill the sidebar field list
            // Connection string
            string connectionString = "server=your-server;database=your-database;user=your-username;password=your-password;";

            // Create a connection object
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // SQL query to execute
                    string query = "SELECT field1, field2 FROM your_table WHERE condition";

                    // Create a command object
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    // Execute the command and get a data reader
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Loop through the rows in the reader
                        while (reader.Read())
                        {
                            // Extract field values by index or name
                            string field1Value = reader.GetString(0);  // or reader["field1"].ToString()
                            int field2Value = reader.GetInt32(1);     // or reader["field2"]

                            // Do something with the extracted values
                            Console.WriteLine($"Field1: {field1Value}, Field2: {field2Value}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
