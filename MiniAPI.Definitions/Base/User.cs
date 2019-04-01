using System;
using System.Collections.Generic;
using System.Text;

namespace MiniAPI.Definitions.Base
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public int inactivity { get; set; }
    }
}
