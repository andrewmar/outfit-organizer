using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/wardrobes/{wardrobeId}/outfits")]
    public class OutfitController : BaseApiController
    {
        private readonly IOutfitService _outfitService;
        private readonly IOutfitClothingItemService _outfitClothingItemService;

        public OutfitController(IOutfitService outfitService, IOutfitClothingItemService outfitClothingItemService)
        {
            _outfitClothingItemService = outfitClothingItemService;
            _outfitService = outfitService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Outfit>>> GetAllOutfits(Guid wardrobeId)
        {
            var outfits = await _outfitService.GetAllOutfits(wardrobeId);
            return Ok(outfits);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Outfit>> GetOutfitById(Guid id)
        {
            var outfit = await _outfitService.GetOutfitById(id);
            return Ok(outfit);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOutfit(Outfit outfit, Guid wardrobeId)
        {
            await _outfitService.CreateOutfit(wardrobeId, outfit);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOutfit(Guid id, Outfit outfit, Guid wardrobeId)
        {
            outfit.Id = id;
            outfit.WardrobeId = wardrobeId;
            await _outfitService.UpdateOutfit(outfit);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOutfit(Guid id)
        {
            await _outfitService.DeleteOutfit(id);
            return Ok();
        }
        [HttpPost("{id}/items/{clothingItemId}")]
        public async Task<IActionResult> AddItemToOutfit(Guid id, Guid clothingItemId)
        {
            await _outfitClothingItemService.AddItemToOutfit(id, clothingItemId);
            return Ok();
        }

        [HttpDelete("{id}/items/{clothingItemId}")]
        public async Task<IActionResult> RemoveItemFromOutfit(Guid id, Guid clothingItemId)
        {
            await _outfitClothingItemService.RemoveItemFromOutfit(id, clothingItemId);
            return Ok();
        }

        [HttpGet("{id}/items")]
        public async Task<ActionResult<List<ClothingItem>>> GetItemsForOutfit(Guid id)
        {
            var items = await _outfitClothingItemService.GetItemsForOutfit(id);
            return Ok(items);
        }
    }
}