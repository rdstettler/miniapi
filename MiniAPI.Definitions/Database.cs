using System;
using System.Collections.Generic;
using System.Text;

namespace MiniAPI.Definitions
{
    public class Database
    {
        public string[] Values { get; set; } // or any other type
        public string[] Values2 { get; set; } // or any other type
    }
}

/*
So the json file has to have basically this format

{
    "Values" : [
        {
            // anything
        }, 
        {
            // anything
        }, 
    ],
    "Values2" : [
        ....
    ]
}

 * */
