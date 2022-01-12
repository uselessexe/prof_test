using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ComplexPrototype
{
    class TestHistory
    {

        public string Statistics { get; set; }
        public DateTime Date { get; set; }
        public TestHistory(){}


        public List<TestHistory> JsonParse(string result)
        {
            List<TestHistory> deserializedProduct = JsonConvert.DeserializeObject<List<TestHistory>>(result);
            return deserializedProduct;
        }
    }
}
