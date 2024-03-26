namespace Task2
{
    public class ContainerShip
    {
        public ContainerShip(int maxSpeed, int maxContainerNumber, double maxWeight)
        {
            MaxSpeed = maxSpeed;
            MaxContainerNumber = maxContainerNumber;
            MaxWeight = maxWeight;
        }

        public List<Container> Containers { get; set; } = new List<Container>();
        public int MaxSpeed { get; }
        public int MaxContainerNumber { get; }
        public double MaxWeight { get; }

        public void AddContainer(Container container)
        {
            if (Containers.Count >= MaxContainerNumber)
            {
                throw new InvalidOperationException("Cannot add more containers, ship capacity reached.");
            }

            double totalWeight = TotalWeight() + container.CargoMass;
            if (totalWeight > MaxWeight)
            {
                throw new InvalidOperationException("Cannot add container, ship weight limit exceeded.");
            }

            Containers.Add(container);
        }


        public void RemoveContainer(Container container)
        {
            Containers.Remove(container);
        }

        public void LoadContainers(List<Container> newContainers)
        {
            if ((Containers.Count + newContainers.Count) > MaxContainerNumber)
            {
                throw new InvalidOperationException("Cannot load more containers, ship capacity reached.");
            }

            double totalWeight = TotalWeight();
            foreach (var container in newContainers)
            {
                if ((totalWeight + container.CargoMass) > MaxWeight)
                {
                    throw new InvalidOperationException("Cannot load container, ship weight limit exceeded.");
                }
                Containers.Add(container);
                totalWeight += container.CargoMass;
            }
        }

        public void UnloadContainer(Container container)
        {
            Containers.Remove(container);
        }

        public void ReplaceContainer(Container oldContainer, Container newContainer)
        {
            int index = Containers.IndexOf(oldContainer);
            if (index != -1)
            {
                Containers[index] = newContainer;
            }
        }

        public void TransferContainer(Container container, ContainerShip destinationShip)
        {
            Containers.Remove(container);
            destinationShip.AddContainer(container);
        }

        public void PrintShipInfo()
        {
            Console.WriteLine($"Ship Max Speed: {MaxSpeed} knots");
            Console.WriteLine($"Max Container Number: {MaxContainerNumber}");
            Console.WriteLine($"Max Weight: {MaxWeight} tons");
            Console.WriteLine($"Current Container Count: {Containers.Count}");
            Console.WriteLine("Containers on board:");
            foreach (var container in Containers)
            {
                Console.WriteLine($"- Serial Number: {container.SerialNumber}, Cargo Mass: {container.CargoMass} kg");
            }
        }

        private double TotalWeight()
        {
            double totalWeight = 0;
            foreach (var container in Containers)
            {
                totalWeight += container.CargoMass;
            }
            return totalWeight;
        }

    }
}