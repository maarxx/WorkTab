using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Fluffy_Tabs
{

    // As I'm writing up templates, I need to pull WorkGiverDefs out of thin air.

    // I don't see WorkGiverDefOf or that would just be the answer.

    // So I guess I want them based upon unique human readable identifiers, ideally strings.

    // Eyeballing this codebase, the best I can come up with on the fly is:
    //      string uniqueID = wgd.verb + "," + wgd.priorityInType

    // So this class is just a map to let me conjure them.

    internal static class MyMapper
    {

        static Dictionary<string, WorkGiverDef> stringToWorkGiverDef = new Dictionary<string, WorkGiverDef>();
        static Dictionary<WorkGiverDef, int> absoluteOrdinals = new Dictionary<WorkGiverDef, int>();

        static MyMapper()
        {
            foreach (WorkGiverDef wgd in DefDatabase<WorkGiverDef>.AllDefsListForReading)
            {
                WorkTypeDef wtd = wgd.workType;
                string stringID = wgd.verb + "," + wgd.priorityInType;
                int absoluteOrdinal = wtd.naturalPriority * 100 + wgd.priorityInType;
                stringToWorkGiverDef.Add(stringID, wgd);
                absoluteOrdinals.Add(wgd, absoluteOrdinal);
            }
        }

        public static WorkGiverDef s(string s)
        {
            WorkGiverDef myOut = null;
            stringToWorkGiverDef.TryGetValue(s, out myOut);
            return myOut;
        }

        public static int ordinal(WorkGiverDef wgd)
        {
            int myOut;
            absoluteOrdinals.TryGetValue(wgd, out myOut);
            return myOut;
        }

    }
}
