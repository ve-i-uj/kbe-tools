namespace UsertypeDefTools
{
	partial class TypeChooseWindow
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
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.m_btn_ok = new System.Windows.Forms.Button();
            this.m_txt_typeName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.m_radioBtn_aliasType = new System.Windows.Forms.RadioButton();
            this.m_groupBox = new System.Windows.Forms.GroupBox();
            this.m_radioBtn_userType = new System.Windows.Forms.RadioButton();
            this.m_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btn_ok
            // 
            this.m_btn_ok.Location = new System.Drawing.Point(144, 222);
            this.m_btn_ok.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.m_btn_ok.Name = "m_btn_ok";
            this.m_btn_ok.Size = new System.Drawing.Size(150, 46);
            this.m_btn_ok.TabIndex = 0;
            this.m_btn_ok.Text = "OK";
            this.m_btn_ok.UseVisualStyleBackColor = true;
            this.m_btn_ok.Click += new System.EventHandler(this.m_btn_ok_Click);
            // 
            // m_txt_typeName
            // 
            this.m_txt_typeName.Location = new System.Drawing.Point(144, 70);
            this.m_txt_typeName.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.m_txt_typeName.Name = "m_txt_typeName";
            this.m_txt_typeName.Size = new System.Drawing.Size(196, 35);
            this.m_txt_typeName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "TypeName:";
            // 
            // m_radioBtn_aliasType
            // 
            this.m_radioBtn_aliasType.AutoSize = true;
            this.m_radioBtn_aliasType.Checked = true;
            this.m_radioBtn_aliasType.Location = new System.Drawing.Point(6, 57);
            this.m_radioBtn_aliasType.Name = "m_radioBtn_aliasType";
            this.m_radioBtn_aliasType.Size = new System.Drawing.Size(137, 28);
            this.m_radioBtn_aliasType.TabIndex = 3;
            this.m_radioBtn_aliasType.TabStop = true;
            this.m_radioBtn_aliasType.Text = "类型别名";
            this.m_radioBtn_aliasType.UseVisualStyleBackColor = true;
            // 
            // m_groupBox
            // 
            this.m_groupBox.Controls.Add(this.m_radioBtn_userType);
            this.m_groupBox.Controls.Add(this.m_radioBtn_aliasType);
            this.m_groupBox.Location = new System.Drawing.Point(433, 70);
            this.m_groupBox.Name = "m_groupBox";
            this.m_groupBox.Size = new System.Drawing.Size(226, 183);
            this.m_groupBox.TabIndex = 4;
            this.m_groupBox.TabStop = false;
            this.m_groupBox.Text = "Type";
            // 
            // m_radioBtn_userType
            // 
            this.m_radioBtn_userType.AutoSize = true;
            this.m_radioBtn_userType.Location = new System.Drawing.Point(6, 111);
            this.m_radioBtn_userType.Name = "m_radioBtn_userType";
            this.m_radioBtn_userType.Size = new System.Drawing.Size(161, 28);
            this.m_radioBtn_userType.TabIndex = 4;
            this.m_radioBtn_userType.TabStop = true;
            this.m_radioBtn_userType.Text = "自定义类型";
            this.m_radioBtn_userType.UseVisualStyleBackColor = true;
            // 
            // TypeChooseWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 342);
            this.Controls.Add(this.m_groupBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_txt_typeName);
            this.Controls.Add(this.m_btn_ok);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "TypeChooseWindow";
            this.Text = "TypeChooseWindow";
            this.m_groupBox.ResumeLayout(false);
            this.m_groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button m_btn_ok;
		private System.Windows.Forms.TextBox m_txt_typeName;
		private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton m_radioBtn_aliasType;
        private System.Windows.Forms.GroupBox m_groupBox;
        private System.Windows.Forms.RadioButton m_radioBtn_userType;
	}
}