using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursusOverzichtApi.Models
{
    public class Cursus
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string CursusCode { get; set; }
        public int Duur { get; set; }
        public List<Cursusinstantie> cursusinstanties { get; set; }

        public Cursus(string titel, string cursusCode, int duur) {
            this.Titel = titel;
            this.CursusCode = cursusCode;
            this.Duur = duur;
        }
    }
}
