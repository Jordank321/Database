using System;
using System.Collections.Generic;
using System.Linq;

namespace Database.Data
{
    public class Table<TRow>
    {
        public string Name { get; set; }
        public IQueryable<TRow>[] Rows { get; set; }
    }
}
