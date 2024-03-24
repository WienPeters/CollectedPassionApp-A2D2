using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectedPassionApp_A2D2.MVVM.Models
{
    public class Collectable4Sale : Collectable
    {
        public double? price { get; set; }

        public bool Tradeable { get; set; }

        public string? ImagePath { get; set; }

        public string? locatie { get; set; }
    }
}
