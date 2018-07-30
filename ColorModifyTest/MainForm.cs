using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColorModifyTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void trackBarH_ValueChanged(object sender, EventArgs e)
        {
            labelH.Text = trackBarH.Value.ToString();
            renderView1.Hue = trackBarH.Value;
            renderView1.Refresh();
        }

        private void trackBarS_ValueChanged(object sender, EventArgs e)
        {
            labelS.Text = trackBarS.Value.ToString();
            renderView1.Saturation = trackBarS.Value;
            renderView1.Refresh();
        }

        private void trackBarV_ValueChanged(object sender, EventArgs e)
        {
            labelV.Text = trackBarV.Value.ToString();
            renderView1.Value = trackBarV.Value;
            renderView1.Refresh();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            trackBarH.Value = 0;
            trackBarS.Value = 0;
            trackBarV.Value = 0;
        }
    }
}
