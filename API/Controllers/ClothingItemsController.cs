using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/wardrobes/{wardrobeId}/clothingitems")]
    public class ClothingItemController : BaseApiController
    {
        private readonly IClothingItemService _clothingItemService;
        private readonly IOutfitClothingItemService _outfitClothingItemService;

        public ClothingItemController(IClothingItemService clothingItemService, IOutfitClothingItemService outfitClothingItemService)
        {
            _clothingItemService = clothingItemService;
            _outfitClothingItemService = outfitClothingItemService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateClothingItem([FromBody] ClothingItem clothingItem, Guid wardrobeId)
        {
            await _clothingItemService.CreateClothingItem(wardrobeId, clothingItem);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<List<ClothingItem>>> GetAllClothingItems(Guid wardrobeID)
        {
            var clothingItems = await _clothingItemService.GetAllClothingItems(wardrobeID);
            return Ok(clothingItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClothingItem>> GetClothingItemById(Guid id)
        {
            var clothingItem = await _clothingItemService.GetClothingItemById(id);
            return Ok(clothingItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClothingItem(Guid id, [FromBody] ClothingItem clothingItem, Guid wardrobeId)
        {
            clothingItem.Id = id;
            clothingItem.WardrobeId = wardrobeId;
            await _clothingItemService.UpdateClothingItem(clothingItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothingItem(Guid id)
        {
            await _clothingItemService.DeleteClothingItem(id);
            return Ok();
        }

        [HttpGet("{id}/outfits")]
        public async Task<ActionResult<List<Outfit>>> GetOutfitsForItem(Guid id)
        {
            var outfits = await _outfitClothingItemService.GetOutfitsForItem(id);
            return Ok(outfits);
        }
    }
}