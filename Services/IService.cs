namespace BLL.Services;
public interface IService<T> {
    List<T> FindAll();
    void Add(T obj);
    void Delete(int id);
    void Update(T obj);
}
