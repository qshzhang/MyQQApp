namespace MyQQApp.Forms
{
    partial class DialogFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogFrm));
            this.richBoxShowRecord = new System.Windows.Forms.RichTextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.panelEditPart = new System.Windows.Forms.Panel();
            this.panelFoldFunction = new System.Windows.Forms.Panel();
            this.panelShowFace = new System.Windows.Forms.Panel();
            this.rTxtInput = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.ucBackPanel = new MyQQApp.FormControl.ucBackPanel();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.btnCaptureScreen = new System.Windows.Forms.Button();
            this.panelEditPart.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // richBoxShowRecord
            // 
            this.richBoxShowRecord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richBoxShowRecord.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richBoxShowRecord.Location = new System.Drawing.Point(27, 89);
            this.richBoxShowRecord.Name = "richBoxShowRecord";
            this.richBoxShowRecord.Size = new System.Drawing.Size(952, 353);
            this.richBoxShowRecord.TabIndex = 1;
            this.richBoxShowRecord.Text = "";
            // 
            // lbTitle
            // 
            this.lbTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.Location = new System.Drawing.Point(-3, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(192, 30);
            this.lbTitle.TabIndex = 4;
            this.lbTitle.Text = "label1";
            // 
            // panelEditPart
            // 
            this.panelEditPart.BackColor = System.Drawing.Color.Gray;
            this.panelEditPart.Controls.Add(this.panelFoldFunction);
            this.panelEditPart.Controls.Add(this.panelShowFace);
            this.panelEditPart.Controls.Add(this.rTxtInput);
            this.panelEditPart.Location = new System.Drawing.Point(27, 459);
            this.panelEditPart.Name = "panelEditPart";
            this.panelEditPart.Size = new System.Drawing.Size(862, 88);
            this.panelEditPart.TabIndex = 5;
            // 
            // panelFoldFunction
            // 
            this.panelFoldFunction.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelFoldFunction.BackgroundImage")));
            this.panelFoldFunction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelFoldFunction.Location = new System.Drawing.Point(3, 20);
            this.panelFoldFunction.Name = "panelFoldFunction";
            this.panelFoldFunction.Size = new System.Drawing.Size(50, 50);
            this.panelFoldFunction.TabIndex = 2;
            this.panelFoldFunction.Click += new System.EventHandler(this.panelFoldFunction_Click);
            // 
            // panelShowFace
            // 
            this.panelShowFace.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelShowFace.BackgroundImage")));
            this.panelShowFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelShowFace.Location = new System.Drawing.Point(799, 20);
            this.panelShowFace.Name = "panelShowFace";
            this.panelShowFace.Size = new System.Drawing.Size(50, 50);
            this.panelShowFace.TabIndex = 1;
            this.panelShowFace.Click += new System.EventHandler(this.panelShowFace_Click);
            // 
            // rTxtInput
            // 
            this.rTxtInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rTxtInput.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rTxtInput.Location = new System.Drawing.Point(54, 20);
            this.rTxtInput.Name = "rTxtInput";
            this.rTxtInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rTxtInput.Size = new System.Drawing.Size(739, 50);
            this.rTxtInput.TabIndex = 0;
            this.rTxtInput.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Blue;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSend.Location = new System.Drawing.Point(895, 459);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(84, 88);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // ucBackPanel
            // 
            this.ucBackPanel.BackColor = System.Drawing.Color.Transparent;
            this.ucBackPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBackPanel.IsShowMinBtn = true;
            this.ucBackPanel.Location = new System.Drawing.Point(0, 0);
            this.ucBackPanel.Name = "ucBackPanel";
            this.ucBackPanel.Size = new System.Drawing.Size(1015, 572);
            this.ucBackPanel.TabIndex = 0;
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.btnCaptureScreen);
            this.panelContainer.Controls.Add(this.btnSendFile);
            this.panelContainer.Location = new System.Drawing.Point(30, 282);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(285, 171);
            this.panelContainer.TabIndex = 7;
            // 
            // btnSendFile
            // 
            this.btnSendFile.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSendFile.Location = new System.Drawing.Point(13, 14);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(96, 56);
            this.btnSendFile.TabIndex = 0;
            this.btnSendFile.Text = "SendFile";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnCaptureScreen
            // 
            this.btnCaptureScreen.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCaptureScreen.Location = new System.Drawing.Point(124, 14);
            this.btnCaptureScreen.Name = "btnCaptureScreen";
            this.btnCaptureScreen.Size = new System.Drawing.Size(96, 56);
            this.btnCaptureScreen.TabIndex = 1;
            this.btnCaptureScreen.Text = "Capture";
            this.btnCaptureScreen.UseVisualStyleBackColor = true;
            this.btnCaptureScreen.Click += new System.EventHandler(this.btnCaptureScreen_Click);
            // 
            // DialogFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 572);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.panelEditPart);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.richBoxShowRecord);
            this.Controls.Add(this.ucBackPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DialogFrm";
            this.Text = "DialogFrm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DialogFrm_FormClosed);
            this.Load += new System.EventHandler(this.DialogFrm_Load);
            this.panelEditPart.ResumeLayout(false);
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FormControl.ucBackPanel ucBackPanel;
        private System.Windows.Forms.RichTextBox richBoxShowRecord;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel panelEditPart;
        private System.Windows.Forms.Panel panelFoldFunction;
        private System.Windows.Forms.Panel panelShowFace;
        private System.Windows.Forms.RichTextBox rTxtInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Button btnCaptureScreen;
    }
}