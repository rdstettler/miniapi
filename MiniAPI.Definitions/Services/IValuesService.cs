using System;
using System.Collections.Generic;
using System.Text;

namespace MiniAPI.Definitions.Services
{
    public interface IValuesService
    {
        string[] GetAll();
        string Get(int id);
        string Put(int id, string myObject);
        void Delete(int id);
        string Post(string myObject);
    }
}
