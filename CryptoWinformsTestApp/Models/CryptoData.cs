using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWinformsTestApp.Models
{
    public class CryptoData
    {
        [DisplayName("Биржа")]
        public string Brocker { get; set; } = "n/a";

        [DisplayName("Пара")]
        public string Symbol { get; set; } = "n/a";

        [DisplayName("Курс")]
        public decimal Rate { get; set; } = 0;

        [DisplayName("Время получения")]
        [DisplayFormat(DataFormatString = "dd.MM.yyyy HH:mm:ss")]
        public DateTime AcquiredAt { get; set; } = DateTime.MinValue;
    }
}
