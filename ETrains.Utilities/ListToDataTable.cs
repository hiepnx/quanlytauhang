using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
namespace ETrains.Utilities
{
    public static class ListToDataTable
    {
        public static DataTable ToDataTable<T>(this List<T> list)
        {
            DataTable dt = new DataTable();
            if (list.Count > 0)
            {
                Type listType = list.ElementAt(0).GetType();
                //Get element properties and add datatable columns  
                PropertyInfo[] properties = listType.GetProperties();
                foreach (PropertyInfo property in properties)
                    dt.Columns.Add(new DataColumn() { ColumnName = property.Name });
                foreach (object item in list)
                {
                    DataRow dr = dt.NewRow();
                    foreach (DataColumn col in dt.Columns)
                        dr[col] = listType.GetProperty(col.ColumnName).GetValue(item, null);
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
    }
}
