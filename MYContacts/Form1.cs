using MYContacts.Repository;
using System;
using System.Windows.Forms;

namespace MYContacts
{
    public partial class Form1: Form
    {
        IcontactsRepository repository;
        public Form1()
        {
            InitializeComponent();
            repository = new ContactRepository();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            dgContacts.AutoGenerateColumns=false;
            dgContacts.DataSource = repository.SelectAll();
             
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgContacts.DataSource = repository.SelectAll();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

       
    }

}
