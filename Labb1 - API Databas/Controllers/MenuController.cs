﻿using Labb1___API_Databas.Models.Dto.BookingDto;
using Labb1___API_Databas.Models;
using Labb1___API_Databas.Models.Dto.CustomerDto;
using Labb1___API_Databas.Models.Dto.MenuDto;
using Labb1___API_Databas.Repositories.MenuRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Labb1___API_Databas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuRepo;
        public MenuController(IMenuService menuRepo)
        {
            _menuRepo = menuRepo;
        }
        [HttpGet]
        [Route("getAllDishes")]
        public async Task<IActionResult> GetAllDishes(CancellationToken cancellationToken)
        {
            try
            {
                var menu = await _menuRepo.GetAllMenuAsync(cancellationToken);
                return Ok(menu);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error occurred while retrieving dishes.");
            }
        }
        [HttpPost]
        [Authorize]
        [Route("addDish")]
        public async Task<IActionResult> AddDish(AddDishDto addDishDto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _menuRepo.AddMenuAsync(addDishDto, cancellationToken);

               
                return StatusCode(200, "added Dish"); 
            }
            catch (Exception ex) 
            { 
          
                return StatusCode(500, ex);
            }
        }
        [HttpPost]
        [Authorize]
        [Route("updateDish")]
        public async Task<IActionResult> UpdateDish(int dishId,UpdateDishDto updateDishDto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                updateDishDto.DishId = dishId; // Ensures the bookingId is set in the DTO
                await _menuRepo.UpdateMenuAsync(updateDishDto, cancellationToken);
                return NoContent(); // Indicate success without returning data
            }
            catch (Exception)
            {

                return BadRequest(ModelState);

            }
        }
        [HttpPost]
        [Authorize]
        [Route("updateDishInStock")]
        public async Task<IActionResult> UpdateDishInStock(int dishId, UpdateDishInStockDto updateDishInStockDto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                updateDishInStockDto.DishId = dishId;
                await _menuRepo.ChangeAvaiableDishAsync(updateDishInStockDto, cancellationToken);
                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest(ModelState);


            }
        }

    }
}
