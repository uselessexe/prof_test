using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ComplexPrototype
{
    class Results
    {
        public int ResultID{get;set;}
        public string ResultName { get; set; }
        public int TestID { get; set; }
        public string Description { get; set; }

        public List<Results> JsonParse(string result)
        {
            List<Results> deserializedProduct = JsonConvert.DeserializeObject<List<Results>>(result);
            return deserializedProduct;
        }

    }
}
