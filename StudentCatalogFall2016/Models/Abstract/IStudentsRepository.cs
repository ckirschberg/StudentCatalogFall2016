using StudentCatalogFall2016.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCatalogFall2016.Models
{
    public interface IStudentsRepository
    {
        List<StudentModel> GetAll();
        StudentModel Find(int? id);
        void InsertOrUpdate(StudentModel student);
        Boolean Delete(int? id);

    }
}
