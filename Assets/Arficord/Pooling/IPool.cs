namespace Arf.Pooling.Interfaces
{
    public interface IPool
    {
        public void ReturnToPool(IPoolable poolable);
    }
}
