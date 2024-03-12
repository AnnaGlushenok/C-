using DAL.Models;

namespace DAL.Services;
internal class StudentRepository : IRepository<Student> {
    private DatabaseContext db;
    public StudentRepository(DatabaseContext db) => this.db = db;

    public List<Student> FindAll() =>
             db.Students.ToList();

    public void Add(Student obj) {
        bool isExist = db.Students.Any(el => el.Surname.Equals(obj.Surname) &&
                                               el.Name.Equals(obj.Name) &&
                                               el.Patronymic.Equals(obj.Patronymic));
        if (!isExist) {
            db.Students.Add(obj);
            db.SaveChanges();
        }
    }

    public void Delete(int id) {
        Student student = db.Students.FirstOrDefault(s => s.Id == id);//?
        db.Students.Remove(student);
        db.SaveChanges();
    }


    public void Update(Student obj) {
        Student student = db.Students.FirstOrDefault(s => s.Id == obj.Id);
        if (student == null)
            return;
        student.Id = obj.Id;
        student.Surname = obj.Surname;
        student.Name = obj.Name;
        student.Patronymic = obj.Patronymic;
        db.SaveChanges();
    }
}
