using CollectedPassionApp_A2D2.Abstractions;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectedPassionApp_A2D2.MVVM.Models
{
    public class Collectable : TableData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        

        [ForeignKey(typeof(Category))]
        public int categoryId { get ; set ; }

        [ForeignKey(typeof(Appuser))]
        public int userId { get ; set;}

        

        

    }
}
