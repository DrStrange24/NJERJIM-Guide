
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
            this.DateTimeLabel = new System.Windows.Forms.Label();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.amountLabel = new System.Windows.Forms.Label();
            this.createLoanButton = new System.Windows.Forms.Button();
            this.clientLabel = new System.Windows.Forms.Label();
            this.loanDataGridView = new System.Windows.Forms.DataGridView();
            this.totalLoanValueLabel = new System.Windows.Forms.Label();
            this.totalLoanLabel = new System.Windows.Forms.Label();
            this.clientComboBox = new System.Windows.Forms.ComboBox();
            this.loanDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.clearInputsButton = new System.Windows.Forms.Button();
            this.remarksRichTextBox = new System.Windows.Forms.RichTextBox();
            this.remarksLabel = new System.Windows.Forms.Label();
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
            this.deleteButton.Location = new System.Drawing.Point(911, 237);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 31;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
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
            // createLoanButton
            // 
            this.createLoanButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createLoanButton.Location = new System.Drawing.Point(830, 237);
            this.createLoanButton.Name = "createLoanButton";
            this.createLoanButton.Size = new System.Drawing.Size(75, 23);
            this.createLoanButton.TabIndex = 20;
            this.createLoanButton.Text = "Create";
            this.createLoanButton.UseVisualStyleBackColor = true;
            this.createLoanButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // clientLabel
            // 
            this.clientLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clientLabel.AutoSize = true;
            this.clientLabel.Location = new System.Drawing.Point(575, 45);
            this.clientLabel.Name = "clientLabel";
            this.clientLabel.Size = new System.Drawing.Size(38, 15);
            this.clientLabel.TabIndex = 18;
            this.clientLabel.Text = "Client";
            // 
            // loanDataGridView
            // 
            this.loanDataGridView.AllowUserToAddRows = false;
            this.loanDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loanDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.loanDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.loanDataGridView.Location = new System.Drawing.Point(12, 12);
            this.loanDataGridView.Name = "loanDataGridView";
            this.loanDataGridView.ReadOnly = true;
            this.loanDataGridView.RowTemplate.Height = 25;
            this.loanDataGridView.Size = new System.Drawing.Size(544, 472);
            this.loanDataGridView.TabIndex = 17;
            this.loanDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.loanDataGridView_CellClick);
            // 
            // totalLoanValueLabel
            // 
            this.totalLoanValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalLoanValueLabel.AutoSize = true;
            this.totalLoanValueLabel.Location = new System.Drawing.Point(706, 493);
            this.totalLoanValueLabel.Name = "totalLoanValueLabel";
            this.totalLoanValueLabel.Size = new System.Drawing.Size(0, 15);
            this.totalLoanValueLabel.TabIndex = 50;
            // 
            // totalLoanLabel
            // 
            this.totalLoanLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalLoanLabel.AutoSize = true;
            this.totalLoanLabel.Location = new System.Drawing.Point(575, 493);
            this.totalLoanLabel.Name = "totalLoanLabel";
            this.totalLoanLabel.Size = new System.Drawing.Size(64, 15);
            this.totalLoanLabel.TabIndex = 49;
            this.totalLoanLabel.Text = "Total Loan:";
            // 
            // clientComboBox
            // 
            this.clientComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clientComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientComboBox.FormattingEnabled = true;
            this.clientComboBox.Location = new System.Drawing.Point(706, 42);
            this.clientComboBox.Name = "clientComboBox";
            this.clientComboBox.Size = new System.Drawing.Size(280, 23);
            this.clientComboBox.TabIndex = 51;
            // 
            // loanDateTimePicker
            // 
            this.loanDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loanDateTimePicker.Location = new System.Drawing.Point(706, 97);
            this.loanDateTimePicker.Name = "loanDateTimePicker";
            this.loanDateTimePicker.Size = new System.Drawing.Size(280, 23);
            this.loanDateTimePicker.TabIndex = 52;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.searchTextBox.Location = new System.Drawing.Point(69, 490);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(280, 23);
            this.searchTextBox.TabIndex = 54;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // searchLabel
            // 
            this.searchLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(12, 493);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(42, 15);
            this.searchLabel.TabIndex = 53;
            this.searchLabel.Text = "Search";
            // 
            // clearInputsButton
            // 
            this.clearInputsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearInputsButton.Location = new System.Drawing.Point(706, 237);
            this.clearInputsButton.Name = "clearInputsButton";
            this.clearInputsButton.Size = new System.Drawing.Size(75, 23);
            this.clearInputsButton.TabIndex = 55;
            this.clearInputsButton.Text = "Clear";
            this.clearInputsButton.UseVisualStyleBackColor = true;
            this.clearInputsButton.Click += new System.EventHandler(this.clearInputsButton_Click);
            // 
            // remarksRichTextBox
            // 
            this.remarksRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.remarksRichTextBox.Location = new System.Drawing.Point(706, 126);
            this.remarksRichTextBox.Name = "remarksRichTextBox";
            this.remarksRichTextBox.Size = new System.Drawing.Size(280, 105);
            this.remarksRichTextBox.TabIndex = 56;
            this.remarksRichTextBox.Text = "";
            // 
            // remarksLabel
            // 
            this.remarksLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.remarksLabel.AutoSize = true;
            this.remarksLabel.Location = new System.Drawing.Point(575, 129);
            this.remarksLabel.Name = "remarksLabel";
            this.remarksLabel.Size = new System.Drawing.Size(52, 15);
            this.remarksLabel.TabIndex = 57;
            this.remarksLabel.Text = "Remarks";
            // 
            // Loan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 524);
            this.Controls.Add(this.remarksLabel);
            this.Controls.Add(this.remarksRichTextBox);
            this.Controls.Add(this.clearInputsButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.loanDateTimePicker);
            this.Controls.Add(this.clientComboBox);
            this.Controls.Add(this.totalLoanValueLabel);
            this.Controls.Add(this.totalLoanLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.selectedIdLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.DateTimeLabel);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.createLoanButton);
            this.Controls.Add(this.clientLabel);
            this.Controls.Add(this.loanDataGridView);
            this.Name = "Loan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Label DateTimeLabel;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.Button createLoanButton;
        private System.Windows.Forms.Label clientLabel;
        private System.Windows.Forms.DataGridView loanDataGridView;
        private System.Windows.Forms.Label totalLoanValueLabel;
        private System.Windows.Forms.Label totalLoanLabel;
        private System.Windows.Forms.ComboBox clientComboBox;
        private System.Windows.Forms.DateTimePicker loanDateTimePicker;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Button clearInputsButton;
        private System.Windows.Forms.RichTextBox remarksRichTextBox;
        private System.Windows.Forms.Label remarksLabel;
    }
}