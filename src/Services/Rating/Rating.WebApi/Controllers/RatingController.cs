﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rating.Application.IServices;
using Rating.Domain.DTOs;

namespace Rating.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RatingController : ControllerBase
	{
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRatingsAsync()
        {
            return Ok(await _ratingService.GetAllRatingsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateRatingAsync([FromBody]CreateRatingDTO ratingDTO)
        {
            await _ratingService.CreateRatingAsync(ratingDTO);

            return StatusCode(201);
        }

        [HttpGet]
        public async Task<IActionResult> GetRatingByFilmName(string filmName)
        {
            return Ok(await _ratingService.GetRatingByFilmName(filmName));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRating(int id)
        {
            await _ratingService.DeleteRating(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRating(RatingDTO ratingDTO)
        {
            await _ratingService.UpdateRating(ratingDTO);

            return Ok();
        }
    }
}
