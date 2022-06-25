namespace Linq
{
    delegate bool FindStudent(Student std);
    internal class StudentExtension
    {
        public static void GetStudent()
        {
            Student[] students = CommonFunctions.where(CommonFunctions.GetStud(), delegate (Student std) { return std.Age > 12 && std.Age < 20; });
            foreach (var item in students)
            {
                if (item != null)
                    Console.WriteLine(item.StudentID + " - " + item.StudentName + " - " + item.Age);
            }
        }
    }
}