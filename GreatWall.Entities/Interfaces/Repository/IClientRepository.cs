namespace GreatWall.Entities.Interfaces.Repository
{
    using System.Collections.Generic;

    public interface IClientRepository<T>
    {
        IList<T> Data { get; }

        void Add(IList<string> customerDetails, IProduct currentProduct);
    }
}
