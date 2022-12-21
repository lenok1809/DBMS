using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DBMS.src
{
    public class DBManager
    {
        private Database chosenDatabase;
        private FileSystemManager fsManager;
        private readonly string path = "D:/Databases/";
        public DBManager()
        {
            fsManager = new FileSystemManager();
            fsManager.CreateDirectory(path);
        }

        public bool CreateDatabase(string databaseName)
        {
            if (databaseName.Trim().Equals(""))
            {
                return false;
            }
            chosenDatabase = new Database(databaseName);
            return true;
        }

        public bool AddTable(string newTableName)
        {
            if (chosenDatabase == null)
            {
                return false;
            }
            return chosenDatabase.AddTable(newTableName);
        }

        public bool AddTable(Table newTable)
        {
            if (chosenDatabase == null)
            {
                return false;
            }
            return chosenDatabase.AddTable(newTable);
        }


        public Table? GetTable(int index)
        {
            return chosenDatabase.GetTable(index);
        }

        public bool AddColumn(int tableIndex, string columnName, string customTypeName)
        {
            if (chosenDatabase == null)
            {
                return false;
            }
            return chosenDatabase.AddColumn(tableIndex, columnName, customTypeName);
        }

        public bool AddRow(int tableIndex)
        {
            if (chosenDatabase == null)
            {
                return false;
            }
            return chosenDatabase.AddRowToTable(tableIndex);
        }

        public bool ChangeValue(string newValue, int tableIndex, int columnIndex, int rowIndex)
        {
            return chosenDatabase.ChangeValue(newValue, tableIndex, columnIndex, rowIndex);
        }

        public bool DeleteRow(int tableIndex, int rowIndex)
        {
            return chosenDatabase.DeleteRow(tableIndex, rowIndex);
        }

        public bool DeleteColumn(int tableIndex, int columnIndex)
        {
            return chosenDatabase.DeleteColumn(tableIndex, columnIndex);
        }

        public bool DeleteTable(int tableIndex)
        {
            return chosenDatabase.DeleteTable(tableIndex);
        }

        public bool SaveCurrentDatabase()
        {
            return fsManager.SaveDatabaseOnDrive(path, chosenDatabase);
        }

        public bool SaveCurrentMongoDatabase()
        {
            if (chosenDatabase == null)
            {
                return false;
            }
            Mongo dbMongo = new Mongo(chosenDatabase.name);
            foreach (Table table in chosenDatabase.tables)
            {
                dbMongo.InsertRecord(table.name, table);
            }
            return true;
        }

        public bool LoadDatabase(string databaseName)
        {
            chosenDatabase = fsManager.LoadDatabaseFromDrive(path, databaseName);
            return chosenDatabase != null;
        }

        public bool LoadMongoDatabase(string databaseName)
        {

            if (chosenDatabase != null && databaseName == chosenDatabase.GetName())
            {
                return false;
            }
            Mongo dbMongo = new Mongo(databaseName);
            CreateDatabase(databaseName);

            var list = dbMongo.GetCollectionNames();
            var listNameTables = dbMongo.GetCollectionNames();
            foreach (var item in listNameTables)
            {
                AddTable(item);
            }
            int numtable = 0;
            foreach (Table table in chosenDatabase.tables)
            {
                var recs = dbMongo.LoadRecords<BsonDocument>(table.name);

                string rc = recs[0].ToJson<MongoDB.Bson.BsonDocument>();

                Regex reg = new Regex("\"Fields\" : (.*?) }],");
                string ColumnsList = reg.Match(rc).Value;

                ColumnsList = ColumnsList.Remove(0, 14).Replace("}],", "");
                var listColumns = ColumnsList.Split(new string[] { "}, {" }, StringSplitOptions.None);

                for (int i = 0; i < listColumns.Count(); i++)
                {
                    Regex reg1 = new Regex("\"Name\" : \"(.*?)\", \"");
                    string nameCol = reg1.Match(listColumns[i]).Value;
                    nameCol = nameCol.Remove(0, 10).Replace("\", \"", "");
                    Regex reg2 = new Regex("\"TypeName\" : \"(.*?)\"");
                    string typeCol = reg2.Match(listColumns[i]).Value;
                    typeCol = typeCol.Remove(0, 12).Replace("\"", "");
                    AddColumn(numtable, nameCol, typeCol);
                }

                Regex regValue = new Regex("\"Records\" : (.*?) }] }");
                string RowsList = regValue.Match(rc).Value;
                RowsList = RowsList.Remove(0, 15).Replace("}] }", "");
                var listRows = RowsList.Split(new string[] { "}, {" }, StringSplitOptions.None);
                for (int i = 0; i < listRows.Count(); i++)
                {
                    AddRow(numtable);
                    Regex reg1 = new Regex("\"ValuesList\" : (.*?)]");
                    string valueList = reg1.Match(listRows[i]).Value;
                    valueList = valueList.Remove(0, 17).Replace("]", "");

                    List<string> values = new List<string>(Regex.Split(valueList, @"\"",{0,1}\s*\""{0,1}"));
                    values.Remove("");

                    List<string> valueslist = values.ToList();

                    chosenDatabase.tables[numtable].rowsList[i].valuesList = valueslist;

                }
                numtable++;
            }
            return true;
        }
        public List<string> GetTablesNameList()
        {
            return chosenDatabase.GetTablesNamesList();
        }

        public bool DeleteDuplicates(Table Table)
        {
            List<Row> tableRow = Table.Rows();
            for( int i=0; i< tableRow.Count; ++i)
            {
                for(int j=tableRow.Count-1; j>0; --j)
                {
                    if (i == j) continue;

                    if (tableRow[i].valuesList.SequenceEqual(tableRow[j].valuesList))
                    {
                        Table.DeleteRow(j);
                    }

                }
            }

            return true;
        }

    }
}
