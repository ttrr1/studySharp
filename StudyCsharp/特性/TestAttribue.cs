using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyCsharp.特性
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribue : Attribute
    {
        public string TableName { set; get; }

        public TableAttribue() { }

        public TableAttribue(string TableName)
        {
            this.TableName = TableName;
        }
    }


    public class IdentityAttribute : Attribute {
        public bool IsIdentity { set; get; }
    }

   [TableAttribue(TableName = "Dept")]  
    public class Department { 
    
    }
}
