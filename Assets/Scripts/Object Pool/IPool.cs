
namespace Scripts.ObjectPool {
public interface IPool<T>
    {
        T Pull();
        void Push(T t);
    }
    
}
