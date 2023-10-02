using AvtoIsay;
class program
{
    static void Main()
    {
        Random rand = new Random();
        Avto car = new Avto();
        car.info("1", 50, 7);
        car.zapravka(50);
        car.move(rand.Next(1, 500));
        //Avto[] cars = new Avto[5];
        //for (int i = 0; i < cars.Length; i++)
        //{
        //    cars[i] = new Avto();
        //}
        car.result();

    }
}