using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ComplexPrototype
{
    class Tests
    {
        public string TestName { get; set; }
        public Tests() { }

        public List<Tests> JsonParse(string result)
        {
            List<Tests> deserializedProduct = JsonConvert.DeserializeObject<List<Tests>>(result);
            return deserializedProduct;
        }
    }
}
