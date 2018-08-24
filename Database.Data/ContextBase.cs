using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Data
{
    public abstract class ContextBase
    {
        public ContextBase(string baseDirectory){
            BaseDirectory = baseDirectory;

        }
        public string BaseDirectory { get; }

        private bool _initialised;
        private readonly IList<Table> _tables;

        public abstract Task Initialise();

        public void RegisterTable<T>(Table<T> table)
        {
            table.Initialise(BaseDirectory);
            _tables.Add(table);
        }
    }
}