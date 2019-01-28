using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.Forms
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
          
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            Books books = new Books();
            books.Show();
            this.Hide();
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            Useres users = new Useres();
            users.Show();
            this.Hide();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {

            Orders_Form orders_Form = new Orders_Form();
            orders_Form.Show();
            this.Hide();
        }
    }
}
