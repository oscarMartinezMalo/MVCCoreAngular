﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCoreAngular.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Size { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string ArtDescription { get; set; }
        public string ArtDating { get; set; }
        public string ArtId { get; set; }
        public string Artist { get; set; }
        public DateTime ArtistBirthDate { get; set; }
        public DateTime ArtistDeathDate { get; set; }
        public string ArtistNationality { get; set; }
    }
}
