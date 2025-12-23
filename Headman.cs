using System;
using System.Xml.Serialization;

public class Headman : Student
{
    protected string phoneNumber = string.Empty;

    // Обязательный параметрless конструктор для XmlSerializer
    public Headman() { }

    public Headman(int studentId, string studentName, string studentSurname, int studentAge, string studentGroup, string phoneNumber)
        : base(studentId, studentName, studentSurname, studentAge, studentGroup)
    {
        this.phoneNumber = phoneNumber;
    }

    public override void ShowStudent()
    {
        Console.WriteLine("СТАРОСТА");
        base.ShowStudent();
        Console.WriteLine($"Номер телефона: {phoneNumber}");
    }

    public override void AddStudent()
    {
        base.AddStudent();
        Console.WriteLine("Введите номер телефона:");
        phoneNumber = Console.ReadLine() ?? string.Empty;
    }

    // Свойство для сериализации
    [XmlElement("PhoneNumber")]
    public string PhoneNumber
    {
        get => phoneNumber;
        set => phoneNumber = value ?? string.Empty;
    }
}