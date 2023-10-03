using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace AvtoIsay
{
    class Avto
    {
        ConsoleKeyInfo key;
        private string num;
        private float amount;
        private float consumption;
        private float speed = 80;
        private float runway;
        private float time;
        private float allway;
        private float x;
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
            float s = km;
            time = s / speed;
            t -= time * consumption;
            if (t < 0)
            {
                time = amount / consumption;
                s -= speed * time;
                runway += km - s;
                Console.WriteLine($"Номер автомобиля {num}");
                Console.WriteLine($"Осталось топлива {0}");
                Console.WriteLine($"Мы проехали {Math.Round(runway, 2)} км, но топливо кончилось. Есть заправка? Напишите y/n");
                key = Console.ReadKey();
                Console.WriteLine(" ");
                switch (key.Key.ToString())
                {
                    case "Y":
                        Console.WriteLine("Сколько вы хотите заправить?");
                        t = Convert.ToInt32(Console.ReadLine());
                        zapravka(t);
                        move(s);
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
        private float Allway(float a)
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
            Console.WriteLine($"Номер автомобиля {num}");
            Console.WriteLine($"Осталось топлива {Math.Round(amount, 2)}");
            Console.WriteLine($"Пройдено за этот раз {Math.Round(runway, 2)}");
            Console.WriteLine($"Пройдено всего {Math.Round(Allway(0), 2)}");
            Console.WriteLine($"Пройдено координат по иксу {Math.Round(coord(0), 2)}");
            Console.WriteLine(" ");
            runway = 0;
        }
        private void accel()
        {

        }
        private void slowdown()
        {

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
