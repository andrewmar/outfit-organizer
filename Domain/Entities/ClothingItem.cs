using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    public class ClothingItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int TimesWorn { get; set; }
        public decimal PricePerWear => Math.Round(TimesWorn > 0 ? Price / TimesWorn : 0, 2);
        public DateTime? PurchaseDate { get; set; }
        public string Image { get; set; }
        public string Notes { get; set; }
        public string Brand { get; set; }
        public string Season { get; set; }
        public string Status { get; set; }
        [NotMapped]
        public Metadata Metadata { get; set; }
        public ICollection<OutfitClothingItem> OutfitClothingItems { get; set; }
        public Guid WardrobeId { get; set; }
        [JsonIgnore]
        public Wardrobe Wardrobe { get; set; }
    }
}