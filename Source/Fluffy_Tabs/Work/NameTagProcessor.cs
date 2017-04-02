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

        private static List<WorkGiverDef> spacers;

        private static List<WorkGiverDef> lifeLimb;
        private static List<WorkGiverDef> baseWork;

        static NameTagProcessor()
        {

            lifeLimb = new List<WorkGiverDef>();
            lifeLimb.Add(MyMapper.s("extinguish,0"));
            lifeLimb.Add(MyMapper.s("receive treatment in,0"));
            lifeLimb.Add(MyMapper.s("rescue,90"));
            lifeLimb.Add(MyMapper.s("take to operate,5"));
            lifeLimb.Add(MyMapper.s("get bed rest in,0"));
            lifeLimb.Add(MyMapper.s("flick switch on,500"));
            lifeLimb.Add(MyMapper.s("do execution on,110"));
            lifeLimb.Add(MyMapper.s("release,100"));
            lifeLimb.Add(MyMapper.s("take to bed,90"));
            lifeLimb.Add(MyMapper.s("repair,80"));
            //lifeLimb.Add(MyMapper.s("haul,80"));

            baseWork = new List<WorkGiverDef>();
            baseWork.Add(MyMapper.s("refuel,60"));
            baseWork.Add(MyMapper.s("manage,100"));
            baseWork.Add(MyMapper.s("feed,60"));
            baseWork.Add(MyMapper.s("feed,80"));
            baseWork.Add(MyMapper.s("deliver food for,70"));
            baseWork.Add(MyMapper.s("slaughter,100"));
            baseWork.Add(MyMapper.s("fill,50"));
            baseWork.Add(MyMapper.s("brew,30"));
            baseWork.Add(MyMapper.s("build roof,70"));
            baseWork.Add(MyMapper.s("remove roof,60"));
            baseWork.Add(MyMapper.s("work on,40"));
            
            baseWork.Add(MyMapper.s("mine_JTReplaceWalls,22"));
            baseWork.Add(MyMapper.s("deconstruct,20"));
            baseWork.Add(MyMapper.s("uninstall,19"));

            baseWork.Add(MyMapper.s("work on,9"));

            baseWork.Add(MyMapper.s("unload,120"));
            baseWork.Add(MyMapper.s("load,110"));
            baseWork.Add(MyMapper.s("strip,100"));
            baseWork.Add(MyMapper.s("bury,90"));
            //baseWork.Add(MyMapper.s("haul,80"));
            baseWork.Add(MyMapper.s("open,70"));
            baseWork.Add(MyMapper.s("rearm,50"));
            baseWork.Add(MyMapper.s("cremate,40"));
            baseWork.Add(MyMapper.s("work at,30"));
            baseWork.Add(MyMapper.s("take beer,20"));
            baseWork.Add(MyMapper.s("fill,19"));

            spacers = new List<WorkGiverDef>();
            for (int i = 0; i < 20; i++)
            {
                WorkGiverDef nextSpacer = new WorkGiverDef();
                nextSpacer.verb = "SPACER";
                nextSpacer.priorityInType = i;
                spacers.Add(nextSpacer);
            }

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

            final.Add(spacers[1]);

            consumeAndAddGroup("D", ref afterDash, ref final);

            consumeAndAddGroup("S", ref afterDash, ref final);

            final.Add(spacers[3]);

            AddGroup(lifeLimb, ref final);

            final.Add(spacers[4]);

            consumeAndAddGroup("W", ref afterDash, ref final);

            consumeAndAddGroup("K", ref afterDash, ref final);

            consumeAndAddGroup("B", ref afterDash, ref final);

            final.Add(MyMapper.s("haul,80"));

            final.Add(spacers[5]);

            string afterDashConcurrencyBuffer = afterDash;
            foreach (char c in afterDashConcurrencyBuffer)
            {
                if (char.IsUpper(c))
                {
                    consumeAndAddGroup(c.ToString(), ref afterDash, ref final);
                }
            }

            final.Add(spacers[8]);

            AddGroup(baseWork, ref final);

            final.Add(spacers[13]);

            afterDashConcurrencyBuffer = afterDash;
            foreach (char c in afterDashConcurrencyBuffer)
            {
                consumeAndAddGroup(c.ToString(), ref afterDash, ref final);
            }

            final.Add(spacers[16]);

            addIfNotContains(MyMapper.s("clear snow,10"), ref final);
            addIfNotContains(MyMapper.s("clean,5"), ref final);

            addIfNotContains(MyMapper.s("haul,10"), ref final);

            final.Add(spacers[18]);

            final.Add(MyMapper.s("cut,0"));

            addIfNotContains(MyMapper.s("hunt,0"), ref final);

            addIfNotContains(MyMapper.s("refine,80"), ref final);

            addIfNotContains(MyMapper.s("stonecut,90"), ref final);

            addIfNotContains(MyMapper.s("craft,100"), ref final);

            assignListToPawn(p, final);

        }

        public static void assignListToPawn(Pawn p, List<WorkGiverDef> final)
        {

            int lastPriority = 1;
            int lastOrdinal = 999999999;
            foreach (WorkGiverDef wgd in final)
            {
                if (wgd.verb == "SPACER")
                {
                    lastPriority = wgd.priorityInType;
                    lastOrdinal = 999999999;
                }
                else
                {
                    int thisPriority = lastPriority;
                    int thisOrdinal = MyMapper.ordinal(wgd);

                    if (lastOrdinal < thisOrdinal)
                    {
                        thisPriority++;
                    }

                    if (trySetPriority(p, wgd, thisPriority))
                    {
                        lastPriority = thisPriority;
                        lastOrdinal = thisOrdinal;
                    }
                }
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
                afterDash = afterDash.Replace(c, "");
            }
        }

        private static void AddGroup(List<WorkGiverDef> group, ref List<WorkGiverDef> final)
        {
            foreach (WorkGiverDef wgd in group)
            {
                addIfNotContains(wgd, ref final);
            }
        }

        private static List<WorkGiverDef> workGiversForFlag(string s)
        {
            return workGiversForFlag(s[0]);
        }

        private static List<WorkGiverDef> workGiversForFlag(char c)
        {
            List<WorkGiverDef> output = new List<WorkGiverDef>();
            switch (c)
            {
                case 'D':
                    output.Add(MyMapper.s("treat,100"));
                    output.Add(MyMapper.s("treat,70"));
                    break;
                case 'K':
                    output.Add(MyMapper.s("cook,100"));
                    output.Add(MyMapper.s("cook,97"));
                    output.Add(MyMapper.s("butcher,90"));
                    break;
                case 'B':
                    output.Add(MyMapper.s("replace broken components in,90"));
                    output.Add(MyMapper.s("construct,50"));
                    output.Add(MyMapper.s("remove floor,10"));
                    output.Add(MyMapper.s("smooth,5"));
                    break;
                case 'S':
                    output.Add(MyMapper.s("operate,80"));
                    output.Add(MyMapper.s("operate,50"));
                    output.Add(MyMapper.s("modify,100"));
                    break;
                case 'W':
                    output.Add(MyMapper.s("chat with,60"));
                    break;
                case 'H':
                case 'h':
                    output.Add(MyMapper.s("milk,90"));
                    output.Add(MyMapper.s("shear,85"));
                    output.Add(MyMapper.s("tame,80"));
                    output.Add(MyMapper.s("train,70"));
                    break;
                case 'U':
                case 'u':
                    output.Add(MyMapper.s("hunt,0"));
                    break;
                case 'G':
                case 'g':
                    output.Add(MyMapper.s("harvest,100"));
                    output.Add(MyMapper.s("sow,50"));
                    break;
                case 'M':
                case 'm':
                    output.Add(MyMapper.s("mine,100"));
                    output.Add(MyMapper.s("drill,50"));
                    break;
                case 'C':
                case 'c':
                    output.Add(MyMapper.s("smith,115"));
                    output.Add(MyMapper.s("work,75"));
                    output.Add(MyMapper.s("produce components,50"));
                    output.Add(MyMapper.s("refine chemicals,97"));
                    output.Add(MyMapper.s("produce drugs,95"));
                    output.Add(MyMapper.s("tailor,110"));
                    output.Add(MyMapper.s("craft,100"));
                    //output.Add(MyMapper.s("stonecut,90"));
                    //output.Add(MyMapper.s("refine,80"));
                    break;
                case 'P':
                case 'p':
                    output.Add(MyMapper.s("produce drugs,95"));
                    break;
                case 'T':
                case 't':
                    output.Add(MyMapper.s("tailor,110"));
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
                    output.Add(MyMapper.s("clear snow,10"));
                    output.Add(MyMapper.s("clean,5"));
                    break;
            }
            return output;
        }

        public static void generateNameTag(Pawn pawn)
        {
            string pawnName = pawn.NameStringShort;

            bool hasDash = pawnName.Contains(" -");
            string beforeDash = pawnName;
            if (hasDash)
            {
                beforeDash = pawnName.Substring(0, pawnName.LastIndexOf(" -"));
            }

            string nameTag = " -";
            if ( pawnHasInterest(pawn, MyMapper.s("treat,100")) )
            {
                nameTag += "D";
            }
            if (pawnHasInterest(pawn, MyMapper.s("cook,100")))
            {
                nameTag += "K";
            }
            if (pawnHasInterest(pawn, MyMapper.s("construct,50")))
            {
                nameTag += "B";
            }
            if (pawnHasInterest(pawn, MyMapper.s("chat with,60")))
            {
                nameTag += "W";
            }
            nameTag += "+";
            if (pawnHasInterest(pawn, MyMapper.s("tame,80")))
            {
                nameTag += "h";
            }
            if (pawnHasInterest(pawn, MyMapper.s("harvest,100")))
            {
                nameTag += "g";
            }
            if (pawnHasInterest(pawn, MyMapper.s("mine,100")))
            {
                nameTag += "m";
            }
            if (pawnHasInterest(pawn, MyMapper.s("smith,115")))
            {
                nameTag += "c";
            }
            if (pawnHasInterest(pawn, MyMapper.s("sculpt,100")))
            {
                nameTag += "a";
            }
            if (pawnHasInterest(pawn, MyMapper.s("research,0")))
            {
                nameTag += "r";
            }

            string newNick = beforeDash + nameTag;

            renamePawn(pawn, newNick);
        }

        private static void renamePawn(Pawn pawn, string newNick)
        {
            NameTriple oldName = (NameTriple) pawn.Name;
            pawn.Name = new NameTriple(oldName.First, newNick, oldName.Last);
        }

        private static bool trySetPriority(Pawn pawn, WorkGiverDef wgd, int priority)
        {
            PawnPrioritiesTracker ppt = WorldObject_Priorities.Get?.WorkgiverTracker(pawn);
            if (pawn != null && pawn.CapableOf(wgd))
            {
                
                ppt.SetPriority(wgd, priority);
                return true;
            }
            else
            {
                ppt.SetPriority(wgd, 0);
                return false;
            }
        }

        private static bool pawnHasInterest(Pawn pawn, WorkGiverDef wgd)
        {
            return ((int)pawn.skills.MaxPassionOfRelevantSkillsFor(wgd.workType) > 0);
        }

        private static void addIfNotContains(WorkGiverDef wgd, ref List<WorkGiverDef> container)
        {
            if (!container.Contains(wgd))
            {
                container.Add(wgd);
            }
        }

    }
}
