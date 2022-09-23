namespace UsertypeDefTools.EntityWidget
{
	partial class MethodWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.m_txt_name = new System.Windows.Forms.TextBox();
            this.m_cb_exposed = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txt_utype = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_lb_args = new System.Windows.Forms.ListBox();
            this.m_lb_alltypes = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_btn_add = new System.Windows.Forms.Button();
            this.m_txt_delete = new System.Windows.Forms.Button();
            this.m_btn_OK = new System.Windows.Forms.Button();
            this.m_btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // m_txt_name
            // 
            this.m_txt_name.Location = new System.Drawing.Point(106, 24);
            this.m_txt_name.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.m_txt_name.Name = "m_txt_name";
            this.m_txt_name.Size = new System.Drawing.Size(196, 35);
            this.m_txt_name.TabIndex = 1;
            // 
            // m_cb_exposed
            // 
            this.m_cb_exposed.AutoSize = true;
            this.m_cb_exposed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cb_exposed.Location = new System.Drawing.Point(408, 28);
            this.m_cb_exposed.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.m_cb_exposed.Name = "m_cb_exposed";
            this.m_cb_exposed.Size = new System.Drawing.Size(126, 28);
            this.m_cb_exposed.TabIndex = 2;
            this.m_cb_exposed.Text = "Exposed";
            this.m_cb_exposed.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Utype:";
            // 
            // m_txt_utype
            // 
            this.m_txt_utype.Location = new System.Drawing.Point(106, 78);
            this.m_txt_utype.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.m_txt_utype.Name = "m_txt_utype";
            this.m_txt_utype.Size = new System.Drawing.Size(196, 35);
            this.m_txt_utype.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 138);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Args:";
            // 
            // m_lb_args
            // 
            this.m_lb_args.FormattingEnabled = true;
            this.m_lb_args.ItemHeight = 24;
            this.m_lb_args.Location = new System.Drawing.Point(28, 168);
            this.m_lb_args.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.m_lb_args.Name = "m_lb_args";
            this.m_lb_args.Size = new System.Drawing.Size(274, 292);
            this.m_lb_args.TabIndex = 6;
            // 
            // m_lb_alltypes
            // 
            this.m_lb_alltypes.FormattingEnabled = true;
            this.m_lb_alltypes.ItemHeight = 24;
            this.m_lb_alltypes.Location = new System.Drawing.Point(408, 168);
            this.m_lb_alltypes.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.m_lb_alltypes.Name = "m_lb_alltypes";
            this.m_lb_alltypes.Size = new System.Drawing.Size(294, 292);
            this.m_lb_alltypes.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(404, 138);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "AllTypes:";
            // 
            // m_btn_add
            // 
            this.m_btn_add.Location = new System.Drawing.Point(320, 204);
            this.m_btn_add.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.m_btn_add.Name = "m_btn_add";
            this.m_btn_add.Size = new System.Drawing.Size(76, 46);
            this.m_btn_add.TabIndex = 9;
            this.m_btn_add.Text = "<<";
            this.m_btn_add.UseVisualStyleBackColor = true;
            this.m_btn_add.Click += new System.EventHandler(this.m_btn_add_Click);
            // 
            // m_txt_delete
            // 
            this.m_txt_delete.Location = new System.Drawing.Point(320, 368);
            this.m_txt_delete.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.m_txt_delete.Name = "m_txt_delete";
            this.m_txt_delete.Size = new System.Drawing.Size(76, 46);
            this.m_txt_delete.TabIndex = 10;
            this.m_txt_delete.Text = "X";
            this.m_txt_delete.UseVisualStyleBackColor = true;
            this.m_txt_delete.Click += new System.EventHandler(this.m_txt_delete_Click);
            // 
            // m_btn_OK
            // 
            this.m_btn_OK.Location = new System.Drawing.Point(106, 510);
            this.m_btn_OK.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.m_btn_OK.Name = "m_btn_OK";
            this.m_btn_OK.Size = new System.Drawing.Size(150, 46);
            this.m_btn_OK.TabIndex = 11;
            this.m_btn_OK.Text = "OK";
            this.m_btn_OK.UseVisualStyleBackColor = true;
            this.m_btn_OK.Click += new System.EventHandler(this.m_btn_OK_Click);
            // 
            // m_btn_cancel
            // 
            this.m_btn_cancel.Location = new System.Drawing.Point(474, 510);
            this.m_btn_cancel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.m_btn_cancel.Name = "m_btn_cancel";
            this.m_btn_cancel.Size = new System.Drawing.Size(150, 46);
            this.m_btn_cancel.TabIndex = 12;
            this.m_btn_cancel.Text = "Cancel";
            this.m_btn_cancel.UseVisualStyleBackColor = true;
            this.m_btn_cancel.Click += new System.EventHandler(this.m_btn_cancel_Click);
            // 
            // MethodWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 600);
            this.Controls.Add(this.m_btn_cancel);
            this.Controls.Add(this.m_btn_OK);
            this.Controls.Add(this.m_txt_delete);
            this.Controls.Add(this.m_btn_add);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_lb_alltypes);
            this.Controls.Add(this.m_lb_args);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_txt_utype);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_cb_exposed);
            this.Controls.Add(this.m_txt_name);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "MethodWindow";
            this.Text = "MethodWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox m_txt_name;
		private System.Windows.Forms.CheckBox m_cb_exposed;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox m_txt_utype;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox m_lb_args;
		private System.Windows.Forms.ListBox m_lb_alltypes;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button m_btn_add;
		private System.Windows.Forms.Button m_txt_delete;
		private System.Windows.Forms.Button m_btn_OK;
		private System.Windows.Forms.Button m_btn_cancel;
	}
}