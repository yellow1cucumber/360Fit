using Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Repository<TModel> where TModel : Model
    {
        private readonly Context context;
        private readonly DbSet<TModel> models;

        public Repository(Context context)
        {
            this.context = context;
            this.models = context.Set<TModel>();
        }


        #region Sync
        public IQueryable<TModel> GetAll()
        {
            return this.models.AsQueryable();
        }
        public TModel Get(int id)
        {
            return this.models.FirstOrDefault(x => x.Id == id)
                ?? throw new ArgumentOutOfRangeException();
        }
        public void Create(TModel model)
        {
            this.models.Add(model);
            this.context.SaveChanges();
        }
        public void Update(TModel model)
        {
            this.models.Update(model);
            this.context.SaveChanges();
        }
        public void Delete(int id)
        {
            var target = this.Get(id);
            this.models.Remove(target);
            this.context.SaveChanges();
        }
        #endregion

        #region Async
        public async Task<TModel> GetAsync(int id)
        {
            return await this.models.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new ArgumentOutOfRangeException();
        }
        public async Task CreateAsync(TModel model)
        {
            await this.models.AddAsync(model);
            await this.context.SaveChangesAsync();
        }
        public async Task UpdateAsync(TModel model)
        {
            this.models.Update(model);
            await this.context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var target = await this.GetAsync(id);
            this.models.Remove(target);
            await this.context.SaveChangesAsync();
        }
        #endregion
        }
}
