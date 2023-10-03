using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace AvtoIsay
{
    internal class Avto
    {
        ConsoleKeyInfo key;
        string num;
        float amount;
        float consumption;
        float speed = 80;
        float runway;
        float time;
        float allway;
        float x = 0;
        public void info(string num, float amount, float consumption)
        {
            this.num = num;
            this.amount = amount;
            this.consumption = consumption;
        }
        public void zapravka(float top)
        {
            amount = top;
        }
        public void move(float km)
        {
            float t = amount;
            time = km / speed;
            t -= time * consumption;
            if (t < 0)
            {
                Console.WriteLine("Мы не доедем. Есть заправка? Напишите y/n");
                key = Console.ReadKey();
                Console.WriteLine(" ");
                switch (key.Key.ToString())
                {
                    case "Y":
                        time = amount / consumption;
                        km -= speed * time;
                        Console.WriteLine("Сколько вы хотите заправить?");
                        t = Convert.ToInt32(Console.ReadLine());
                        runway += km;
                        zapravka(t);
                        move(km);
                        break;
                    case "N":
                        Console.WriteLine($"Пройдено всего {runway}");
                        Environment.Exit(0);
                        break;
                }
            }
            else if (t >= 0) 
            {
                runway += km;
                Allway(runway);
                amount = t;
                coord(runway);
            }
            
        }
        public float Allway(float a)
        {
            allway += a;
            return allway;
        }
        private float coord(float c)
        {
            x += c;
            return x;
        }
        public void result()
        {
            Console.WriteLine($"Осталось топлива {Math.Round(amount, 2)}");
            Console.WriteLine($"Пройдено за этот раз {Math.Round(runway, 2)}");
            Console.WriteLine($"Пройдено всего {Math.Round(Allway(0), 2)}");
            Console.WriteLine($"Пройдено координат по иксу {Math.Round(coord(0), 2)}");
            runway = 0;
        }
        //public void crush()
        //{
        //    stop();

        //}
        //public void stop()
        //{
        //    speed = 0;
        //}
    }
}
