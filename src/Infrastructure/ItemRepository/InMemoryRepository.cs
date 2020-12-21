using Cds.TestFormationDotnetcore.Domain.ItemAggregate.Abstractions;
using Cds.TestFormationDotnetcore.Infrastructure.ItemRepository.Abstractions;
using Cds.TestFormationDotnetcore.Infrastructure.ItemRepository.Dtos;

namespace Cds.TestFormationDotnetcore.Infrastructure.Data.Items
{
    /// <summary>
    /// Represents the data repository for <see cref="ItemDto"/>.
    /// </summary>
    public sealed class InMemoryRepository : IItemRepository, IItemReadRepository
    {
    }
}
