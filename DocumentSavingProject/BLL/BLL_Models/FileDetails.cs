using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL_Models
{
    public class FileDetails
    {
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string FileExtension { get; set; }
        public string FileName { get; set; }
    }
}
