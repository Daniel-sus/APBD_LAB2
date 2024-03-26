namespace Task2
{
    public class GasContainer : Container, IHazardNotifier
    {
        public double Pressure { get; private set; }

        public GasContainer(string serialNumber, double cargoMass, double height, double tareWeight, double depth, double maxPayload, double pressure)
            : base(serialNumber, cargoMass, height, tareWeight, depth, maxPayload)
        {
            Pressure = pressure;
        }

        public override void LoadCargo(double cargoMass)
        {
            if (cargoMass < 0)
            {
                throw new ArgumentException("Cargo mass cannot be negative.");
            }

            if (cargoMass > MaxPayload)
            {
                throw new OverfillException("Cargo mass exceeds allowable payload.");
            }

            CargoMass = cargoMass;
        }

        public override void EmptyCargo()
        {
            CargoMass *= 0.05;
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine($"Hazardous situation: {message}. Container number: {SerialNumber}");
        }
    }
}