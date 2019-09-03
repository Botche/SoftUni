using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Common
{
    public class ExceptionMessages
    {
        public const string InvalidMachineName = "Machine name cannot be null or empty.";

        public const string InvalidPilotName = "Pilot name cannot be null or empty string.";

        public const string NullPilot = "Pilot cannot be null.";

        public const string NullTarget = "Target cannot be null.";

        public const string NullMachineTriedToAddToPilot = "Null machine cannot be added to the pilot.";

    }
}
