using RockPaperScissors.Exceptions;
using System; 

namespace RockPaperScissors
{
    public class RpsGame
    {
        string[] _allowedStrategies = { "R", "P", "S" };

        public string[] RpsGameWinner(string[,] elementList)
        {
            string[] winnerData = null;
            elementList = MakeStrategiesUpperCase(elementList);

            try
            {
                Validate(elementList);

                if (elementList[0, 1].Equals(elementList[1, 1]))
                {
                    winnerData = new string[] { elementList[0, 0], elementList[0, 1] };
                }
                else
                {
                    var winner = GetTheWinnerStrategy(elementList[0, 1], elementList[1, 1]);

                    for (int i = 0; i < elementList.GetLength(0); i++)
                    {
                        if (winner.Equals(elementList[i, 1]))
                        {
                            winnerData = new string[] { elementList[i, 0], elementList[i, 1] };
                        }
                    }
                }
            }
            catch (WrongNumberOfPlayersError wnop)
            {
                Console.WriteLine(wnop.Message);
            }
            catch (NoSuchStrategyError nsse)
            {
                Console.WriteLine(nsse.Message);
            }

            return winnerData;
        }

        public string[] RpsTournamentWinner(string[ , , ] tournamentList)
        {
            int participantsNumber = tournamentList.Length;
            string[] tournamentChampion = new string[2];

            try
            {
                if (VerifyTournamentStructure(participantsNumber))
                {
                    tournamentChampion = ExecuteTournament(tournamentList);
                }
            }
            catch (InvalidTournamentStructureError itse)
            {
                Console.WriteLine(itse.Message);
            }

            return tournamentChampion;
        }

        private string[] ExecuteTournament(string[,,] tournamentList)
        {
            int rounds = tournamentList.GetLength(0);

            string[,,] newTournamentFase = new string[rounds / 2, 2, 2];
            string[,] finalTournamentFase = new string[2, 2];
            string[] winner = new string[2];

            int oponentControl = 0;
            int faseControl = 0;

            for (int i = 0; i < rounds; i++)
            {
                winner = RpsGameWinner(new string[2, 2] { { tournamentList[i, 0, 0], tournamentList[i, 0, 1] }, { tournamentList[i, 1, 0], tournamentList[i, 1, 1] } });

                if (rounds > 1)
                {
                    if (oponentControl == 0)
                    {
                        faseControl++;
                        newTournamentFase[faseControl - 1, 0, 0] = winner[0];
                        newTournamentFase[faseControl - 1, 0, 1] = winner[1];
                        oponentControl++;
                    }
                    else if (oponentControl == 1)
                    {
                        newTournamentFase[faseControl - 1, 1, 0] = winner[0];
                        newTournamentFase[faseControl - 1, 1, 1] = winner[1];
                        oponentControl = 0;
                    }
                }
            }

            if (rounds > 1)
            {
                winner = ExecuteTournament(newTournamentFase);
            }

            return winner;
        }

        private bool VerifyTournamentStructure(int number)
        {
            bool correctTournamentStructure = false;

            var divisionResult = number / 2;
            var modResult = number % 2;

            if (divisionResult != 1 && modResult == 0)
            {
                correctTournamentStructure = VerifyTournamentStructure(divisionResult);
            }
            else if (divisionResult == 1 && modResult == 0)
            {
                correctTournamentStructure = true;
            }
            else
            {
                correctTournamentStructure = false;
                throw new InvalidTournamentStructureError();
            }

            return correctTournamentStructure;
        }

        private void Validate(string[,] elementList)
        {
            bool playerMissing = false;
            bool wrongStrategy = false;

            if (elementList.GetLength(0) < 2)
            {
                throw new WrongNumberOfPlayersError();
            }
            else
            {
                for (int i = 0; i < elementList.GetLength(0); i++)
                {
                    playerMissing = string.IsNullOrEmpty(elementList[i, 0]) || string.IsNullOrEmpty(elementList[i, 1]) ? true : false;
                    wrongStrategy = !isValidStrategy(elementList[i, 1]);
                }

                if (playerMissing)
                {
                    throw new WrongNumberOfPlayersError();
                }

                if (wrongStrategy)
                {
                    throw new NoSuchStrategyError();
                }
            }

        }

        private bool isValidStrategy(string strategy)
        {
            for (int i = 0; i < _allowedStrategies.Length; i++)
            {
                if (_allowedStrategies[i].Equals(strategy))
                {
                    return true;
                }
            }

            return false;
        }

        private string GetTheWinnerStrategy(string strategyA, string strategyB)
        {

            if ((strategyA.Equals("R") || strategyB.Equals("R")) && (strategyA.Equals("P") || strategyB.Equals("P")))
            {
                return "P";
            }
            else if ((strategyA.Equals("R") || strategyB.Equals("R")) && (strategyA.Equals("S") || strategyB.Equals("S")))
            {
                return "R";
            }
            else if ((strategyA.Equals("S") || strategyB.Equals("S")) && (strategyA.Equals("P") || strategyB.Equals("P")))
            {
                return "S";
            }
            else
            {
                return strategyA;
            }
        }

        private string[,] MakeStrategiesUpperCase(string[,] elementList)
        {
            for (int i = 0; i < elementList.GetLength(0); i++)
            {
                if (!string.IsNullOrEmpty(elementList[i, 0]) && !string.IsNullOrEmpty(elementList[i, 1]))
                {
                    elementList[i, 1] = elementList[i, 1].ToUpper();
                }
            }

            return elementList;
        }
    }
}
