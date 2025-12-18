
using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Models;

public class UserRepository : IRepository<User>
{
    private UserDbContext _context;

    public UserRepository(UserDbContext context)
    {
        _context = context;
    }
    public User GetById(int id)
    {
        return _context.Users.FirstOrDefault(u => u.Id == id);
    }

    public List<User> GetAll()
    {
        return _context.Users.ToList();
    }

    public User Create(User entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public User Update(User entity)
    {
        User user = GetById(entity.Id);
        if (user == null)
        {
            return null;
        }

        _context.Update(entity);
        _context.SaveChanges();
        return entity;
    }

    public bool Delete(int id)
    {
        User user = GetById(id);

        _context.Remove(user);
        _context.SaveChanges();
        return true;
    }
}