using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace parking_Artem
{
    [Table("Parking")]
    public class Parking
    {
        [PrimaryKey, AutoIncrement, Column("_id")]

        public int Id { get; set; }

        public string Name { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string Park { get; set; }

    }
}
