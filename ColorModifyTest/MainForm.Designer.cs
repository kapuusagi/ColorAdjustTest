namespace ColorModifyTest
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.trackBarH = new System.Windows.Forms.TrackBar();
            this.trackBarS = new System.Windows.Forms.TrackBar();
            this.trackBarV = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelH = new System.Windows.Forms.Label();
            this.labelS = new System.Windows.Forms.Label();
            this.labelV = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelElapseTime = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.renderView1 = new ColorModifyTest.RenderView();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBarH
            // 
            this.trackBarH.Location = new System.Drawing.Point(67, 18);
            this.trackBarH.Maximum = 180;
            this.trackBarH.Minimum = -180;
            this.trackBarH.Name = "trackBarH";
            this.trackBarH.Size = new System.Drawing.Size(203, 45);
            this.trackBarH.TabIndex = 1;
            this.trackBarH.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarH.ValueChanged += new System.EventHandler(this.trackBarH_ValueChanged);
            // 
            // trackBarS
            // 
            this.trackBarS.Location = new System.Drawing.Point(67, 69);
            this.trackBarS.Maximum = 255;
            this.trackBarS.Minimum = -255;
            this.trackBarS.Name = "trackBarS";
            this.trackBarS.Size = new System.Drawing.Size(203, 45);
            this.trackBarS.TabIndex = 1;
            this.trackBarS.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarS.ValueChanged += new System.EventHandler(this.trackBarS_ValueChanged);
            // 
            // trackBarV
            // 
            this.trackBarV.Location = new System.Drawing.Point(67, 120);
            this.trackBarV.Maximum = 255;
            this.trackBarV.Minimum = -255;
            this.trackBarV.Name = "trackBarV";
            this.trackBarV.Size = new System.Drawing.Size(203, 45);
            this.trackBarV.TabIndex = 1;
            this.trackBarV.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarV.ValueChanged += new System.EventHandler(this.trackBarV_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "色相";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "彩度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "明度";
            // 
            // labelH
            // 
            this.labelH.AutoSize = true;
            this.labelH.Location = new System.Drawing.Point(12, 34);
            this.labelH.Name = "labelH";
            this.labelH.Size = new System.Drawing.Size(11, 12);
            this.labelH.TabIndex = 6;
            this.labelH.Text = "0";
            // 
            // labelS
            // 
            this.labelS.AutoSize = true;
            this.labelS.Location = new System.Drawing.Point(12, 85);
            this.labelS.Name = "labelS";
            this.labelS.Size = new System.Drawing.Size(11, 12);
            this.labelS.TabIndex = 7;
            this.labelS.Text = "0";
            // 
            // labelV
            // 
            this.labelV.AutoSize = true;
            this.labelV.Location = new System.Drawing.Point(12, 136);
            this.labelV.Name = "labelV";
            this.labelV.Size = new System.Drawing.Size(11, 12);
            this.labelV.TabIndex = 8;
            this.labelV.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ColorModifyTest.Properties.Resources.sample;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(234, 449);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelElapseTime);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.buttonReset);
            this.groupBox1.Controls.Add(this.trackBarH);
            this.groupBox1.Controls.Add(this.labelV);
            this.groupBox1.Controls.Add(this.trackBarS);
            this.groupBox1.Controls.Add(this.labelS);
            this.groupBox1.Controls.Add(this.trackBarV);
            this.groupBox1.Controls.Add(this.labelH);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(540, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 252);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(12, 179);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 9;
            this.buttonReset.Text = "リセット";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // labelElapseTime
            // 
            this.labelElapseTime.AutoSize = true;
            this.labelElapseTime.Location = new System.Drawing.Point(113, 179);
            this.labelElapseTime.Name = "labelElapseTime";
            this.labelElapseTime.Size = new System.Drawing.Size(0, 12);
            this.labelElapseTime.TabIndex = 10;
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "画像を変更する";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "PNGファイル|*.png|JPEGファイル|*.jpg|BMPファイル|*.bmp|全てのファイル|*.*";
            this.openFileDialog.Title = "画像を読み込む";
            // 
            // renderView1
            // 
            this.renderView1.Hue = 0;
            this.renderView1.Image = ((System.Drawing.Image)(resources.GetObject("renderView1.Image")));
            this.renderView1.Location = new System.Drawing.Point(274, 12);
            this.renderView1.Name = "renderView1";
            this.renderView1.Saturation = 0;
            this.renderView1.Size = new System.Drawing.Size(244, 449);
            this.renderView1.TabIndex = 0;
            this.renderView1.Value = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 494);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.renderView1);
            this.Name = "MainForm";
            this.Text = "カラー調整テスト";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RenderView renderView1;
        private System.Windows.Forms.TrackBar trackBarH;
        private System.Windows.Forms.TrackBar trackBarS;
        private System.Windows.Forms.TrackBar trackBarV;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelH;
        private System.Windows.Forms.Label labelS;
        private System.Windows.Forms.Label labelV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelElapseTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

