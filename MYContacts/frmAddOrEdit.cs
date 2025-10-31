using MYContacts.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MYContacts
{
    public partial class frmAddOrEdit : Form
    {
        IcontactsRepository Repository;
        public int contactId = 0;
        private string txtfamily;

        public frmAddOrEdit()
        {

            InitializeComponent();
            Repository = new ContactRepository();
        }
        private void frmAddOrEdit_Load(object sender, EventArgs e)
        {
            if (contactId == 0)
            {
                this.Text = "افزودن شخص";

            }
            else
            {
                this.Text = "ویرایش شخص";
                DataTable dt = Repository.SelectRow(contactId);
                txtName.Text = dt.Rows[0][1].ToString();
                txtEamil.Text=dt.Rows[0][2].ToString();
                txtMobile.Text=dt.Rows[0][4].ToString();
                txtAge.Text=dt.Rows[0][5].ToString();
                txtAddress.Text=dt.Rows[0][6 ].ToString();
                bynSubmitt.Text = "ویرایش";
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        bool ValidateInputs()
        {

            if (txtName.Text == "")
            {
                MessageBox.Show("لطفا نام را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            if (txtEmail.Text == "")
            {


                MessageBox.Show("لطفا ایمیل را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtEamil.Text == "")
            {

                MessageBox.Show("لطفا نام خانوادگی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtAge.Value == 0)
            {

                MessageBox.Show("لطفا سن را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtMobile.Text == "")
            {

                MessageBox.Show("لطفا موبایل را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void bynSubmitt_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                bool isSuccess;
                if (contactId == 0)
                { 
                    isSuccess = Repository.Insert(txtName.Text, txtEmail.Text, txtEamil.Text, txtAddress.Text, (int)txtAge.Value, txtMobile.Text);
                }
                else
                {
                   isSuccess = Repository.Update(contactId,txtName.Text, txtEmail.Text, txtEamil.Text, txtAddress.Text, (int)txtAge.Value, txtMobile.Text);
                }
                if (isSuccess == true)
                {

                    MessageBox.Show("عملیات با موفقیت انجام شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    
                 MessageBox.Show("عملیات با شکست مواجه شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
