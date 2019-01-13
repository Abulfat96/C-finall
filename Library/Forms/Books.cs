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
        LibraryEntities1 db = new LibraryEntities1();
        public Books()
        {
            InitializeComponent();
            FillBooks();

        }

        public void FillBooks()
        {
            dgvList.Rows.Clear();
            foreach (Book book in db.Books.ToList()) 
            {
                dgvList.Rows.Add(book.Id, book.AD, book.Count);


            }
            db.SaveChanges();
        }
    }
}
