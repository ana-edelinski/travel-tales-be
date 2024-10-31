﻿using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;

namespace Explorer.Stakeholders.Infrastructure.Database.Repositories;

public class UserDatabaseRepository : IUserRepository
{
    private readonly StakeholdersContext _dbContext;

    public UserDatabaseRepository(StakeholdersContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool Exists(string username)
    {
        return _dbContext.Users.Any(user => user.Username == username);
    }

    public User? GetActiveByName(string username)
    {
        return _dbContext.Users.FirstOrDefault(user => user.Username == username && user.IsActive);
    }

    public User Create(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
        return user;
    }

    public long GetPersonId(long userId)
    {
        var person = _dbContext.People.FirstOrDefault(i => i.UserId == userId);
        if (person == null) throw new KeyNotFoundException("Not found.");
        return person.Id;
    }

    public User? GetById(long userId)
    {
        var user = _dbContext.Users.FirstOrDefault(i => i.Id == userId);
        return user;
    }

    public bool IsAuthor(long userId)
    {
        var user= _dbContext.Users.FirstOrDefault(i => i.Id == userId);
        if(user.Role==UserRole.Author) return true;
        return false; 
    }

    public List<User> GetActiveUsers()
    {
        return _dbContext.Users
            .Where(user => user.IsActive && user.Role == UserRole.Tourist)
            .ToList();
    }
}