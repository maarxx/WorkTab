namespace Fluffy_Tabs
{
    internal static class WorkTemplateOf
    {

        public static WorkTemplate FLEX;

        static WorkTemplateOf()
        {

            FLEX = new WorkTemplate();

            FLEX.maximums.Add(MyMapper.s("cut,0"), 9);
            FLEX.maximums.Add(MyMapper.s("hunt,0"), 9);

            FLEX.maximums.Add(MyMapper.s("chat with,60"), 9);
            FLEX.maximums.Add(MyMapper.s("tame,80"), 9);
            FLEX.maximums.Add(MyMapper.s("train,70"), 9);
            FLEX.maximums.Add(MyMapper.s("harvest,100"), 9);
            FLEX.maximums.Add(MyMapper.s("sow,50"), 9);
            FLEX.maximums.Add(MyMapper.s("mine,100"), 9);
            FLEX.maximums.Add(MyMapper.s("drill,50"), 9);
            FLEX.maximums.Add(MyMapper.s("smith,115"), 9);
            FLEX.maximums.Add(MyMapper.s("work,75"), 9);
            FLEX.maximums.Add(MyMapper.s("produce components,50"), 9);
            FLEX.maximums.Add(MyMapper.s("tailor,110"), 9);
            FLEX.maximums.Add(MyMapper.s("sculpt,100"), 9);
            FLEX.maximums.Add(MyMapper.s("craft,100"), 9);
            FLEX.maximums.Add(MyMapper.s("refine chemicals,97"), 9);
            FLEX.maximums.Add(MyMapper.s("produce drugs,95"), 9);
            FLEX.maximums.Add(MyMapper.s("stonecut,90"), 9);
            FLEX.maximums.Add(MyMapper.s("refine,80"), 9);
            FLEX.maximums.Add(MyMapper.s("research,0"), 9);

            FLEX.maximums.Add(MyMapper.s("haul,10"), 9);

            FLEX.maximums.Add(MyMapper.s("clear snow,10"), 9);
            FLEX.maximums.Add(MyMapper.s("clean,5"), 9);

        }
    }
}
