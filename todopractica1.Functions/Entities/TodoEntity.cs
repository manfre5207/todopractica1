﻿using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace todopractica1.Functions.Entities
{
    public class TodoEntity : TableEntity
    {
        public DateTime CreatedTime { get; set; }
        public string TaskDescription { get; set; }
        public bool IsComplete { get; set; }
    }
}