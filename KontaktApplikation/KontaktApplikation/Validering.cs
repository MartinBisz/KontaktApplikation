using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace KontaktApplikation
{
    //En egen klass för validering utav data användaren matar in. En validering för var typ av data.
    //Fick lägga till ytterligare en Reference för detta. Den sista i listan using
    public static class Validering
    {
        public static bool ValideraMenyVal(int val)
        {
            var r = new RegularExpressionAttribute("[1-6]{1}");
            return r.IsValid(val);
        }

        public static bool ValideraMenyValSök(int val)
        {
            var r = new RegularExpressionAttribute("[1-7]{1}");
            return r.IsValid(val);
        }


        public static bool ValideraNamn(string val)
        {
            var r = new RegularExpressionAttribute("[ a-ézåäö]{3,25}");
            return r.IsValid(val);
        }
        public static bool ValideraENamn(string val)
        {
            var p = new RegularExpressionAttribute("[ a-ézåäö]{3,25}");
            return p.IsValid(val);
        }
        public static bool ValideraAdress(string val)
        {
            var r = new RegularExpressionAttribute("[a-zåäö 0-9]{0,40}");
            return r.IsValid(val);
        }
        public static bool ValideraMobilNummer(string val)
        {
            var r = new RegularExpressionAttribute("[ 0-9- ]{0,20}");
            return r.IsValid(val);
        }
        public static bool ValideraHemNummer(string val)
        {
            var r = new RegularExpressionAttribute("[0-9- ]{0,20}");
            return r.IsValid(val);
        }
        public static bool ValideraJobbNummer(string val)
        {
            var r = new RegularExpressionAttribute("[0-9- ]{0,20}");
            return r.IsValid(val);
        }
        public static bool ValideraKategori(string val)
        {
            var r = new RegularExpressionAttribute("[a-zåäö ]{0,20}");
            return r.IsValid(val);
        }
        // metoder utifall inmatningen blir felaktig.
        public static void Unvalid()
        {
            Console.WriteLine("Ogiltigt format. Försök igen.");
        }

        public static void FelSök()
        {
            Console.WriteLine("Din sökträff gav inga träffar");
        }
    }
}
