using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class JsonConverter
    {
        public static string GetChatInJson(AppGlobal _global)
        {
            return JsonConvert.SerializeObject(_global.GetChat());
        }

        public static List<string> SetWordList()
        {
            return  JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(Environment.CurrentDirectory + @"..\..\..\Resource\WordList.json"));
        }
    }
}
