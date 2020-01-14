namespace _01._RawData
{
    class Car
    {
        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }

        public string Model { get; set; }
        public Tire[] Tires { get; private set; }
        public Engine Engine { get; private set; }
        public Cargo Cargo { get; private set; }
    }
}