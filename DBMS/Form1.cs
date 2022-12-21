using DBMS.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS
{
    public partial class Form1 : Form
    {
        DBManager databaseManager = new DBManager();
        string currentFilePath = "";
        string cellOldValue = "";
        string cellNewValue = "";
        public Form1()
        {
            InitializeComponent();
            comboBoxColumnsTypes.SelectedIndex = 0;
        }
        private void textBox1_TextChanged( object sender, EventArgs e)
        {

        }

        public void RemoveTextCreateDB(object sender, EventArgs e)
        {
            if (textBoxCreateDatabase.Text == "Database name")
            {
                textBoxCreateDatabase.Text = "";
            }
        }

        public void AddTextCreateDB(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxCreateDatabase.Text))
                textBoxCreateDatabase.Text = "Database name";
        }

        public void RemoveTextLoadDB(object sender, EventArgs e)
        {
            if (textBoxLoadDatabase.Text == "Database name")
            {
                textBoxLoadDatabase.Text = "";
            }
        }

        public void AddTextLoadDB(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxLoadDatabase.Text))
                textBoxLoadDatabase.Text = "Database name";
        }

        public void RemoveTextAddTable(object sender, EventArgs e)
        {
            if (textBoxCreateTable.Text == "Table name")
            {
                textBoxCreateTable.Text = "";
            }
        }

        public void AddTextAddTable(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxCreateTable.Text))
                textBoxCreateTable.Text = "Table name";
        }

        public void RemoveTextAddColumn(object sender, EventArgs e)
        {
            if (textBoxAddColumn.Text == "Column name")
            {
                textBoxAddColumn.Text = "";
            }
        }

        public void AddTextAddColumn(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxAddColumn.Text))
                textBoxAddColumn.Text = "Column name";
        }

        public void RemoveTextDeleteDuplicates(object sender, EventArgs e)
        {
            if (textBoxDeleteDuplicatesTableName.Text == "Table name")
            {
                textBoxDeleteDuplicatesTableName.Text = "";
            }
        }

        public void AddTextDeleteDuplicates(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxDeleteDuplicatesTableName.Text))
                textBoxDeleteDuplicatesTableName.Text = "Table name";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (databaseManager.AddColumn(tablesControl.SelectedIndex, textBoxAddColumn.Text, comboBoxColumnsTypes.Text))
            {
                int tableIndex = tablesControl.SelectedIndex;
                if (tableIndex != -1)
                {
                    ShowTable(databaseManager.GetTable(tableIndex));
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView.Columns.Count == 0) return;
            try
            {
                databaseManager.DeleteColumn(tablesControl.SelectedIndex, dataGridView.CurrentCell.ColumnIndex);
            }
            catch { }

            int tableIndex = tablesControl.SelectedIndex;
            if (tableIndex != -1)
            {
                ShowTable(databaseManager.GetTable(tableIndex));
            }
        }

        private void butCreateDatabase_Click(object sender, EventArgs e)
        {
            if (currentFilePath != String.Empty)
            {
                DialogResult dialogResult = MessageBox.Show("Save changings?", "Attention!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //databaseManager.SaveCurrentDatabase();
                    databaseManager.SaveCurrentMongoDatabase();
                }
            }
            if (databaseManager.CreateDatabase(textBoxCreateDatabase.Text))
            {
                currentFilePath = "";
                tablesControl.TabPages.Clear();
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
            }
        }

        private void butLoadDatabase_Click(object sender, EventArgs e)
        {
            if (currentFilePath != String.Empty)
            {
                DialogResult dialogResult = MessageBox.Show("Save changings?", "Attention!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    databaseManager.SaveCurrentMongoDatabase();
                    //databaseManager.SaveCurrentDatabase();
                }
            }
            var databaseName = textBoxLoadDatabase.Text;
            if (!databaseManager.LoadMongoDatabase(databaseName))
            //if(!databaseManager.LoadDatabase(databaseName))
            {
                return;
            }
            currentFilePath = databaseName;
            tablesControl.TabPages.Clear();
            List<string> tablesNames = databaseManager.GetTablesNameList();
            foreach (string tableName in tablesNames)
            {
                tablesControl.TabPages.Add(tableName);
            }
            int selectedTableIndex = tablesControl.SelectedIndex;
            if (selectedTableIndex != -1)
            {
                ShowTable(databaseManager.GetTable(selectedTableIndex));
            }
        }

        private void ShowTable(Table table)
        {
            try
            {
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();

                foreach (Column column in table.Columns())
                {
                    DataGridViewColumn dataGridColumn;
                    dataGridColumn = new DataGridViewTextBoxColumn();
                    dataGridColumn.Name = column.GetName();
                    dataGridColumn.HeaderText = column.GetName();
                    dataGridView.Columns.Add(dataGridColumn);
                }

                foreach (Row row in table.Rows())
                {
                    DataGridViewRow dataGridRow = new DataGridViewRow();
                    for (int i = 0; i < row.GetValuesList().Count; ++i)
                    {
                        DataGridViewCell cell;
                        var stringCellValue = row.GetValuesList()[i];
                        cell = new DataGridViewTextBoxCell();
                        cell.Value = stringCellValue;
                        dataGridRow.Cells.Add(cell);
                    }
                    try
                    {
                        dataGridView.Rows.Add(dataGridRow);
                    }
                    catch { }
                }
            }
            catch { }
        }

        private void butCreateTable_Click(object sender, EventArgs e)
        {
            if (databaseManager.AddTable(textBoxCreateTable.Text))
            {
                tablesControl.TabPages.Add(textBoxCreateTable.Text);
            }
        }

        private void butDeleteTable_Click(object sender, EventArgs e)
        {
            if (tablesControl.TabCount == 0)
            {
                return;
            }
            try
            {
                databaseManager.DeleteTable(tablesControl.SelectedIndex);
                tablesControl.TabPages.RemoveAt(tablesControl.SelectedIndex);
            }
            catch { }
            if (tablesControl.TabCount == 0)
            {
                return;
            }

            int tableIndex = tablesControl.SelectedIndex;
            if (tableIndex != -1)
            {
               ShowTable(databaseManager.GetTable(tableIndex));
            }
        }

        private void butDeleteRow_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count == 0)
            {
                return;
            }
            try
            {
                databaseManager.DeleteRow(tablesControl.SelectedIndex, dataGridView.CurrentCell.RowIndex);
            }
            catch { }

            int tableIndex = tablesControl.SelectedIndex;
            if (tableIndex != -1)
            {
                ShowTable(databaseManager.GetTable(tableIndex));
            }
        }

        private void butAddRow_Click(object sender, EventArgs e)
        {
            if (databaseManager.AddRow(tablesControl.SelectedIndex))
            {
                int tableIndex = tablesControl.SelectedIndex;
                if (tableIndex != -1)
                {
                    ShowTable(databaseManager.GetTable(tableIndex));
                }
            }
        }

        private void butDeleteDuplicates_Click(object sender, EventArgs e)
        {
            int tableIndex = -1;
            string TableName = textBoxDeleteDuplicatesTableName.Text;

            foreach (TabPage page in tablesControl.TabPages)
            {
                if (page.Text == TableName)
                {
                    tableIndex = tablesControl.TabPages.IndexOf(page);
                }
            }
            if (tableIndex != -1)
            {
                Table table = databaseManager.GetTable(tableIndex);
                if (!databaseManager.DeleteDuplicates(table))
                {
                    return;
                }

                ShowTable(table);
            }
        }

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int selectedTableIndex = tablesControl.SelectedIndex;
            if (selectedTableIndex == -1)
            {
                return;
            }
            var table = databaseManager.GetTable(selectedTableIndex);
            if (table.Columns()[e.ColumnIndex].customTypeName != Constants.textFileTypeName)
            {
                var currentCellValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                cellOldValue = currentCellValue == null ? String.Empty : currentCellValue.ToString();
                return;
            }
            var cell = new DataGridViewTextBoxCell();
            cellOldValue = table.Rows()[e.RowIndex].GetValuesList()[e.ColumnIndex];
            cell.Value = cellOldValue;
            dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex] = cell;
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var cellValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (cellValue == null)
            {
                return;
            }
            cellNewValue = cellValue.ToString();
            if (!databaseManager.ChangeValue(cellNewValue, tablesControl.SelectedIndex, e.ColumnIndex, e.RowIndex))
            {
                dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cellOldValue;
                return;
            }
            int selectedTableIndex = tablesControl.SelectedIndex;
            if (selectedTableIndex == -1)
            {
                return;
            }
            var table = databaseManager.GetTable(selectedTableIndex);
            if (table.Columns()[e.ColumnIndex].customTypeName == Constants.textFileTypeName && cellNewValue != String.Empty)
            {
                var cell = new DataGridViewTextBoxCell();
                string [] lines = File.ReadAllLines(cellNewValue);
                List<string> listLines= new List<string>(lines);
                string value = string.Join(" ", listLines);
                cell.Value = value;
                dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex] = cell;
            }
            ShowTable(databaseManager.GetTable(selectedTableIndex));
            
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void butSaveDatabase_Click(object sender, EventArgs e)
        {
            databaseManager.SaveCurrentMongoDatabase();
        }

        private void tablesControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tablesIndex = tablesControl.SelectedIndex;
            if (tablesIndex != -1)
            {
                ShowTable(databaseManager.GetTable(tablesIndex));
            }
        }

        private void dataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int selectedTableIndex = tablesControl.SelectedIndex;
            if (selectedTableIndex == -1)
            {
                return;
            }
            var table = databaseManager.GetTable(selectedTableIndex);
            if (table.Columns()[e.ColumnIndex].customTypeName != Constants.textFileTypeName)
            {
                return;
            }
            var cell = new DataGridViewTextBoxCell();
            cell.Value = table.Rows()[e.RowIndex].GetValuesList()[e.ColumnIndex];
            dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex] = cell;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
