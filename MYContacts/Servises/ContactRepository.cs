using System.Data;
using System.Data.SqlClient;

namespace MYContacts.Repository
{
    class ContactRepository : IcontactsRepository
    {
        private string connectionString = "Data Source=.; Initial Catalog=MyDb; User ID=sa; Password=zxcvZXCV";

        public DataTable SelectAll()
        {
            string query = "SELECT * FROM dbo.Products"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                return data;
            }
        }

        public bool Insert(string name, string family, string email, string phone, int age, string address)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(int contactId, string name, string family, string email, string phone, int age, string address)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int contactId)
        {
            throw new System.NotImplementedException();
        }
    }
}
