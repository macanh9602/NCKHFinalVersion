using System;

namespace Scripts{
    
    public interface IPoolable<T>
    {
        void Initialize(Action<T> returnAction);
        void ReturnToPool();
    }
    
}
