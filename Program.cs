using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            University aua = new University();

            Student student1 = new Student();
            student1.AddStudent(1, "Aram", "Vardanyan", 17, new int[] { 45, 55, 68, 70 });
            Student student2 = new Student();
            student2.AddStudent(2, "Anna", "Grigoryan", 18, new int[] { 85, 95, 78, 80 });
            Student student3 = new Student();
            student3.AddStudent(3, "Lilit", "Khachatryan", 17, new int[] { 25, 15, 28, 75 });
            Student student4 = new Student();
            student4.AddStudent(4, "Gor", "Simonyan", 17, new int[] { 45, 55, 48, 50 });
            Student student5 = new Student();
            student5.AddStudent(5, "Nelli", "Ghazaryan", 20, new int[] { 65, 85, 78, 90 });

            aua.AddStudentToUniversity(student1);
            aua.AddStudentToUniversity(student2);
            aua.AddStudentToUniversity(student3);
            aua.AddStudentToUniversity(student4);
            aua.AddStudentToUniversity(student5);
            aua.GetStudentsList();
            aua.AverageScore(student3);
            aua.GetStudentByID(2);

        }
    }

    class University
    {
        public string name;
        public Student[] faculty = new Student[10];
        int count = 0;


        public void AddStudentToUniversity(Student student)
        {
            faculty[count++] = student;
        }

        public void GetStudentsList()
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write($"{faculty[i].id}: {faculty[i].name} {faculty[i].surname}  \n");
            }
        }

        public void AverageScore(Student student)
        {
            int[] score = new int[8];
            int average = 0;
            int scoreCount = 0;
            int assessment = 0;
            for (int i = 0; i < student.grade.Length; i++)
            {

                for (int j = 0; j < score.Length; j++)
                {
                    score[j] = student.grade[i];
                    assessment += score[j];
                    scoreCount++;
                }

            }
            average = assessment / scoreCount;
            Console.WriteLine();
            Console.WriteLine($"Average score for {student.name} {student.surname} : {average}");
            if (average < 40)
            {
                DeleteStudent(student.id);
                Console.WriteLine();
                Console.WriteLine($"Dear {student.name} your average is to low. You expelled from university");
            }
        }

        public void DeleteStudent(int id)
        {
            for (int i = 0; i < faculty.Length; i++)
            {
                if (id == faculty[i].id && i < count - 2)
                {
                    faculty[i] = faculty[i + 1];
                }
                else
                {
                    faculty[count - 1] = null;
                    return;
                }
            }
        }

        public void GetStudentByID(int id)
        {

            for (int i = 0; i < faculty.Length; i++)
            {
                if (faculty[i].id == id)
                {
                    Console.WriteLine();
                    Console.Write($"{faculty[i].id}: {faculty[i].name} {faculty[i].surname}");
                    Console.WriteLine();
                    return;
                }
            }
        }

    }

    class Student
    {
        public int id;
        public string name;
        public string surname;
        public int age;
        public int[] grade;

        public void AddStudent(int id, string name, string surname, int age, int[] grade)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.grade = grade;
        }
    }
}
