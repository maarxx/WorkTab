using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace Fluffy_Tabs
{
    public static class NameTagProcessor
    {
        private static List<WorkGiverDef> lifeLimb;
        private static List<WorkGiverDef> baseWork;

        static NameTagProcessor()
        {
            lifeLimb = new List<WorkGiverDef>();
            lifeLimb.Add(MyMapper.s("extinguish,0"));
            lifeLimb.Add(MyMapper.s("rescue,90"));

            baseWork = new List<WorkGiverDef>();
            baseWork.Add(MyMapper.s("feed,60"));
            baseWork.Add(MyMapper.s("refuel,60"));
        }

        public static void processOrderedFlags(Pawn p)
        {

            List<WorkGiverDef> final = new List<WorkGiverDef>();

            string pawnName = p.NameStringShort;
            bool hasDash = pawnName.Contains("-");
            string afterDash = "";
            if (hasDash)
            {
                afterDash = pawnName.Substring(pawnName.LastIndexOf('-') + 1);
            }


            consumeAndAddGroup("D", ref afterDash, ref final);

            AddGroup(lifeLimb, ref final);

            consumeAndAddGroup("K", ref afterDash, ref final);

            consumeAndAddGroup("B", ref afterDash, ref final);

            final.Add(MyMapper.s("haul,80"));

            consumeAndAddGroup("S", ref afterDash, ref final);

            consumeAndAddGroup("W", ref afterDash, ref final);

            string afterDashConcurrencyBuffer = afterDash;
            foreach (char c in afterDashConcurrencyBuffer)
            {
                if(char.IsUpper(c))
                {
                    consumeAndAddGroup(c.ToString(), ref afterDash, ref final);
                }
            }

            AddGroup(baseWork, ref final);

            afterDashConcurrencyBuffer = afterDash;
            foreach (char c in afterDashConcurrencyBuffer)
            {
                consumeAndAddGroup(c.ToString(), ref afterDash, ref final);
            }

            final.Add(MyMapper.s("cut,0"));
            final.Add(MyMapper.s("hunt,0"));

            final.Add(MyMapper.s("clear snow,10"));
            final.Add(MyMapper.s("clean,5"));

            final.Add(MyMapper.s("haul,10"));

            int lastPriority = 1;
            int lastOrdinal = 0;
            foreach (WorkGiverDef wgd in final)
            {
                int thisPriority = lastPriority;
                int thisOrdinal = MyMapper.ordinal(wgd);

                if (lastOrdinal > thisOrdinal)
                {
                    thisPriority++;
                }

                trySetPriority(p, wgd, thisPriority);

                lastPriority = thisPriority;
                lastOrdinal = thisOrdinal;
            }

            foreach (WorkGiverDef wgd in DefDatabase<WorkGiverDef>.AllDefsListForReading)
            {
                if (!final.Contains(wgd))
                {
                    trySetPriority(p, wgd, 0);
                }
            }
        }

        private static void consumeAndAddGroup(string c, ref string afterDash, ref List<WorkGiverDef> final)
        {
            if (afterDash.Contains(c))
            {
                AddGroup(workGiversForFlag(c), ref final);
                afterDash.Replace(c, "");
            }
        }

        private static void AddGroup(List<WorkGiverDef> group, ref List<WorkGiverDef> final)
        {
            foreach (WorkGiverDef wgd in group)
            {
                final.Add(wgd);
            }
        }

        private static List<WorkGiverDef> workGiversForFlag(string s)
        {
            return workGiversForFlag(s[0]);
        }

        private static List<WorkGiverDef> workGiversForFlag(char c)
        {
            List<WorkGiverDef> output = new List<WorkGiverDef>();
            //char c_norm = char.ToUpper(c);
            switch (c)
            {
                case 'D':
                    output.Add(MyMapper.s("treat,100"));
                    break;
                case 'K':
                    output.Add(MyMapper.s("cook,100"));
                    break;
                case 'B':
                    output.Add(MyMapper.s("construct,50"));
                    break;
                case 'S':
                    output.Add(MyMapper.s("operate,80"));
                    break;
                case 'W':
                    output.Add(MyMapper.s("chat with,60"));
                    break;
                case 'H':
                case 'h':
                    output.Add(MyMapper.s("tame,80"));
                    break;
                case 'U':
                case 'u':
                    output.Add(MyMapper.s("hunt,0"));
                    break;
                case 'G':
                case 'g':
                    output.Add(MyMapper.s("harvest,100"));
                    break;
                case 'M':
                case 'm':
                    output.Add(MyMapper.s("mine,100"));
                    break;
                case 'C':
                case 'c':
                    output.Add(MyMapper.s("smith,115"));
                    break;
                case 'A':
                case 'a':
                    output.Add(MyMapper.s("sculpt,100"));
                    break;
                case 'R':
                case 'r':
                    output.Add(MyMapper.s("research,0"));
                    break;
                case 'X':
                case 'x':
                    output.Add(MyMapper.s("haul,10"));
                    break;
                case 'Y':
                case 'y':
                    output.Add(MyMapper.s("clean,5"));
                    break;
            }
            return output;
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
