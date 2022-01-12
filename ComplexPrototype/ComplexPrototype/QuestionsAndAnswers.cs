using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ComplexPrototype
{
    class QuestionsAndAnswers
    {
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public int TestID { get; set; }
        public int QuestionNumber { get; set; }
        public int AnswerID { get; set; }
        public string AnswerText { get; set; }
        public int ResultID { get; set; }
        public List<QuestionsAndAnswers> JsonParse(string result)
        {
            List<QuestionsAndAnswers> deserializedProduct = JsonConvert.DeserializeObject<List<QuestionsAndAnswers>>(result);
            return deserializedProduct;
        }
    }
}
