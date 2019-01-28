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

namespace Library.Forms
{


    public partial class Useres : Form
    {
        LibraryEntities3 db = new LibraryEntities3();


        public Useres()
        {
            InitializeComponent();
            Filladd();
        }
        public void resetTo()
        {
            Filladd();
        }
        public void Filladd()
        {
            dgvUserslist.Rows.Clear();
            foreach (var item in db.Users.ToList())
            {
                dgvUserslist.Rows.Add(item.Name, item.Surname, item.Phone, item.Id);
            }
            db.SaveChanges();
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();

            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Users users = new Users();
           

                
            
            if(string.IsNullOrEmpty(txtPhone.Text)|| string.IsNullOrEmpty(txtSurname.Text)|| string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Bosluq buraxmayin");
            }
            else
            {
                users.Phone = txtPhone.Text;
                users.Surname = txtSurname.Text;
                dgvUserslist.Rows.Add(users.Name, users.Surname, users.Phone);
                db.Users.Add(users);
                users.Name = txtName.Text;

                
             
            }
            if (txtName.Text != null ||txtPhone.Text!=null|| txtSurname.Text!=null)
            {
                txtName.Text = "";
                txtSurname.Text = "";
                txtPhone.Text = "";
        
                db.SaveChanges();
                resetTo();
            }
           
       
        }


        private void Useres_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Istifadəçini silmək istyisizmi?", "İstifadəçi silindi", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
            {
                Models.Users toRemove = db.Users.Find(dgvUserslist.CurrentRow.Cells[3].Value);

                dgvUserslist.Rows.RemoveAt(dgvUserslist.CurrentRow.Index);
                     
                db.Users.Remove(toRemove);

                db.SaveChanges();

                MessageBox.Show("İstifadəçi silindi");
            }
           
           

        }


    }
}






