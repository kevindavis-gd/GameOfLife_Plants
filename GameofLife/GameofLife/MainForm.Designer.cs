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
            this.components = new System.ComponentModel.Container();
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
            this.groupBox_Control = new System.Windows.Forms.GroupBox();
            this.button_ContinueFromManualSelect = new System.Windows.Forms.Button();
            this.groupBox_manualSelect = new System.Windows.Forms.GroupBox();
            this.radioButton_ManualDeadly = new System.Windows.Forms.RadioButton();
            this.radioButton_ManualFly = new System.Windows.Forms.RadioButton();
            this.radioButton_ManualMimic = new System.Windows.Forms.RadioButton();
            this.button_ManualLoad = new System.Windows.Forms.Button();
            this.radioButton_Manual = new System.Windows.Forms.RadioButton();
            this.radioButton_Auto = new System.Windows.Forms.RadioButton();
            this.label_genCount = new System.Windows.Forms.Label();
            this.label_generationNum = new System.Windows.Forms.Label();
            this.textBox_generationNum = new System.Windows.Forms.TextBox();
            this.button_Restart = new System.Windows.Forms.Button();
            this.label_DeadlyCount = new System.Windows.Forms.Label();
            this.label_MajesticCount = new System.Windows.Forms.Label();
            this.label_FlyCount = new System.Windows.Forms.Label();
            this.timer_Game = new System.Windows.Forms.Timer(this.components);
            this.button_AutoLoad = new System.Windows.Forms.Button();
            this.groupBox_Control.SuspendLayout();
            this.groupBox_manualSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_FlyNum
            // 
            this.textBox_FlyNum.Location = new System.Drawing.Point(77, 14);
            this.textBox_FlyNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_FlyNum.Name = "textBox_FlyNum";
            this.textBox_FlyNum.Size = new System.Drawing.Size(28, 22);
            this.textBox_FlyNum.TabIndex = 53;
            // 
            // textBox_MajesticNum
            // 
            this.textBox_MajesticNum.Location = new System.Drawing.Point(77, 43);
            this.textBox_MajesticNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_MajesticNum.Name = "textBox_MajesticNum";
            this.textBox_MajesticNum.Size = new System.Drawing.Size(28, 22);
            this.textBox_MajesticNum.TabIndex = 54;
            // 
            // textBox_DeadlyNum
            // 
            this.textBox_DeadlyNum.Location = new System.Drawing.Point(77, 74);
            this.textBox_DeadlyNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_DeadlyNum.Name = "textBox_DeadlyNum";
            this.textBox_DeadlyNum.Size = new System.Drawing.Size(28, 22);
            this.textBox_DeadlyNum.TabIndex = 55;
            // 
            // label_FlyNum
            // 
            this.label_FlyNum.AutoSize = true;
            this.label_FlyNum.Location = new System.Drawing.Point(32, 18);
            this.label_FlyNum.Name = "label_FlyNum";
            this.label_FlyNum.Size = new System.Drawing.Size(38, 17);
            this.label_FlyNum.TabIndex = 56;
            this.label_FlyNum.Text = "Fly #";
            this.label_FlyNum.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_MajesticNum
            // 
            this.label_MajesticNum.AutoSize = true;
            this.label_MajesticNum.Location = new System.Drawing.Point(-1, 48);
            this.label_MajesticNum.Name = "label_MajesticNum";
            this.label_MajesticNum.Size = new System.Drawing.Size(71, 17);
            this.label_MajesticNum.TabIndex = 57;
            this.label_MajesticNum.Text = "Majestic #";
            // 
            // label_DeadlyNums
            // 
            this.label_DeadlyNums.AutoSize = true;
            this.label_DeadlyNums.Location = new System.Drawing.Point(5, 78);
            this.label_DeadlyNums.Name = "label_DeadlyNums";
            this.label_DeadlyNums.Size = new System.Drawing.Size(64, 17);
            this.label_DeadlyNums.TabIndex = 58;
            this.label_DeadlyNums.Text = "Deadly #";
            // 
            // textBox_Rows
            // 
            this.textBox_Rows.Location = new System.Drawing.Point(220, 15);
            this.textBox_Rows.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Rows.Name = "textBox_Rows";
            this.textBox_Rows.Size = new System.Drawing.Size(31, 22);
            this.textBox_Rows.TabIndex = 59;
            // 
            // textBox_Columns
            // 
            this.textBox_Columns.Location = new System.Drawing.Point(220, 46);
            this.textBox_Columns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Columns.Name = "textBox_Columns";
            this.textBox_Columns.Size = new System.Drawing.Size(31, 22);
            this.textBox_Columns.TabIndex = 60;
            // 
            // label_Cols
            // 
            this.label_Cols.AutoSize = true;
            this.label_Cols.Location = new System.Drawing.Point(167, 18);
            this.label_Cols.Name = "label_Cols";
            this.label_Cols.Size = new System.Drawing.Size(47, 17);
            this.label_Cols.TabIndex = 61;
            this.label_Cols.Text = "Row #";
            this.label_Cols.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_Rows
            // 
            this.label_Rows.AutoSize = true;
            this.label_Rows.Location = new System.Drawing.Point(167, 48);
            this.label_Rows.Name = "label_Rows";
            this.label_Rows.Size = new System.Drawing.Size(40, 17);
            this.label_Rows.TabIndex = 62;
            this.label_Rows.Text = "Col #";
            this.label_Rows.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button_Next
            // 
            this.button_Next.Location = new System.Drawing.Point(328, 12);
            this.button_Next.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(75, 23);
            this.button_Next.TabIndex = 63;
            this.button_Next.Text = "Next";
            this.button_Next.UseVisualStyleBackColor = true;
            this.button_Next.Visible = false;
            this.button_Next.Click += new System.EventHandler(this.button_Next_Click);
            // 
            // groupBox_Control
            // 
            this.groupBox_Control.AutoSize = true;
            this.groupBox_Control.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox_Control.Controls.Add(this.button_AutoLoad);
            this.groupBox_Control.Controls.Add(this.button_ContinueFromManualSelect);
            this.groupBox_Control.Controls.Add(this.groupBox_manualSelect);
            this.groupBox_Control.Controls.Add(this.button_ManualLoad);
            this.groupBox_Control.Controls.Add(this.radioButton_Manual);
            this.groupBox_Control.Controls.Add(this.radioButton_Auto);
            this.groupBox_Control.Controls.Add(this.label_genCount);
            this.groupBox_Control.Controls.Add(this.label_generationNum);
            this.groupBox_Control.Controls.Add(this.textBox_generationNum);
            this.groupBox_Control.Controls.Add(this.button_Restart);
            this.groupBox_Control.Controls.Add(this.label_DeadlyCount);
            this.groupBox_Control.Controls.Add(this.label_MajesticCount);
            this.groupBox_Control.Controls.Add(this.label_FlyCount);
            this.groupBox_Control.Controls.Add(this.label_DeadlyNums);
            this.groupBox_Control.Controls.Add(this.button_Next);
            this.groupBox_Control.Controls.Add(this.label_MajesticNum);
            this.groupBox_Control.Controls.Add(this.textBox_Columns);
            this.groupBox_Control.Controls.Add(this.label_Rows);
            this.groupBox_Control.Controls.Add(this.label_FlyNum);
            this.groupBox_Control.Controls.Add(this.label_Cols);
            this.groupBox_Control.Controls.Add(this.textBox_Rows);
            this.groupBox_Control.Controls.Add(this.textBox_DeadlyNum);
            this.groupBox_Control.Controls.Add(this.textBox_MajesticNum);
            this.groupBox_Control.Controls.Add(this.textBox_FlyNum);
            this.groupBox_Control.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_Control.Location = new System.Drawing.Point(0, 0);
            this.groupBox_Control.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Control.Name = "groupBox_Control";
            this.groupBox_Control.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Control.Size = new System.Drawing.Size(1072, 121);
            this.groupBox_Control.TabIndex = 64;
            this.groupBox_Control.TabStop = false;
            // 
            // button_ContinueFromManualSelect
            // 
            this.button_ContinueFromManualSelect.Location = new System.Drawing.Point(314, 9);
            this.button_ContinueFromManualSelect.Name = "button_ContinueFromManualSelect";
            this.button_ContinueFromManualSelect.Size = new System.Drawing.Size(109, 23);
            this.button_ContinueFromManualSelect.TabIndex = 75;
            this.button_ContinueFromManualSelect.Text = "Continue";
            this.button_ContinueFromManualSelect.UseVisualStyleBackColor = true;
            this.button_ContinueFromManualSelect.Visible = false;
            this.button_ContinueFromManualSelect.Click += new System.EventHandler(this.button_ContinueFromManualSelect_Click);
            // 
            // groupBox_manualSelect
            // 
            this.groupBox_manualSelect.Controls.Add(this.radioButton_ManualDeadly);
            this.groupBox_manualSelect.Controls.Add(this.radioButton_ManualFly);
            this.groupBox_manualSelect.Controls.Add(this.radioButton_ManualMimic);
            this.groupBox_manualSelect.Location = new System.Drawing.Point(2, 15);
            this.groupBox_manualSelect.Name = "groupBox_manualSelect";
            this.groupBox_manualSelect.Size = new System.Drawing.Size(115, 86);
            this.groupBox_manualSelect.TabIndex = 74;
            this.groupBox_manualSelect.TabStop = false;
            this.groupBox_manualSelect.Visible = false;
            // 
            // radioButton_ManualDeadly
            // 
            this.radioButton_ManualDeadly.AutoSize = true;
            this.radioButton_ManualDeadly.Location = new System.Drawing.Point(0, 8);
            this.radioButton_ManualDeadly.Name = "radioButton_ManualDeadly";
            this.radioButton_ManualDeadly.Size = new System.Drawing.Size(116, 21);
            this.radioButton_ManualDeadly.TabIndex = 2;
            this.radioButton_ManualDeadly.Text = "Majestic Plant";
            this.radioButton_ManualDeadly.UseVisualStyleBackColor = true;
            this.radioButton_ManualDeadly.CheckedChanged += new System.EventHandler(this.radioButton_ManualDeadly_CheckedChanged);
            // 
            // radioButton_ManualFly
            // 
            this.radioButton_ManualFly.AutoSize = true;
            this.radioButton_ManualFly.Checked = true;
            this.radioButton_ManualFly.Location = new System.Drawing.Point(0, 48);
            this.radioButton_ManualFly.Name = "radioButton_ManualFly";
            this.radioButton_ManualFly.Size = new System.Drawing.Size(47, 21);
            this.radioButton_ManualFly.TabIndex = 1;
            this.radioButton_ManualFly.TabStop = true;
            this.radioButton_ManualFly.Text = "Fly";
            this.radioButton_ManualFly.UseVisualStyleBackColor = true;
            this.radioButton_ManualFly.CheckedChanged += new System.EventHandler(this.radioButton_ManualFly_CheckedChanged);
            // 
            // radioButton_ManualMimic
            // 
            this.radioButton_ManualMimic.AutoSize = true;
            this.radioButton_ManualMimic.Location = new System.Drawing.Point(0, 28);
            this.radioButton_ManualMimic.Name = "radioButton_ManualMimic";
            this.radioButton_ManualMimic.Size = new System.Drawing.Size(112, 21);
            this.radioButton_ManualMimic.TabIndex = 0;
            this.radioButton_ManualMimic.Text = "Deadly Mimic";
            this.radioButton_ManualMimic.UseVisualStyleBackColor = true;
            this.radioButton_ManualMimic.CheckedChanged += new System.EventHandler(this.radioButton_ManualMimic_CheckedChanged);
            // 
            // button_ManualLoad
            // 
            this.button_ManualLoad.Location = new System.Drawing.Point(314, 73);
            this.button_ManualLoad.Name = "button_ManualLoad";
            this.button_ManualLoad.Size = new System.Drawing.Size(109, 23);
            this.button_ManualLoad.TabIndex = 73;
            this.button_ManualLoad.Text = "Manual Load";
            this.button_ManualLoad.UseVisualStyleBackColor = true;
            this.button_ManualLoad.Click += new System.EventHandler(this.button_ManualLoad_Click);
            // 
            // radioButton_Manual
            // 
            this.radioButton_Manual.AutoSize = true;
            this.radioButton_Manual.Checked = true;
            this.radioButton_Manual.Location = new System.Drawing.Point(443, 39);
            this.radioButton_Manual.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton_Manual.Name = "radioButton_Manual";
            this.radioButton_Manual.Size = new System.Drawing.Size(141, 21);
            this.radioButton_Manual.TabIndex = 72;
            this.radioButton_Manual.TabStop = true;
            this.radioButton_Manual.Text = "Manual Increment";
            this.radioButton_Manual.UseVisualStyleBackColor = true;
            this.radioButton_Manual.CheckedChanged += new System.EventHandler(this.radioButton_Manual_CheckedChanged);
            // 
            // radioButton_Auto
            // 
            this.radioButton_Auto.AutoSize = true;
            this.radioButton_Auto.Location = new System.Drawing.Point(443, 14);
            this.radioButton_Auto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton_Auto.Name = "radioButton_Auto";
            this.radioButton_Auto.Size = new System.Drawing.Size(124, 21);
            this.radioButton_Auto.TabIndex = 71;
            this.radioButton_Auto.Text = "Auto Increment";
            this.radioButton_Auto.UseVisualStyleBackColor = true;
            this.radioButton_Auto.CheckedChanged += new System.EventHandler(this.radioButton_Auto_CheckedChanged);
            // 
            // label_genCount
            // 
            this.label_genCount.AutoSize = true;
            this.label_genCount.Location = new System.Drawing.Point(657, 71);
            this.label_genCount.Name = "label_genCount";
            this.label_genCount.Size = new System.Drawing.Size(13, 17);
            this.label_genCount.TabIndex = 70;
            this.label_genCount.Text = "-";
            // 
            // label_generationNum
            // 
            this.label_generationNum.AutoSize = true;
            this.label_generationNum.Location = new System.Drawing.Point(123, 78);
            this.label_generationNum.Name = "label_generationNum";
            this.label_generationNum.Size = new System.Drawing.Size(91, 17);
            this.label_generationNum.TabIndex = 69;
            this.label_generationNum.Text = "Generation #";
            // 
            // textBox_generationNum
            // 
            this.textBox_generationNum.Location = new System.Drawing.Point(220, 71);
            this.textBox_generationNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_generationNum.Name = "textBox_generationNum";
            this.textBox_generationNum.Size = new System.Drawing.Size(31, 22);
            this.textBox_generationNum.TabIndex = 68;
            // 
            // button_Restart
            // 
            this.button_Restart.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_Restart.Location = new System.Drawing.Point(469, 75);
            this.button_Restart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Restart.Name = "button_Restart";
            this.button_Restart.Size = new System.Drawing.Size(75, 23);
            this.button_Restart.TabIndex = 67;
            this.button_Restart.Text = "Restart";
            this.button_Restart.UseVisualStyleBackColor = true;
            this.button_Restart.Visible = false;
            this.button_Restart.Click += new System.EventHandler(this.button_Restart_Click);
            // 
            // label_DeadlyCount
            // 
            this.label_DeadlyCount.AutoSize = true;
            this.label_DeadlyCount.Location = new System.Drawing.Point(657, 50);
            this.label_DeadlyCount.Name = "label_DeadlyCount";
            this.label_DeadlyCount.Size = new System.Drawing.Size(13, 17);
            this.label_DeadlyCount.TabIndex = 66;
            this.label_DeadlyCount.Text = "-";
            // 
            // label_MajesticCount
            // 
            this.label_MajesticCount.AutoSize = true;
            this.label_MajesticCount.Location = new System.Drawing.Point(657, 30);
            this.label_MajesticCount.Name = "label_MajesticCount";
            this.label_MajesticCount.Size = new System.Drawing.Size(13, 17);
            this.label_MajesticCount.TabIndex = 65;
            this.label_MajesticCount.Text = "-";
            // 
            // label_FlyCount
            // 
            this.label_FlyCount.AutoSize = true;
            this.label_FlyCount.Location = new System.Drawing.Point(657, 12);
            this.label_FlyCount.Name = "label_FlyCount";
            this.label_FlyCount.Size = new System.Drawing.Size(13, 17);
            this.label_FlyCount.TabIndex = 64;
            this.label_FlyCount.Text = "-";
            // 
            // timer_Game
            // 
            this.timer_Game.Interval = 20;
            this.timer_Game.Tick += new System.EventHandler(this.timer_Game_Tick);
            // 
            // button_AutoLoad
            // 
            this.button_AutoLoad.Location = new System.Drawing.Point(314, 45);
            this.button_AutoLoad.Name = "button_AutoLoad";
            this.button_AutoLoad.Size = new System.Drawing.Size(109, 23);
            this.button_AutoLoad.TabIndex = 76;
            this.button_AutoLoad.Text = "Auto Load";
            this.button_AutoLoad.UseVisualStyleBackColor = true;
            this.button_AutoLoad.Click += new System.EventHandler(this.button_AutoLoad_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScrollMargin = new System.Drawing.Size(1000, 1000);
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1072, 863);
            this.Controls.Add(this.groupBox_Control);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(799, 820);
            this.Name = "MainForm";
            this.Text = "Plants";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox_Control.ResumeLayout(false);
            this.groupBox_Control.PerformLayout();
            this.groupBox_manualSelect.ResumeLayout(false);
            this.groupBox_manualSelect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.GroupBox groupBox_Control;
        private System.Windows.Forms.Label label_DeadlyCount;
        private System.Windows.Forms.Label label_MajesticCount;
        private System.Windows.Forms.Label label_FlyCount;
        private System.Windows.Forms.Button button_Restart;
        private System.Windows.Forms.Label label_generationNum;
        private System.Windows.Forms.TextBox textBox_generationNum;
        private System.Windows.Forms.Timer timer_Game;
        private System.Windows.Forms.Label label_genCount;
        private System.Windows.Forms.RadioButton radioButton_Manual;
        private System.Windows.Forms.RadioButton radioButton_Auto;
        private System.Windows.Forms.Button button_ManualLoad;
        private System.Windows.Forms.GroupBox groupBox_manualSelect;
        private System.Windows.Forms.RadioButton radioButton_ManualDeadly;
        private System.Windows.Forms.RadioButton radioButton_ManualFly;
        private System.Windows.Forms.RadioButton radioButton_ManualMimic;
        private System.Windows.Forms.Button button_ContinueFromManualSelect;
        private System.Windows.Forms.Button button_AutoLoad;
    }
}

