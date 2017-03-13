using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Fluffy_Tabs
{
    internal class WorkTemplate
    {
        public Dictionary<WorkGiverDef, int> baseline;
        public Dictionary<WorkGiverDef, int> ifInterest;
        public Dictionary<WorkGiverDef, int> ifPassion;
        public List<NameFlagOverride> nameFlagOverrides;
        public Dictionary<WorkGiverDef, int> minimums;
        public Dictionary<WorkGiverDef, int> maximums;

        public WorkTemplate()
        {
            baseline = new Dictionary<WorkGiverDef, int>();
            ifInterest = new Dictionary<WorkGiverDef, int>();
            ifPassion = new Dictionary<WorkGiverDef, int>();
            nameFlagOverrides = new List<NameFlagOverride>();
            minimums = new Dictionary<WorkGiverDef, int>();
            maximums = new Dictionary<WorkGiverDef, int>();
        }

        public void updatePawn(Pawn pawn)
        {

            foreach (WorkGiverDef wgd in baseline.Keys)
            {
                int priority = -1;
                if (baseline.TryGetValue(wgd, out priority))
                {
                    trySetPriority(pawn, wgd, priority);
                }
            }

            foreach (WorkGiverDef wgd in ifInterest.Keys)
            {
                int priority = -1;
                if (ifInterest.TryGetValue(wgd, out priority))
                {
                    if ( (int) pawn.skills.MaxPassionOfRelevantSkillsFor(wgd.workType) > 0 )
                    {
                        trySetPriority(pawn, wgd, priority);
                    }
                }
            }

            foreach (WorkGiverDef wgd in ifPassion.Keys)
            {
                int priority = -1;
                if (ifPassion.TryGetValue(wgd, out priority))
                {
                    if ( (int) pawn.skills.MaxPassionOfRelevantSkillsFor(wgd.workType) > 1 )
                    {
                        trySetPriority(pawn, wgd, priority);
                    }
                }
            }

            string pawnName = pawn.NameStringShort;
            bool hasDash = pawnName.Contains("-");
            string afterDash = "";
            if (hasDash)
            {
                afterDash = pawnName.Substring(pawnName.LastIndexOf('-') + 1);
            }

            foreach (NameFlagOverride nfo in nameFlagOverrides)
            {
                if (afterDash.Contains(nfo.nameFlag))
                {
                    trySetPriority(pawn, nfo.wgd, nfo.priorityOverride);
                }
            }

            PawnPrioritiesTracker ppt = WorldObject_Priorities.Get?.WorkgiverTracker(pawn);

            foreach (WorkGiverDef wgd in minimums.Keys)
            {
                int priority = -1;
                if (minimums.TryGetValue(wgd, out priority))
                {
                    if (ppt.GetPriority(wgd) == 0 || ppt.GetPriority(wgd) > priority)
                    {
                        trySetPriority(pawn, wgd, priority);
                    }
                }
            }

            foreach (WorkGiverDef wgd in maximums.Keys)
            {
                int priority = -1;
                if (maximums.TryGetValue(wgd, out priority))
                {
                    if (ppt.GetPriority(wgd) != 0 && ppt.GetPriority(wgd) < priority)
                    {
                        trySetPriority(pawn, wgd, priority);
                    }
                }
            }

        }

        private static void trySetPriority(Pawn pawn, WorkGiverDef wgd, int priority)
        {
            if (pawn != null && pawn.CapableOf(wgd))
            {
                PawnPrioritiesTracker ppt = WorldObject_Priorities.Get?.WorkgiverTracker(pawn);
                ppt.SetPriority(wgd, priority);
            }
        }

        private static void processOrderedFlags(Pawn p)
        {
            string pawnName = p.NameStringShort;
            bool hasDash = pawnName.Contains("-");
            string afterDash = "";
            if (hasDash)
            {
                afterDash = pawnName.Substring(pawnName.LastIndexOf('-') + 1);
            }

            int lastPriority = 3;
            int lastOrdinal = 0;

            int curPriority = 3;
            int curOrdinal = 0;

            bool curCaps = true;
            bool lastCaps = true;

            //WorkTemplateOf.DEFAULT.updatePawn(p);

            foreach (char c in afterDash)
            {
                List<WorkGiverDef> wgds = new List<WorkGiverDef>();
                switch (c)
                {
                    case 'D':
                        wgds.Add(MyMapper.s("treat,100"));
                        break;
                    case 'K':
                        wgds.Add(MyMapper.s("cook,100"));
                        break;
                    case 'B':
                        wgds.Add(MyMapper.s("construct,50"));
                        break;
                    case 'S':
                        wgds.Add(MyMapper.s("operate,80"));
                        break;
                    case 'W':
                        wgds.Add(MyMapper.s("chat with,60"));
                        break;
                    
                    
                    case 'H':
                    case 'h':
                        wgds.Add(MyMapper.s("tame,80"));
                        break;
                    case 'U':
                    case 'u':
                        wgds.Add(MyMapper.s("hunt,0"));
                        break;
                    case 'G':
                    case 'g':
                        wgds.Add(MyMapper.s("harvest,100"));
                        break;
                    case 'M':
                    case 'm':
                        wgds.Add(MyMapper.s("mine,100"));
                        break;
                    case 'C':
                    case 'c':
                        wgds.Add(MyMapper.s("smith,115"));
                        break;
                    case 'A':
                    case 'a':
                        wgds.Add(MyMapper.s("sculpt,100"));
                        break;
                    case 'R':
                    case 'r':
                        wgds.Add(MyMapper.s("research,0"));
                        break;
                    case 'X':
                    case 'x':
                        wgds.Add(MyMapper.s("haul,10"));
                        break;
                    case 'Y':
                    case 'y':
                        wgds.Add(MyMapper.s("clean,5"));
                        break;
                }
            }
        }
    }

    // Why the hell isn't Tuple working?
    // Whatever, rolling my own.
    // I have no idea how to C#.
    internal class NameFlagOverride
    {
        public string nameFlag;
        public WorkGiverDef wgd;
        public int priorityOverride;

        public NameFlagOverride(string nameFlag, WorkGiverDef wgd, int priorityOverride)
        {
            this.nameFlag = nameFlag;
            this.wgd = wgd;
            this.priorityOverride = priorityOverride;
        }
    }

}
