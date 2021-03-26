using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursusOverzichtApi.Models
{
    public class UploadResult
    {
        public int NewCursussen { get; set; }
        public int NewInstanties { get; set; }
        public bool validUpload { get; set; }
    }
}
