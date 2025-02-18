﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Avatar_Challenge.Models
{
    public class SerialNumber
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ItemId { get; set; }
        [ForeignKey("ItemId")]

        public Item? Item { get; set; }
    }
}
