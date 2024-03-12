using DAL.Models;

namespace DAL.Services;
internal class SubjectRepository : IRepository<Subject> {
    private DatabaseContext db;
    public SubjectRepository(DatabaseContext db) => this.db = db;

    public void Add(Subject obj) {
        bool isExist = db.Subjects.Any(el => el.Name.Equals(obj.Name));
        if (!isExist) {
            db.Subjects.Add(obj);
            db.SaveChanges();
        }
    }

    public void Delete(int id) {
        Subject subject = db.Subjects.FirstOrDefault(s => s.Id == id);
        db.Subjects.Remove(subject);
        db.SaveChanges();
    }

    public List<Subject> FindAll() =>
         db.Subjects.ToList();

    public void Update(Subject obj) {
        Subject subject = db.Subjects.FirstOrDefault(s => s.Id == obj.Id);
        if (subject == null)
            return;
        subject.Id = obj.Id;
        subject.Name = obj.Name;
        db.SaveChanges();
    }

}
