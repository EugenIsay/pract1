using AvtoIsay;
using System.ComponentModel.Design;

class program
{
    static void Main()
    {

        Random rand = new Random();
        Avto car = new Avto();
        Console.WriteLine("Введите объём бака");
        int V = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите потребление бака л/ч");
        float P = float.Parse(Console.ReadLine());
        Console.WriteLine("Введите начальный пробег");
        car.Allway(Convert.ToInt32(Console.ReadLine()));
        Console.WriteLine("Скорость автомобиля 80 км/ч");
        Console.WriteLine("Расстояние случайно определяется от 1 км до 3000");
        car.dop(V);
        car.info("1", V, P);
        car.zapravka(V);
        while (true)
        {
            car.move(rand.Next(1, 3000));
            car.result();
        }
        //Avto[] cars = new Avto[5];
        //for (int i = 0; i < cars.Length; i++)
        //{
        //    cars[i] = new Avto();
        //    cars[i].info($"{i + 1}", 50, 7);
        //    cars[i].zapravka(50);
        //}
    }
}