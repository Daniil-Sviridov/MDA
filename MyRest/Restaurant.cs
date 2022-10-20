using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRest
{
    public class Restaurant
    {
        private readonly List<Table> _tables = new();

        public Restaurant()
        {
            for (int i = 0; i <= 10; i++)
            {
                _tables.Add(new Table(i));
            }
        }

        public void BookFreeTable(int countOfPerson)
        {
            Console.WriteLine("Добрый день! Подождите секундочку ....");

            var table = _tables.FirstOrDefault(t => t.SeatsCount > countOfPerson && t.State == State.Free);
            table?.SetState(State.Booked);
            Thread.Sleep(1000 * 5);

            Console.WriteLine(table is null ? "Все столы заняты" : $"Ваш столик {table.Id}");

        }

        public void BookFreeTableAsync(int countOfPerson)
        {
            Console.WriteLine("Добрый день! Подождите секундочку ....");

            Task.Run(async () =>
            {
                var table = _tables.FirstOrDefault(t => t.SeatsCount > countOfPerson && t.State == State.Free);
                table?.SetState(State.Booked);

                await Task.Delay(1000 * 5);

                Console.WriteLine(table is null ? "Все столы заняты" : $"Ваш столик {table.Id}");
            });
        }


        public void FreeTable(int id)
        {
            Console.WriteLine("Подождите секундочку ....");

            var table = _tables.Where(t => t.Id == id && t.State == State.Booked);

            if (table != null)
                Console.WriteLine($"Не существует или не занят {id}");
            table.First().SetState(State.Free);
        }

        public void FreeTableAsync(int id)
        {
            Console.WriteLine("Подождите секундочку ....");

            Task.Run(async () =>
            {
                var a = 1;
            });
        }

    }
}
