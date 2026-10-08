using System;
using System.Collections.Generic;

namespace Unit4_MVC_rec.Models
{
    public interface IStudentCRUDInterface
    {
        List<StudentModel> getAllStudents();
        StudentModel? getStudentById(int id);
        StudentModel getOneStudent(int index);
        void AddStudent(StudentModel newStudent);
        void DeleteStudent(int studentId);
        void UpdateStudent(int studentId, StudentModel updatedStudent);
    }

    public class StudentRepository : IStudentCRUDInterface
    {

        //DEBT -- this should be accessing a database
        static List<StudentModel> myStudents = new List<StudentModel>();

        public StudentRepository()
        {
            if (myStudents.Count == 0)
            {
                // if list is empty, initialize it
                myStudents.Add(new StudentModel(1001, "Tom", 16));
                myStudents.Add(new StudentModel(1002, "Jen", 8));
                myStudents.Add(new StudentModel(1003, "Sabah", 16));
            }

        }

        public List<StudentModel> getAllStudents()
        {
            return myStudents;
        }


        public StudentModel? getStudentById(int id)
        {
            // return myStudents.Find(student => student.Id == id);
            //Console.WriteLine("Getting student with id = " + id);
            foreach (StudentModel student in myStudents)
            {
                if (student.Id == id)
                {
                    //Console.WriteLine("Student Found ");
                    return (student);
                }
            }
            // if you can't find the correct student return the first one
            //Console.WriteLine("Student NOT Found ");
            return (nullStudent());

        }

        private StudentModel nullStudent()
        {
            // create a null student
            StudentModel nullStudent = new StudentModel(-1, "Null Student", -999);
            return nullStudent;
        }



        public StudentModel getOneStudent(int index)
        {
            return (myStudents[index]);
        }
        public void AddStudent(StudentModel newStudent)
        {
            myStudents.Add(newStudent);
        }

        public void DeleteStudent(int studentId)
        {
            // search the list for the student that matches the student ID
            // DEBT --- Handle case when student id not found and index is -1
            int index = myStudents.FindIndex(student => (student.Id == studentId));
            if (index >= 0)
            {
                myStudents.RemoveAt(index);
            }
        }

        public void UpdateStudent(int studentId, StudentModel updatedStudent)
        {
            // search the list for the student that matches the student ID
            // DEBT --- Handle case when student id not found and index is -1
            int index = myStudents.FindIndex(student => (student.Id == studentId));
            if (index >= 0)
            {
                myStudents[index] = updatedStudent;
            }
        }
    }
}


