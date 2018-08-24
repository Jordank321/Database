using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Database.Data
{
    public abstract class Table<TRow> : Table
    {
        private string _baseTablePath = null;
        private TableMetadata _metadata;
        private TableData<TRow> _data;

        internal async Task Initialise(string baseDirectory)
        {
            _baseTablePath = Path.Combine(baseDirectory, this.GetType().Name);
            
            if (!Directory.Exists(_baseTablePath)) Directory.CreateDirectory(_baseTablePath);
            else
            {
                await SetupMetadata();
                SetupCore();
            }
        }

        public TRow FindById(object id){
            if (_metadata.IdColumn.Type != DbTypeHelpers.GetDbType(id.GetType()))
                throw new ArgumentException($"Could not map the type {id.GetType().FullName} to the Id column DB type {_metadata.IdColumn.Type.ToString()}");

            return _data.FindRow(id);
        }

        private void SetupCore()
        {
            var path = Path.Combine(_baseTablePath, "table.mdb");
            if (!File.Exists(path)) File.Create(path);
            _data = new TableData<TRow>(_metadata, path);
        }

        private async Task SetupMetadata()
        {
            using (var stream = new StreamWriter(File.OpenWrite(Path.Combine(_baseTablePath, "meta.json"))))
            {
                _metadata = new TableMetadata(this);
                var json = JsonConvert.SerializeObject(_metadata);
                await stream.WriteAsync(json);
            }            
        }
    }

    internal class TableData<TRow>
    {
        private  readonly TableMetadata _metadata;
        private readonly string _pathToTableData;

        public TableData(TableMetadata metadata, string pathToTableData)
        {
            _metadata = metadata;
            _pathToTableData = pathToTableData;
        }

        internal Task WriteRowAsync(StreamWriter stream, long rowNum)
        {
            return Task.CompletedTask;
            // TODO: Write row data to linear lenght db file
        }

        public TRow FindRow(object key)
        {
            var location = GetRowLocation(key);
            return GetByLocation(location);
        }

        private long GetRowLocation(object key)
        {

        }

        private TRow GetByLocation(long location)
        {

        }
    }

    public abstract class Table
    {
    }
}
