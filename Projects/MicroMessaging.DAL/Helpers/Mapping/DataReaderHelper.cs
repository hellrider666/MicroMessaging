using FastMember;
using System.Data.Common;
using System.Reflection;

namespace MicroMessaging.DAL.Helpers.Mapping
{
    public static class DataReaderHelper
    {
        public static List<TObj> MapToList<TObj>(this DbDataReader dataReader)
        {
            List<TObj> currentList = new List<TObj>();

            TObj obj = default(TObj);

            while(dataReader.Read())
            {
                obj = Activator.CreateInstance<TObj>();

                foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
                {
                    if (!Equals(dataReader[propertyInfo.Name], DBNull.Value))
                        propertyInfo.SetValue(obj, dataReader[propertyInfo.Name], null);
                }

                currentList.Add(obj);
            }

            return currentList;
        }
    }
}
