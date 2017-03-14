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
    public partial class ProgressForm : Form
    {
        private int baseNum = 0;

        public int BaseNum
        {
            get { return baseNum; }
            set { baseNum = value; }
        }

        private int interval = 2;

        public ProgressForm()
        {
            InitializeComponent();

            timerLoop.Enabled = false;
            timerLoop.Interval = 100;
        }

        private void timerLoop_Tick(object sender, EventArgs e)
        {
            progressBarTip.Value += 2;
            if (progressBarTip.Value >= progressBarTip.Maximum)
            {
                progressBarTip.Value = progressBarTip.Minimum;
            }
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            progressBarTip.Maximum = baseNum * interval;
            progressBarTip.Minimum = 0;
            progressBarTip.Value = progressBarTip.Minimum;
        }

        public void partFinished()
        {
            progressBarTip.Value += interval;
        }
    }
}
