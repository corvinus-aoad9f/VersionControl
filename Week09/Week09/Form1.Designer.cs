
namespace Week09
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.resultText = new System.Windows.Forms.RichTextBox();
            this.browseBut = new System.Windows.Forms.Button();
            this.startBut = new System.Windows.Forms.Button();
            this.endYearNum = new System.Windows.Forms.NumericUpDown();
            this.personText = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.endYearNum)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Záróév:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Népesség fájl";
            // 
            // resultText
            // 
            this.resultText.Location = new System.Drawing.Point(13, 45);
            this.resultText.Name = "resultText";
            this.resultText.Size = new System.Drawing.Size(634, 393);
            this.resultText.TabIndex = 2;
            this.resultText.Text = "";
            // 
            // browseBut
            // 
            this.browseBut.Location = new System.Drawing.Point(461, 8);
            this.browseBut.Name = "browseBut";
            this.browseBut.Size = new System.Drawing.Size(75, 23);
            this.browseBut.TabIndex = 3;
            this.browseBut.Text = "Browse";
            this.browseBut.UseVisualStyleBackColor = true;
            this.browseBut.Click += new System.EventHandler(this.browseBut_Click);
            // 
            // startBut
            // 
            this.startBut.Enabled = false;
            this.startBut.Location = new System.Drawing.Point(542, 8);
            this.startBut.Name = "startBut";
            this.startBut.Size = new System.Drawing.Size(75, 23);
            this.startBut.TabIndex = 4;
            this.startBut.Text = "Start";
            this.startBut.UseVisualStyleBackColor = true;
            this.startBut.Click += new System.EventHandler(this.startBut_Click);
            // 
            // endYearNum
            // 
            this.endYearNum.Location = new System.Drawing.Point(68, 11);
            this.endYearNum.Maximum = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.endYearNum.Minimum = new decimal(new int[] {
            2005,
            0,
            0,
            0});
            this.endYearNum.Name = "endYearNum";
            this.endYearNum.Size = new System.Drawing.Size(91, 20);
            this.endYearNum.TabIndex = 5;
            this.endYearNum.Value = new decimal(new int[] {
            2024,
            0,
            0,
            0});
            // 
            // personText
            // 
            this.personText.Location = new System.Drawing.Point(290, 10);
            this.personText.Name = "personText";
            this.personText.Size = new System.Drawing.Size(165, 20);
            this.personText.TabIndex = 6;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.personText);
            this.Controls.Add(this.endYearNum);
            this.Controls.Add(this.startBut);
            this.Controls.Add(this.browseBut);
            this.Controls.Add(this.resultText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.endYearNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox resultText;
        private System.Windows.Forms.Button browseBut;
        private System.Windows.Forms.Button startBut;
        private System.Windows.Forms.NumericUpDown endYearNum;
        private System.Windows.Forms.TextBox personText;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

