namespace Lurnyx.Data.Interfaces
{
    /// <summary>
    /// Defines a contract for database entities, ensuring they have a primary key.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the primary key for this entity.
        /// </summary>
        int Id { get; set; }
    }
}
