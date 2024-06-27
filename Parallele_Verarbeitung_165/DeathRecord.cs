using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallele_Verarbeitung_165
{
    public class DeathRecord
    {
        public MongoDB.Bson.ObjectId Id { get; set; }
        public int Year { get; set; }
        public int Week { get; set; }
        public string Ending { get; set; }
        public string Age { get; set; }
        public int NoDeaths_EP { get; set; }
        public int Expected { get; set; }
        public int LowerB { get; set; }
        public int UpperB { get; set; }
        public string Diff { get; set; }
    }

}
