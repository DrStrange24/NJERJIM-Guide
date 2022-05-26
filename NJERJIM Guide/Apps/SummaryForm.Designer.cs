
namespace NJERJIM_Guide
{
    partial class SummaryForm
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
            this.backButton = new System.Windows.Forms.Button();
            this.availableMoneyLabel = new System.Windows.Forms.Label();
            this.availableMoneyValueLabel = new System.Windows.Forms.Label();
            this.moneyLabel = new System.Windows.Forms.Label();
            this.moneyValueLabel = new System.Windows.Forms.Label();
            this.profitValueLabel = new System.Windows.Forms.Label();
            this.profitLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.Location = new System.Drawing.Point(284, 173);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 47;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // availableMoneyLabel
            // 
            this.availableMoneyLabel.AutoSize = true;
            this.availableMoneyLabel.Location = new System.Drawing.Point(12, 9);
            this.availableMoneyLabel.Name = "availableMoneyLabel";
            this.availableMoneyLabel.Size = new System.Drawing.Size(98, 15);
            this.availableMoneyLabel.TabIndex = 48;
            this.availableMoneyLabel.Text = "Available Money:";
            // 
            // availableMoneyValueLabel
            // 
            this.availableMoneyValueLabel.AutoSize = true;
            this.availableMoneyValueLabel.Location = new System.Drawing.Point(116, 9);
            this.availableMoneyValueLabel.Name = "availableMoneyValueLabel";
            this.availableMoneyValueLabel.Size = new System.Drawing.Size(0, 15);
            this.availableMoneyValueLabel.TabIndex = 49;
            // 
            // moneyLabel
            // 
            this.moneyLabel.AutoSize = true;
            this.moneyLabel.Location = new System.Drawing.Point(63, 43);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(47, 15);
            this.moneyLabel.TabIndex = 50;
            this.moneyLabel.Text = "Money:";
            // 
            // moneyValueLabel
            // 
            this.moneyValueLabel.AutoSize = true;
            this.moneyValueLabel.Location = new System.Drawing.Point(116, 43);
            this.moneyValueLabel.Name = "moneyValueLabel";
            this.moneyValueLabel.Size = new System.Drawing.Size(0, 15);
            this.moneyValueLabel.TabIndex = 51;
            // 
            // profitValueLabel
            // 
            this.profitValueLabel.AutoSize = true;
            this.profitValueLabel.Location = new System.Drawing.Point(116, 80);
            this.profitValueLabel.Name = "profitValueLabel";
            this.profitValueLabel.Size = new System.Drawing.Size(0, 15);
            this.profitValueLabel.TabIndex = 53;
            // 
            // profitLabel
            // 
            this.profitLabel.AutoSize = true;
            this.profitLabel.Location = new System.Drawing.Point(71, 80);
            this.profitLabel.Name = "profitLabel";
            this.profitLabel.Size = new System.Drawing.Size(39, 15);
            this.profitLabel.TabIndex = 52;
            this.profitLabel.Text = "Profit:";
            // 
            // SummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 208);
            this.Controls.Add(this.profitValueLabel);
            this.Controls.Add(this.profitLabel);
            this.Controls.Add(this.moneyValueLabel);
            this.Controls.Add(this.moneyLabel);
            this.Controls.Add(this.availableMoneyValueLabel);
            this.Controls.Add(this.availableMoneyLabel);
            this.Controls.Add(this.backButton);
            this.Name = "SummaryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SummaryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label availableMoneyLabel;
        private System.Windows.Forms.Label availableMoneyValueLabel;
        private System.Windows.Forms.Label moneyLabel;
        private System.Windows.Forms.Label moneyValueLabel;
        private System.Windows.Forms.Label profitValueLabel;
        private System.Windows.Forms.Label profitLabel;
    }
}