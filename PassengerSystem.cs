using System;

namespace PassengerSystem
{
    public class PassengerSystem
    {
        private const int PASSENGER_CAPACITY = 40;
        private double[,] DM;
        private string[] passengers;
        private string[] seats;
        private double[] distances;

        public PassengerSystem()
        {
            this.DM = new double[PASSENGER_CAPACITY, PASSENGER_CAPACITY];
            Random random = new Random();

            for (int i = 0; i < DM.GetLength(0); i++)
            {
                for (int j = 0; j < DM.GetLength(1); j++)
                {
                    if (i == j) DM[i,j] = 0.0;
                    else DM[i, j] = Math.Round(random.NextDouble() * 9.8, 1) + 0.1;

                    DM[j, i] = DM[i, j];
                }
            }

            this.passengers = new string[PASSENGER_CAPACITY]
            {
            "John Smith",
            "Mary Johnson",
            "James Brown",
            "Jennifer Davis",
            "Michael Wilson",
            "Linda Anderson",
            "David Lee",
            "Susan Martinez",
            "Robert Taylor",
            "Patricia Garcia",
            "William Miller",
            "Karen Rodriguez",
            "Richard Martinez",
            "Nancy Harris",
            "Joseph Jackson",
            "Jessica Taylor",
            "Thomas Lewis",
            "Elizabeth White",
            "Charles Clark",
            "Sarah Walker",
            "Daniel Turner",
            "Lisa King",
            "Matthew Hall",
            "Margaret Young",
            "Kevin Adams",
            "Laura Scott",
            "Christopher Wright",
            "Kimberly Allen",
            "Edward Hill",
            "Donna Perez",
            "Brian Moore",
            "Ruth Turner",
            "Mark Phillips",
            "Sharon Evans",
            "George Hernandez",
            "Carol Mitchell",
            "Steven Campbell",
            "Deborah Green",
            "Paul Anderson",
            "Amanda Martinez"
            };

            seats = new string[PASSENGER_CAPACITY];
            distances = new double[PASSENGER_CAPACITY];
        }

        public void printDM()
        {
            Console.Write("\nDistance Matrix (DM): \n\n ");

            for (int i = 0; i < 10; i++)
                Console.Write("     " + (i + 1));

            for (int i = 10; i < this.DM.GetLength(1); i++)
                Console.Write("    " + (i + 1));

            Console.WriteLine();

            for (int i = 0; i < this.DM.GetLength(0); i++)
            {
                Console.WriteLine();

                if (i < 9)
                    Console.Write(" ");

                Console.Write((i + 1) + "   ");

                for (int j = 0; j < this.DM.GetLength(1); j++)
                    Console.Write("{0:0.0}   ", DM[i,j]);

                Console.WriteLine();
            }
        }

        public bool isPassengerPlaced(string pName)
        {
            foreach (string name in seats)
            {
                if (pName == name)
                    return true;
            }

            return false;
        }

        public int findPassengerIndex(string pName)
        {
            int count = 0;
            foreach (string name in passengers)
            {
                if (pName == name)
                    break;

                count++;
            }

            return count;
        }

        public void placePassengers()
        {
            Random random = new Random();

            seats[0] = passengers[random.Next(0, 40)];
            distances[0] = 0.0;

            double shortestDistance; int pIndex = 0;

            for (int i = 1; i <= 3; i++)
            {
                shortestDistance = 10.0;

                for (int j = 0; j < PASSENGER_CAPACITY; j++)
                {
                    if (isPassengerPlaced(passengers[j])) continue;

                    if (DM[findPassengerIndex(seats[i - 1]), j] < shortestDistance)
                    {
                        pIndex = j;
                        shortestDistance = DM[findPassengerIndex(seats[i - 1]), j];
                    }
                }

                seats[i] = passengers[pIndex];
                distances[i] = shortestDistance;
            }

            for (int i = 4; i < PASSENGER_CAPACITY; i++)
            {
                if (i % 4 == 0)
                {
                    shortestDistance = 20.0;

                    for (int j = 0; j < PASSENGER_CAPACITY; j++)
                    {
                        if (isPassengerPlaced(passengers[j])) continue;

                        double totalDistance = DM[findPassengerIndex(seats[i - 4]), j] + DM[findPassengerIndex(seats[i - 3]), j];

                        if (totalDistance < shortestDistance)
                        {
                            pIndex = j;
                            shortestDistance = totalDistance;
                        }
                    }
                }

                else if (i % 4 == 3)
                {
                    shortestDistance = 30.0;

                    for (int j = 0; j < PASSENGER_CAPACITY; j++)
                    {
                        if (isPassengerPlaced(passengers[j])) continue;

                        double totalDistance = DM[findPassengerIndex(seats[i - 1]), j] + DM[findPassengerIndex(seats[i - 5]), j] + DM[findPassengerIndex(seats[i - 4]), j];

                        if (totalDistance < shortestDistance)
                        {
                            pIndex = j;
                            shortestDistance = totalDistance;
                        }
                    }
                }

                else
                {
                    shortestDistance = 40.0;

                    for (int j = 0; j < PASSENGER_CAPACITY; j++)
                    {
                        if (isPassengerPlaced(passengers[j])) continue;

                        double totalDistance = DM[findPassengerIndex(seats[i - 1]), j] + DM[findPassengerIndex(seats[i - 5]), j] + DM[findPassengerIndex(seats[i - 4]), j] + DM[findPassengerIndex(seats[i - 3]), j];

                        if (totalDistance < shortestDistance)
                        {
                            pIndex = j;
                            shortestDistance = totalDistance;
                        }
                    }
                }

                seats[i] = passengers[pIndex];
                distances[i] = shortestDistance;
            }
        }

        public void printSeatList()
        {
            int count = 1;
            Console.WriteLine("\nPassenger seat list: ");

            foreach (String name in seats)
            {
                if (count % 4 == 1) Console.WriteLine();
                Console.Write((findPassengerIndex(name) + 1) + " - " + name + "    ");
                count++;
            }
        }

        public void printTotalDistances()
        {
            int count = 1; double totalDistance = 0;
            Console.WriteLine("\n\nPassengers in seats' distances: ");

            foreach (double distance in distances)
            {
                if (count % 4 == 1)
                    Console.WriteLine();

                if (count < 10)
                    Console.Write(" ");

                Console.Write("{0} - {1:0.0}    ", count++, distance);

                if (distance < 10.0)
                    Console.Write(" ");

                totalDistance += distance;
            }

            Console.WriteLine("\n\nTotal distances for all passengers: {0:0.0}", totalDistance);
        }
    }
}
