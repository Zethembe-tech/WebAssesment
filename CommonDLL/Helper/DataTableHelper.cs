//using CommonDLL.DTO;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CommonDLL.Helper
//{
//    public class DataTableHelper
//    {

//        public static DataTable GetDataTable(List<string> strings)
//        {
//            var table = new DataTable();
//            table.Columns.Add("Value", typeof(string));

//            if (strings == null)
//            {
//                return table;
//            }

//            foreach (var str in strings)
//            {
//                table.Rows.Add(str);
//            }

//            return table;
//        }

//        //public static DataTable GetDataTable(List<int> strings)
//        //{
//        //    var table = new DataTable();
//        //    table.Columns.Add("string", typeof(string));
//        //    if (strings == null)
//        //    {
//        //        return table;
//        //    }

//        //    foreach (var stri in strings)
//        //    {
//        //        table.Rows.Add(stri);
//        //    }
//        //    return table;

//        //}

//        //public static DataTable GetKeyValueDataTable(List<DynamicFormDTO> formdata)
//        //{
//        //    var table = new DataTable();
//        //    table.Columns.Add("key", typeof(string));
//        //    table.Columns.Add("value", typeof(string));
//        //    if (formdata == null)
//        //    {
//        //        return table;
//        //    }

//        //    foreach (var stri in formdata)
//        //    {
//        //        table.Rows.Add(stri.Key, stri.Value);
//        //    };

//        //    return table;

//        //}

//    }
//}
