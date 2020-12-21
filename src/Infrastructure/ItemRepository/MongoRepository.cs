using Cds.TestFormationDotnetcore.Domain.ItemAggregate;
using Cds.TestFormationDotnetcore.Infrastructure.ItemRepository.Abstractions;
using Cds.TestFormationDotnetcore.Infrastructure.ItemRepository.Dtos;
using Cds.Foundation.Data.Mongo;
using MongoDB.Driver;
using System;
using Cds.TestFormationDotnetcore.Domain.ItemAggregate.Abstractions;

namespace Cds.TestFormationDotnetcore.Infrastructure.Data.Items
{
    /// <summary>
    /// Represents the SQL data repository for <see cref="ItemDto"/>.
    /// </summary>
    public sealed class MongoRepository : IItemRepository, IItemReadRepository
    {
        private readonly IMongoCollection<Item> _collection;

        /// <summary>
        /// Instantiate a new instance of <see cref="MongoRepository"/> with a context.
        /// </summary>
        /// <param name="context">MongoDB Context</param>
        public MongoRepository(IMongoDbContext context)
        {
            var ctx = context ?? throw new ArgumentNullException(nameof(context));
            var dbName = context.DatabaseName ?? throw new ArgumentNullException(nameof(context.DatabaseName));
            var db = ctx.Client.GetDatabase(dbName);
            _collection = db.GetCollection<Item>("myCollection");
        }
    }
}
