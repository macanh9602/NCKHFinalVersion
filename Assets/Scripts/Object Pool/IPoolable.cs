using System;

namespace Scripts.ObjectPool {
    
    public interface IPoolable<T>
    {
        void Initialize(Action<T> returnAction);
        void ReturnToPool();
    }
    
}
