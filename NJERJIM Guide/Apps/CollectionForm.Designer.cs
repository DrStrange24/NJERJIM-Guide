
namespace NJERJIM_Guide
{
    partial class CollectionForm
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
            this.collectionDataGridView = new System.Windows.Forms.DataGridView();
            this.totalCollectionLabel = new System.Windows.Forms.Label();
            this.totalCollectionValueLabel = new System.Windows.Forms.Label();
            this.clearInputsButton = new System.Windows.Forms.Button();
            this.collectionDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.loanComboBox = new System.Windows.Forms.ComboBox();
            this.DateTimeLabel = new System.Windows.Forms.Label();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.amountLabel = new System.Windows.Forms.Label();
            this.createLoanButton = new System.Windows.Forms.Button();
            this.loanLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.collectionDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.Location = new System.Drawing.Point(911, 489);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 46;
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
            this.selectedIdLabel.TabIndex = 45;
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
            this.idLabel.TabIndex = 44;
            this.idLabel.Text = "Id";
            this.idLabel.Visible = false;
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(911, 129);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 43;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // collectionDataGridView
            // 
            this.collectionDataGridView.AllowUserToAddRows = false;
            this.collectionDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.collectionDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.collectionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.collectionDataGridView.Location = new System.Drawing.Point(12, 12);
            this.collectionDataGridView.Name = "collectionDataGridView";
            this.collectionDataGridView.ReadOnly = true;
            this.collectionDataGridView.RowTemplate.Height = 25;
            this.collectionDataGridView.Size = new System.Drawing.Size(544, 500);
            this.collectionDataGridView.TabIndex = 35;
            this.collectionDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.collectionDataGridView_CellClick);
            // 
            // totalCollectionLabel
            // 
            this.totalCollectionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalCollectionLabel.AutoSize = true;
            this.totalCollectionLabel.Location = new System.Drawing.Point(575, 493);
            this.totalCollectionLabel.Name = "totalCollectionLabel";
            this.totalCollectionLabel.Size = new System.Drawing.Size(92, 15);
            this.totalCollectionLabel.TabIndex = 47;
            this.totalCollectionLabel.Text = "Total Collection:";
            // 
            // totalCollectionValueLabel
            // 
            this.totalCollectionValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalCollectionValueLabel.AutoSize = true;
            this.totalCollectionValueLabel.Location = new System.Drawing.Point(706, 493);
            this.totalCollectionValueLabel.Name = "totalCollectionValueLabel";
            this.totalCollectionValueLabel.Size = new System.Drawing.Size(0, 15);
            this.totalCollectionValueLabel.TabIndex = 48;
            // 
            // clearInputsButton
            // 
            this.clearInputsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearInputsButton.Location = new System.Drawing.Point(706, 129);
            this.clearInputsButton.Name = "clearInputsButton";
            this.clearInputsButton.Size = new System.Drawing.Size(75, 23);
            this.clearInputsButton.TabIndex = 63;
            this.clearInputsButton.Text = "Clear";
            this.clearInputsButton.UseVisualStyleBackColor = true;
            this.clearInputsButton.Click += new System.EventHandler(this.clearInputsButton_Click);
            // 
            // collectionDateTimePicker
            // 
            this.collectionDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.collectionDateTimePicker.Location = new System.Drawing.Point(706, 97);
            this.collectionDateTimePicker.Name = "collectionDateTimePicker";
            this.collectionDateTimePicker.Size = new System.Drawing.Size(280, 23);
            this.collectionDateTimePicker.TabIndex = 62;
            // 
            // loanComboBox
            // 
            this.loanComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loanComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loanComboBox.FormattingEnabled = true;
            this.loanComboBox.Location = new System.Drawing.Point(706, 42);
            this.loanComboBox.Name = "loanComboBox";
            this.loanComboBox.Size = new System.Drawing.Size(280, 23);
            this.loanComboBox.TabIndex = 61;
            // 
            // DateTimeLabel
            // 
            this.DateTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTimeLabel.AutoSize = true;
            this.DateTimeLabel.Location = new System.Drawing.Point(575, 103);
            this.DateTimeLabel.Name = "DateTimeLabel";
            this.DateTimeLabel.Size = new System.Drawing.Size(60, 15);
            this.DateTimeLabel.TabIndex = 60;
            this.DateTimeLabel.Text = "Date Time";
            // 
            // amountTextBox
            // 
            this.amountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.amountTextBox.Location = new System.Drawing.Point(706, 71);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(280, 23);
            this.amountTextBox.TabIndex = 59;
            this.amountTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.creatCollectionTextBox_KeyDown);
            // 
            // amountLabel
            // 
            this.amountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(575, 74);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(51, 15);
            this.amountLabel.TabIndex = 58;
            this.amountLabel.Text = "Amount";
            // 
            // createLoanButton
            // 
            this.createLoanButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createLoanButton.Location = new System.Drawing.Point(830, 129);
            this.createLoanButton.Name = "createLoanButton";
            this.createLoanButton.Size = new System.Drawing.Size(75, 23);
            this.createLoanButton.TabIndex = 57;
            this.createLoanButton.Text = "Create";
            this.createLoanButton.UseVisualStyleBackColor = true;
            this.createLoanButton.Click += new System.EventHandler(this.createLoanButton_Click);
            // 
            // loanLabel
            // 
            this.loanLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loanLabel.AutoSize = true;
            this.loanLabel.Location = new System.Drawing.Point(575, 45);
            this.loanLabel.Name = "loanLabel";
            this.loanLabel.Size = new System.Drawing.Size(33, 15);
            this.loanLabel.TabIndex = 56;
            this.loanLabel.Text = "Loan";
            // 
            // CollectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 524);
            this.Controls.Add(this.clearInputsButton);
            this.Controls.Add(this.collectionDateTimePicker);
            this.Controls.Add(this.loanComboBox);
            this.Controls.Add(this.DateTimeLabel);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.createLoanButton);
            this.Controls.Add(this.loanLabel);
            this.Controls.Add(this.totalCollectionValueLabel);
            this.Controls.Add(this.totalCollectionLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.selectedIdLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.collectionDataGridView);
            this.Name = "CollectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CollectionForm";
            ((System.ComponentModel.ISupportInitialize)(this.collectionDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label selectedIdLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DataGridView collectionDataGridView;
        private System.Windows.Forms.Label totalCollectionLabel;
        private System.Windows.Forms.Label totalCollectionValueLabel;
        private System.Windows.Forms.Button clearInputsButton;
        private System.Windows.Forms.DateTimePicker collectionDateTimePicker;
        private System.Windows.Forms.ComboBox loanComboBox;
        private System.Windows.Forms.Label DateTimeLabel;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.Button createLoanButton;
        private System.Windows.Forms.Label loanLabel;
    }
}