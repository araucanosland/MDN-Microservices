using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CDK.Json
{
    public class JsonProcessResult
    {

        private static JsonProcessResult instance;


        public ResultType Result { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public static JsonProcessResult Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JsonProcessResult();
                }
                return instance;
            }
        }

        private JsonProcessResult() { }

    }
}
