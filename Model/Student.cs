using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Student
{
    public string Name { get; set; }
    public string Speciality { get; set; }
    public string Group { get; set; }
    
    [Key]
    public string StudentNumber { get; set; }

    public Student() { }

    public Student(string name, string speciality, string group, string studentNumber)
    {
        Name = name;
        Speciality = speciality;
        Group = group;
        StudentNumber = studentNumber;
    }
}
