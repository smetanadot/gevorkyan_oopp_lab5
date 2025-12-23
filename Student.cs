using System;
using System.Xml.Serialization;

[XmlInclude(typeof(Headman))] // Важно для полиморфной сериализации
public class Student
{
    protected int studentId;
    protected string studentName = string.Empty;
    protected string studentSurname = string.Empty;
    protected int studentAge;
    protected string studentGroup = string.Empty;

    // Параметрless конструктор ОБЯЗАТЕЛЕН для XmlSerializer
    public Student() { }

    public Student(int studentId, string studentName, string studentSurname, int studentAge, string studentGroup)
    {
        this.studentId = studentId;
        this.studentName = studentName;
        this.studentSurname = studentSurname;
        this.studentAge = studentAge;
        this.studentGroup = studentGroup;
    }

    public virtual void ShowStudent()
    {
        Console.WriteLine($"ID: {studentId}");
        Console.WriteLine($"Имя: {studentName}");
        Console.WriteLine($"Фамилия: {studentSurname}");
        Console.WriteLine($"Возраст: {studentAge}");
        Console.WriteLine($"Группа: {studentGroup}");
    }

    public virtual void AddStudent()
    {
        Console.WriteLine("Введите имя:");
        studentName = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Введите фамилию:");
        studentSurname = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Введите возраст:");
        string? ageInput = Console.ReadLine();
        studentAge = int.TryParse(ageInput, out int age) ? age : 0;
    }

    public void SetStudentGroup(string studentGroupName)
    {
        studentGroup = studentGroupName;
    }

    public void SetStudentId(int id)
    {
        studentId = id;
    }

    public int GetStudentId()
    {
        return studentId;
    }

    [XmlElement("StudentId")]
    public int StudentId
    {
        get => studentId;
        set => studentId = value;
    }

    [XmlElement("StudentName")]
    public string StudentName
    {
        get => studentName;
        set => studentName = value ?? string.Empty;
    }

    [XmlElement("StudentSurname")]
    public string StudentSurname
    {
        get => studentSurname;
        set => studentSurname = value ?? string.Empty;
    }

    [XmlElement("StudentAge")]
    public int StudentAge
    {
        get => studentAge;
        set => studentAge = value;
    }

    [XmlElement("StudentGroup")]
    public string StudentGroup
    {
        get => studentGroup;
        set => studentGroup = value ?? string.Empty;
    }
}