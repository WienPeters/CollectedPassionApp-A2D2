using CollectedPassionApp_A2D2.Abstractions;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectedPassionApp_A2D2.MVVM.Models
{
    public class Category : TableData
    {
        public string Catname { get; set; }
        public string Description { get; set; }

        [OneToMany(CascadeOperations =CascadeOperation.All)]
        public List<Collectable>? collectables { get; set; }


        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Collectable4Sale>? Marketables { get; set; }


    }
}
