using CollectedPassionApp_A2D2.Abstractions;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectedPassionApp_A2D2.MVVM.Models
{
    public class Appuser : TableData
    {
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string adres { get; set; }
        public string city { get; set; }
        public string role { get; set; }


        [OneToMany]
        public List<Collectable4Sale>? Collecta4bles { get; set; }

        
        
    }
}
