class StudentAndTeacherTest
    {
        static void Main(string[] args)
        {
            
            Person person = new Person();
            person.Greet();

           
            Student student = new Student();
            student.SetAge(21);
            student.Greet();
            student.ShowAge();
            student.GoToClasses();

            
            Teacher teacher = new Teacher("Math");
            teacher.SetAge(30);
            teacher.Greet();
            teacher.Explain();
        }
    }
