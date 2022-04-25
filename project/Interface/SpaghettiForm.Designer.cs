namespace Message_Relay_GUI
{
    partial class SpaghettiForm
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
            this.portLabel = new System.Windows.Forms.Label();
            this.portNumberBox = new System.Windows.Forms.MaskedTextBox();
            this.connectionButton = new System.Windows.Forms.Button();
            this.messageBox = new System.Windows.Forms.RichTextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.connectionDisplayBox = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ipLabel = new System.Windows.Forms.Label();
            this.addressBox = new System.Windows.Forms.TextBox();
            this.sendDataBox = new Message_Relay_GUI.EnterTextBox();
            this.clientRadio = new System.Windows.Forms.RadioButton();
            this.serverRadio = new System.Windows.Forms.RadioButton();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(172, 74);
            this.portLabel.Margin = new System.Windows.Forms.Padding(0);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(26, 13);
            this.portLabel.TabIndex = 0;
            this.portLabel.Text = "Port";
            this.portLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // portNumberBox
            // 
            this.portNumberBox.HidePromptOnLeave = true;
            this.portNumberBox.Location = new System.Drawing.Point(201, 71);
            this.portNumberBox.Mask = "09999";
            this.portNumberBox.Name = "portNumberBox";
            this.portNumberBox.Size = new System.Drawing.Size(42, 20);
            this.portNumberBox.TabIndex = 1;
            this.portNumberBox.Text = "31337";
            this.portNumberBox.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.PortNumberBox_MaskInputRejected);
            this.portNumberBox.Leave += new System.EventHandler(this.PortNumberBox_Leave);
            // 
            // connectionButton
            // 
            this.connectionButton.Location = new System.Drawing.Point(249, 106);
            this.connectionButton.Name = "connectionButton";
            this.connectionButton.Size = new System.Drawing.Size(63, 20);
            this.connectionButton.TabIndex = 3;
            this.connectionButton.Text = "Listen";
            this.connectionButton.UseVisualStyleBackColor = true;
            this.connectionButton.Click += new System.EventHandler(this.ConnectionButton_Click);
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(21, 144);
            this.messageBox.Name = "messageBox";
            this.messageBox.ReadOnly = true;
            this.messageBox.Size = new System.Drawing.Size(291, 210);
            this.messageBox.TabIndex = 7;
            this.messageBox.Text = "[Spaghetti Relay Program]";
            // 
            // sendButton
            // 
            this.sendButton.Enabled = false;
            this.sendButton.Location = new System.Drawing.Point(249, 71);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(63, 20);
            this.sendButton.TabIndex = 6;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // connectionDisplayBox
            // 
            this.connectionDisplayBox.BackColor = System.Drawing.SystemColors.Window;
            this.connectionDisplayBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.connectionDisplayBox.Enabled = false;
            this.connectionDisplayBox.Location = new System.Drawing.Point(218, 37);
            this.connectionDisplayBox.Name = "connectionDisplayBox";
            this.connectionDisplayBox.ReadOnly = true;
            this.connectionDisplayBox.Size = new System.Drawing.Size(94, 20);
            this.connectionDisplayBox.TabIndex = 2;
            this.connectionDisplayBox.TabStop = false;
            this.connectionDisplayBox.Text = "Not Listening";
            this.connectionDisplayBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(332, 24);
            this.menuStrip.TabIndex = 10;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(18, 74);
            this.ipLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(45, 13);
            this.ipLabel.TabIndex = 12;
            this.ipLabel.Text = "Address";
            // 
            // addressBox
            // 
            this.addressBox.Enabled = false;
            this.addressBox.Location = new System.Drawing.Point(76, 71);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(93, 20);
            this.addressBox.TabIndex = 0;
            this.addressBox.Text = "127.0.0.1";
            // 
            // sendDataBox
            // 
            this.sendDataBox.Location = new System.Drawing.Point(21, 106);
            this.sendDataBox.MaxLength = 255;
            this.sendDataBox.Name = "sendDataBox";
            this.sendDataBox.Size = new System.Drawing.Size(222, 20);
            this.sendDataBox.TabIndex = 13;
            this.sendDataBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SendDataBox_KeyDown);
            // 
            // clientRadio
            // 
            this.clientRadio.AutoSize = true;
            this.clientRadio.Location = new System.Drawing.Point(122, 37);
            this.clientRadio.Name = "clientRadio";
            this.clientRadio.Size = new System.Drawing.Size(81, 17);
            this.clientRadio.TabIndex = 14;
            this.clientRadio.TabStop = true;
            this.clientRadio.Text = "Client Mode";
            this.clientRadio.UseVisualStyleBackColor = true;
            // 
            // serverRadio
            // 
            this.serverRadio.AutoSize = true;
            this.serverRadio.Checked = true;
            this.serverRadio.Location = new System.Drawing.Point(21, 37);
            this.serverRadio.Name = "serverRadio";
            this.serverRadio.Size = new System.Drawing.Size(86, 17);
            this.serverRadio.TabIndex = 15;
            this.serverRadio.TabStop = true;
            this.serverRadio.Text = "Server Mode";
            this.serverRadio.UseVisualStyleBackColor = true;
            this.serverRadio.CheckedChanged += new System.EventHandler(this.RadioChanged);
            // 
            // SpaghettiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 366);
            this.Controls.Add(this.serverRadio);
            this.Controls.Add(this.clientRadio);
            this.Controls.Add(this.sendDataBox);
            this.Controls.Add(this.addressBox);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.connectionDisplayBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.connectionButton);
            this.Controls.Add(this.portNumberBox);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "SpaghettiForm";
            this.Text = "Spaghetti Relay";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MessageForm_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.MaskedTextBox portNumberBox;
        private System.Windows.Forms.Button connectionButton;
        private System.Windows.Forms.RichTextBox messageBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox connectionDisplayBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.TextBox addressBox;
        private System.Windows.Forms.RadioButton clientRadio;
        private System.Windows.Forms.RadioButton serverRadio;
        private EnterTextBox sendDataBox;
    }
}

