using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class WardrobesController : BaseApiController
    {
        private readonly IWardrobeService _wardrobeService;

        public WardrobesController(IWardrobeService wardrobeService)
        {
            _wardrobeService = wardrobeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWardrobe([FromBody] Wardrobe wardrobe)
        {
            if (wardrobe == null)
            {
                return BadRequest("No wardrobe details provided");
            }

            await _wardrobeService.CreateWardrobe(wardrobe);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<Wardrobe>> GetWardrobeByUser()
        {
            var wardrobe = await _wardrobeService.GetWardrobeByUser();

            if (wardrobe == null)
            {
                return NotFound();
            }

            return Ok(wardrobe);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWardrobe([FromBody] Wardrobe updatedWardrobe)
        {
            var existingWardrobe = await _wardrobeService.GetWardrobeByUser();

            if (existingWardrobe == null)
            {
                return NotFound();
            }

            existingWardrobe.Name = updatedWardrobe.Name;

            await _wardrobeService.UpdateWardrobe(existingWardrobe);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWardrobe(Guid id)
        {
            await _wardrobeService.DeleteWardrobe(id);
            return Ok();
        }
    }
}