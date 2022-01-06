using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Repository.Interfaces;
using Repository.Repositories;

namespace Repository.Configuration
{
    public static class Configuration
    {
        public static IServiceCollection StartMongoDatabase<T>(this IServiceCollection services, string mongoCollectionName, string databaseName, string connectionString) where T : IEntity
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

            services.AddSingleton(s =>
            {
                var mongoClient = new MongoClient(connectionString);
                return mongoClient.GetDatabase(databaseName);
            });

            services.AddSingleton<IRepositoryBase<T>>(s =>
            {
                var database = s.GetService<IMongoDatabase>();
                return new MongoDB<T>(database, mongoCollectionName);
            });

            return services;
        }
    }
}
