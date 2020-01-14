namespace _01._RawData
{
    class Tire
    {
        public Tire(double pressure,int age)
        {
            Age = age;
            Pressure = pressure;
        }

        public double Pressure { get; private set; }
        public int Age { get; private set; }
    }
}
