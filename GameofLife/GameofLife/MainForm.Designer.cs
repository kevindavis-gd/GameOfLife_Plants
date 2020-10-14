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
            this.SuspendLayout();
            // 
            // LoadDataButton
            // 
            this.LoadDataButton.Location = new System.Drawing.Point(41, 702);
            this.LoadDataButton.Name = "LoadDataButton";
            this.LoadDataButton.Size = new System.Drawing.Size(75, 23);
            this.LoadDataButton.TabIndex = 0;
            this.LoadDataButton.Text = "Load";
            this.LoadDataButton.UseVisualStyleBackColor = true;
            this.LoadDataButton.Click += new System.EventHandler(this.LoadButton_click);
            // 
            // textBox_FlyNum
            // 
            this.textBox_FlyNum.Location = new System.Drawing.Point(83, 582);
            this.textBox_FlyNum.Name = "textBox_FlyNum";
            this.textBox_FlyNum.Size = new System.Drawing.Size(100, 22);
            this.textBox_FlyNum.TabIndex = 53;
            // 
            // textBox_MajesticNum
            // 
            this.textBox_MajesticNum.Location = new System.Drawing.Point(83, 611);
            this.textBox_MajesticNum.Name = "textBox_MajesticNum";
            this.textBox_MajesticNum.Size = new System.Drawing.Size(100, 22);
            this.textBox_MajesticNum.TabIndex = 54;
            // 
            // textBox_DeadlyNum
            // 
            this.textBox_DeadlyNum.Location = new System.Drawing.Point(83, 639);
            this.textBox_DeadlyNum.Name = "textBox_DeadlyNum";
            this.textBox_DeadlyNum.Size = new System.Drawing.Size(100, 22);
            this.textBox_DeadlyNum.TabIndex = 55;
            // 
            // label_FlyNum
            // 
            this.label_FlyNum.AutoSize = true;
            this.label_FlyNum.Location = new System.Drawing.Point(35, 587);
            this.label_FlyNum.Name = "label_FlyNum";
            this.label_FlyNum.Size = new System.Drawing.Size(38, 17);
            this.label_FlyNum.TabIndex = 56;
            this.label_FlyNum.Text = "Fly #";
            this.label_FlyNum.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_MajesticNum
            // 
            this.label_MajesticNum.AutoSize = true;
            this.label_MajesticNum.Location = new System.Drawing.Point(2, 611);
            this.label_MajesticNum.Name = "label_MajesticNum";
            this.label_MajesticNum.Size = new System.Drawing.Size(71, 17);
            this.label_MajesticNum.TabIndex = 57;
            this.label_MajesticNum.Text = "Majestic #";
            // 
            // label_DeadlyNums
            // 
            this.label_DeadlyNums.AutoSize = true;
            this.label_DeadlyNums.Location = new System.Drawing.Point(9, 639);
            this.label_DeadlyNums.Name = "label_DeadlyNums";
            this.label_DeadlyNums.Size = new System.Drawing.Size(64, 17);
            this.label_DeadlyNums.TabIndex = 58;
            this.label_DeadlyNums.Text = "Deadly #";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 753);
            this.Controls.Add(this.label_DeadlyNums);
            this.Controls.Add(this.label_MajesticNum);
            this.Controls.Add(this.label_FlyNum);
            this.Controls.Add(this.textBox_DeadlyNum);
            this.Controls.Add(this.textBox_MajesticNum);
            this.Controls.Add(this.textBox_FlyNum);
            this.Controls.Add(this.LoadDataButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadDataButton;
        private System.Windows.Forms.TextBox textBox_FlyNum;
        private System.Windows.Forms.TextBox textBox_MajesticNum;
        private System.Windows.Forms.TextBox textBox_DeadlyNum;
        private System.Windows.Forms.Label label_FlyNum;
        private System.Windows.Forms.Label label_MajesticNum;
        private System.Windows.Forms.Label label_DeadlyNums;
    }
}

