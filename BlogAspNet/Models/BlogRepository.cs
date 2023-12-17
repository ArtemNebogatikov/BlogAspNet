﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BlogAspNet.Models
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogContext _context;
        public BlogRepository(BlogContext context)
        {
            _context = context;
        }
        public async Task AddUser(User user)
        {
            user.JoinDate = DateTime.Now;
            user.Id = Guid.NewGuid();

            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
            {
                await _context.Users.AddAsync(user);
            }
            await _context.SaveChangesAsync();
        }
        public async Task<User[]> GetUsers()
        {
            // Получим всех активных пользователей
            return await _context.Users.ToArrayAsync();
        }
    }
}
