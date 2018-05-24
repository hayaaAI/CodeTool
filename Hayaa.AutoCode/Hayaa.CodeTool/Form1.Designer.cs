namespace Hayaa.CodeTool
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.DaoPath = new System.Windows.Forms.TextBox();
            this.ModelPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LanguageType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CreateCodeBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dao层路径";
            // 
            // DaoPath
            // 
            this.DaoPath.Location = new System.Drawing.Point(111, 358);
            this.DaoPath.Name = "DaoPath";
            this.DaoPath.Size = new System.Drawing.Size(528, 25);
            this.DaoPath.TabIndex = 1;
            // 
            // ModelPath
            // 
            this.ModelPath.Location = new System.Drawing.Point(111, 55);
            this.ModelPath.Name = "ModelPath";
            this.ModelPath.Size = new System.Drawing.Size(528, 25);
            this.ModelPath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Model层路径";
            // 
            // LanguageType
            // 
            this.LanguageType.FormattingEnabled = true;
            this.LanguageType.Items.AddRange(new object[] {
            "C#",
            "Java"});
            this.LanguageType.Location = new System.Drawing.Point(111, 13);
            this.LanguageType.Name = "LanguageType";
            this.LanguageType.Size = new System.Drawing.Size(121, 23);
            this.LanguageType.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "语言类型";
            // 
            // CreateCodeBtn
            // 
            this.CreateCodeBtn.Location = new System.Drawing.Point(14, 809);
            this.CreateCodeBtn.Name = "CreateCodeBtn";
            this.CreateCodeBtn.Size = new System.Drawing.Size(75, 23);
            this.CreateCodeBtn.TabIndex = 6;
            this.CreateCodeBtn.Text = "创建";
            this.CreateCodeBtn.UseVisualStyleBackColor = true;
            this.CreateCodeBtn.Click += new System.EventHandler(this.CreateCodeBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(672, 368);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "需要有文件名";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(672, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "需要有文件名";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(111, 100);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(658, 234);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(111, 408);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(658, 234);
            this.richTextBox2.TabIndex = 11;
            this.richTextBox2.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-2, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Model代码模板";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-2, 411);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Dao代码模板";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(111, 648);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(658, 147);
            this.richTextBox3.TabIndex = 17;
            this.richTextBox3.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 710);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "Sql";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 857);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CreateCodeBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LanguageType);
            this.Controls.Add(this.ModelPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DaoPath);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "编码效率工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DaoPath;
        private System.Windows.Forms.TextBox ModelPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox LanguageType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CreateCodeBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Label label9;
    }
}

