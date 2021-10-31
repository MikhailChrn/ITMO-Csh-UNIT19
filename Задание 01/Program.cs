using System;
using System.Collections.Generic;
using System.Linq;

namespace Задание_01
//1.Модель  компьютера  характеризуется  кодом  и  названием  марки компьютера,  типом  процессора,
//частотой  работы  процессора,  объемом оперативной памяти, объемом жесткого диска, объемом памяти видеокарты,
//стоимостью компьютера в условных единицах и количеством экземпляров, имеющихся в наличии.
//Создать список, содержащий 6-10 записей с различным набором значений характеристик.

//Определить:
//- все компьютеры с указанным процессором.Название процессора запросить у пользователя;
//- все компьютеры с объемом ОЗУ не ниже, чем указано.Объем ОЗУ запросить у пользователя;
//- вывести весь список, отсортированный по увеличению стоимости;
//- вывести весь список, сгруппированный по типу процессора;
//- найти самый дорогой и самый бюджетный компьютер;
//- есть ли хотя бы один компьютер в количестве не менее 30 штук?

{
    class Computer
    {
        public int ComputerCode { get; set; }
        public string ComputerBrand { get; set; }
        public string ProcessorType { get; set; }
        public int ProcessorFrequency { get; set; }
        public int RAMsize { get; set; }
        public int HDDsize { get; set; }
        public int VideoRAMsize { get; set; }
        public int CompuerPrice { get; set; }
        public int WarehouseRemain { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> listComputer = new List<Computer>()
            {
                new Computer(){ComputerCode = 1, ComputerBrand = "Compaq", ProcessorType = "Intel Pentium 3", ProcessorFrequency = 450, RAMsize = 64, HDDsize = 120, VideoRAMsize = 4, CompuerPrice = 2500, WarehouseRemain = 27},
                new Computer(){ComputerCode = 2, ComputerBrand = "Dell", ProcessorType = "Intel Pentium 3", ProcessorFrequency = 333, RAMsize = 32, HDDsize = 80, VideoRAMsize = 2, CompuerPrice = 1800, WarehouseRemain = 39},
                new Computer(){ComputerCode = 3, ComputerBrand = "Emachines", ProcessorType = "Intel Celeron", ProcessorFrequency = 433, RAMsize = 32, HDDsize = 40, VideoRAMsize = 2, CompuerPrice = 950, WarehouseRemain = 57},
                new Computer(){ComputerCode = 4, ComputerBrand = "Hp", ProcessorType = "Cyrix 6x86MX", ProcessorFrequency = 333, RAMsize = 16, HDDsize = 20, VideoRAMsize = 1, CompuerPrice = 730, WarehouseRemain = 4},
                new Computer(){ComputerCode = 5, ComputerBrand = "IBM", ProcessorType = "Intel Pentium 3", ProcessorFrequency = 566, RAMsize = 64, HDDsize = 120, VideoRAMsize = 4, CompuerPrice = 3900, WarehouseRemain = 17},
                new Computer(){ComputerCode = 6, ComputerBrand = "No name", ProcessorType = "Amd K7", ProcessorFrequency = 333, RAMsize = 8, HDDsize = 20, VideoRAMsize = 1, CompuerPrice = 590, WarehouseRemain = 91},
                new Computer(){ComputerCode = 7, ComputerBrand = "No name", ProcessorType = "Amd K7", ProcessorFrequency = 466, RAMsize = 16, HDDsize = 40, VideoRAMsize = 1, CompuerPrice = 990, WarehouseRemain = 47},
                new Computer(){ComputerCode = 8, ComputerBrand = "No name", ProcessorType = "Intel Celeron", ProcessorFrequency = 333, RAMsize = 8, HDDsize = 20, VideoRAMsize = 1, CompuerPrice = 650, WarehouseRemain = 24},
                new Computer(){ComputerCode = 9, ComputerBrand = "No name", ProcessorType = "Amd K7", ProcessorFrequency = 650, RAMsize = 32, HDDsize = 80, VideoRAMsize = 2, CompuerPrice = 1490, WarehouseRemain = 13}
            };


            Console.WriteLine("Здравствуйте!!");

            //Запрос 1.Все компьютеры с указанным процессором
            Console.WriteLine("Введите наименование процессора:");
            string proc1 = Console.ReadLine();
            IEnumerable<Computer> compQuery1 = listComputer.Where(c => c.ProcessorType == proc);

            Console.WriteLine("Перечень техники:");
            foreach (Computer c in compQuery1)
                Console.WriteLine($"{c.ComputerCode} {c.ComputerBrand}, {c.ProcessorType}, {c.ProcessorFrequency} MHz, ОЗУ {c.RAMsize} Mb, HDD {c.HDDsize} Gb, video {c.VideoRAMsize} Mb, {c.CompuerPrice,5}$");
            Console.WriteLine();

            //Запрос 2.Все компьютеры с объемом ОЗУ не ниже
            Console.WriteLine("Введите наименьший объём ОЗУ [Мб]:");
            int ram = Convert.ToInt16(Console.ReadLine());
            IEnumerable<Computer> compQuery2 = listComputer.Where(c => c.RAMsize >= ram);

            Console.WriteLine("Перечень техники:");
            foreach (Computer c in compQuery2)
                Console.WriteLine($"{c.ComputerCode} {c.ComputerBrand}, {c.ProcessorType}, {c.ProcessorFrequency} MHz, ОЗУ {c.RAMsize} Mb, HDD {c.HDDsize} Gb, video {c.VideoRAMsize} Mb, {c.CompuerPrice,5}$");

            //Запрос 3.Вывести весь список, отсортированный по увеличению стоимости
            IEnumerable<Computer> compQuery3 = listComputer.OrderBy(c => c.CompuerPrice);

            Console.WriteLine("Перечень техники по возрастанию цены:");
            foreach (Computer c in compQuery3)
                Console.WriteLine($"{c.ComputerCode} {c.ComputerBrand}, {c.ProcessorType}, {c.ProcessorFrequency} MHz, ОЗУ {c.RAMsize} Mb, HDD {c.HDDsize} Gb, video {c.VideoRAMsize} Mb, {c.CompuerPrice,5}$");

            //Запрос 4.Весь список, сгруппированный по типу процессора
            //По методу GroupBy удалось разобраться по примерам в интернете

            var compQuery4 = listComputer.GroupBy(c => c.ProcessorType);
            Console.WriteLine("Перечень техники cгрупированный по типу процессора:");
            
            foreach (var proc4 in compQuery4)
            {
                Console.WriteLine("{0} : {1} моделей компьютеров", proc4.Key, proc4.Count());
                foreach (var c in proc4)
                {
                    Console.WriteLine($"     {c.ComputerCode} {c.ComputerBrand}, {c.ProcessorType}, {c.ProcessorFrequency} MHz, ОЗУ {c.RAMsize} Mb, HDD {c.HDDsize} Gb, video {c.VideoRAMsize} Mb, {c.CompuerPrice,5}$");
                }
            }

            //Запрос 5.Нахождение самого дорогой и самый бюджетной позиции
            int maxPrice = listComputer.Max(c => c.CompuerPrice);
            int minPrice = listComputer.Min(c => c.CompuerPrice);

            IEnumerable<Computer> compQuery5 = listComputer.Where(c => c.CompuerPrice == maxPrice || c.CompuerPrice == minPrice);

            Console.WriteLine("Наиболее дорогостоящая и наименеестоящая модели:");
            foreach (Computer c in compQuery5)
                Console.WriteLine($"{c.ComputerCode} {c.ComputerBrand}, {c.ProcessorType}, {c.ProcessorFrequency} MHz, ОЗУ {c.RAMsize} Mb, HDD {c.HDDsize} Gb, video {c.VideoRAMsize} Mb, {c.CompuerPrice,5}$");

            //Запрос 6.Нахождение позиций в количестве превышающем 30 шт.
            IEnumerable<Computer> compQuery6 = listComputer.Where(c => c.WarehouseRemain >= 30).OrderBy(c => c.WarehouseRemain);

            Console.WriteLine("Наиболее дорогостоящая и наименеестоящая модели:");
            foreach (Computer c in compQuery6)
                Console.WriteLine($"{c.ComputerCode} {c.ComputerBrand} {c.CompuerPrice,5}$ {c.WarehouseRemain} шт.");

            Console.ReadLine();
        }
    }
}
