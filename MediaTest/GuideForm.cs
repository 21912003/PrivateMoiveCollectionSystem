using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MediaTest
{
    public partial class GuideForm : Form
    {
        public GuideForm()
        {
            InitializeComponent(); 
        }

        private void btnAllTextQuery_Click(object sender, EventArgs e)
        {
            this.Hide();
            MovieQuery movieQuery = new MovieQuery();
            movieQuery.ShowDialog();
            this.Show();
        }

        private void btnMake_Click(object sender, EventArgs e)
        {
            this.Hide();
            MediaInfoGetting mediaGetForm = new MediaInfoGetting();
            mediaGetForm.ShowDialog();
            this.Show();
        }
    }
}
