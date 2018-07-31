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
            AdjustPosition();
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

        private void timer_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = renderView1.ProcessTime;
            labelElapseTime.Text = String.Format("処理時間 {0}秒 {1}ミリ秒", ts.Seconds, ts.Milliseconds);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Stop();
        }

        private void button1_Click(object sender, EventArgs evt)
        {
            DialogResult dr = openFileDialog.ShowDialog(this);
            if (dr != DialogResult.OK)
            {
                return;
            }

            try
            {
                string path = openFileDialog.FileName;

                Image image = Image.FromFile(path);

                pictureBox1.Image = image;
                renderView1.Image = image;
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "エラー");
            }

        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            AdjustPosition();

        }
        private void AdjustPosition()
        {
            int inset = 4;
            int editPanelWidth = groupBox1.Width;
            int pictureControlWidth = (ClientSize.Width - editPanelWidth - inset * 4) / 2;
            int pictureControlHeight = ClientSize.Height - inset * 2;

            int pictureBoxX = 4;
            int pictureBoxY = 4;
            pictureBox1.SetBounds(pictureBoxX, pictureBoxY, pictureControlWidth, pictureControlHeight);

            int renderViewX = pictureBoxX + pictureBox1.Width + inset;
            int renderViewY = pictureBoxY;
            renderView1.SetBounds(renderViewX, renderViewY, pictureControlWidth, pictureControlHeight);

            int editPanelX = renderViewX + renderView1.Width + inset;
            int editPanelY = pictureBoxY;
            int editPanelHeight = pictureControlHeight;
            groupBox1.SetBounds(editPanelX, editPanelY, editPanelWidth, editPanelHeight);
        }
    }
}
