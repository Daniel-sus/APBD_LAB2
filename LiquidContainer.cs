namespace Task2
{
    public class LiquidContainer : Container, IHazardNotifier
    {

        public string LiquidType { get; }

        public bool IsHazardous { get; private set; }

        public LiquidContainer(string serialNumber, double cargoMass, double height, double tareWeight, double depth, double maxPayload, string liquidType, bool isHazardous)
            : base(serialNumber, cargoMass, height, tareWeight, depth, maxPayload)
        {
            LiquidType = liquidType;

            IsHazardous = isHazardous;
        }

        public override void LoadCargo(double cargoMass)
        {
            if (cargoMass < 0)
            {
                throw new ArgumentException("Cargo mass cannot be negative.");
            }

            if (IsHazardous)
            {
                if (cargoMass > MaxPayload * 0.5)
                {
                    throw new OverfillException("Attempting to fill hazardous cargo beyond allowed limit.");
                }
            }
            else
            {
                if (cargoMass > MaxPayload * 0.9)
                {
                    throw new OverfillException("Attempting to overfill container beyond allowed limit.");
                }
            }

            CargoMass = cargoMass;
        }

        public override void EmptyCargo()
        {
            CargoMass = 0;
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine($"Hazardous situation: {message}. Container number: {SerialNumber}");
        }

    }
}