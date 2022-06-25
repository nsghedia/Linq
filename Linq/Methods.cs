using System.Linq.Expressions;

namespace Linq
{
    internal class Methods
    {
        public static void LINQQueryToArray()
        {
            // Data source
            string[] names = { "Bill", "Steve", "James", "Mohan" };

            // LINQ Query 
            var myLinqQuery = from name in names
                              where name.Contains('a')
                              select name;

            // Query execution
            foreach (var name in myLinqQuery)
                Console.Write(name + " ");
        }
        public static void WithoutLINQStudentListToArray()
        {
            Student[] studentArray = CommonFunctions.GetStud();
            Student[] students = new Student[10];

            int i = 0;

            foreach (Student std in studentArray)
            {
                if (std.Age > 12 && std.Age < 20)
                {
                    students[i] = std;
                    i++;
                }
            }
            foreach (var item in students)
            {
                if (item != null)
                    Console.WriteLine(item.StudentID + " - " + item.StudentName + " - " + item.Age);
            }
        }
        public static void WithLINQStudentListToArray()
        {
            Student[] studentArray = CommonFunctions.GetStud();

            Console.WriteLine("----teenAgerStudents----");
            // Use LINQ to find teenager students
            Student[] teenAgerStudents = studentArray.Where(s => s.Age > 12 && s.Age < 20).ToArray();

            foreach (var item in teenAgerStudents)
            {
                if (item != null)
                    Console.WriteLine(item.StudentID + " - " + item.StudentName + " - " + item.Age);
            }
            Console.WriteLine("----bill----");

            // Use LINQ to find first student whose name is Bill 
            Student bill = studentArray.Where(s => s.StudentName == "Bill").FirstOrDefault();

            if (bill != null)
                Console.WriteLine(bill.StudentID + " - " + bill.StudentName + " - " + bill.Age);
            Console.WriteLine("----student5----");

            // Use LINQ to find student whose StudentID is 5
            Student student5 = studentArray.Where(s => s.StudentID == 5).FirstOrDefault();

            if (student5 != null)
                Console.WriteLine(student5.StudentID + " - " + student5.StudentName + " - " + student5.Age);
        }
        public static void LINQQuerySyntax()
        {
            Console.WriteLine("\n---First---\n");

            // string collection
            IList<string> stringList = new List<string>() {
                                                        "C# Tutorials",
                                                        "VB.NET Tutorials",
                                                        "Learn C++",
                                                        "MVC Tutorials" ,
                                                        "Java"
                                                    };

            // LINQ Query Syntax
            var result = from s in stringList
                         where s.Contains("Tutorials")
                         select s;

            foreach (var item in result)
            {
                if (item != null)
                    Console.WriteLine(item);
            }

            Console.WriteLine("\n---Second---\n");

            Student[] studentArray = CommonFunctions.GetStud();

            var teenAgerStudent = from s in studentArray
                                  where s.Age > 12 && s.Age < 20
                                  select s;

            foreach (var student5 in teenAgerStudent)
            {
                if (student5 != null)
                    Console.WriteLine(student5.StudentID + " - " + student5.StudentName + " - " + student5.Age);
            }

            Console.WriteLine("\n---Third---\n");

            // LINQ Method Syntax to find out teenager students
            var teenAgerStudents = studentArray.Where(s => s.Age > 12 && s.Age < 20).ToList<Student>();

            foreach (var student5 in teenAgerStudent)
            {
                if (student5 != null)
                    Console.WriteLine(student5.StudentID + " - " + student5.StudentName + " - " + student5.Age);
            }
        }

        public static void Expressions()
        {
            ParameterExpression pe = Expression.Parameter(typeof(Student), "s");

            MemberExpression me = Expression.Property(pe, "Age");

            ConstantExpression constant = Expression.Constant(18, typeof(int));

            BinaryExpression body = Expression.GreaterThanOrEqual(me, constant);

            var ExpressionTree = Expression.Lambda<Func<Student, bool>>(body, new[] { pe });

            Console.WriteLine("Expression Tree: {0}", ExpressionTree);

            Console.WriteLine("Expression Tree Body: {0}", ExpressionTree.Body);

            Console.WriteLine("Number of Parameters in Expression Tree: {0}",
                                            ExpressionTree.Parameters.Count);

            Console.WriteLine("Parameters in Expression Tree: {0}", ExpressionTree.Parameters[0]);
        }
    }
}
