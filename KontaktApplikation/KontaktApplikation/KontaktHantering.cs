using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontaktApplikation
{
    class KontaktHantering
    {
        //Property för Listan samt användaren utav listan.
        public KontaktPerson Ägare { get; set; }
        public List<KontaktPerson> KontaktLista { get; set; }


        public KontaktHantering(KontaktPerson person)
        {
            this.Ägare = Ägare;
            this.KontaktLista = new List<KontaktPerson>();
        }

        public KontaktPerson VisaÄgare()
        {
            return this.Ägare;
        }

        //Metoder för att lägga till en kontakt i listan. Metodoverload utifall en kontakt kanske inte har Hemnummer
        public void LäggTillKontakt(string Namn, string Efternamn, string Adress, string MobilNummer)
        {
            KontaktLista.Add(new KontaktPerson(Namn, Efternamn, Adress, MobilNummer));
        }
        public void LäggTillKontakt(string Namn, string Efternamn, string Adress, string MobilNummer, string Kategori)
        {
            KontaktLista.Add(new KontaktPerson(Namn, Efternamn, Adress, MobilNummer, Kategori));
        }
        public void LäggTillKontakt(string Namn, string Efternamn, string Adress, string MobilNummer, string HemNummer, string Kategori)
        {
            KontaktLista.Add(new KontaktPerson(Namn, Efternamn, Adress, MobilNummer, HemNummer, Kategori));
        }
        public void LäggTillKontakt(string Namn, string Efternamn, string Adress, string MobilNummer, string HemNummer, string JobbNummer, string Kategori)
        {
            KontaktLista.Add(new KontaktPerson(Namn, Efternamn, Adress, MobilNummer, HemNummer, JobbNummer, Kategori));
        }

        //Metod för att lista upp alla befintliga kontakter samt innehavaren utav listan.
        public void ListaKontakter()
        {
            Console.Clear();
            foreach (var item in KontaktLista)
            {
                Console.WriteLine(item);
                Console.WriteLine("----------------------------------");
            }
        }

        public void ListauppÄgare()
        {
            Console.WriteLine(Ägare);
        }

        //Sökmetoder att kunna söka efter kontakten via Namn, Adress, Mobilnr, Hemnr eller Jobbnr samt kategori, listar bara en person per sök.

        public KontaktPerson SökViaNamn(string value)
        {
            return KontaktLista.Find(e => e.Namn == value.ToLower());
        }
        public KontaktPerson SökViaENamn(string value)
        {
            return KontaktLista.Find(e => e.Efternamn == value.ToLower());
        }
        public KontaktPerson SökViaAdress(string value)
        {
            return KontaktLista.Find(e => e.Adress == value.ToLower());
        }
        public KontaktPerson SökViaMobil(string value)
        {
            return KontaktLista.Find(e => e.MobilNummer == value.ToLower());
        }
        public KontaktPerson SökViaHemNr(string value)
        {
            return KontaktLista.Find(e => e.HemNummer == value.ToLower());
        }
        public KontaktPerson SökViaJobbNr(string value)
        {
            return KontaktLista.Find(e => e.JobbNummer == value.ToLower());
        }
        public KontaktPerson SökViaKategori(string value)
        {
            return KontaktLista.Find(e => e.Kategori == value.ToLower());
        }
    }
}
