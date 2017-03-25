using RimWorld;
using Verse;

namespace Fluffy_Tabs
{
    internal static class WorkTemplateOf
    {

        public static WorkTemplate FLEX;
        public static WorkTemplate CLEANHAUL;
        public static WorkTemplate HUNT;
        public static WorkTemplate FOOD;
        public static WorkTemplate CLEAR;

        static WorkTemplateOf()
        {

            FLEX = new WorkTemplate();

            FLEX.maximums.Add(MyMapper.s("cut,0"), 15);
            FLEX.maximums.Add(MyMapper.s("hunt,0"), 15);

            FLEX.maximums.Add(MyMapper.s("chat with,60"), 15);
            FLEX.maximums.Add(MyMapper.s("tame,80"), 15);
            FLEX.maximums.Add(MyMapper.s("train,70"), 15);
            FLEX.maximums.Add(MyMapper.s("harvest,100"), 15);
            FLEX.maximums.Add(MyMapper.s("sow,50"), 15);
            FLEX.maximums.Add(MyMapper.s("mine,100"), 15);
            FLEX.maximums.Add(MyMapper.s("drill,50"), 15);
            FLEX.maximums.Add(MyMapper.s("smith,115"), 15);
            FLEX.maximums.Add(MyMapper.s("work,75"), 15);
            FLEX.maximums.Add(MyMapper.s("produce components,50"), 15);
            FLEX.maximums.Add(MyMapper.s("tailor,110"), 15);
            FLEX.maximums.Add(MyMapper.s("sculpt,100"), 15);
            FLEX.maximums.Add(MyMapper.s("craft,100"), 15);
            FLEX.maximums.Add(MyMapper.s("refine chemicals,97"), 15);
            FLEX.maximums.Add(MyMapper.s("produce drugs,95"), 15);
            FLEX.maximums.Add(MyMapper.s("stonecut,90"), 15);
            FLEX.maximums.Add(MyMapper.s("refine,80"), 15);
            FLEX.maximums.Add(MyMapper.s("research,0"), 15);

            FLEX.maximums.Add(MyMapper.s("haul,10"), 15);

            FLEX.maximums.Add(MyMapper.s("clear snow,10"), 15);
            FLEX.maximums.Add(MyMapper.s("clean,5"), 15);



            CLEANHAUL = new WorkTemplate();

            CLEANHAUL.minimums.Add(MyMapper.s("haul,10"), 11);
            CLEANHAUL.minimums.Add(MyMapper.s("clear snow,10"), 10);
            CLEANHAUL.minimums.Add(MyMapper.s("clean,5"), 10);



            FOOD = new WorkTemplate();

            FOOD.minimums.Add(MyMapper.s("harvest,100"), 5);
            FOOD.minimums.Add(MyMapper.s("sow,50"), 5);
            FOOD.minimums.Add(MyMapper.s("haul,10"), 10);
            FOOD.minimums.Add(MyMapper.s("cut,0"), 11);
            FOOD.minimums.Add(MyMapper.s("hunt,0"), 12);



            HUNT = new WorkTemplate();

            HUNT.minimums.Add(MyMapper.s("hunt,0"), 10);



            CLEAR = new WorkTemplate();
            foreach (WorkGiverDef wgd in DefDatabase<WorkGiverDef>.AllDefsListForReading)
            {
                CLEAR.baseline.Add(wgd, 0);
            }



        }
    }
}
