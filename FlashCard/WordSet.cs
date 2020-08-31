using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public WordSet()
        {
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

            this.OriginalSort();
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

        public void OriginalSort()
        {
            this.Words = this.OriginalWords.Select(x => x).ToList();
            this.CurrentNo = 0;
        }

        public void ReverseSort()
        {
            this.Words = this.OriginalWords.Select(x => x).Reverse().ToList();
            this.CurrentNo = 0;
        }

        public void RandomSort()
        {
            List<string> oldWords = this.Words;
            this.Words = new List<string>();
            Random rand = new Random();

            for (int i = this.OriginalWords.Count; i > 0; i--)
            {
                int iChose = rand.Next(0, i);
                this.Words.Add(oldWords[iChose]);
                oldWords.Remove(oldWords[iChose]);
            }

            this.CurrentNo = 0;
        }
    }
}
