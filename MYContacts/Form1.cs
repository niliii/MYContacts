using MYContacts.Repository;
using System;
using System.Windows.Forms;

namespace MYContacts
{
    public partial class Form1 : Form
    {
        IcontactsRepository repository;
        public Form1()
        {
            InitializeComponent();
            repository = new ContactRepository();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            BindGrid();

        }

        private void BindGrid()
        {
            dgContacts.AutoGenerateColumns = false;
            dgContacts.Columns[0].Visible = false;
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnNewContact_Click(object sender, EventArgs e)
        {
            frmAddOrEdit frm = new frmAddOrEdit();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgContacts.CurrentRow != null)
            {
                string name=dgContacts.CurrentRow.Cells[1].Value.ToString();
                string family = dgContacts.CurrentRow.Cells[2].Value.ToString();
                string fullName=name+" "+family;

                if (MessageBox.Show($"آیا از حذف {fullName}مطمعنی؟","توجه",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int contactId = int.Parse(dgContacts.CurrentRow.Cells[0].Value.ToString());
                    repository.Delete(contactId);
                    BindGrid();
                }
                else
                {
                    MessageBox.Show("لطفا یک شخص را انتخاب کنید");
                }

            }
        }
    }

}
