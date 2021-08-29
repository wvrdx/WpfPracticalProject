﻿using WpfPracticalProject.Common;

namespace WpfPracticalProject.Models
{
    public class TableToView : ModelsBase
    {
        public int ID { get; set; }
        public string TableName { get; set; }
        public int TableTypeID { get; set; }
        public string TableType { get; set; }
        public string TableStatus { get; set; }
    }
}