using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Fluffy_Tabs
{
    // As I'm writing up templates, I need to pull WorkGiverDefs out of thin air
    // based upon unique human readable identifiers, ideally strings.

    // Eyeballing this codebase, the best I can come up with on the fly is:
    //      string uniqueID = wgd.verb + "," + wgd.priorityInType

    // So this class is just a bidirectional map to let me go back and forth.
    
    internal static class MyMapper
    {
        // This is just a bidirectional map.
        // I don't know much about C#, and don't want to add any dependences,
        // so I think we'll just use two Dictionaries, one in each direction.

        static Dictionary<string, WorkGiverDef> stringToWorkGiverDef = new Dictionary<string, WorkGiverDef>();
        static Dictionary<WorkGiverDef, string> workGiverDefToString = new Dictionary<WorkGiverDef, string>();

        static MyMapper()
        {
            foreach (WorkGiverDef wgd in DefDatabase<WorkGiverDef>.AllDefsListForReading)
            {
                string stringID = wgd.verb + "," + wgd.priorityInType;
                stringToWorkGiverDef.Add(stringID, wgd);
                workGiverDefToString.Add(wgd, stringID);
            }
        }

        public static WorkGiverDef s(string s)
        {
            WorkGiverDef myOut = null;
            stringToWorkGiverDef.TryGetValue(s, out myOut);
            return myOut;
        }

        public static string wgd(WorkGiverDef wgd)
        {
            string myOut = null;
            workGiverDefToString.TryGetValue(wgd, out myOut);
            return myOut;
        }

    }
}
