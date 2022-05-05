using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIRaft.Data;
using Microsoft.AspNetCore.Http;

namespace APIRaft.Models.Data
{
    public class GetOrder
    {
        public double? price { get; set; }
        public string deposit { get; set; }
        public DateTime? date { get; set; }
        public DateTime? datelast { get; set; }
        public string userid { get; set; }
        //public List<Promotion> Promotion { get; set; }
        public string iDPro { get; set; }
        public string Pathfile { get; set; }
        public string raft { get; set; }
        public string services { get; set; }
        public string PathfilepPay { get; set; }

    }
}
