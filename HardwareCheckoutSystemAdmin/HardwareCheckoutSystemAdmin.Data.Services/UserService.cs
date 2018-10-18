﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HardwareCheckoutSystemAdmin.Data.Infrastructure;
using HardwareCheckoutSystemAdmin.Models;

namespace HardwareCheckoutSystemAdmin.Data.Services
{
  public class UserService : IUserService
  {
    public async Task Delete(Guid key)
    {
      using (var context = new DataContext())
      {
        var userToDelete = (from d in context.Users
                              where d.Id == key
                              select d).FirstOrDefault();
        context.Users.Remove(userToDelete);
        await context.SaveChangesAsync();
      }
    }

    public async Task<List<User>> FindAll()
    {
      using (var context = new DataContext())
      {
        return await context.Users.ToListAsync();
      }
    }

    public async Task<User> FindById(Guid userId)
    {
      using (var context = new DataContext())
      {
        return await context.Users.FirstOrDefaultAsync(d => d.Id == userId);
      }
    }

    public async Task Insert(User user)
    {
      using (var context = new DataContext())
      {
        context.Users.Add(user);
        await context.SaveChangesAsync();
      }
    }

    public async Task Update(User user)
    {
      using (var context = new DataContext())
      {
        var userToUpdate = (from d in context.Users
                              where d.Id == user.Id
                              select d).FirstOrDefault();
        userToUpdate = user;
        await context.SaveChangesAsync();
      }
    }
  }
}
