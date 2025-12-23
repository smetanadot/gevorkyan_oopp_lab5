using System;
using System.IO;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Group group = new Group("DEFAULT");

while (true)
{
    ShowMenu();
    int action = ReadIntInRange(0, 7);

    switch (action)
    {
        case 1:
            group.AddStudent(new Student());
            break;

        case 2:
            group.AddStudent(new Headman());
            break;

        case 3:
            group.ShowAllStudents();
            break;

        case 4:
            Console.Write("Введите имя файла: ");
            string filenameToSave = Console.ReadLine() ?? "group";
            filenameToSave = Path.ChangeExtension(filenameToSave, ".txt");
            group.SaveStudentsToFile(filenameToSave);
            break;

        case 5:
            Console.Write("Введите имя файла: ");
            string filenameToLoad = Console.ReadLine() ?? "group";
            filenameToLoad = Path.ChangeExtension(filenameToLoad, ".txt");
            group = Group.LoadStudentsFromFile(filenameToLoad);
            break;

        case 6:
            group.DeleteAllStudents();
            Console.WriteLine("Успешно");
            break;

        case 7:
            Console.WriteLine($"Текущее название группы: {group.GetGroupName()}");
            Console.Write("Введите новое название группы: ");
            string newGroupName = Console.ReadLine() ?? "DEFAULT";
            group.SetGroupName(newGroupName);
            Console.WriteLine("Успешно");
            break;

        case 0:
            return;
    }

    Console.WriteLine();
}


static void ShowMenu()
{
    Console.WriteLine("1. Добавить студента");
    Console.WriteLine("2. Добавить старосту");
    Console.WriteLine("3. Показать всех студентов");
    Console.WriteLine("4. Сохранить группу в файл");
    Console.WriteLine("5. Загрузить группу из файла");
    Console.WriteLine("6. Удалить всех студентов");
    Console.WriteLine("7. Изменить название группы");
    Console.WriteLine("0. Выход");
}

static int ReadIntInRange(int min, int max)
{
    while (true)
    {
        Console.Write($"Введите число от {min} до {max}: ");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int value) && value >= min && value <= max)
            return value;

        Console.WriteLine("Некорректные данные. Попробуйте снова.");
    }
}