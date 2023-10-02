using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AvtoIsay
{
    internal class Avto
    {
        string num;
        float amount;
        float consumption;
        int speed = 80;
        int runway;
        int time;
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
        public void move(int km)
        {
            time = speed / km;
            amount =- time * consumption;
            if (amount < 0)
            {
                Console.WriteLine("Мы не доедем. Есть заправка?");
            }
            else if (amount >= 0) 
            {
                runway = km;
            }
        }
        public void result()
        {
            Console.WriteLine(amount);
            Console.WriteLine(runway);
        }
        //public void slowdown()
        //{

        //}
        //public double accel()
        //{
        //    double a;
        //    a = speed / 0.00556;
        //    do
        //    {
        //        a = +a;
        //        time++;
        //    }
        //    while (a < time) ;
        //    return time;
        //}
    }
}
