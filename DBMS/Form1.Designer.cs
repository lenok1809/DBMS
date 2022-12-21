using System;

namespace DBMS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.butCreateDatabase = new System.Windows.Forms.Button();
            this.textBoxCreateDatabase = new System.Windows.Forms.TextBox();
            this.butLoadDatabase = new System.Windows.Forms.Button();
            this.butSaveDatabase = new System.Windows.Forms.Button();
            this.butCreateTable = new System.Windows.Forms.Button();
            this.textBoxCreateTable = new System.Windows.Forms.TextBox();
            this.butDeleteTable = new System.Windows.Forms.Button();
            this.butAddColumn = new System.Windows.Forms.Button();
            this.textBoxAddColumn = new System.Windows.Forms.TextBox();
            this.butDeleteColumn = new System.Windows.Forms.Button();
            this.comboBoxColumnsTypes = new System.Windows.Forms.ComboBox();
            this.butAddRow = new System.Windows.Forms.Button();
            this.butDeleteRow = new System.Windows.Forms.Button();
            this.butDeleteDuplicates = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.tablesControl = new System.Windows.Forms.TabControl();
            this.openDatabaseDialog = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogChooseFilePath = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogSaveDatabase = new System.Windows.Forms.SaveFileDialog();
            this.textBoxLoadDatabase = new System.Windows.Forms.TextBox();
            this.textBoxDeleteDuplicatesTableName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // butCreateDatabase
            // 
            this.butCreateDatabase.Location = new System.Drawing.Point(16, 26);
            this.butCreateDatabase.Name = "butCreateDatabase";
            this.butCreateDatabase.Size = new System.Drawing.Size(159, 37);
            this.butCreateDatabase.TabIndex = 0;
            this.butCreateDatabase.Text = "Create database";
            this.butCreateDatabase.UseVisualStyleBackColor = true;
            this.butCreateDatabase.Click += new System.EventHandler(this.butCreateDatabase_Click);
            // 
            // textBoxCreateDatabase
            // 
            this.textBoxCreateDatabase.Location = new System.Drawing.Point(204, 36);
            this.textBoxCreateDatabase.Name = "textBoxCreateDatabase";
            this.textBoxCreateDatabase.Size = new System.Drawing.Size(155, 27);
            this.textBoxCreateDatabase.TabIndex = 1;
            this.textBoxCreateDatabase.Text = "Database name";
            this.textBoxCreateDatabase.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBoxCreateDatabase.GotFocus += new System.EventHandler(this.RemoveTextCreateDB);
            this.textBoxCreateDatabase.LostFocus += new System.EventHandler(this.AddTextCreateDB);
            // 
            // butLoadDatabase
            // 
            this.butLoadDatabase.Location = new System.Drawing.Point(16, 83);
            this.butLoadDatabase.Name = "butLoadDatabase";
            this.butLoadDatabase.Size = new System.Drawing.Size(159, 41);
            this.butLoadDatabase.TabIndex = 2;
            this.butLoadDatabase.Text = "Load database";
            this.butLoadDatabase.UseVisualStyleBackColor = true;
            this.butLoadDatabase.Click += new System.EventHandler(this.butLoadDatabase_Click);
            // 
            // butSaveDatabase
            // 
            this.butSaveDatabase.Location = new System.Drawing.Point(16, 144);
            this.butSaveDatabase.Name = "butSaveDatabase";
            this.butSaveDatabase.Size = new System.Drawing.Size(159, 37);
            this.butSaveDatabase.TabIndex = 3;
            this.butSaveDatabase.Text = "Save database";
            this.butSaveDatabase.UseVisualStyleBackColor = true;
            this.butSaveDatabase.Click += new System.EventHandler(this.butSaveDatabase_Click);
            // 
            // butCreateTable
            // 
            this.butCreateTable.Location = new System.Drawing.Point(388, 26);
            this.butCreateTable.Name = "butCreateTable";
            this.butCreateTable.Size = new System.Drawing.Size(159, 37);
            this.butCreateTable.TabIndex = 4;
            this.butCreateTable.Text = "Add Table";
            this.butCreateTable.UseVisualStyleBackColor = true;
            this.butCreateTable.Click += new System.EventHandler(this.butCreateTable_Click);
            // 
            // textBoxCreateTable
            // 
            this.textBoxCreateTable.Location = new System.Drawing.Point(574, 36);
            this.textBoxCreateTable.Name = "textBoxCreateTable";
            this.textBoxCreateTable.Size = new System.Drawing.Size(155, 27);
            this.textBoxCreateTable.TabIndex = 5;
            this.textBoxCreateTable.Text = "Table name";
            this.textBoxCreateTable.GotFocus += new System.EventHandler(this.RemoveTextAddTable);
            this.textBoxCreateTable.LostFocus += new System.EventHandler(this.AddTextAddTable);
            // 
            // butDeleteTable
            // 
            this.butDeleteTable.Location = new System.Drawing.Point(388, 80);
            this.butDeleteTable.Name = "butDeleteTable";
            this.butDeleteTable.Size = new System.Drawing.Size(159, 37);
            this.butDeleteTable.TabIndex = 6;
            this.butDeleteTable.Text = "Delete Table";
            this.butDeleteTable.UseVisualStyleBackColor = true;
            this.butDeleteTable.Click += new System.EventHandler(this.butDeleteTable_Click);
            // 
            // butAddColumn
            // 
            this.butAddColumn.Location = new System.Drawing.Point(766, 26);
            this.butAddColumn.Name = "butAddColumn";
            this.butAddColumn.Size = new System.Drawing.Size(154, 37);
            this.butAddColumn.TabIndex = 8;
            this.butAddColumn.Text = "Add Column";
            this.butAddColumn.UseVisualStyleBackColor = true;
            this.butAddColumn.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBoxAddColumn
            // 
            this.textBoxAddColumn.Location = new System.Drawing.Point(948, 36);
            this.textBoxAddColumn.Name = "textBoxAddColumn";
            this.textBoxAddColumn.Size = new System.Drawing.Size(159, 27);
            this.textBoxAddColumn.TabIndex = 9;
            this.textBoxAddColumn.Text = "Column name";
            this.textBoxAddColumn.GotFocus += new System.EventHandler(this.RemoveTextAddColumn);
            this.textBoxAddColumn.LostFocus += new System.EventHandler(this.AddTextAddColumn);
            // 
            // butDeleteColumn
            // 
            this.butDeleteColumn.Location = new System.Drawing.Point(766, 80);
            this.butDeleteColumn.Name = "butDeleteColumn";
            this.butDeleteColumn.Size = new System.Drawing.Size(154, 37);
            this.butDeleteColumn.TabIndex = 10;
            this.butDeleteColumn.Text = "Delete column";
            this.butDeleteColumn.UseVisualStyleBackColor = true;
            this.butDeleteColumn.Click += new System.EventHandler(this.button7_Click);
            // 
            // comboBoxColumnsTypes
            // 
            this.comboBoxColumnsTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColumnsTypes.FormattingEnabled = true;
            this.comboBoxColumnsTypes.Items.AddRange(new object[] {
            "Integer",
            "String",
            "Char",
            "Real",
            "Time",
            "TimeInvl"});
            this.comboBoxColumnsTypes.Location = new System.Drawing.Point(1141, 35);
            this.comboBoxColumnsTypes.Name = "comboBoxColumnsTypes";
            this.comboBoxColumnsTypes.Size = new System.Drawing.Size(156, 28);
            this.comboBoxColumnsTypes.TabIndex = 12;
            // 
            // butAddRow
            // 
            this.butAddRow.Location = new System.Drawing.Point(948, 80);
            this.butAddRow.Name = "butAddRow";
            this.butAddRow.Size = new System.Drawing.Size(159, 37);
            this.butAddRow.TabIndex = 13;
            this.butAddRow.Text = "Add row";
            this.butAddRow.UseVisualStyleBackColor = true;
            this.butAddRow.Click += new System.EventHandler(this.butAddRow_Click);
            // 
            // butDeleteRow
            // 
            this.butDeleteRow.Location = new System.Drawing.Point(1141, 80);
            this.butDeleteRow.Name = "butDeleteRow";
            this.butDeleteRow.Size = new System.Drawing.Size(156, 37);
            this.butDeleteRow.TabIndex = 14;
            this.butDeleteRow.Text = "Delete row";
            this.butDeleteRow.UseVisualStyleBackColor = true;
            this.butDeleteRow.Click += new System.EventHandler(this.butDeleteRow_Click);
            // 
            // butDeleteDuplicates
            // 
            this.butDeleteDuplicates.Location = new System.Drawing.Point(948, 133);
            this.butDeleteDuplicates.Name = "butDeleteDuplicates";
            this.butDeleteDuplicates.Size = new System.Drawing.Size(159, 38);
            this.butDeleteDuplicates.TabIndex = 15;
            this.butDeleteDuplicates.Text = "Delete Duplicates";
            this.butDeleteDuplicates.UseVisualStyleBackColor = true;
            this.butDeleteDuplicates.Click += new System.EventHandler(this.butDeleteDuplicates_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(16, 240);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(1281, 617);
            this.dataGridView.TabIndex = 18;
            this.dataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            this.dataGridView.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellLeave);
            this.dataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseDoubleClick);
            // 
            // tablesControl
            // 
            this.tablesControl.Location = new System.Drawing.Point(17, 187);
            this.tablesControl.Name = "tablesControl";
            this.tablesControl.SelectedIndex = 0;
            this.tablesControl.Size = new System.Drawing.Size(1280, 47);
            this.tablesControl.TabIndex = 19;
            this.tablesControl.SelectedIndexChanged += new System.EventHandler(this.tablesControl_SelectedIndexChanged);
            // 
            // openDatabaseDialog
            // 
            this.openDatabaseDialog.FileName = "openFileDialog1";
            // 
            // openFileDialogChooseFilePath
            // 
            this.openFileDialogChooseFilePath.FileName = "openFileDialog1";
            // 
            // textBoxLoadDatabase
            // 
            this.textBoxLoadDatabase.Location = new System.Drawing.Point(204, 97);
            this.textBoxLoadDatabase.Name = "textBoxLoadDatabase";
            this.textBoxLoadDatabase.Size = new System.Drawing.Size(155, 27);
            this.textBoxLoadDatabase.TabIndex = 20;
            this.textBoxLoadDatabase.Text = "Database name";
            this.textBoxLoadDatabase.GotFocus += new System.EventHandler(this.RemoveTextLoadDB);
            this.textBoxLoadDatabase.LostFocus += new System.EventHandler(this.AddTextLoadDB);
            // 
            // textBoxDeleteDuplicatesTableName
            // 
            this.textBoxDeleteDuplicatesTableName.Location = new System.Drawing.Point(1141, 144);
            this.textBoxDeleteDuplicatesTableName.Name = "textBoxDeleteDuplicatesTableName";
            this.textBoxDeleteDuplicatesTableName.Size = new System.Drawing.Size(156, 27);
            this.textBoxDeleteDuplicatesTableName.TabIndex = 21;
            this.textBoxDeleteDuplicatesTableName.Text = "Table name";
            this.textBoxDeleteDuplicatesTableName.GotFocus += new System.EventHandler(this.RemoveTextDeleteDuplicates);
            this.textBoxDeleteDuplicatesTableName.LostFocus += new System.EventHandler(this.AddTextDeleteDuplicates);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 869);
            this.Controls.Add(this.textBoxDeleteDuplicatesTableName);
            this.Controls.Add(this.textBoxLoadDatabase);
            this.Controls.Add(this.tablesControl);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.butDeleteDuplicates);
            this.Controls.Add(this.butDeleteRow);
            this.Controls.Add(this.butAddRow);
            this.Controls.Add(this.comboBoxColumnsTypes);
            this.Controls.Add(this.butDeleteColumn);
            this.Controls.Add(this.textBoxAddColumn);
            this.Controls.Add(this.butAddColumn);
            this.Controls.Add(this.butDeleteTable);
            this.Controls.Add(this.textBoxCreateTable);
            this.Controls.Add(this.butCreateTable);
            this.Controls.Add(this.butSaveDatabase);
            this.Controls.Add(this.butLoadDatabase);
            this.Controls.Add(this.textBoxCreateDatabase);
            this.Controls.Add(this.butCreateDatabase);
            this.Name = "Form1";
            this.Text = "Local Database Manager System";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butCreateDatabase;
        private System.Windows.Forms.TextBox textBoxCreateDatabase;
        private System.Windows.Forms.Button butLoadDatabase;
        private System.Windows.Forms.Button butSaveDatabase;
        private System.Windows.Forms.Button butCreateTable;
        private System.Windows.Forms.TextBox textBoxCreateTable;
        private System.Windows.Forms.Button butDeleteTable;
        private System.Windows.Forms.Button butAddColumn;
        private System.Windows.Forms.TextBox textBoxAddColumn;
        private System.Windows.Forms.Button butDeleteColumn;
        private System.Windows.Forms.ComboBox comboBoxColumnsTypes;
        private System.Windows.Forms.Button butAddRow;
        private System.Windows.Forms.Button butDeleteRow;
        private System.Windows.Forms.Button butDeleteDuplicates;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TabControl tablesControl;
        private System.Windows.Forms.OpenFileDialog openDatabaseDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialogChooseFilePath;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSaveDatabase;
        private System.Windows.Forms.TextBox textBoxLoadDatabase;
        private System.Windows.Forms.TextBox textBoxDeleteDuplicatesTableName;
    }
}

