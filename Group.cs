using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

[Serializable]
public class Group
{
    private string groupName = string.Empty;
    private List<Student> groupStudents = new List<Student>();
    private int id = 1;

    // Обязательный параметрless конструктор для XmlSerializer
    public Group() { }

    public Group(string groupName)
    {
        this.groupName = groupName;
        this.id = 1;
    }

    public void SetGroupName(string name)
    {
        groupName = name;
        foreach (var student in groupStudents)
        {
            student.SetStudentGroup(groupName);
        }
    }

    public string GetGroupName() => groupName;

    public void AddStudent(Student student)
    {
        student.AddStudent();
        student.SetStudentId(id);
        student.SetStudentGroup(groupName);
        groupStudents.Add(student);
        id++;
    }

    public void ShowAllStudents()
    {
        Console.WriteLine($"Группа: {groupName}");

        if (groupStudents.Count == 0)
        {
            Console.WriteLine("Группа пуста");
            return;
        }

        foreach (var student in groupStudents)
        {
            student.ShowStudent();
            Console.WriteLine("------------------------------");
        }

        //for (int i = 0; i < groupStudents.Count; i++)
        //{
        //    groupStudents[i].ShowStudent();
        //    Console.WriteLine("------------------------------");
        //}

    }

    public void DeleteAllStudents()
    {
        groupStudents.Clear();
        id = 1;
        Console.WriteLine("Группа очищена");
    }

    // Метод для сохранения в XML-файл
    public void SaveStudentsToFile(string filePath)
    {
        var serializer = new XmlSerializer(typeof(Group));
        using (var writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, this);
        }
        Console.WriteLine("Сохранено");
    }

    // Метод для загрузки из XML-файла
    public static Group LoadStudentsFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден");
            return new Group();
        }

        var serializer = new XmlSerializer(typeof(Group));
        using (var reader = new StreamReader(filePath))
        {
            var group = (Group?)serializer.Deserialize(reader);
            Console.WriteLine("Загружено");
            return group ?? new Group();
        }
    }

    // Свойства для сериализации (обязательны — XmlSerializer работает только с публичными членами)
    [XmlElement("GroupName")]
    public string GroupName
    {
        get => groupName;
        set => groupName = value ?? string.Empty;
    }

    [XmlElement("Students")]
    public List<Student> Students
    {
        get => groupStudents;
        set => groupStudents = value ?? new List<Student>();
    }

    [XmlElement("NextId")]
    public int NextId
    {
        get => id;
        set => id = value;
    }
}