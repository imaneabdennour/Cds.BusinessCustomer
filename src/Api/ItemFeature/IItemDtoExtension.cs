using Cds.TestFormationDotnetcore.Domain.ItemAggregate.Abstractions;

namespace Cds.TestFormationDotnetcore.Api.ItemFeature
{
    /// <summary>
    /// The <see cref="IItemDto"/> mappers methods.
    /// </summary>
    public static class IItemDtoExtension
    {
        /// <summary>
        /// Maps a <see cref="IItemDto"/> in a <see cref="ItemViewModel"/>
        /// </summary>
        /// <param name="item">The <see cref="IItemDto"/></param>
        /// <returns>The item view model.</returns>
        public static ItemViewModel ToViewModel(this IItemDto item)
        {
            return new ItemViewModel();
        }
    }
}
