using System;

namespace Database.Data
{
    public enum DbType
    {
        varchar = 0,
        number = 0
    }

    public static class DbTypeHelpers
    {
        public static DbType GetDbType(Type mapType)
        {
            switch(Type.GetTypeCode(mapType))
            {
                case TypeCode.String:
                    return DbType.varchar;
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                    return DbType.number;
                default:
                    throw new InvalidOperationException($"Could not map the type {mapType.FullName} to DbType");
            }
        }
    }
}