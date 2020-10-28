using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontaktApplikation
{
    class KontaktPerson
    {
        //Instansvariablar för vad vi anser en kontakt ska inneha
        public string Namn { get; set; }
        public string Efternamn { get; set; }
        public string Adress { get; set; }
        public string MobilNummer { get; set; }
        public string HemNummer { get; set; }
        public string JobbNummer { get; set; }
        public string Kategori { get; set; }

        //Konstruktoverload. Utifall en kontakt inte har tex jobbnummer.
        public KontaktPerson(string Namn, string Efternamn, string Adress, string MobilNummer)
        {
            this.Namn = Namn;
            this.Efternamn = Efternamn;
            this.Adress = Adress;
            this.MobilNummer = MobilNummer;
        }
        public KontaktPerson(string Namn, string Efternamn, string Adress, string MobilNummer, string Kategori)
        {
            this.Namn = Namn;
            this.Efternamn = Efternamn;
            this.Adress = Adress;
            this.MobilNummer = MobilNummer;
            this.Kategori = Kategori;
        }
        public KontaktPerson(string Namn, string Efternamn, string Adress, string MobilNummer, string HemNummer, string Kategori)
        {
            this.Namn = Namn;
            this.Efternamn = Efternamn;
            this.Adress = Adress;
            this.MobilNummer = MobilNummer;
            this.HemNummer = HemNummer;
            this.Kategori = Kategori;
        }
        public KontaktPerson(string Namn, string Efternamn, string Adress, string MobilNummer, string HemNummer, string JobbNummer, string Kategori)
        {
            this.Namn = Namn;
            this.Efternamn = Efternamn;
            this.Adress = Adress;
            this.MobilNummer = MobilNummer;
            this.HemNummer = HemNummer;
            this.JobbNummer = JobbNummer;
            this.Kategori = Kategori;
        }

        //Metdo för att visa en specifik kontakt
        public override string ToString()
        {
            return $"Namn: {Namn}\nEFternamn: {Efternamn}\nAdress: {Adress}\nMobilnummer: {MobilNummer}\nHemnummer: {HemNummer}\nJobbnummer: {JobbNummer}\nKategori: {Kategori}\n----------------------------------";
        }

    }
}
