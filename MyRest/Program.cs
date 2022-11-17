
using MyRest;
using System.Diagnostics;

var rest = new Restaurant();

while (true)
{
    /*Console.WriteLine("Hello, забранируйте столик? \n 1 - уведомим по смс(асинхроно) " +
        "\n 2 - ожидайте по телефону(синхроно)" +
        "\n 3 - Освободить (асинхронно)" +
        "\n 4 - Освободить (синхроно)");

    int.TryParse(Console.ReadLine(), out var choise);
    */

    await Task.Delay(10000);

    Console.WriteLine("Привет! Желаете забронировать столик?");
    var stopWathc = new Stopwatch();

    stopWathc.Start();

    rest.BookFreeTableAsync(1);

    /*switch (choise)
    {
        case 1:
            rest.BookFreeTableAsync(1);
            break;
        case 2:
            rest.BookFreeTable(1);
            break;
        case 3:
            Console.WriteLine("Какой стол осовбодить?");
            int.TryParse(Console.ReadLine(), out choise);
            rest.FreeTableAsync(choise);
            break;
        case 4:
            Console.WriteLine("Какой стол осовбодить?");
            int.TryParse(Console.ReadLine(), out choise);
            rest.FreeTable(choise);
            break;

        default:
            Console.WriteLine("1,2, 3 или 4.");
            continue;
    }*/

    Console.WriteLine("Спасибо!!!");

    stopWathc.Stop();

    var t = stopWathc.Elapsed;
    Console.WriteLine($"{t.Seconds}:{t.Milliseconds}");

}

Console.ReadKey();
