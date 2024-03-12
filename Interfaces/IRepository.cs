public interface IRepository<T>{
    List<T> FindAll();
    void Add(T obj);
    void Delete(int id);
    void Update(T obj);
}

