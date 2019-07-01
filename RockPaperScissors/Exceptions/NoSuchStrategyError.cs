using System;

namespace RockPaperScissors.Exceptions
{
    class NoSuchStrategyError : Exception
    {
        public NoSuchStrategyError()
            : base("The only Strategies allowed are: 'R', 'P' and 'S' ")
        {
        }
    }
}
