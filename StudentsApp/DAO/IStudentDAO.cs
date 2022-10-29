﻿using StudentsApp.Model;

namespace StudentsApp.DAO
{
    public interface IStudentDAO
    {
        void Insert(Student? student);
        void Update(Student? student);
        Student? Delete(Student? student);
        Student? GetStudent(int id);
        List<Student> GetAll();

    }
}
