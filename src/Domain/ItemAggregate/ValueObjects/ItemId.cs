using System;

namespace Cds.TestFormationDotnetcore.Domain.ItemAggregate.ValueObjects
{
    /// <summary>
    /// Represents the <see cref="Item"/> identifier.
    /// </summary>
       public struct ItemId : IEquatable<ItemId>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemId"/> struct.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public ItemId(int id)
        {
            _value = id;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.
        /// </returns>
        public bool Equals(ItemId other) => Equals(this, other);

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is ItemId other && Equals(this, other);

        /// <inheritdoc />
        public override int GetHashCode() => _value.GetHashCode();

        /// <inheritdoc />
        public override string ToString() => _value.ToString();

        /// <summary>
        /// Checks equality between 2 instances.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns></returns>
        public static bool Equals(ItemId left, ItemId right) => left._value == right._value;

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(ItemId left, ItemId right) => Equals(left, right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(ItemId left, ItemId right) => !Equals(left, right);

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="ItemId"/>.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator ItemId(int i) => new ItemId(i);

        /// <summary>
        /// Performs an explicit conversion from <see cref="ItemId"/> to <see cref="System.Int32"/>.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static explicit operator int(ItemId id) => id._value;

        private readonly int _value;
    }
}
