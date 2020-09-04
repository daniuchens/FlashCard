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
        private List<string> Words;
        private List<string> OriginalWords;
        private int CurrentNo = 0;

        public Setting Setting { get; set; }


        public WordSet(Setting setting)
        {
            string wordFile = setting.CurrentFile;
            this.Setting = setting;

            if (string.IsNullOrEmpty(wordFile) || !File.Exists(wordFile))
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
                #endregion

                this.Setting.CurrentFile = "";
                this.OriginalSort();
            } 
            else
            {
                ImportFile(wordFile);
            }
        }

        public string GetCurrentWord()
        {
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

        public string GetFirstWord()
        {
            this.CurrentNo = 0;
            return this.Words[CurrentNo];
        }

        public void OriginalSort()
        {
            this.Words = this.OriginalWords.Select(x => x).ToList();
            this.CurrentNo = 0;
            this.Setting.SortType = SortType.Original;
        }

        public void ReverseSort()
        {
            this.Words = this.OriginalWords.Select(x => x).Reverse().ToList();
            this.CurrentNo = 0;
            this.Setting.SortType = SortType.Reverse;
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

        public void ImportFile(string fileName)
        {
            //讀出所有內容.
            string fileText = File.ReadAllText(fileName, Encoding.Default);

            //移除所有的\r\n
            fileText = fileText.Replace("\r\n", "");

            //每個指令去除頭尾的空白
            OriginalWords = fileText.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            this.Setting.CurrentFile = fileName;

            switch(this.Setting.SortType)
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
