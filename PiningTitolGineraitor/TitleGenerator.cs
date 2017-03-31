using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace PiningTitolGineraitor
{
    class TitleGenerator
    {
        private static Random rnd = new Random();
        IEnumerable<string> pdTitles;
        Words words;
        public TitleGenerator()
        {
            words = new Words();
            pdTitles = File.ReadLines("Dicts/pdTitles.txt");
        }
        public string GenerateTitle()
        {
            var title = String.Empty;
            if(rnd.Next(0,2) == 1)
            {
                var noOfFillers = rnd.Next(0, 3);
                title += words.GetNoun() + " ";
                for(int i = 0; i < noOfFillers; i++)
                {
                    title += words.GetFiller() + " ";
                }
                if (rnd.Next(0, 4) == 1)
                {
                    title += "w/ ";
                    title += words.GetDisgustingPhrase() + " ";
                }
                title += "System";

                return title;
            }
            title = GetPDTitle();
            return title;
        }

        private string GetPDTitle()
        {
            int r = rnd.Next(pdTitles.Count());
            return pdTitles.ElementAt(r);
        }
       
    }
}
