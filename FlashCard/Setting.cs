﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCard
{
    /// <summary>
    /// 記錄目前設定
    /// </summary>
    public class Setting
    {
        public string CurrentFile { get; set; }

        public SortType SortType { get; set; }
    }
}