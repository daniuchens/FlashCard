using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FlashCard
{
    /// <summary>
    /// 儲存字卡內容的物件
    /// </summary>
    public class WordSet
    {
        private int CurrentNo = 0;
        private List<string> OriginalWords;
        private List<string> Words;

        public WordSet(Setting setting)
        {
            this.Setting = setting;

            if (setting.DisplayMode == DisplayMode.ImageFolder && ImportImageFolder(setting.CurrentPath))
            {
                return;
            }
            else if (string.IsNullOrEmpty(setting.CurrentPath) || !File.Exists(setting.CurrentPath))
            {
                InitialDefaultText();
            }
            else
            {
                ImportFile(setting.CurrentPath);
            }
        }

        public Setting Setting { get; private set; }

        public string GetCurrentWord()
        {
            return this.Words[CurrentNo];
        }

        public string GetFirstWord()
        {
            this.CurrentNo = 0;
            return this.Words[CurrentNo];
        }

        public string GetNextWord()
        {
            this.CurrentNo = (this.CurrentNo + 1) % this.Words.Count;
            return this.Words[CurrentNo];
        }

        public string GetPreviousWord()
        {
            this.CurrentNo = (this.Words.Count + this.CurrentNo - 1) % this.Words.Count;
            return this.Words[CurrentNo];
        }

        public void ImportFile(string fileName)
        {
            //讀出所有內容.
            string fileText = File.ReadAllText(fileName, Encoding.Default);

            //移除所有的\r\n
            fileText = fileText.Replace("\r\n", "");

            //每個指令去除頭尾的空白
            OriginalWords = fileText.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            this.Setting.CurrentPath = fileName;
            this.Setting.DisplayMode = DisplayMode.TextFile;
            this.SettingSort();

            this.Setting.RememberRecentPath(fileName, DisplayMode.TextFile);
        }

        public bool ImportImageFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                return false;
            }

            DirectoryInfo folder = new DirectoryInfo(folderPath);

            List<string> imageFiles = new List<string>();
            foreach (var file in folder.GetFiles("*.*").OrderBy(x => x.Name))
            {
                //檢查是否為BitMap所支援的圖檔
                if (!ImageHelper.IsImageFile(file.Extension))
                {
                    continue;
                }

                imageFiles.Add(file.FullName);
            }

            //都沒有圖檔的時候，載入失敗.
            if (imageFiles.Count == 0)
            {
                return false;
            }

            //文字檔改成存檔案路徑
            this.OriginalWords = imageFiles;
            this.Setting.CurrentPath = folderPath;
            this.Setting.DisplayMode = DisplayMode.ImageFolder;
            this.SettingSort();

            this.Setting.RememberRecentPath(folderPath, DisplayMode.ImageFolder);

            return true;
        }

        public void OriginalSort()
        {
            this.Words = this.OriginalWords.Select(x => x).ToList();
            this.CurrentNo = 0;
            this.Setting.SortType = SortType.Original;
        }

        public void RandomSort()
        {
            List<string> oldWords = this.OriginalWords.Select(x => x).ToList();
            this.Words = new List<string>();
            Random rand = new Random();

            for (int i = this.OriginalWords.Count; i > 0; i--)
            {
                int iChose = rand.Next(0, i);
                this.Words.Add(oldWords[iChose]);
                oldWords.Remove(oldWords[iChose]);
            }

            this.CurrentNo = 0;
            this.Setting.SortType = SortType.Random;
        }

        public void ReverseSort()
        {
            this.Words = this.OriginalWords.Select(x => x).Reverse().ToList();
            this.CurrentNo = 0;
            this.Setting.SortType = SortType.Reverse;
        }

        private void InitialDefaultText()
        {
            #region 當沒有任何字集檔時，給予一個初始值

            this.OriginalWords = new List<string>() {
                    "A a",
                    "B b",
                    "C c",
                    "D d",
                    "E e",
                    "F f",
                    "G g",
                    "H h",
                    "I i",
                    "J j",
                    "K k",
                    "L l",
                    "M m",
                    "N n",
                    "O o",
                    "P p",
                    "Q q",
                    "R r",
                    "S s",
                    "T t",
                    "U u",
                    "V v",
                    "W w",
                    "X x",
                    "Y y",
                    "Z z",
                };

            #endregion 當沒有任何字集檔時，給予一個初始值

            this.Setting.CurrentPath = "";
            this.SettingSort();
            this.Setting.DisplayMode = DisplayMode.TextFile;
        }

        private void SettingSort()
        {
            switch (this.Setting.SortType)
            {
                case SortType.Reverse:
                    ReverseSort();
                    break;

                case SortType.Random:
                    RandomSort();
                    break;

                default:
                    OriginalSort();
                    break;
            }
        }
    }
}