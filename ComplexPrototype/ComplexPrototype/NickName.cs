using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ComplexPrototype
{
    class NickName
    {
        public string Login { get; set; }

        public NickName()
        {
        }
        public NickName JsonParse(string result)
        {
            NickName deserializedProduct = JsonConvert.DeserializeObject<NickName>(result);
            return deserializedProduct;
        }
    }
}
