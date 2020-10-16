namespace GameofLife
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoadDataButton = new System.Windows.Forms.Button();
            this.textBox_FlyNum = new System.Windows.Forms.TextBox();
            this.textBox_MajesticNum = new System.Windows.Forms.TextBox();
            this.textBox_DeadlyNum = new System.Windows.Forms.TextBox();
            this.label_FlyNum = new System.Windows.Forms.Label();
            this.label_MajesticNum = new System.Windows.Forms.Label();
            this.label_DeadlyNums = new System.Windows.Forms.Label();
            this.textBox_Rows = new System.Windows.Forms.TextBox();
            this.textBox_Columns = new System.Windows.Forms.TextBox();
            this.label_Cols = new System.Windows.Forms.Label();
            this.label_Rows = new System.Windows.Forms.Label();
            this.button_Next = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_FlyCount = new System.Windows.Forms.Label();
            this.label_MajesticCount = new System.Windows.Forms.Label();
            this.label_DeadlyCount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoadDataButton
            // 
            this.LoadDataButton.Location = new System.Drawing.Point(257, 51);
            this.LoadDataButton.Name = "LoadDataButton";
            this.LoadDataButton.Size = new System.Drawing.Size(75, 23);
            this.LoadDataButton.TabIndex = 0;
            this.LoadDataButton.Text = "Load";
            this.LoadDataButton.UseVisualStyleBackColor = true;
            this.LoadDataButton.Click += new System.EventHandler(this.LoadButton_click);
            // 
            // textBox_FlyNum
            // 
            this.textBox_FlyNum.Location = new System.Drawing.Point(83, 4);
            this.textBox_FlyNum.Name = "textBox_FlyNum";
            this.textBox_FlyNum.Size = new System.Drawing.Size(28, 22);
            this.textBox_FlyNum.TabIndex = 53;
            // 
            // textBox_MajesticNum
            // 
            this.textBox_MajesticNum.Location = new System.Drawing.Point(83, 32);
            this.textBox_MajesticNum.Name = "textBox_MajesticNum";
            this.textBox_MajesticNum.Size = new System.Drawing.Size(28, 22);
            this.textBox_MajesticNum.TabIndex = 54;
            // 
            // textBox_DeadlyNum
            // 
            this.textBox_DeadlyNum.Location = new System.Drawing.Point(83, 60);
            this.textBox_DeadlyNum.Name = "textBox_DeadlyNum";
            this.textBox_DeadlyNum.Size = new System.Drawing.Size(28, 22);
            this.textBox_DeadlyNum.TabIndex = 55;
            // 
            // label_FlyNum
            // 
            this.label_FlyNum.AutoSize = true;
            this.label_FlyNum.Location = new System.Drawing.Point(39, 4);
            this.label_FlyNum.Name = "label_FlyNum";
            this.label_FlyNum.Size = new System.Drawing.Size(38, 17);
            this.label_FlyNum.TabIndex = 56;
            this.label_FlyNum.Text = "Fly #";
            this.label_FlyNum.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_MajesticNum
            // 
            this.label_MajesticNum.AutoSize = true;
            this.label_MajesticNum.Location = new System.Drawing.Point(6, 29);
            this.label_MajesticNum.Name = "label_MajesticNum";
            this.label_MajesticNum.Size = new System.Drawing.Size(71, 17);
            this.label_MajesticNum.TabIndex = 57;
            this.label_MajesticNum.Text = "Majestic #";
            // 
            // label_DeadlyNums
            // 
            this.label_DeadlyNums.AutoSize = true;
            this.label_DeadlyNums.Location = new System.Drawing.Point(13, 57);
            this.label_DeadlyNums.Name = "label_DeadlyNums";
            this.label_DeadlyNums.Size = new System.Drawing.Size(64, 17);
            this.label_DeadlyNums.TabIndex = 58;
            this.label_DeadlyNums.Text = "Deadly #";
            // 
            // textBox_Rows
            // 
            this.textBox_Rows.Location = new System.Drawing.Point(174, 7);
            this.textBox_Rows.Name = "textBox_Rows";
            this.textBox_Rows.Size = new System.Drawing.Size(31, 22);
            this.textBox_Rows.TabIndex = 59;
            // 
            // textBox_Columns
            // 
            this.textBox_Columns.Location = new System.Drawing.Point(174, 35);
            this.textBox_Columns.Name = "textBox_Columns";
            this.textBox_Columns.Size = new System.Drawing.Size(31, 22);
            this.textBox_Columns.TabIndex = 60;
            // 
            // label_Cols
            // 
            this.label_Cols.AutoSize = true;
            this.label_Cols.Location = new System.Drawing.Point(133, 7);
            this.label_Cols.Name = "label_Cols";
            this.label_Cols.Size = new System.Drawing.Size(35, 17);
            this.label_Cols.TabIndex = 61;
            this.label_Cols.Text = "Cols";
            this.label_Cols.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_Rows
            // 
            this.label_Rows.AutoSize = true;
            this.label_Rows.Location = new System.Drawing.Point(126, 37);
            this.label_Rows.Name = "label_Rows";
            this.label_Rows.Size = new System.Drawing.Size(42, 17);
            this.label_Rows.TabIndex = 62;
            this.label_Rows.Text = "Rows";
            this.label_Rows.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button_Next
            // 
            this.button_Next.Location = new System.Drawing.Point(257, 7);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(75, 23);
            this.button_Next.TabIndex = 63;
            this.button_Next.Text = "Next";
            this.button_Next.UseVisualStyleBackColor = true;
            this.button_Next.Click += new System.EventHandler(this.button_Next_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_DeadlyCount);
            this.groupBox1.Controls.Add(this.label_MajesticCount);
            this.groupBox1.Controls.Add(this.label_FlyCount);
            this.groupBox1.Controls.Add(this.label_DeadlyNums);
            this.groupBox1.Controls.Add(this.LoadDataButton);
            this.groupBox1.Controls.Add(this.button_Next);
            this.groupBox1.Controls.Add(this.label_MajesticNum);
            this.groupBox1.Controls.Add(this.textBox_Columns);
            this.groupBox1.Controls.Add(this.label_Rows);
            this.groupBox1.Controls.Add(this.label_FlyNum);
            this.groupBox1.Controls.Add(this.label_Cols);
            this.groupBox1.Controls.Add(this.textBox_Rows);
            this.groupBox1.Controls.Add(this.textBox_DeadlyNum);
            this.groupBox1.Controls.Add(this.textBox_MajesticNum);
            this.groupBox1.Controls.Add(this.textBox_FlyNum);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 102);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            // 
            // label_FlyCount
            // 
            this.label_FlyCount.AutoSize = true;
            this.label_FlyCount.Location = new System.Drawing.Point(443, 18);
            this.label_FlyCount.Name = "label_FlyCount";
            this.label_FlyCount.Size = new System.Drawing.Size(46, 17);
            this.label_FlyCount.TabIndex = 64;
            this.label_FlyCount.Text = "label1";
            // 
            // label_MajesticCount
            // 
            this.label_MajesticCount.AutoSize = true;
            this.label_MajesticCount.Location = new System.Drawing.Point(443, 40);
            this.label_MajesticCount.Name = "label_MajesticCount";
            this.label_MajesticCount.Size = new System.Drawing.Size(46, 17);
            this.label_MajesticCount.TabIndex = 65;
            this.label_MajesticCount.Text = "label2";
            // 
            // label_DeadlyCount
            // 
            this.label_DeadlyCount.AutoSize = true;
            this.label_DeadlyCount.Location = new System.Drawing.Point(443, 65);
            this.label_DeadlyCount.Name = "label_DeadlyCount";
            this.label_DeadlyCount.Size = new System.Drawing.Size(46, 17);
            this.label_DeadlyCount.TabIndex = 66;
            this.label_DeadlyCount.Text = "label3";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(1000, 1000);
            this.ClientSize = new System.Drawing.Size(911, 554);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadDataButton;
        private System.Windows.Forms.TextBox textBox_FlyNum;
        private System.Windows.Forms.TextBox textBox_MajesticNum;
        private System.Windows.Forms.TextBox textBox_DeadlyNum;
        private System.Windows.Forms.Label label_FlyNum;
        private System.Windows.Forms.Label label_MajesticNum;
        private System.Windows.Forms.Label label_DeadlyNums;
        private System.Windows.Forms.TextBox textBox_Rows;
        private System.Windows.Forms.TextBox textBox_Columns;
        private System.Windows.Forms.Label label_Cols;
        private System.Windows.Forms.Label label_Rows;
        private System.Windows.Forms.Button button_Next;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_DeadlyCount;
        private System.Windows.Forms.Label label_MajesticCount;
        private System.Windows.Forms.Label label_FlyCount;
    }
}

