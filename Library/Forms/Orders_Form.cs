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
    public partial class Orders_Form : Form
    {
        LibraryEntities3 db = new LibraryEntities3();
        public Orders_Form()
        {
            InitializeComponent();
         
            FilladdUser();
            FilladdBooks();
            toReset();

        }






        private void btnBack_Click(object sender, EventArgs e)
        {

            Home home = new Home();
            home.Show();
            this.Hide();
        }
        public void FilladdUser()
        {
            foreach (var item in db.Users.OrderBy(c => c.Name).ToList())
            {
                cmbUsers.Items.Add(item.Id + "-" + item.Name);
            }
        }
        public void FilladdBooks()
        {
            foreach (var item in db.Books.OrderBy(c => c.AD).ToList())
            {
                cmbBooks.Items.Add(item.Id + "-" + item.AD);
            }
        }
      


         public void toReset()
        {
            dgvOrders.Rows.Clear();
            foreach (var item in db.Orders)
            {
                dgvOrders.Rows.Add(item.Id, item.Users.Name,item.Books.AD,item.StartDate,item.EndDate,item.Cerime);
            }
            
        }
     
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Orders order = new Orders();
            
          

            if (string.IsNullOrEmpty(cmbBooks.Text)||string.IsNullOrEmpty(cmbUsers.Text))
            {
                MessageBox.Show("Seçim edin");

            }
           
            else
            {
               
                order.UserId = Convert.ToInt32(cmbUsers.Text.Split('-')[0]);
                order.BookId = Convert.ToInt32(cmbBooks.Text.Split('-')[0]);
                order.StartDate = DateTime.Now;
                
                order.EndDate = order.StartDate.Value.AddMinutes(1);
                  
                db.Orders.Add(order);
                db.SaveChanges();
                toReset();
                


            }
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("İstifadəçini silmək istiyirsinizmi ?", "İstifadəçi silindi", MessageBoxButtons.YesNo);
            if (r==DialogResult.Yes)
            {
                Orders toRemove = db.Orders.Find(dgvOrders.CurrentRow.Cells[0].Value);
                db.Orders.Remove(toRemove);
                dgvOrders.Rows.RemoveAt(dgvOrders.CurrentRow.Index);
                MessageBox.Show("Istifadəçi silindi");
            }
            db.SaveChanges();
        }

        private void Orders_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }

        }
    





