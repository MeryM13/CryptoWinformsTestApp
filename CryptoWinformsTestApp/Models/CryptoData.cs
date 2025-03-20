using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWinformsTestApp.Models
{
    public class CryptoData
    {
        public string Brocker { get; set; } = string.Empty;
        public string Symbol { get; set; } = "n/a";
        public decimal Rate { get; set; } = 0;
        public DateTime AcquiredAt { get; set; } = DateTime.Now;
    }
}
