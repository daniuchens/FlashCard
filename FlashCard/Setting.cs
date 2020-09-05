using System.Collections.Generic;
using System.Linq;

namespace FlashCard
{
    /// <summary>
    /// 記錄目前設定
    /// </summary>
    public class Setting
    {
        private const int MaxRememberPathCount = 10;
        public string CurrentPath { get; set; }

        public DisplayMode DisplayMode { get; set; }
        public List<WordPath> RecentPaths { get; set; }
        public SortType SortType { get; set; }

        public void RememberRecentPath(string path, DisplayMode mode)
        {
            if (RecentPaths == null)
            {
                RecentPaths = new List<WordPath>();
            }

            // 如果之前已經有存過了，就先刪掉.
            RemoveFromRecentPaths(path);

            // 最新的加在開頭
            RecentPaths.Insert(0, new WordPath()
            {
                Path = path,
                PathMode = mode
            });

            //如果已經記錄超過了最大限制，就刪掉最後一個(最不常開的)
            if (RecentPaths.Count > MaxRememberPathCount)
            {
                RecentPaths.RemoveAt(MaxRememberPathCount);
            }
        }

        /// <summary>
        /// 從最近記錄檔中刪除指定的路徑(通常用於檔案或路徑已經不存在時)
        /// </summary>
        /// <param name="path"></param>
        public void RemoveFromRecentPaths(string path)
        {
            if (RecentPaths == null || !RecentPaths.Any())
            {
                return;
            }

            int pos = RecentPaths.FindIndex(x => x.Path == path);
            if (pos >= 0)
            {
                RecentPaths.RemoveAt(pos);
            }
        }
    }
}