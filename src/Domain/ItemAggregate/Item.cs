using Cds.TestFormationDotnetcore.Domain.ItemAggregate.ValueObjects;

namespace Cds.TestFormationDotnetcore.Domain.ItemAggregate
{
    /// <summary>
    /// Represents an item.
    /// </summary>
    public sealed class Item
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public ItemId Id { get; }

        private Item(ItemId id)
        {
            Id = id;
        }

        /// <summary>
        /// Create a new Item instance with 0 as id.
        /// </summary>
        /// <returns>The new <see cref="Item"/>.</returns>
        public static Item CreateNew()
        {
            return new Item(0);
        }

        /// <summary>
        /// Create a new Item instance with the <paramref name="id"/> a ItemId.
        /// </summary>
        /// <param name="id">The item identifier.</param>
        /// <returns>The new <see cref="Item"/>.</returns>
        public static Item CreateFromStore(int id)
        {
            return new Item(new ItemId(id));
        }
    }
}
