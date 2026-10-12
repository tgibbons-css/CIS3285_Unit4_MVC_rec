
namespace Unit4_MVC_rec.Models
{
    public interface IStudentCRUDInterface
    {
        public List<IStudentInterface> getAllStudents();
        public IStudentInterface getStudentById(int id);
        public void AddStudent(IStudentInterface newStudent);
        public void UpdateStudent(int studentId, IStudentInterface updatedStudent);
        public void DeleteStudent(int studentId);
    }

}