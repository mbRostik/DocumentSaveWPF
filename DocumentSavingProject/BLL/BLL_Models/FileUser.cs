﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL_Models
{
    public class FileUser
    {
        public int ENTE {  get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int PROGRESSIVO { get; set; }

        public string CODFISC { get; set; } = null;
    }
}
