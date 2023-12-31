﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataExtractionTool.DataLayer.Models
{
    public class DataExtractionUsers
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public bool ReadOnly { get; set; }
    }
}
