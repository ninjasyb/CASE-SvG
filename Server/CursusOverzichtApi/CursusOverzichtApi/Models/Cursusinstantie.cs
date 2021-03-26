using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursusOverzichtApi.Models
{
    public class Cursusinstantie
    {
        public int Id { get; set; }
        public int cursusId { get; set; }
        public DateTime Startdatum { get; set; }
        
        public Cursusinstantie(int cursusId, DateTime startdatum) {
            this.cursusId = cursusId;
            this.Startdatum = startdatum;
        }
    }
}
