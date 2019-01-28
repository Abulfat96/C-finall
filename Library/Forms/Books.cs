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
    public partial class Books : Form
    {

        LibraryEntities3 db = new LibraryEntities3();


        public Books()
        {
            InitializeComponent();
            FillBooks();

        }

        public void ResetDgv()


        {
            dgvList.Rows.Clear();
            FillBooks();

        }


        public void FillBooks()
        {
            dgvList.Rows.Clear();
            foreach (var book in db.Books.ToList())
            {

                dgvList.Rows.Add(book.Id, book.Count, book.AD);


            }

            db.SaveChanges();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();

        }



        private void btnAdd_Click(object sender, EventArgs e)
        {

            Models.Books book = new Models.Books();
           
            if (string.IsNullOrEmpty(textName.Text) || nmCount.Value == 0)
            {
                MessageBox.Show("Kitabın adını və sayını yazın");
                return;
            }
           

            else if (nmCount.Value != 0)
            {


                book.AD = textName.Text;
                book.Count = Convert.ToString(nmCount.Value);
                dgvList.Rows.Add(book.AD, book.Count);
                db.Books.Add(book);
                db.SaveChanges();
                ResetDgv();
            }
            if (textName.Text!=null|| nmCount.Value!=0)
            {
                textName.Text = " ";
                nmCount.Value = 0;
            }

            
            
        }



        private void btnDelet_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bu kitabı silmək istəyirsinizmi ?", "Kitab silindi", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)

            {

                Models.Books toRemove = db.Books.Find(dgvList.CurrentRow.Cells[0].Value);
                if (toRemove != null)
                {
                    db.Books.Remove(toRemove);
                    dgvList.Rows.RemoveAt(dgvList.CurrentRow.Index);
                }

                
                MessageBox.Show("Kitab silindi");

                db.SaveChanges();
              
            }

        }

        private void Books_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}


    



