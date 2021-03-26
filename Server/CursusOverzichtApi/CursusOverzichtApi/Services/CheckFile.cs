using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursusOverzichtApi.Services
{
    public class CheckFile
    {
        public string ExtractTitle(string line) {
            if(line == null) {
                throw new ArgumentException("De title mag geen null waarde hebben.");
            }
            char[] title = new char[line.Length - 7];
            char[] arr = line.ToCharArray();
            int j = 0;
            for (int i = 7; i < arr.Length; i++) {
                title[j] = arr[i];
                j++;
            }
            string s = new string(title);
            return s;
        }

        public string ExtractCode(string line) {
            if (line == null) {
                throw new ArgumentException("De code mag geen null waarde hebben.");
            }
            char[] code = new char[line.Length - 7];
            char[] arr = line.ToCharArray();
            int j = 0;
            for (int i = 13; i < arr.Length; i++) {
                code[j] = arr[i];
                j++;
            }
            string s = new string(code);
            return s;
        }
        public int ExtractDuur(string line) {
            if (line == null) {
                throw new ArgumentException("De duur van de cursus mag geen null waarde hebben.");
            }
            char[] arr = line.ToCharArray();

            int duur = int.Parse(arr[arr.Length - 7].ToString());
            return duur;
        }
        public DateTime ExtractStartDatum(string line) {
            if (line == null) {
                throw new ArgumentException("De startdatum mag geen null waarde hebben.");
            }
            char[] date = new char[line.Length - 7];
            char[] arr = line.ToCharArray();
            int j = 0;
            for (int i = 13; i < arr.Length; i++) {
                date[j] = arr[i];
                j++;
            }
            string s = new string(date);
            try {
                return DateTime.Parse(s);
            } catch (ArgumentOutOfRangeException) {
                return DateTime.Now;

            }
        }
    }
}
