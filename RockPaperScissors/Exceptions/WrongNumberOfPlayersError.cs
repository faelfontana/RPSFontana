using System;

namespace RockPaperScissors.Exceptions
{
    class WrongNumberOfPlayersError : Exception
    {
        public WrongNumberOfPlayersError()
            : base("You must to inform 2 players.")
        {
        }
    }
}
