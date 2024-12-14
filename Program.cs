using System.Data.Entity;

namespace FirstAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StudentContext())
            {
                int id = 1;
                string name = "Alex";
                int age = 22;
                string email = "Alex@yahoo.com";

                var stu = new Student { StudentId = id, Name = name, Age = age, Email = email };
                db.Students.Add(stu);
                db.SaveChanges();
                Console.Write("Showing Names of Students from Database: ");
                var query = from b in db.Students
                            orderby b.Name
                            select b;

                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }
            }

        }
    }
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }

    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}

