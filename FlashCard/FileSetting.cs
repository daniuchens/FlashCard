using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace FlashCard
{
    /// <summary>
    /// 將程式設定記錄在檔案中
    /// </summary>
    public static class FileSetting
    {
        private const string filePath = "setting.json";

        public static Setting Load()
        {
            if (!File.Exists(filePath))
            {
                return new Setting() { CurrentPath = "" };
            }

            string jsonString = File.ReadAllText(filePath, Encoding.UTF8);
            return JsonConvert.DeserializeObject<Setting>(jsonString);
        }

        public static void Save(Setting setting)
        {
            string jsonString = JsonConvert.SerializeObject(setting);
            File.WriteAllText(filePath, jsonString, Encoding.UTF8);
        }
    }
}