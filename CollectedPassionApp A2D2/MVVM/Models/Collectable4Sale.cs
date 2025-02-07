﻿using CollectedPassionApp_A2D2.Abstractions;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectedPassionApp_A2D2.MVVM.Views.Collector;

namespace CollectedPassionApp_A2D2.MVVM.Models
{
    
    public class Collectable4Sale : TableData
    {
        
        public string? Name { get; set; }
        public string? Description { get; set; }

        public double? price { get; set; }

        public bool? tradeable { get; set; }

        public string? imagepath { get; set ; }

        public string? locatie { get; set; }

        [ForeignKey(typeof(Category))]
        public int categoryId { get; set; }
        
        [ForeignKey(typeof(Appuser))]
        public int userId { get; set; }
        
    }
}
