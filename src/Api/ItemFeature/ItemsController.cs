using System;

using Cds.TestFormationDotnetcore.Domain.ItemAggregate;
using Cds.TestFormationDotnetcore.Domain.ItemAggregate.Abstractions;
using Cds.TestFormationDotnetcore.Infrastructure.ItemRepository.Abstractions;

using Microsoft.AspNetCore.Mvc;

namespace Cds.TestFormationDotnetcore.Api.ItemFeature
{
    /// <summary>
    /// Represents the controller to handle <see cref="Item"/>s.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        #region Fields

        private readonly IItemReadRepository _read;
        private readonly ItemHandler _handler;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsController"/> class.
        /// </summary>
        /// <param name="read">The read repository.</param>
        /// <param name="handler">The repository.</param>
        public ItemsController(IItemReadRepository read, ItemHandler handler)
        {
            _read = read ?? throw new ArgumentNullException(nameof(read));
            _handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }
    }
}
