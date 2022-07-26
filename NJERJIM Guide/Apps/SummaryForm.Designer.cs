
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
            this.cashOnHandValueLabel = new System.Windows.Forms.Label();
            this.moneyLabel = new System.Windows.Forms.Label();
            this.totalSupplyValueLabel = new System.Windows.Forms.Label();
            this.profitValueLabel = new System.Windows.Forms.Label();
            this.profitLabel = new System.Windows.Forms.Label();
            this.cashOnHandWithProfitValueLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.Location = new System.Drawing.Point(385, 173);
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
            this.availableMoneyLabel.Size = new System.Drawing.Size(85, 15);
            this.availableMoneyLabel.TabIndex = 48;
            this.availableMoneyLabel.Text = "Cash on Hand:";
            // 
            // cashOnHandValueLabel
            // 
            this.cashOnHandValueLabel.AutoSize = true;
            this.cashOnHandValueLabel.Location = new System.Drawing.Point(116, 9);
            this.cashOnHandValueLabel.Name = "cashOnHandValueLabel";
            this.cashOnHandValueLabel.Size = new System.Drawing.Size(0, 15);
            this.cashOnHandValueLabel.TabIndex = 49;
            // 
            // moneyLabel
            // 
            this.moneyLabel.AutoSize = true;
            this.moneyLabel.Location = new System.Drawing.Point(23, 43);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(74, 15);
            this.moneyLabel.TabIndex = 50;
            this.moneyLabel.Text = "Total Supply:";
            // 
            // totalSupplyValueLabel
            // 
            this.totalSupplyValueLabel.AutoSize = true;
            this.totalSupplyValueLabel.Location = new System.Drawing.Point(116, 43);
            this.totalSupplyValueLabel.Name = "totalSupplyValueLabel";
            this.totalSupplyValueLabel.Size = new System.Drawing.Size(0, 15);
            this.totalSupplyValueLabel.TabIndex = 51;
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
            this.profitLabel.Location = new System.Drawing.Point(47, 80);
            this.profitLabel.Name = "profitLabel";
            this.profitLabel.Size = new System.Drawing.Size(50, 15);
            this.profitLabel.TabIndex = 52;
            this.profitLabel.Text = "Income:";
            // 
            // cashOnHandWithProfitValueLabel
            // 
            this.cashOnHandWithProfitValueLabel.AutoSize = true;
            this.cashOnHandWithProfitValueLabel.Location = new System.Drawing.Point(394, 9);
            this.cashOnHandWithProfitValueLabel.Name = "cashOnHandWithProfitValueLabel";
            this.cashOnHandWithProfitValueLabel.Size = new System.Drawing.Size(0, 15);
            this.cashOnHandWithProfitValueLabel.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 15);
            this.label2.TabIndex = 54;
            this.label2.Text = "Cash On Hand with Profit:";
            // 
            // SummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 208);
            this.Controls.Add(this.cashOnHandWithProfitValueLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.profitValueLabel);
            this.Controls.Add(this.profitLabel);
            this.Controls.Add(this.totalSupplyValueLabel);
            this.Controls.Add(this.moneyLabel);
            this.Controls.Add(this.cashOnHandValueLabel);
            this.Controls.Add(this.availableMoneyLabel);
            this.Controls.Add(this.backButton);
            this.Name = "SummaryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Summary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label availableMoneyLabel;
        private System.Windows.Forms.Label cashOnHandValueLabel;
        private System.Windows.Forms.Label moneyLabel;
        private System.Windows.Forms.Label totalSupplyValueLabel;
        private System.Windows.Forms.Label profitValueLabel;
        private System.Windows.Forms.Label profitLabel;
        private System.Windows.Forms.Label cashOnHandWithProfitValueLabel;
        private System.Windows.Forms.Label label2;
    }
}