using System.IO;
using Xunit;
using DBMS.src;

using System.Collections.Generic;

namespace DBMSUnitTests
{
    public class UnitTest1
    {

        [Fact]
        public void Test_DeleteDuplicatesTrue()
        {
            var dbManager = new DBManager();
            var A1 = new Column("A", Constants.stringTypeName);
            var B = new Column("B", Constants.stringTypeName);
            var C = new Column("C", Constants.stringTypeName);
            var column = new List<Column>() { A1, B, C };
            Row tblrow1 = new Row { valuesList = { "A1", "B1" , "C1"} };
            Row tblrow2 = new Row { valuesList = { "A2", "B2" , "C2"} };

            var tbl = new Table { name = "Test", columnsList = column, rowsList = { tblrow1, tblrow2, tblrow1, tblrow1, tblrow2 } };
            var expected = new Table { name = "Test", columnsList = column, rowsList = { tblrow1, tblrow2} };
            dbManager.DeleteDuplicates(tbl);
            Assert.True(expected.Equals(tbl));
        }

        [Fact]
        public void  Test_TimeValidationTrue()
        {
            var value = "23:50";
            Assert.True(TypesValidator.IsValidValue("Time", value));
        }

        [Fact]
        public void Test_TimeValidationFalse()
        {
            var value = "3";
            Assert.False(TypesValidator.IsValidValue("Time", value));
        }

        [Fact]
        public void Test_TimeInvlTrue()
        {
            var value = "21:00-21:05";
            Assert.True(TypesValidator.IsValidValue("TimeInvl", value));
        }

        [Fact]
        public void Test_TimeInvlFalse1() //left part > right part
        {
            var value = "14:00-12:00";
            Assert.False(TypesValidator.IsValidValue("TimeInvl", value));
        }

        public void Test_TimeInvlFalse2() //wrong separator
        {
            var value = "14:00;12:00";
            Assert.False(TypesValidator.IsValidValue("TimeInvl", value));
        }
        public void Test_TimeInvlFalse3() //equals parts
        {
            var value = "14:00-14:00";
            Assert.False(TypesValidator.IsValidValue("TimeInvl", value));
        }


    }
}
