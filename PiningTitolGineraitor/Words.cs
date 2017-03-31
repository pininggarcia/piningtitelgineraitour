using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace PiningTitolGineraitor
{
    class Words
    {
        private static Random rnd = new Random();
        IEnumerable<string> nouns;
        IEnumerable<string> fillers;
        IEnumerable<string> disgusting;
        IEnumerable<string> disAdj;
        public Words()
        {
            nouns = File.ReadLines("Dicts/nouns.txt");
            fillers = File.ReadLines("Dicts/fillers.txt");
            disgusting = File.ReadLines("Dicts/disgustingNoun.txt");
            disAdj = File.ReadLines("Dicts/adj.txt");
        }
        public string GetNoun()
        {
            int r = rnd.Next(nouns.Count());
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nouns.ElementAt(r));
        }
        public string GetFiller()
        {
            int r = rnd.Next(fillers.Count());
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(fillers.ElementAt(r));
        }
        public string GetDisgustingPhrase()
        {
            var phrase = String.Empty;
            int r = rnd.Next(disAdj.Count());
            phrase += CultureInfo.CurrentCulture.TextInfo.ToTitleCase(disAdj.ElementAt(r)) + " ";
            r = rnd.Next(disgusting.Count());
            phrase += CultureInfo.CurrentCulture.TextInfo.ToTitleCase(disgusting.ElementAt(r));

            return phrase;
        }
    }
}
