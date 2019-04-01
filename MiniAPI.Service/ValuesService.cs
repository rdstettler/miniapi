using Microsoft.Extensions.Options;
using MiniAPI.Definitions;
using MiniAPI.Definitions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniAPI.Service
{
    public class ValuesService : BaseService, IValuesService
    {
        public ValuesService(IOptions<AppSettings> appSettings) : base(appSettings)
        {

        }

        public void Delete(int id)
        {
            string[] values = repository.ReadValue<string[]>("Values"); // use here the same name as in the json Database
            values.ToList().RemoveAt(id);
            repository.WriteValue("Values", values.ToArray());
        }

        public string Get(int id)
        {
            string[] values = repository.ReadValue<string[]>("Values"); // use here the same name as in the json Database
            return values[id];
        }

        public string[] GetAll()
        {
            return repository.ReadValue<string[]>("Values");
        }

        public string Post(string myObject)
        {
            string[] values = repository.ReadValue<string[]>("Values"); // use here the same name as in the json Database
            values.ToList().Add(myObject);
            repository.WriteValue("Values", values.ToArray());
            return myObject;
        }

        public string Put(int id, string myObject)
        {
            List<string> values = repository.ReadValue<string[]>("Values").ToList(); // use here the same name as in the json Database
            values.RemoveAt(id);
            values.Add(myObject);
            repository.WriteValue("Values", values.ToArray());
            return myObject;
        }
    }
}
