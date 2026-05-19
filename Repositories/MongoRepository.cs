using MongoDB.Driver;
using SmartLMS.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartLMS.Repositories
{
    // CONCEPT: Repository Pattern & Code Reusability
    // This class handles direct database access for any MongoDB collection.
    // CONCEPT: Dependency Inversion (SOLID) - Controllers will depend on IGenericRepository, not MongoRepository.
    public class MongoRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        // CONCEPT: Dependency Injection (Constructor Injection)
        public MongoRepository(IMongoDatabase database)
        {
            var collectionName = typeof(T).Name + "s"; // e.g. "Courses"
            _collection = database.GetCollection<T>(collectionName);
        }

        // CONCEPT: CRUD Operations - READ ALL
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var results = await _collection.FindAsync(_ => true);
            return await results.ToListAsync();
        }

        // CONCEPT: CRUD Operations - READ BY ID
        public async Task<T> GetByIdAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", new MongoDB.Bson.ObjectId(id));
            var result = await _collection.FindAsync(filter);
            return await result.FirstOrDefaultAsync();
        }

        // CONCEPT: CRUD Operations - CREATE
        public async Task CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        // CONCEPT: CRUD Operations - UPDATE
        public async Task UpdateAsync(string id, T entity)
        {
            var filter = Builders<T>.Filter.Eq("_id", new MongoDB.Bson.ObjectId(id));
            await _collection.ReplaceOneAsync(filter, entity);
        }

        // CONCEPT: CRUD Operations - DELETE
        public async Task DeleteAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", new MongoDB.Bson.ObjectId(id));
            await _collection.DeleteOneAsync(filter);
        }
    }
}
