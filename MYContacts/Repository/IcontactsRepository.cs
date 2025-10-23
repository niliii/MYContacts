using System.Data;

namespace MYContacts.Repository
{
    interface IcontactsRepository
    {
        DataTable SelectAll();
        bool Insert(string name, string family, string email, string phone, int age, string address);
        bool Update(int contactId, string name, string family, string email, string phone, int age, string address);
        bool Delete(int contactId);
    }
}
