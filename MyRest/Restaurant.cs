using MyRest.Messaging;

namespace MyRest
{
    public class Restaurant
    {
        private readonly List<Table> _tables = new();

        private readonly Producer _producer =
            new("BookingNotification", "localhost");

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

    
        public async Task<bool?> BookFreeTableAsync(int countOfPersons)
        {
            Console.WriteLine($"Спасибо за Ваше обращение, я подберу столик и подтвержу вашу бронь," +
                              "Вам придет уведомление");

            var table = _tables.FirstOrDefault(t => t.SeatsCount > countOfPersons
                                                        && t.State == State.Free);
            // await Task.Delay(100 * 5); //у нас нерасторопные менеджеры, 5 секунд они находятся в поисках стола
            return table?.SetState(State.Booked);
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
