using System;

namespace RockPaperScissors.Exceptions
{
    public class InvalidTournamentStructureError : Exception
    {
        public InvalidTournamentStructureError()
            : base("The tournament structure is not valid!")
        {
        }
    }
}
