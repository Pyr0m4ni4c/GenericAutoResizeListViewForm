namespace GenericAutoResizeListViewForm
{
    sealed partial class DefaultListViewForm<T>
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
            this.m_Panel = new System.Windows.Forms.Panel();
            this.m_Panel_ListView = new System.Windows.Forms.Panel();
            this.m_Panel_Head = new System.Windows.Forms.Panel();
            this.m_Panel_Header = new System.Windows.Forms.Panel();
            this.m_Label_Guthaben_Wert = new System.Windows.Forms.Label();
            this.m_Label_Guthaben = new System.Windows.Forms.Label();
            this.m_Panel_TestButtons = new System.Windows.Forms.Panel();
            this.m_Button_Add = new System.Windows.Forms.Button();
            this.m_Button_Remove = new System.Windows.Forms.Button();
            this.m_Panel_Buttons = new System.Windows.Forms.Panel();
            this.m_Button_Beenden = new System.Windows.Forms.Button();
            this.m_Panel.SuspendLayout();
            this.m_Panel_Head.SuspendLayout();
            this.m_Panel_Header.SuspendLayout();
            this.m_Panel_TestButtons.SuspendLayout();
            this.m_Panel_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_Panel
            // 
            this.m_Panel.AutoSize = true;
            this.m_Panel.BackColor = System.Drawing.SystemColors.Control;
            this.m_Panel.Controls.Add(this.m_Panel_ListView);
            this.m_Panel.Controls.Add(this.m_Panel_Head);
            this.m_Panel.Controls.Add(this.m_Panel_TestButtons);
            this.m_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_Panel.Location = new System.Drawing.Point(12, 12);
            this.m_Panel.Margin = new System.Windows.Forms.Padding(0);
            this.m_Panel.Name = "m_Panel";
            this.m_Panel.Size = new System.Drawing.Size(280, 86);
            this.m_Panel.TabIndex = 0;
            // 
            // m_Panel_ListView
            // 
            this.m_Panel_ListView.AutoSize = true;
            this.m_Panel_ListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_Panel_ListView.Location = new System.Drawing.Point(0, 74);
            this.m_Panel_ListView.Name = "m_Panel_ListView";
            this.m_Panel_ListView.Size = new System.Drawing.Size(280, 12);
            this.m_Panel_ListView.TabIndex = 15;
            // 
            // m_Panel_Head
            // 
            this.m_Panel_Head.AutoSize = true;
            this.m_Panel_Head.Controls.Add(this.m_Panel_Buttons);
            this.m_Panel_Head.Controls.Add(this.m_Panel_Header);
            this.m_Panel_Head.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_Panel_Head.Location = new System.Drawing.Point(0, 34);
            this.m_Panel_Head.MinimumSize = new System.Drawing.Size(280, 40);
            this.m_Panel_Head.Name = "m_Panel_Head";
            this.m_Panel_Head.Padding = new System.Windows.Forms.Padding(3);
            this.m_Panel_Head.Size = new System.Drawing.Size(280, 40);
            this.m_Panel_Head.TabIndex = 14;
            // 
            // m_Panel_Header
            // 
            this.m_Panel_Header.AutoSize = true;
            this.m_Panel_Header.Controls.Add(this.m_Label_Guthaben_Wert);
            this.m_Panel_Header.Controls.Add(this.m_Label_Guthaben);
            this.m_Panel_Header.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_Panel_Header.Location = new System.Drawing.Point(3, 3);
            this.m_Panel_Header.Name = "m_Panel_Header";
            this.m_Panel_Header.Padding = new System.Windows.Forms.Padding(3);
            this.m_Panel_Header.Size = new System.Drawing.Size(224, 34);
            this.m_Panel_Header.TabIndex = 15;
            // 
            // m_Label_Guthaben_Wert
            // 
            this.m_Label_Guthaben_Wert.AutoSize = true;
            this.m_Label_Guthaben_Wert.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_Label_Guthaben_Wert.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.m_Label_Guthaben_Wert.Location = new System.Drawing.Point(140, 3);
            this.m_Label_Guthaben_Wert.Name = "m_Label_Guthaben_Wert";
            this.m_Label_Guthaben_Wert.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.m_Label_Guthaben_Wert.Size = new System.Drawing.Size(81, 28);
            this.m_Label_Guthaben_Wert.TabIndex = 12;
            this.m_Label_Guthaben_Wert.Text = "<Wert>";
            // 
            // m_Label_Guthaben
            // 
            this.m_Label_Guthaben.AutoSize = true;
            this.m_Label_Guthaben.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_Label_Guthaben.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_Label_Guthaben.Location = new System.Drawing.Point(3, 3);
            this.m_Label_Guthaben.Name = "m_Label_Guthaben";
            this.m_Label_Guthaben.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.m_Label_Guthaben.Size = new System.Drawing.Size(137, 28);
            this.m_Label_Guthaben.TabIndex = 11;
            this.m_Label_Guthaben.Text = "<LabelText>:";
            // 
            // m_Panel_TestButtons
            // 
            this.m_Panel_TestButtons.Controls.Add(this.m_Button_Add);
            this.m_Panel_TestButtons.Controls.Add(this.m_Button_Remove);
            this.m_Panel_TestButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_Panel_TestButtons.Location = new System.Drawing.Point(0, 0);
            this.m_Panel_TestButtons.Name = "m_Panel_TestButtons";
            this.m_Panel_TestButtons.Padding = new System.Windows.Forms.Padding(3);
            this.m_Panel_TestButtons.Size = new System.Drawing.Size(280, 34);
            this.m_Panel_TestButtons.TabIndex = 16;
            // 
            // m_Button_Add
            // 
            this.m_Button_Add.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_Button_Add.Location = new System.Drawing.Point(3, 3);
            this.m_Button_Add.Name = "m_Button_Add";
            this.m_Button_Add.Size = new System.Drawing.Size(132, 28);
            this.m_Button_Add.TabIndex = 16;
            this.m_Button_Add.Text = "m_Button_Add";
            this.m_Button_Add.UseVisualStyleBackColor = true;
            // 
            // m_Button_Remove
            // 
            this.m_Button_Remove.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_Button_Remove.Location = new System.Drawing.Point(141, 3);
            this.m_Button_Remove.Name = "m_Button_Remove";
            this.m_Button_Remove.Size = new System.Drawing.Size(136, 28);
            this.m_Button_Remove.TabIndex = 1;
            this.m_Button_Remove.Text = "m_Button_Remove";
            this.m_Button_Remove.UseVisualStyleBackColor = true;
            // 
            // m_Panel_Buttons
            // 
            this.m_Panel_Buttons.AutoSize = true;
            this.m_Panel_Buttons.Controls.Add(this.m_Button_Beenden);
            this.m_Panel_Buttons.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_Panel_Buttons.Location = new System.Drawing.Point(229, 3);
            this.m_Panel_Buttons.Name = "m_Panel_Buttons";
            this.m_Panel_Buttons.Padding = new System.Windows.Forms.Padding(3);
            this.m_Panel_Buttons.Size = new System.Drawing.Size(48, 34);
            this.m_Panel_Buttons.TabIndex = 16;
            // 
            // m_Button_Beenden
            // 
            this.m_Button_Beenden.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_Button_Beenden.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_Button_Beenden.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_Button_Beenden.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_Button_Beenden.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.m_Button_Beenden.Location = new System.Drawing.Point(3, 3);
            this.m_Button_Beenden.Name = "m_Button_Beenden";
            this.m_Button_Beenden.Size = new System.Drawing.Size(42, 28);
            this.m_Button_Beenden.TabIndex = 9;
            this.m_Button_Beenden.Text = "X";
            this.m_Button_Beenden.UseVisualStyleBackColor = true;
            // 
            // DefaultListViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(304, 110);
            this.Controls.Add(this.m_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(304, 110);
            this.Name = "DefaultListViewForm";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PosBelegeForm";
            this.m_Panel.ResumeLayout(false);
            this.m_Panel.PerformLayout();
            this.m_Panel_Head.ResumeLayout(false);
            this.m_Panel_Head.PerformLayout();
            this.m_Panel_Header.ResumeLayout(false);
            this.m_Panel_Header.PerformLayout();
            this.m_Panel_TestButtons.ResumeLayout(false);
            this.m_Panel_Buttons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel m_Panel;
        private System.Windows.Forms.Label m_Label_Guthaben;
        private System.Windows.Forms.Panel m_Panel_Head;
        private System.Windows.Forms.Label m_Label_Guthaben_Wert;
        private System.Windows.Forms.Panel m_Panel_ListView;
        private System.Windows.Forms.Panel m_Panel_Header;
        private System.Windows.Forms.Button m_Button_Remove;
        private System.Windows.Forms.Panel m_Panel_TestButtons;
        private System.Windows.Forms.Button m_Button_Add;
        private System.Windows.Forms.Panel m_Panel_Buttons;
        private System.Windows.Forms.Button m_Button_Beenden;
    }
}