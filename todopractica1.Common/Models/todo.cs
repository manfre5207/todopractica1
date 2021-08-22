using System;

namespace todopractica1.Common.Models
{
    public class todo
    {
        public DateTime CreatedTime { get; set; }
        public string TaskDescription { get; set; }
        public bool IsComplete { get; set; }
    }
}
