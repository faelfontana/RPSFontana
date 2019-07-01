using System; 

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecutePartA();
            ExecutePartB();

            Console.ReadKey();
        }

        static void ExecutePartA()
        {
            string[,] elementList = new string[2, 2];

            elementList[0, 0] = "Armando";
            elementList[0, 1] = "s";
            elementList[1, 0] = "Dave";
            elementList[1, 1] = "P";

            RpsGame rpsWinner = new RpsGame();
            var result = rpsWinner.RpsGameWinner(elementList);

            if (result != null)
            {
                Console.WriteLine($"Game: {elementList[0, 0]}: {elementList[0, 1]} VS {elementList[1, 0]}: {elementList[1, 1]}");
                Console.WriteLine($"The winner is: {result[0]}: {result[1]}");
            }

            Console.ReadKey();
        }

        static void ExecutePartB()
        {
            string[,,] tournament = new string[4, 2, 2];

            tournament[0, 0, 0] = "Armando";
            tournament[0, 0, 1] = "P";
            tournament[0, 1, 0] = "Dave";
            tournament[0, 1, 1] = "S";
            tournament[1, 0, 0] = "Richard";
            tournament[1, 0, 1] = "R";
            tournament[1, 1, 0] = "Michael";
            tournament[1, 1, 1] = "S";
            tournament[2, 0, 0] = "Allen";
            tournament[2, 0, 1] = "S";
            tournament[2, 1, 0] = "Omer";
            tournament[2, 1, 1] = "P";
            tournament[3, 0, 0] = "David E.";
            tournament[3, 0, 1] = "R";
            tournament[3, 1, 0] = "Richard X.";
            tournament[3, 1, 1] = "P";

            RpsGame tournamentChampion = new RpsGame();
            var result = tournamentChampion.RpsTournamentWinner(tournament);

            if (result != null)
            {
                Console.WriteLine($"The tournament champion is: {result[0]}: {result[1]}! Congratulations!");
            }

            Console.ReadKey();
        }
    }
}
