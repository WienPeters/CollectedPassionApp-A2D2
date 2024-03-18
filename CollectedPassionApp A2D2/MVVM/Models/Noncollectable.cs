using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Media;

namespace CollectedPassionApp_A2D2.MVVM.Models
{
    public class Noncollectable : Collectable
    {
        public double price {  get; set; }

        public bool Tradeable { get; set; }

        public string ImagePath { get; set; } 
        
        public string locatie {  get; set; }

        public string adres {  get; set; }

        [ForeignKey(typeof(User))]
        public int? userId { get; set; }
    }
}
