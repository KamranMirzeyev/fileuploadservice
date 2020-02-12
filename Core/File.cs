using System;

namespace Core
{
    public class File: BaseEntity
    {
        public int Id {get;set;}
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}
