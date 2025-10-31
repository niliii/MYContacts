using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MYContacts.Repository
{
    class ContactRepository : IcontactsRepository
    {
        private string connectionString = "Data Source=.; Initial Catalog=Contacts; User ID=sa; Password=zxcvZXCV";
        public int contactId = 0;
        public DataTable SelectAll()
        {
            string query = "SELECT * FROM Contacts  ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                return data;
            }
        }
        public DataTable SelectRow(int contactId)
        {
            string query = "SELECT * FROM Contacts where Id=" + contactId;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                return data;
            }
        }
        public bool Insert(string name, string family, string email, string mobile, int age, string address)
        {
            string query = "Insert Into Contacts(Name,Family,Email,Mobile,Age,Address) values (@Name,@Family,@Email,@Mobile,@Age,@Address)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Family", family);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Mobile", mobile);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.CommandType = CommandType.Text;
                connection.Open();

                int Result = cmd.ExecuteNonQuery();

                connection.Close();
            }
            return true;



        }

        public bool Update(int contactId, string name, string family, string email, string mobile, int age, string address)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "UPDATE Contacts SET Name=@Name, Family=@Family, Email=@Email, Mobile=@Mobile, Age=@Age, Address=@Address WHERE Id=@Id";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", contactId);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Family", family);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Mobile", mobile);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Address", address);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    MessageBox.Show("ویرایش با موفقیت انجام شد ✅");
                else
                    MessageBox.Show("هیچ رکوردی برای ویرایش یافت نشد ⚠️");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در ویرایش: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }

        }

        public bool Delete(int contactId)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                string query = "Delete From Contacts where Id=@Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", contactId);
                connection.Open();
                MessageBox.Show(contactId.ToString());

                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {

                connection.Close();

            }
        }

        public DataTable Search(string parameter)
        
               
            {
            string query = "SELECT * FROM Contacts where Name like @parameter  or Family like @parameter";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@parameter", "%" + parameter + "%");
                DataTable data = new DataTable();
                adapter.Fill(data);
                return data;
            }
        }
    
    }
}
