using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public static class ExceptionMessages
    {
        public static string InvalidName = "A name should not be empty.";
        public static string InvalidStat = "{0} should be between 0 and 100.";
        public static string InvalidPlayer = "Player {0} is not in {1} team.";
        public static string InvalidTeam = "Team {0} does not exist.";
        public static string ShowInvalidTeam = "Team {0} does not exist.";
    }
}
