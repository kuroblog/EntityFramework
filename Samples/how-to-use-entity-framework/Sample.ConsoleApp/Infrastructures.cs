
namespace Sample.ConsoleApp
{
    using System;

    public interface IEntity
    {
        Guid Id { get; set; }

        DateTime CreatedOn { get; set; }
    }
}
