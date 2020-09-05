namespace FlashCard
{
    /// <summary>
    /// 記錄目前設定
    /// </summary>
    public class Setting
    {
        public string CurrentPath { get; set; }

        public SortType SortType { get; set; }

        public DisplayMode DisplayMode { get; set; }
    }
}