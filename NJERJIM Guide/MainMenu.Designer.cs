
namespace NJERJIM_Guide
{
    partial class MainMenu
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
            this.clientButton = new System.Windows.Forms.Button();
            this.loanButton = new System.Windows.Forms.Button();
            this.collectionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clientButton
            // 
            this.clientButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientButton.Location = new System.Drawing.Point(146, 74);
            this.clientButton.Name = "clientButton";
            this.clientButton.Size = new System.Drawing.Size(109, 23);
            this.clientButton.TabIndex = 0;
            this.clientButton.Text = "Client";
            this.clientButton.UseVisualStyleBackColor = true;
            this.clientButton.Click += new System.EventHandler(this.clientButton_Click);
            // 
            // loanButton
            // 
            this.loanButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loanButton.Location = new System.Drawing.Point(146, 103);
            this.loanButton.Name = "loanButton";
            this.loanButton.Size = new System.Drawing.Size(109, 23);
            this.loanButton.TabIndex = 1;
            this.loanButton.Text = "Loan";
            this.loanButton.UseVisualStyleBackColor = true;
            this.loanButton.Click += new System.EventHandler(this.loanButton_Click);
            // 
            // collectionButton
            // 
            this.collectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.collectionButton.Location = new System.Drawing.Point(146, 132);
            this.collectionButton.Name = "collectionButton";
            this.collectionButton.Size = new System.Drawing.Size(109, 23);
            this.collectionButton.TabIndex = 2;
            this.collectionButton.Text = "Collection";
            this.collectionButton.UseVisualStyleBackColor = true;
            this.collectionButton.Click += new System.EventHandler(this.collectionButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 271);
            this.Controls.Add(this.collectionButton);
            this.Controls.Add(this.loanButton);
            this.Controls.Add(this.clientButton);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button clientButton;
        private System.Windows.Forms.Button loanButton;
        private System.Windows.Forms.Button collectionButton;
    }
}