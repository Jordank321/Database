using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Database.Data
{
    internal class TableMetadata
    {
        public TableMetadata(Table table)
        {
            var columnsProps = table.GetType().GetProperties(BindingFlags.Public)
                .Where(prop => prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(decimal) || prop.PropertyType == typeof(string));
            
            foreach (var prop in columnsProps)
            {
                Columns.Add(new ColumnMetadata{
                    Type = DbTypeHelpers.GetDbType(prop.PropertyType)
                });
            }            
        }
        
        public ColumnMetadata IdColumn { get; set; }
        public List<ColumnMetadata> Columns { get; set; }
    }

    internal class ColumnMetadata
    {
        public DbType Type { get; set; }
    }    
}