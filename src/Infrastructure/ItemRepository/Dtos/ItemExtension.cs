using Cds.TestFormationDotnetcore.Domain.ItemAggregate;
using Cds.TestFormationDotnetcore.Domain.ItemAggregate.Abstractions;

namespace Cds.TestFormationDotnetcore.Infrastructure.ItemRepository.Dtos
{
    /// <summary>
    /// The <see cref="Item"/> mappers methods.
    /// </summary>
    public static class ItemExtension
    {
        /// <summary>
        /// Maps a <see cref="Item"/> in a <see cref="IItemDto"/>
        /// </summary>
        /// <param name="item">The <see cref="Item"/></param>
        /// <returns>The item DTO.</returns>
        public static IItemDto ToDto(this Item item)
        {
            return new ItemDto();
        }
    }
}
