using System;
using Newtonsoft.Json;

namespace CLientServerUtil
{
    class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }

        // Create the JSON representation of object
        // See also: https://stackoverflow.com/questions/17038810/newtonsoft-json-deserialize


        public string ToJSON()
        {
            return JsonConvert.SerializeObject(this);

            #region similar to:
            //string str = "{";
            //str += "'name': '" + Name;
            //str += "','email': '" + Email;
            //str += "','message': '" + Message;

            //str += "'}";
            //return str;
#endregion
        }
    }
}
