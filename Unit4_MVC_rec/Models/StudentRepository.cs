
using System;
using System.Collections.Generic;

namespace Unit4_MVC_rec.Models
{
    public interface IStudentCRUDInterface
    {
        List<IStudentInterface> getAllStudents();
        IStudentInterface? getStudentById(int id);
        IStudentInterface getOneStudent(int index);
        void AddStudent(IStudentInterface newStudent);
        void DeleteStudent(int studentId);
        void UpdateStudent(int studentId, IStudentInterface updatedStudent);
    }

    public class StudentRepository : IStudentCRUDInterface
    {
        // DEBT -- this should be accessing a database
        static List<IStudentInterface> myStudents = new List<IStudentInterface>();

        public StudentRepository()
        {
            if (myStudents.Count == 0)
            {
                // If list is empty, initialize it
                myStudents.Add(new StudentModel(1001, "Tom", 16));
                myStudents.Add(new StudentModel(1002, "Jen", 8));
                myStudents.Add(new StudentModel(1003, "Sabah", 16));
            }
        }

        public List<IStudentInterface> getAllStudents()
        {
            return myStudents;
        }

        public IStudentInterface? getStudentById(int id)
        {
            // Search for a student using their ID
            foreach (IStudentInterface student in myStudents)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }

            // Return a NullStudent if no matching ID is found
            return new NullStudent();
        }

        public IStudentInterface getOneStudent(int index)
        {
            return myStudents[index];
        }

        public void AddStudent(IStudentInterface newStudent)
        {
            myStudents.Add(newStudent);
        }

        public void DeleteStudent(int studentId)
        {
            // Find the student matching the given ID
            int index = myStudents.FindIndex(student => student.Id == studentId);

            if (index >= 0)
            {
                myStudents.RemoveAt(index);
            }
        }

        public void UpdateStudent(int studentId, IStudentInterface updatedStudent)
        {
            // Find the student matching the given ID
            int index = myStudents.FindIndex(student => student.Id == studentId);

            if (index >= 0)
            {
                myStudents[index] = updatedStudent;
            }
        }
    }
}
