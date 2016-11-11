using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentCatalogFall2016.Models.Entity;

namespace StudentCatalogFall2016.Models
{
    public class StudentsRepository : IStudentsRepository
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public bool Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public StudentModel Find(int? id)
        {
            return db.Students.Find(id);
        }

        public List<StudentModel> GetAll()
        {
            return db.Students.ToList();
        }

        public void InsertOrUpdate(StudentModel student)
        {
            if (student.StudentModelId <= 0)
            {
                db.Students.Add(student);
            }
            else
            {
                db.Entry(student).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
        }
    }
}



