using System;

namespace Scripts.Pool{
    
    public interface IPoolable<T>
    {
        void Initialize(Action<T> returnAction);
        void ReturnToPool();
    }
    
}
