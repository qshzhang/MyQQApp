using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQApp.common
{
    public class GlobalDataTable
    {
        public static DataTable GetSexTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("value", Type.GetType("System.Int16"));
            dataTable.Columns.Add("text", Type.GetType("System.String"));

            dataTable.Rows.Add(new object[] { 0, "===not selected===" });
            dataTable.Rows.Add(new object[] { 1, "F" });
            dataTable.Rows.Add(new object[] { 2, "M" });

            return dataTable;
        }

        public static DataTable GetDegreeTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("value", Type.GetType("System.Int16"));
            dataTable.Columns.Add("text", Type.GetType("System.String"));

            dataTable.Rows.Add(new object[] { 0, "===not selected===" });
            dataTable.Rows.Add(new object[] { 1, "Primary" });
            dataTable.Rows.Add(new object[] { 2, "Junior" });
            dataTable.Rows.Add(new object[] { 3, "High" });
            dataTable.Rows.Add(new object[] { 4, "B.S" });
            dataTable.Rows.Add(new object[] { 5, "M.S" });
            dataTable.Rows.Add(new object[] { 6, "Doctor" });

            return dataTable;
        }

    }
}
