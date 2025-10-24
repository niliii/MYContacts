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

        public DataTable SelectAll()
        {
            string query = "SELECT * FROM Contacts";

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
            throw new System.NotImplementedException();
        }

        public bool Delete(int contactId)
        {
            throw new System.NotImplementedException();
        }
    }
}
