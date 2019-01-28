﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Models;

namespace Library.Forms
{
    public partial class Logins : Form
    {
        LibraryEntities3 db = new LibraryEntities3();
        public Logins()
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
                this.Hide();
            }
            else
            {
                MessageBox.Show("Email və parol səhv ola bilməz");
            }

        }
    }
}