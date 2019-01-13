using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Models;
using Library.Forms;


namespace Library
{
    public partial class Form1 : Form
    {
        LibraryEntities1 db = new LibraryEntities1();
       
        public Form1()
        {
            InitializeComponent();
        }

        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textName.Text) || string.IsNullOrEmpty(textPassword.Text))
            {
                MessageBox.Show("Ad və parol boş ola bilməz");

            }
            else if (db.Admins.FirstOrDefault(a => a.E_mail.ToLower() == textName.Text.ToLower() && a.Parol == textPassword.Text) != null)
            {
                Home home = new Home();
                home.Show();
            }
            else
            {
                MessageBox.Show("Email və parol səhv ola bilməz");
            }

        }
    }
}
