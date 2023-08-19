namespace PassengerSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PassengerSystem passengerSystem = new PassengerSystem();

            passengerSystem.printDM();
            passengerSystem.placePassengers();
            passengerSystem.printSeatList();
            passengerSystem.printTotalDistances();
        }
    }
}
