using linq;
using System.Threading.Taks;
using Microsoft.EntityFrameworkCore;
using MaapUP.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Infra.Context;

namespace MaapUP.Infra.Repositories{
    public class UserRespository : BaseRepository<User>, IUserRepository{
    
    private readonly MaapUpContext _context;

     public BaseRepository(MaapUpContext _context) : base(context){
        _context = context;
    } 

    public async Task<User> GetByEmail(string email){

        var user = await _context.Users
                                .Where(
                                    x => x.Email.ToLower() == email.ToLower()
                                )
                                .AsNoTracking()
                                .ToListAsync();

        return user.FirstOrDefault();

    }

        public async Task<List<User>> SearchByEmail(string email){

        var allUsers = await _context.Users
                                .Where(
                                    x => x.Email.ToLower().Contains(email.ToLower())
                                )
                                .AsNoTracking()
                                .ToListAsync();
        return allUsers;


    }

            public async Task<List<User>> SearchByName(string name){

        var allUsers = await _context.Users
                                .Where(
                                    x => x.name.ToLower().Contains(name.ToLower())
                                )
                                .AsNoTracking()
                                .ToListAsync();
        return allUsers;

    }
    
    }
}