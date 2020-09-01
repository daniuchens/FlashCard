using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FlashCard
{
    /// <summary>
    /// 將程式設定記錄在檔案中
    /// </summary>
    public class FileSetting
    {
        private const string filePath = "setting.json";
        
        public static Setting LoadFileSetting()
        {
            if(!File.Exists(filePath))
            {
                return new Setting() { CurrentFile = "" };
            }

            string jsonString = File.ReadAllText(filePath, Encoding.UTF8);
            return JsonConvert.DeserializeObject<Setting>(jsonString);
        }

        public static void SaveFileSetting(Setting setting)
        {
            string jsonString = JsonConvert.SerializeObject(setting);
            File.WriteAllText(filePath, jsonString, Encoding.UTF8);
        }
    }
}
