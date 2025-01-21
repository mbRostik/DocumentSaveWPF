using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class DOCUMENTO_UPLOAD
    {
        public int ID { get; set; }
        public int? ENTE { get; set; }
        public int? ANNO { get; set; }
        public int? MESE { get; set; }
        public int? SUBMESE { get; set; }
        public byte[] FILE { get; set; }
        public string FILENAME { get; set; }
        public string EXTENSION { get; set; }
        public string DENOMINAZIONE { get; set; }

        public virtual ICollection<DOCUMENTO_UPLOAD_DIPENDENTE> DOCUMENTO_UPLOAD_DIPENDENTEs { get; set; } = new List<DOCUMENTO_UPLOAD_DIPENDENTE>();

    }
}
