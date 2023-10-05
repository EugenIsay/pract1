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
        private float value;
        private float amount;
        private float consumption;
        private float speed = 80;
        private float runway;
        private float time;
        private float allway;
        private float x;
        private float ac;
        private float sl;
        public void info(string num, float amount, float consumption)
        {
            this.num = num;
            this.amount = amount;
            this.consumption = consumption;
        }
        public void dop(float d) 
        { 
            value = d;
        }
        public void zapravka(float top)
        {
            amount = top;
        }
        public void move(float km)
        {
            Console.WriteLine($" = Нужно проехать {km + runway}");
            float t = amount;
            float s = km - accel() - slowdown();
            time = s / speed;
            t -= (time + float.Parse("0,002778") + float.Parse("0,000825")) * consumption;
            if (t < 0)
            {
                time = (amount - ((float.Parse("0,002778") + float.Parse("0,000825")) * consumption)) / consumption;
                s -= speed * time;
                s += accel() + slowdown();
                runway += km - s;
                Console.WriteLine($"Номер автомобиля {num}");
                Console.WriteLine($"Осталось топлива {0}");
                Console.WriteLine($"Не хватает топлива {Math.Round(Math.Abs(t). 2)}");
                Console.WriteLine($"Всего проехали {Math.Round(runway + Allway(0), 2)}");
                Console.WriteLine($"Мы проехали {Math.Round(runway, 2)} км, но топливо кончилось. Есть заправка? Напишите y/n");
                key = Console.ReadKey();
                Console.WriteLine(" ");
                switch (key.Key.ToString())
                {
                    case "Y":
                        Console.WriteLine("Сколько вы хотите заправить?");
                        t = Convert.ToInt32(Console.ReadLine());
                        while (value < t)
                        {
                            Console.WriteLine("У нас не настолько большой бак");
                            Console.WriteLine("Сколько вы хотите заправить?");
                            t = Convert.ToInt32(Console.ReadLine());
                        }
                        zapravka(t);
                        move(s);
                        break;
                    case "N":
                        Console.WriteLine($"Пройдено всего {runway}");
                        Environment.Exit(0);
                        break;
                    default:
                        runway -= km - s;
                        move(km);
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
            Console.WriteLine($"Номер автомобиля {num}");
            Console.WriteLine($"Осталось топлива {Math.Round(amount, 2)}");
            Console.WriteLine($"Пройдено за этот раз {Math.Round(runway, 2)}");
            Console.WriteLine($"Пройдено всего {Math.Round(Allway(0), 2)}");
            Console.WriteLine($"Пройдено координат по иксу {Math.Round(coord(0), 2)}");
            Console.WriteLine(" ");
            runway = 0;
        }
        private float accel()
        {
            time = float.Parse("0,002778");
            ac = speed / time;
            ac = ac * (float)Math.Pow(time, 2);
            return ac;
        }
        private float slowdown()
        {
            time = float.Parse("0,000825");
            sl = Math.Abs(time * speed);
            return sl;
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
