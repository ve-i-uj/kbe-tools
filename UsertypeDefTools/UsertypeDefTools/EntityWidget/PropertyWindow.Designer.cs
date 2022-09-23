namespace UsertypeDefTools.EntityWidget
{
    partial class PropertyWindow
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
            this.m_cbb_type = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txt_utype = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cbb_flags = new System.Windows.Forms.ComboBox();
            this.m_cb_persistent = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txt_databaseLength = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_cbb_index = new System.Windows.Forms.ComboBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txt_name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txt_default = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(419, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type:";
            // 
            // m_cbb_type
            // 
            this.m_cbb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbb_type.FormattingEnabled = true;
            this.m_cbb_type.Location = new System.Drawing.Point(495, 31);
            this.m_cbb_type.Name = "m_cbb_type";
            this.m_cbb_type.Size = new System.Drawing.Size(213, 32);
            this.m_cbb_type.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(407, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Utype:";
            // 
            // m_txt_utype
            // 
            this.m_txt_utype.Location = new System.Drawing.Point(495, 89);
            this.m_txt_utype.Name = "m_txt_utype";
            this.m_txt_utype.Size = new System.Drawing.Size(213, 35);
            this.m_txt_utype.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Flags:";
            // 
            // m_cbb_flags
            // 
            this.m_cbb_flags.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbb_flags.FormattingEnabled = true;
            this.m_cbb_flags.Location = new System.Drawing.Point(123, 162);
            this.m_cbb_flags.Name = "m_cbb_flags";
            this.m_cbb_flags.Size = new System.Drawing.Size(213, 32);
            this.m_cbb_flags.TabIndex = 5;
            // 
            // m_cb_persistent
            // 
            this.m_cb_persistent.AutoSize = true;
            this.m_cb_persistent.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cb_persistent.Location = new System.Drawing.Point(492, 164);
            this.m_cb_persistent.Name = "m_cb_persistent";
            this.m_cb_persistent.Size = new System.Drawing.Size(174, 28);
            this.m_cb_persistent.TabIndex = 7;
            this.m_cb_persistent.Text = "Persistent:";
            this.m_cb_persistent.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "DatabaseLength:";
            // 
            // m_txt_databaseLength
            // 
            this.m_txt_databaseLength.Location = new System.Drawing.Point(209, 247);
            this.m_txt_databaseLength.Name = "m_txt_databaseLength";
            this.m_txt_databaseLength.Size = new System.Drawing.Size(127, 35);
            this.m_txt_databaseLength.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(451, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "Index:";
            // 
            // m_cbb_index
            // 
            this.m_cbb_index.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbb_index.FormattingEnabled = true;
            this.m_cbb_index.Location = new System.Drawing.Point(539, 250);
            this.m_cbb_index.Name = "m_cbb_index";
            this.m_cbb_index.Size = new System.Drawing.Size(169, 32);
            this.m_cbb_index.TabIndex = 11;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(139, 321);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(93, 38);
            this.btn_OK.TabIndex = 12;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(440, 321);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(93, 38);
            this.btn_cancel.TabIndex = 13;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 24);
            this.label6.TabIndex = 14;
            this.label6.Text = "Name:";
            // 
            // m_txt_name
            // 
            this.m_txt_name.Location = new System.Drawing.Point(123, 31);
            this.m_txt_name.Name = "m_txt_name";
            this.m_txt_name.Size = new System.Drawing.Size(213, 35);
            this.m_txt_name.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 24);
            this.label7.TabIndex = 16;
            this.label7.Text = "Default:";
            // 
            // m_txt_default
            // 
            this.m_txt_default.Location = new System.Drawing.Point(123, 89);
            this.m_txt_default.Name = "m_txt_default";
            this.m_txt_default.Size = new System.Drawing.Size(213, 35);
            this.m_txt_default.TabIndex = 17;
            // 
            // PropertyWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 405);
            this.Controls.Add(this.m_txt_default);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_txt_name);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.m_cbb_index);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_txt_databaseLength);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_cb_persistent);
            this.Controls.Add(this.m_cbb_flags);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_txt_utype);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_cbb_type);
            this.Controls.Add(this.label1);
            this.Name = "PropertyWindow";
            this.Text = "PropertyWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox m_cbb_type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_txt_utype;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox m_cbb_flags;
        private System.Windows.Forms.CheckBox m_cb_persistent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox m_txt_databaseLength;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox m_cbb_index;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox m_txt_name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox m_txt_default;
    }
}