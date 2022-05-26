
namespace NJERJIM_Guide
{
    partial class Loan
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
            this.selectedIdLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.dateTimeTextBox = new System.Windows.Forms.TextBox();
            this.DateTimeLabel = new System.Windows.Forms.Label();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.amountLabel = new System.Windows.Forms.Label();
            this.addLoanButton = new System.Windows.Forms.Button();
            this.clientIdLabel = new System.Windows.Forms.Label();
            this.loanDataGridView = new System.Windows.Forms.DataGridView();
            this.totalLoanValueLabel = new System.Windows.Forms.Label();
            this.totalLoanLabel = new System.Windows.Forms.Label();
            this.clientIdComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.loanDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.Location = new System.Drawing.Point(911, 489);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 34;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // selectedIdLabel
            // 
            this.selectedIdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedIdLabel.AutoSize = true;
            this.selectedIdLabel.Location = new System.Drawing.Point(706, 12);
            this.selectedIdLabel.Name = "selectedIdLabel";
            this.selectedIdLabel.Size = new System.Drawing.Size(65, 15);
            this.selectedIdLabel.TabIndex = 33;
            this.selectedIdLabel.Text = "Selected ID";
            this.selectedIdLabel.Visible = false;
            // 
            // idLabel
            // 
            this.idLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(575, 12);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(17, 15);
            this.idLabel.TabIndex = 32;
            this.idLabel.Text = "Id";
            this.idLabel.Visible = false;
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(911, 129);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 31;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // dateTimeTextBox
            // 
            this.dateTimeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimeTextBox.Location = new System.Drawing.Point(706, 100);
            this.dateTimeTextBox.Name = "dateTimeTextBox";
            this.dateTimeTextBox.Size = new System.Drawing.Size(280, 23);
            this.dateTimeTextBox.TabIndex = 24;
            this.dateTimeTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimeTextBox_KeyDown);
            // 
            // DateTimeLabel
            // 
            this.DateTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTimeLabel.AutoSize = true;
            this.DateTimeLabel.Location = new System.Drawing.Point(575, 103);
            this.DateTimeLabel.Name = "DateTimeLabel";
            this.DateTimeLabel.Size = new System.Drawing.Size(60, 15);
            this.DateTimeLabel.TabIndex = 23;
            this.DateTimeLabel.Text = "Date Time";
            // 
            // amountTextBox
            // 
            this.amountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.amountTextBox.Location = new System.Drawing.Point(706, 71);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(280, 23);
            this.amountTextBox.TabIndex = 22;
            this.amountTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimeTextBox_KeyDown);
            // 
            // amountLabel
            // 
            this.amountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(575, 74);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(51, 15);
            this.amountLabel.TabIndex = 21;
            this.amountLabel.Text = "Amount";
            // 
            // addLoanButton
            // 
            this.addLoanButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addLoanButton.Location = new System.Drawing.Point(830, 129);
            this.addLoanButton.Name = "addLoanButton";
            this.addLoanButton.Size = new System.Drawing.Size(75, 23);
            this.addLoanButton.TabIndex = 20;
            this.addLoanButton.Text = "Add";
            this.addLoanButton.UseVisualStyleBackColor = true;
            this.addLoanButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // clientIdLabel
            // 
            this.clientIdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clientIdLabel.AutoSize = true;
            this.clientIdLabel.Location = new System.Drawing.Point(575, 45);
            this.clientIdLabel.Name = "clientIdLabel";
            this.clientIdLabel.Size = new System.Drawing.Size(52, 15);
            this.clientIdLabel.TabIndex = 18;
            this.clientIdLabel.Text = "Client ID";
            // 
            // loanDataGridView
            // 
            this.loanDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loanDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.loanDataGridView.Location = new System.Drawing.Point(12, 12);
            this.loanDataGridView.Name = "loanDataGridView";
            this.loanDataGridView.RowTemplate.Height = 25;
            this.loanDataGridView.Size = new System.Drawing.Size(544, 500);
            this.loanDataGridView.TabIndex = 17;
            this.loanDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.loanDataGridView_CellClick);
            // 
            // totalLoanValueLabel
            // 
            this.totalLoanValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalLoanValueLabel.AutoSize = true;
            this.totalLoanValueLabel.Location = new System.Drawing.Point(706, 493);
            this.totalLoanValueLabel.Name = "totalLoanValueLabel";
            this.totalLoanValueLabel.Size = new System.Drawing.Size(0, 15);
            this.totalLoanValueLabel.TabIndex = 50;
            // 
            // totalLoanLabel
            // 
            this.totalLoanLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalLoanLabel.AutoSize = true;
            this.totalLoanLabel.Location = new System.Drawing.Point(575, 493);
            this.totalLoanLabel.Name = "totalLoanLabel";
            this.totalLoanLabel.Size = new System.Drawing.Size(64, 15);
            this.totalLoanLabel.TabIndex = 49;
            this.totalLoanLabel.Text = "Total Loan:";
            // 
            // clientIdComboBox
            // 
            this.clientIdComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clientIdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientIdComboBox.FormattingEnabled = true;
            this.clientIdComboBox.Location = new System.Drawing.Point(706, 42);
            this.clientIdComboBox.Name = "clientIdComboBox";
            this.clientIdComboBox.Size = new System.Drawing.Size(280, 23);
            this.clientIdComboBox.TabIndex = 51;
            // 
            // Loan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 524);
            this.Controls.Add(this.clientIdComboBox);
            this.Controls.Add(this.totalLoanValueLabel);
            this.Controls.Add(this.totalLoanLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.selectedIdLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.dateTimeTextBox);
            this.Controls.Add(this.DateTimeLabel);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.addLoanButton);
            this.Controls.Add(this.clientIdLabel);
            this.Controls.Add(this.loanDataGridView);
            this.Name = "Loan";
            this.Text = "LoanForm";
            ((System.ComponentModel.ISupportInitialize)(this.loanDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label selectedIdLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox dateTimeTextBox;
        private System.Windows.Forms.Label DateTimeLabel;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.Button addLoanButton;
        private System.Windows.Forms.Label clientIdLabel;
        private System.Windows.Forms.DataGridView loanDataGridView;
        private System.Windows.Forms.Label totalLoanValueLabel;
        private System.Windows.Forms.Label totalLoanLabel;
        private System.Windows.Forms.ComboBox clientIdComboBox;
    }
}