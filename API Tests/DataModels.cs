using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Tests
{
    internal class DataModels
    {
        public class user
        {
            [JsonProperty("id")]
            public string id;
            [JsonProperty("first_name")]
            public string first_name;
            [JsonProperty("last_name")]
            public string last_name;
            [JsonProperty("avatar")]
            public string avatar;
        }

        public class general
        {
            [JsonProperty("page")]
            public int page;
            [JsonProperty("per_page")]
            public int per_page;
            [JsonProperty("total")]
            public int total;
            [JsonProperty("total_per_page")]
            public int total_per_page;
            [JsonProperty("data")]
            public List<user> data;
        }

        public class createUserPayload
        {
            [JsonProperty("first_name")]
            private string first_name;
            public string First_name
            {
                get { return first_name; }
                set { first_name = value; }
            }
            [JsonProperty("last_name")]
            private string last_name;
            public string Last_name
            {
                get { return last_name; }
                set { last_name = value; }
            }
        }

        public class updateUserPayload
        {
            [JsonProperty("first_name")]
            private string first_name;
            public string First_name
            {
                get { return first_name; }
                set { first_name = value; }
            }
            [JsonProperty("last_name")]
            private string last_name;
            public string Last_name
            {
                get { return last_name; }
                set { last_name = value; }
            }
        }

    }
}
