
namespace NJERJIM_Guide
{
    partial class Collection
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
            this.collectButton = new System.Windows.Forms.Button();
            this.loanLabel = new System.Windows.Forms.Label();
            this.remarksLabel = new System.Windows.Forms.Label();
            this.remarksRichTextBox = new System.Windows.Forms.RichTextBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchByComboBox = new System.Windows.Forms.ComboBox();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateTimeToLabel = new System.Windows.Forms.Label();
            this.dateTimeFromLabel = new System.Windows.Forms.Label();
            this.searchByLabel = new System.Windows.Forms.Label();
            this.dateTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.loanIdComboBox = new System.Windows.Forms.ComboBox();
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
            this.selectedIdLabel.VisibleChanged += new System.EventHandler(this.selectedIdLabel_VisibleChanged);
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
            this.deleteButton.Location = new System.Drawing.Point(911, 237);
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
            this.collectionDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.collectionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.collectionDataGridView.Location = new System.Drawing.Point(12, 12);
            this.collectionDataGridView.Name = "collectionDataGridView";
            this.collectionDataGridView.ReadOnly = true;
            this.collectionDataGridView.RowTemplate.Height = 25;
            this.collectionDataGridView.Size = new System.Drawing.Size(544, 387);
            this.collectionDataGridView.TabIndex = 35;
            this.collectionDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.collectionDataGridView_CellDoubleClick);
            // 
            // totalCollectionLabel
            // 
            this.totalCollectionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalCollectionLabel.AutoSize = true;
            this.totalCollectionLabel.Location = new System.Drawing.Point(12, 414);
            this.totalCollectionLabel.Name = "totalCollectionLabel";
            this.totalCollectionLabel.Size = new System.Drawing.Size(92, 15);
            this.totalCollectionLabel.TabIndex = 47;
            this.totalCollectionLabel.Text = "Total Collection:";
            // 
            // totalCollectionValueLabel
            // 
            this.totalCollectionValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalCollectionValueLabel.AutoSize = true;
            this.totalCollectionValueLabel.Location = new System.Drawing.Point(143, 414);
            this.totalCollectionValueLabel.Name = "totalCollectionValueLabel";
            this.totalCollectionValueLabel.Size = new System.Drawing.Size(0, 15);
            this.totalCollectionValueLabel.TabIndex = 48;
            // 
            // clearInputsButton
            // 
            this.clearInputsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearInputsButton.Location = new System.Drawing.Point(706, 237);
            this.clearInputsButton.Name = "clearInputsButton";
            this.clearInputsButton.Size = new System.Drawing.Size(75, 23);
            this.clearInputsButton.TabIndex = 59;
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
            this.collectionDateTimePicker.TabIndex = 63;
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
            this.amountTextBox.TabIndex = 62;
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
            // collectButton
            // 
            this.collectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.collectButton.Location = new System.Drawing.Point(830, 237);
            this.collectButton.Name = "collectButton";
            this.collectButton.Size = new System.Drawing.Size(75, 23);
            this.collectButton.TabIndex = 57;
            this.collectButton.Text = "Collect";
            this.collectButton.UseVisualStyleBackColor = true;
            this.collectButton.Click += new System.EventHandler(this.collectButton_Click);
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
            // remarksLabel
            // 
            this.remarksLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.remarksLabel.AutoSize = true;
            this.remarksLabel.Location = new System.Drawing.Point(575, 129);
            this.remarksLabel.Name = "remarksLabel";
            this.remarksLabel.Size = new System.Drawing.Size(52, 15);
            this.remarksLabel.TabIndex = 64;
            this.remarksLabel.Text = "Remarks";
            // 
            // remarksRichTextBox
            // 
            this.remarksRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.remarksRichTextBox.Location = new System.Drawing.Point(706, 126);
            this.remarksRichTextBox.Name = "remarksRichTextBox";
            this.remarksRichTextBox.Size = new System.Drawing.Size(280, 105);
            this.remarksRichTextBox.TabIndex = 64;
            this.remarksRichTextBox.Text = "";
            // 
            // searchLabel
            // 
            this.searchLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(12, 493);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(42, 15);
            this.searchLabel.TabIndex = 66;
            this.searchLabel.Text = "Search";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.searchTextBox.Location = new System.Drawing.Point(213, 489);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(231, 23);
            this.searchTextBox.TabIndex = 67;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchByTextBox_TextChanged);
            // 
            // searchByComboBox
            // 
            this.searchByComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.searchByComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchByComboBox.FormattingEnabled = true;
            this.searchByComboBox.Items.AddRange(new object[] {
            "Loan ID",
            "Customer Name"});
            this.searchByComboBox.Location = new System.Drawing.Point(86, 489);
            this.searchByComboBox.Name = "searchByComboBox";
            this.searchByComboBox.Size = new System.Drawing.Size(121, 23);
            this.searchByComboBox.TabIndex = 68;
            this.searchByComboBox.TextChanged += new System.EventHandler(this.searchByComboBox_TextChanged);
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fromDateTimePicker.Location = new System.Drawing.Point(142, 449);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(200, 23);
            this.fromDateTimePicker.TabIndex = 70;
            this.fromDateTimePicker.ValueChanged += new System.EventHandler(this.fromDateTimePicker_ValueChanged);
            // 
            // toDateTimePicker
            // 
            this.toDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toDateTimePicker.Location = new System.Drawing.Point(373, 449);
            this.toDateTimePicker.Name = "toDateTimePicker";
            this.toDateTimePicker.Size = new System.Drawing.Size(200, 23);
            this.toDateTimePicker.TabIndex = 72;
            this.toDateTimePicker.ValueChanged += new System.EventHandler(this.fromtoDateTimePicker_ValueChanged);
            // 
            // dateTimeToLabel
            // 
            this.dateTimeToLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimeToLabel.AutoSize = true;
            this.dateTimeToLabel.Location = new System.Drawing.Point(348, 455);
            this.dateTimeToLabel.Name = "dateTimeToLabel";
            this.dateTimeToLabel.Size = new System.Drawing.Size(19, 15);
            this.dateTimeToLabel.TabIndex = 71;
            this.dateTimeToLabel.Text = "To";
            // 
            // dateTimeFromLabel
            // 
            this.dateTimeFromLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimeFromLabel.AutoSize = true;
            this.dateTimeFromLabel.Location = new System.Drawing.Point(101, 455);
            this.dateTimeFromLabel.Name = "dateTimeFromLabel";
            this.dateTimeFromLabel.Size = new System.Drawing.Size(35, 15);
            this.dateTimeFromLabel.TabIndex = 73;
            this.dateTimeFromLabel.Text = "From";
            // 
            // searchByLabel
            // 
            this.searchByLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.searchByLabel.AutoSize = true;
            this.searchByLabel.Location = new System.Drawing.Point(60, 493);
            this.searchByLabel.Name = "searchByLabel";
            this.searchByLabel.Size = new System.Drawing.Size(20, 15);
            this.searchByLabel.TabIndex = 74;
            this.searchByLabel.Text = "By";
            // 
            // dateTimeCheckBox
            // 
            this.dateTimeCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimeCheckBox.AutoSize = true;
            this.dateTimeCheckBox.Location = new System.Drawing.Point(12, 453);
            this.dateTimeCheckBox.Name = "dateTimeCheckBox";
            this.dateTimeCheckBox.Size = new System.Drawing.Size(76, 19);
            this.dateTimeCheckBox.TabIndex = 75;
            this.dateTimeCheckBox.Text = "DateTime";
            this.dateTimeCheckBox.UseVisualStyleBackColor = true;
            this.dateTimeCheckBox.CheckedChanged += new System.EventHandler(this.dateTimeCheckBox_CheckedChanged);
            // 
            // loanIdComboBox
            // 
            this.loanIdComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loanIdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loanIdComboBox.FormattingEnabled = true;
            this.loanIdComboBox.Location = new System.Drawing.Point(213, 489);
            this.loanIdComboBox.Name = "loanIdComboBox";
            this.loanIdComboBox.Size = new System.Drawing.Size(121, 23);
            this.loanIdComboBox.TabIndex = 76;
            this.loanIdComboBox.Visible = false;
            this.loanIdComboBox.SelectedIndexChanged += new System.EventHandler(this.loanIdComboBox_SelectedIndexChanged);
            // 
            // Collection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 524);
            this.Controls.Add(this.loanIdComboBox);
            this.Controls.Add(this.dateTimeCheckBox);
            this.Controls.Add(this.searchByLabel);
            this.Controls.Add(this.dateTimeFromLabel);
            this.Controls.Add(this.toDateTimePicker);
            this.Controls.Add(this.dateTimeToLabel);
            this.Controls.Add(this.fromDateTimePicker);
            this.Controls.Add(this.searchByComboBox);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.remarksLabel);
            this.Controls.Add(this.remarksRichTextBox);
            this.Controls.Add(this.clearInputsButton);
            this.Controls.Add(this.collectionDateTimePicker);
            this.Controls.Add(this.loanComboBox);
            this.Controls.Add(this.DateTimeLabel);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.collectButton);
            this.Controls.Add(this.loanLabel);
            this.Controls.Add(this.totalCollectionValueLabel);
            this.Controls.Add(this.totalCollectionLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.selectedIdLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.collectionDataGridView);
            this.Name = "Collection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Collection";
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
        private System.Windows.Forms.Button collectButton;
        private System.Windows.Forms.Label loanLabel;
        private System.Windows.Forms.Label remarksLabel;
        private System.Windows.Forms.RichTextBox remarksRichTextBox;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.ComboBox searchByComboBox;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.DateTimePicker toDateTimePicker;
        private System.Windows.Forms.Label dateTimeToLabel;
        private System.Windows.Forms.Label dateTimeFromLabel;
        private System.Windows.Forms.Label searchByLabel;
        private System.Windows.Forms.CheckBox dateTimeCheckBox;
        private System.Windows.Forms.ComboBox loanIdComboBox;
    }
}