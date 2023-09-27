using linq;
using System.Threading.Taks;
using Microsoft.EntityFrameworkCore;
using MaapUP.Domain.Entities;
using MaapUP.Infra.Interfaces;
using MaapUP.Infra.Context;

namespace MaapUP.Infra.Repositories{

{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base{
        private readonly MaapUpContext _context;

        public BaseRepository(MaapUpContext _context){
            _context = context;
        }

        public virtual async Task<T> Create(T obj){
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Upadate(T obj){
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Delete(long id){
            var obj = await Get(id);

            if(obj != null){
               _context.Remove(obj);
               await _context.SaveChangesAsync(); 
            }
        }

        public virtual async Task<T> Get(long id){
            var obj = await _context.Set<T>()
                                    .AsNoTracking()
                                    .where(x=>x.Id == id)
                                    .ToListAsync();
            
            return obj.FirstOrDefault();
        }

        public virtual async Task<List<T>> Get(){
            return await _context.Set<T>()
                                 .AsNoTracking()
                                 .ToListAsync();
        }
    }
}
