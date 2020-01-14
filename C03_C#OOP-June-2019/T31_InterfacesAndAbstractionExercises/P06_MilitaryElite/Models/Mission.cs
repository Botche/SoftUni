using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Mission
    {
        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; private set; }
        public string State { get; private set; }

        public void CompleteMission (Mission mission)
        {
            if (mission.State=="inProgress")
            {
                mission.State = "Finished";
            }
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }

        public bool CheckMissionState(string state)
        {
            bool isValid = true;

            if (state != "Finished" && state != "inProgress")
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
