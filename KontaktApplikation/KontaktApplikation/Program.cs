using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KontaktApplikation
{
    class Program
    {
        static KontaktPerson person1 = new KontaktPerson("Basgrupp TRE", "Bettorpsvägen 10", "333", "333333", "333333333", "Fullstackutvecklare");
        static KontaktHantering minLista = new KontaktHantering(person1);

        KontaktPerson projektledare = new KontaktPerson("Seija", "Juntunen", "Slottstornet", "0705311410");
        

        static void Main(string[] args)
        {
            //Klart våran app ska ha våra kontaktuppgifter
            minLista.LäggTillKontakt("seija", "juntunen", "slottstornet", "0705311410");
            minLista.LäggTillKontakt("mikaela", "nyström", "förlossningsavdelningen", "0707174314");
            minLista.LäggTillKontakt("kardo", "rahim", "köpingståget", "0707141600");
            minLista.LäggTillKontakt("tobias", "persson", "surfgärdet 18", "0700708145");
            minLista.LäggTillKontakt("martin", "biszczak", "under en sten", "0781520247");

            for (;;)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("Skriv en siffra av vad du vill göra och tryck Enter");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("[1] = Skapa kontakt\n[2] = Lista alla kontakter\n[3] = Sök upp en kontakt\n[4] = Ändra en kontakt.\n[5] = Visa ägare av kontaktlista.\n[6] = Avsluta applikationen.");
                Console.WriteLine("--------------------------------------------------");

                int val = int.TryParse(Console.ReadLine(), out val) ? val: 0;
                if (Validering.ValideraMenyVal(val))
                {


                    switch (val)
                    {
                        case 1:
                            {
                                Console.Clear();
                                AddaKontakt();
                                break;
                            }
                        case 2:
                            {
                                Console.Clear();
                                minLista.ListaKontakter();
                                Console.Write("Tryck på en tangent för att gå till huvudmenyn");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        case 3:
                            {
                                Console.Clear();
                                SökaBlandKontakter();
                                break;
                            }
                        case 4:
                            {
                                Console.Clear();
                                ÄndraKontakt();
                                break;
                            }
                        case 5:
                            {
                                Console.Clear();
                                Console.WriteLine(person1);
                                Console.Write("Tryck på en tangent för att gå till huvudmenyn");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        case 6:
                            {
                                Environment.Exit(1);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Vänligen väl bland alternativen");
                                break;
                            }
                    }
                } else
                {
                    Console.WriteLine("Välj en siffra ur menyn");
                }
                
            }
        }

        //Metod för att lägga till en kontakt i listan. Validerar allt från valideringsklassen och dess metoder för varje steg
        // och loopar tillbaka ifall inmatningen inte är korrekt.
        
        // Man kan inte lägga in fler än en användare med blankt telefonnummer.
        public static void AddaKontakt()
        {
            string Namn;
            string Efternamn;
            string Adress;
            string MobilNummer;
            string HemNummer;
            string JobbNummer;
            string Kategori;

            Console.WriteLine("Fyll i informationsfälten, använd endast små bokstäver. Tryck Enter för att gå vidare eller för att hoppa över ett steg.");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            do
            {
                Console.Write("Namn: ");
                Namn = Console.ReadLine().ToLower();
                if (!Validering.ValideraNamn(Namn))
                {
                    Validering.Unvalid();
                }
            }
            while (Validering.ValideraENamn(Namn) == false );
            do
            {
                Console.Write("Efternamn: ");
                Efternamn = Console.ReadLine().ToLower();
                if (!Validering.ValideraENamn(Efternamn))
                {
                    Validering.Unvalid();
                }
            }
            while (Validering.ValideraNamn(Efternamn) == false);

            do
            {
                Console.Write("Adress: ");
                Adress = Console.ReadLine().ToLower();
                if (!Validering.ValideraAdress(Adress))
                {
                    Validering.Unvalid();
                }
            }
            while (Validering.ValideraAdress(Adress) == false);
            do
            {
                Console.Write("Mobilnummer: ");
                MobilNummer = Console.ReadLine();
                if (!Validering.ValideraMobilNummer(MobilNummer))
                {
                    Validering.Unvalid();
                }
            }
            while (Validering.ValideraMobilNummer(MobilNummer) == false);
            do
            {
                Console.Write("Hemnummer: ");
                HemNummer = Console.ReadLine();
                if (!Validering.ValideraHemNummer(HemNummer))
                {
                    Validering.Unvalid();
                }
            }
            while (Validering.ValideraHemNummer(HemNummer) == false);
            do
            {
                Console.Write("Jobbnummer: ");
                JobbNummer = Console.ReadLine();
                if (!Validering.ValideraJobbNummer(JobbNummer))
                {
                    Validering.Unvalid();
                }
            }
            while (Validering.ValideraJobbNummer(JobbNummer) == false);
            do
            {
                Console.Write("Kategori: ");
                Kategori = Console.ReadLine().ToLower();
                if (!Validering.ValideraKategori(Kategori))
                {
                    Validering.Unvalid();
                }
            }
            while (Validering.ValideraKategori(Kategori) == false);

            //en ifsats med en metod för att inte kunna skapa en dubblet som innehåller samma mobil, jobb eller hemnummer
            if (!minLista.KontaktLista.Exists(e => e.MobilNummer == MobilNummer) || !minLista.KontaktLista.Exists(e => e.JobbNummer == JobbNummer)
                || !minLista.KontaktLista.Exists(e => e.HemNummer == HemNummer))
            
            {
                minLista.LäggTillKontakt(Namn, Efternamn, Adress, MobilNummer, HemNummer, JobbNummer, Kategori);
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("Kontakt skapad. Tryck på valfri tangent för att komma till huvudmenyn");
                Console.WriteLine("---------------------------------------------------------------------");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Du har försökt skapa en dubblet");
            }
            
        }

        //Metod innehållande switch för att söka bland olika kontakter
        public static void SökaBlandKontakter()
        {
            Console.WriteLine("Välj bland alternativ på hur du vill söka fram en kontakt");
            Console.WriteLine("[1] = Sök via Namn\n[2] = Sök via efternamn\n[3] = Sök via Adress\n[4] = Sök via Mobilnummer\n[5] = Sök via Hemnummer\n[6] = Sök via Jobbnummer\n[7] = Sök via Kategori");

            int val = int.TryParse(Console.ReadLine(), out val) ? val : 0;
            Console.Clear();
            string valText;
            if (Validering.ValideraMenyValSök(val))
            {
                switch (val)
                {
                    case 1:
                        {
                            Console.Write("Skriv Namnet på den du söker: ");
                            valText = Console.ReadLine();
                            if (minLista.KontaktLista.Exists(e => e.Namn == valText.ToLower()))
                            {
                                var x = minLista.SökViaNamn(valText);
                                Console.Clear();
                                Console.WriteLine("Träff som matchar din sökning");
                                Console.WriteLine("-----------------------------");
                                Console.WriteLine(x.ToString());
                                Console.WriteLine("Tryck på en tangent för att gå till huvudmenyn");
                                Console.ReadKey();
                                Console.Clear();
                                
                            }
                            else
                            {
                                Validering.FelSök();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Skriv Efternamnet på den du söker: ");
                            valText = Console.ReadLine();
                            if (minLista.KontaktLista.Exists(e => e.Efternamn == valText.ToLower()))
                            {
                                var t = minLista.SökViaENamn(valText);
                                Console.Clear();
                                Console.WriteLine("Träff som matchar din sökning");
                                Console.WriteLine("-----------------------------");
                                Console.WriteLine(t.ToString());
                                Console.WriteLine("Tryck på en tangent för att gå till huvudmenyn");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Validering.FelSök();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.Write("Skriv Adressen du vill söka på: ");
                            valText = Console.ReadLine();
                            if (minLista.KontaktLista.Exists(e => e.Adress == valText.ToLower()))
                            {
                                var y = minLista.SökViaAdress(valText);
                                Console.Clear();
                                Console.WriteLine("Träff som matchar din sökning");
                                Console.WriteLine("-----------------------------");
                                Console.WriteLine(y.ToString());
                                Console.WriteLine("Tryck på en tangent för att gå till huvudmenyn");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Validering.FelSök();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.Write("Skriv Mobilnummret du söker efter: ");
                            valText = Console.ReadLine();
                            if (minLista.KontaktLista.Exists(e => e.MobilNummer == valText.ToLower()))
                            {
                                var z = minLista.SökViaMobil(valText);
                                Console.Clear();
                                Console.WriteLine("Träff som matchar din sökning");
                                Console.WriteLine("-----------------------------");
                                Console.WriteLine(z.ToString());
                                Console.WriteLine("Tryck på en tangent för att gå till huvudmenyn");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Validering.FelSök();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.Write("Skriv Hemnummret du söker efter: ");
                            valText = Console.ReadLine();
                            if (minLista.KontaktLista.Exists(e => e.HemNummer == valText.ToLower()))
                            {
                                var c = minLista.SökViaHemNr(valText);
                                Console.Clear();
                                Console.WriteLine("Träff som matchar din sökning");
                                Console.WriteLine("-----------------------------");
                                Console.WriteLine(c.ToString());
                                Console.WriteLine("Tryck på en tangent för att gå till huvudmenyn");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Validering.FelSök();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        }
                    case 6:
                        {
                            Console.Write("Skriv Jobbnummret du söker efter: ");
                            valText = Console.ReadLine();
                            if (minLista.KontaktLista.Exists(e => e.JobbNummer == valText.ToLower()))
                            {
                                var v = minLista.SökViaJobbNr(valText);
                                Console.Clear();
                                Console.WriteLine("Träff som matchar din sökning");
                                Console.WriteLine("-----------------------------");
                                Console.WriteLine(v.ToString());
                                Console.WriteLine("Tryck på en tangent för att gå till huvudmenyn");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Validering.FelSök();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        }
                    case 7:
                        {
                            Console.Write("Skriv Kategori du söker efter: ");
                            valText = Console.ReadLine();
                            if (minLista.KontaktLista.Exists(e => e.Kategori == valText.ToLower()))
                            {
                                var t = minLista.SökViaKategori(valText);
                                
                                Console.WriteLine("Träff som matchar din sökning");
                                Console.WriteLine("-----------------------------");
                                Console.WriteLine(t.ToString());
                                Console.WriteLine("Tryck på en tangent för att gå till huvudmenyn");
                                Console.ReadKey();
                                
                            }
                            else
                            {
                                Validering.FelSök();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Vänligen välj ett alternativ mellan 1 - 6");
                            break;
                        }
                }
            } else
            {
                Console.WriteLine("Välj en siffra ur listan.");
            }
        }

        //Metdo för att ändra befintlig kontakt
        public static void ÄndraKontakt()
        {
            
            Console.WriteLine("Välj först vad du skulle vilja ändra med kontakten");
            Console.WriteLine($"[1] = Ändra på namn\n[2] = Ändra efternamnn\n[3] = Ändra adress\n[4] = Ändra mobilnummer\n[5] = Ändra på hemnummer\n[6] = Ändra på jobbnummer");

            int val = int.TryParse(Console.ReadLine(), out val) ? val : 0;
            string valText;
            if (Validering.ValideraMenyVal(val)) 
            {
                switch (val)

                {
                    case 1:
                        Console.WriteLine("Sök upp kontakten genom att skriva förnamn, tryck sedan enter");
                        valText = Console.ReadLine();
                        if (minLista.KontaktLista.Exists(e => e.Namn == valText.ToLower()))
                        {
                            var x = minLista.SökViaNamn(valText);
                            Console.WriteLine("Din sökning hittade kontakt: ");
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine(x.ToString());
                            Console.Write("Skriv nu vad du vill ändra namnet till: ");
                            x.Namn = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine($"Färdigt!");
                            Console.WriteLine("---------------------------");
                            Console.WriteLine(x.ToString());
                            Console.WriteLine("Tryck på valfri tangent för att gå vidare till huvudmenyn");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Validering.FelSök();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Sök upp kontakten genom att skriva förnamnnamn, tryck sedan enter");
                        valText = Console.ReadLine();
                        if (minLista.KontaktLista.Exists(e => e.Namn == valText.ToLower()))
                        {
                            var z = minLista.SökViaNamn(valText);
                            Console.Write("Skriv nu vad du vill ändra efternamnet till: ");
                            z.Efternamn = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine($"Färdigt!");
                            Console.WriteLine("---------------------------");
                            Console.WriteLine(z.ToString());
                            Console.WriteLine("Tryck på valfri tangent för att gå vidare till huvudmenyn");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Validering.FelSök();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Sök upp kontakten genom att skriva förnamn, tryck sedan enter");
                        valText = Console.ReadLine();
                        if (minLista.KontaktLista.Exists(e => e.Namn == valText.ToLower()))
                        {
                            var y = minLista.SökViaNamn(valText);
                            Console.Write("Skriv nu vad du vill ändra adress till: ");
                            y.Adress = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine($"Färdigt!");
                            Console.WriteLine("---------------------------");
                            Console.WriteLine(y.ToString());
                            Console.WriteLine("Tryck på valfri tangent för att gå vidare till huvudmenyn");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Validering.FelSök();
                        }
                        break;
                    case 4:
                        Console.WriteLine("Sök upp kontakten genom att skriva förnamn, tryck sedan enter");
                        valText = Console.ReadLine();
                        if (minLista.KontaktLista.Exists(e => e.Namn == valText.ToLower()))
                        {
                            var v = minLista.SökViaNamn(valText);
                            Console.WriteLine("skriv vad du vill ändra mobilnumret till");
                            v.MobilNummer = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine($"Färdigt!");
                            Console.WriteLine("---------------------------");
                            Console.WriteLine(v.ToString());
                            Console.WriteLine("Tryck på valfri tangent för att gå vidare till huvudmenyn");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Validering.FelSök();
                        }
                        break;
                    case 5:
                        Console.WriteLine("Sök upp kontakten genom att skriva förnamn, tryck sedan enter");
                        valText = Console.ReadLine();
                        if (minLista.KontaktLista.Exists(e => e.Namn == valText.ToLower()))
                        {
                            var c = minLista.SökViaNamn(valText);
                            Console.Write("Skriv nu vad du vill ändra hemnumret till: ");
                            c.HemNummer = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine($"Färdigt!");
                            Console.WriteLine("---------------------------");
                            Console.WriteLine(c.ToString());
                            Console.WriteLine("Tryck på valfri tangent för att gå vidare till huvudmenyn");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Validering.FelSök();
                        }
                        break;

                    case 6:
                        Console.WriteLine("Sök upp kontakten genom att skriva förnamn, tryck sedan enter");
                        valText = Console.ReadLine();
                        if (minLista.KontaktLista.Exists(e => e.Namn == valText.ToLower()))
                        {
                            var c = minLista.SökViaNamn(valText);
                            Console.Write("Skriv nu vad du vill ändra jobbnummret till: ");
                            c.JobbNummer = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine($"Färdigt!");
                            Console.WriteLine("---------------------------");
                            Console.WriteLine(c.ToString());
                            Console.WriteLine("Tryck på valfri tangent för att gå vidare till huvudmenyn");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Validering.FelSök();
                        }
                        break;
                } 
                

                

            } else
            {
                Console.WriteLine("Välj en siffra ur menyn");
            }
        }
    }
}
