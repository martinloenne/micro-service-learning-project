using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using MongoDB.Driver;
using Repository.Interfaces;


// Maybe use Dapper here instead?
namespace Repository.Repositories
{
    public class MongoDB<T> : IRepositoryBase<T> where T : IEntity
    {
        private readonly IMongoCollection<T> dbCol;
        private readonly FilterDefinitionBuilder<T> mongoDBFilter = Builders<T>.Filter;

        public MongoDB(IMongoDatabase database, string collectionName)
        {
            dbCol = database.GetCollection<T>(collectionName);
        }

        public async Task<IReadOnlyCollection<T>> GetAll()
        {
            return await dbCol.Find(mongoDBFilter.Empty).ToListAsync();
        }

        public async Task<T> Get(Guid id)
        {
            FilterDefinition<T> filter = mongoDBFilter.Eq(entity => entity.Id, id);
            return await dbCol.Find(filter).FirstOrDefaultAsync();
        }


        public async Task Create(T entity)
        {
            await dbCol.InsertOneAsync(entity);
        }

        public async Task Update(T entity)
        {
            FilterDefinition<T> filter = mongoDBFilter.Eq(existingEntity => existingEntity.Id, entity.Id);
            await dbCol.ReplaceOneAsync(filter, entity);
        }

        public async Task Remove(Guid id)
        {
            FilterDefinition<T> filter = mongoDBFilter.Eq(entity => entity.Id, id);
            await dbCol.DeleteOneAsync(filter);
        }
    }
}
