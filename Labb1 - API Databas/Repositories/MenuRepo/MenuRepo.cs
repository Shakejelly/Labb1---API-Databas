﻿using Labb1___API_Databas.Data;
using Labb1___API_Databas.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb1___API_Databas.Repositories.MenuRepo
{
    public class MenuRepo : IMenuRepo

    {
        private readonly RestaurantContext _context;
        public MenuRepo(RestaurantContext context)
        {
            _context = context;

        }
        public async Task AddMenuAsync(Menu menu)
        {
            try
            {
                _context.Menus.Add(menu);
                await _context.SaveChangesAsync();
                return;
            }
            catch (Exception)
            {
                throw new Exception("Couldn't add the menu.");
            }
        }
        public async Task DeleteTableAsync(Menu Menu)
        {
            try
            {
                _context.Menus.Remove(Menu);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't delete the menu.");
            }

        }
    }
}
