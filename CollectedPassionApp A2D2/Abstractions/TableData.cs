using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectedPassionApp_A2D2.Abstractions
{
    public class TableData
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int Id { get; set; }
    }
}
