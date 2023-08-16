using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    public class Outfit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<ClothingItem> ClothingItems { get; set; }
        public List<string> Tags { get; set; }
        public List<string> ColorSchemes { get; set; }
        public string Notes { get; set; }
        public Guid? WardrobeId { get; set; }
        [JsonIgnore]
        public Wardrobe Wardrobe { get; set; }
        [NotMapped]
        public Metadata Metadata { get; set; }
        public ICollection<OutfitClothingItem> OutfitClothingItems { get; set; }
    }
}