using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
namespace StudyCsharp.泛型和反射
{
    class ListToDatatable
    {
        public static DataTable ToDataDable<T>(IList<T> list) {
            //create propertyInfo
            List<PropertyInfo> pList = new List<PropertyInfo>();
            //get reflector interface
            Type type = typeof(T);
            DataTable dt = new DataTable();
            //add datatable column
            Array.ForEach<PropertyInfo>(type.GetProperties(), p =>
            {
                pList.Add(p);
                dt.Columns.Add(p.Name, Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType);//??左边值不为null取左边的值，为null取右边的值
            });
            foreach (var item in list)
            {
                //create new row
                DataRow row = dt.NewRow();
                pList.ForEach(p => row[p.Name] = p.GetValue(item, null) ?? System.DBNull.Value);
                dt.Rows.Add(row);
            }
            return dt;
        } 
    } 
}
