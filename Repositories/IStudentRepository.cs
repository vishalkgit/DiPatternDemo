﻿using DiPatternDemo.Models;

namespace DiPatternDemo.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();

        Student GetStudentById(int id);

        int AddStudent(Student student);    

        int UpdateStudent(Student student);

        int DeleteStudent(int id);
    }
}
