using MiniAPI.Definitions;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;


namespace MiniAPI.Repository
{
    public class BaseRepository : IDisposable
    {
        Database d;
        StreamReader sr;
        StreamWriter sw;
        private readonly string filePath = @"C:\path\wannabeDB.json";

        public BaseRepository()
        {
            sr = File.OpenText(filePath);
            string json = sr.ReadToEnd();
            d = JsonConvert.DeserializeObject<Database>(json);
            sr.Dispose();
        }

        private void SaveDatabase()
        {
            string json = JsonConvert.SerializeObject(d);
            sw = new StreamWriter(filePath, false);
            sw.Write(json);
            sw.Dispose();
        }

        public T ReadValue<T>(string variable)
        {
            PropertyInfo prop = typeof(Database).GetProperty(variable);
            if (prop == null)
                return default(T);
            T value = (T)prop.GetValue(d, null);
            return value;
        }

        public void WriteValue<T>(string variable, T value)
        {
            PropertyInfo prop = typeof(Database).GetProperty(variable);
            if (prop != null)
                prop.SetValue(d, value);
            SaveDatabase();
        }

        public void Dispose()
        {

        }
    }
}
