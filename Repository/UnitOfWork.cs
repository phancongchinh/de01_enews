using De01_Enews.Models.Entities;

namespace De01_Enews.Repository;

public class UnitOfWork
{
    private readonly AppDbContext _context;

    public readonly Repository<User> UserRepository;
    public readonly Repository<Role> RoleRepository;
    public readonly Repository<Category> CategoryRepository;
    public readonly Repository<Image> ImageRepository;

    public UnitOfWork()
    {
        _context = AppDbContext.Init();
        UserRepository = new Repository<User>(_context);
        RoleRepository = new Repository<Role>(_context);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}