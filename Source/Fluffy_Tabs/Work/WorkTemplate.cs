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
        public Dictionary<WorkGiverDef, int> minimums;
        public Dictionary<WorkGiverDef, int> maximums;

        public WorkTemplate()
        {
            baseline = new Dictionary<WorkGiverDef, int>();
            ifInterest = new Dictionary<WorkGiverDef, int>();
            ifPassion = new Dictionary<WorkGiverDef, int>();
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
                    if ((int)pawn.skills.MaxPassionOfRelevantSkillsFor(wgd.workType) > 0)
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
                    if ((int)pawn.skills.MaxPassionOfRelevantSkillsFor(wgd.workType) > 1)
                    {
                        trySetPriority(pawn, wgd, priority);
                    }
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

    }
}
