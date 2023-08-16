using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class OutfitClothingItem
    {
        public Guid OutfitId { get; set; }
        public Guid ClothingItemId { get; set; }

        public Outfit Outfit { get; set; }
        public ClothingItem ClothingItem { get; set; }
    }
}