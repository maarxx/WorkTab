namespace Fluffy_Tabs
{
    internal static class WorkTemplateOf
    {
        public static WorkTemplate DEFAULT;
        public static WorkTemplate HAULING;
        public static WorkTemplate CLEANING;
        public static WorkTemplate FOOD;

        static WorkTemplateOf()
        {


            DEFAULT = new WorkTemplate();
            HAULING = new WorkTemplate();
            CLEANING = new WorkTemplate();
            FOOD = new WorkTemplate();



            DEFAULT.baseline.Add(MyMapper.s("extinguish,0"), 2);

            DEFAULT.baseline.Add(MyMapper.s("receive treatment in,0"), 2);

            DEFAULT.baseline.Add(MyMapper.s("treat,100"), 0);
            DEFAULT.baseline.Add(MyMapper.s("rescue,90"), 2);
            DEFAULT.baseline.Add(MyMapper.s("operate,80"), 0);
            DEFAULT.baseline.Add(MyMapper.s("treat,70"), 0);
            DEFAULT.baseline.Add(MyMapper.s("feed,60"), 4);
            DEFAULT.baseline.Add(MyMapper.s("operate,50"), 0);
            DEFAULT.baseline.Add(MyMapper.s("take to operate,5"), 2);
            DEFAULT.baseline.Add(MyMapper.s("visit,3"), 0);

            DEFAULT.baseline.Add(MyMapper.s("get bed rest in,0"), 2);

            DEFAULT.baseline.Add(MyMapper.s("flick switch on,500"), 2);

            DEFAULT.baseline.Add(MyMapper.s("do execution on,110"), 2);
            DEFAULT.baseline.Add(MyMapper.s("release,100"), 2);
            DEFAULT.baseline.Add(MyMapper.s("take to bed,90"), 2);
            DEFAULT.baseline.Add(MyMapper.s("feed,80"), 4);
            DEFAULT.baseline.Add(MyMapper.s("deliver food for,70"), 4);
            DEFAULT.baseline.Add(MyMapper.s("chat with,60"), 0);

            DEFAULT.baseline.Add(MyMapper.s("slaughter,100"), 2);
            DEFAULT.baseline.Add(MyMapper.s("milk,90"), 0);
            DEFAULT.baseline.Add(MyMapper.s("shear,85"), 0);
            DEFAULT.baseline.Add(MyMapper.s("tame,80"), 0);
            DEFAULT.baseline.Add(MyMapper.s("train,70"), 0);

            DEFAULT.baseline.Add(MyMapper.s("cook,100"), 0);
            DEFAULT.baseline.Add(MyMapper.s("cook,97"), 0);
            DEFAULT.baseline.Add(MyMapper.s("butcher,90"), 0);
            DEFAULT.baseline.Add(MyMapper.s("fill,50"), 4);
            DEFAULT.baseline.Add(MyMapper.s("brew,30"), 4);

            DEFAULT.baseline.Add(MyMapper.s("hunt,0"), 8);

            DEFAULT.baseline.Add(MyMapper.s("modify,100"), 0);
            DEFAULT.baseline.Add(MyMapper.s("replace broken components in,90"), 0);
            DEFAULT.baseline.Add(MyMapper.s("repair,80"), 2);
            //DEFAULT.baseline.Add(MyMapper.s("build roof,70"), 0);
            //DEFAULT.baseline.Add(MyMapper.s("remove roof,60"), 0);
            DEFAULT.baseline.Add(MyMapper.s("build roof,70"), 4);
            DEFAULT.baseline.Add(MyMapper.s("remove roof,60"), 4);
            DEFAULT.baseline.Add(MyMapper.s("construct,50"), 0);
            DEFAULT.baseline.Add(MyMapper.s("work on,40"), 4);
            //DEFAULT.baseline.Add(MyMapper.s("work on,30"), 4);
            DEFAULT.baseline.Add(MyMapper.s("work on,9"), 4); // JTReplaceWalls changes work on,30 to work on,9
            DEFAULT.baseline.Add(MyMapper.s("deconstruct,20"), 4);
            DEFAULT.baseline.Add(MyMapper.s("uninstall,19"), 4);
            DEFAULT.baseline.Add(MyMapper.s("remove floor,10"), 0);
            DEFAULT.baseline.Add(MyMapper.s("smooth,5"), 0);

            DEFAULT.baseline.Add(MyMapper.s("harvest,100"), 0);
            DEFAULT.baseline.Add(MyMapper.s("sow,50"), 0);

            DEFAULT.baseline.Add(MyMapper.s("mine,100"), 9);
            DEFAULT.baseline.Add(MyMapper.s("drill,50"), 9);

            DEFAULT.baseline.Add(MyMapper.s("cut,0"), 8);

            DEFAULT.baseline.Add(MyMapper.s("smith,115"), 0);
            DEFAULT.baseline.Add(MyMapper.s("work,75"), 0);
            DEFAULT.baseline.Add(MyMapper.s("produce components,50"), 0);
            DEFAULT.baseline.Add(MyMapper.s("tailor,110"), 0);
            DEFAULT.baseline.Add(MyMapper.s("craft,100"), 0);
            DEFAULT.baseline.Add(MyMapper.s("refine chemicals,97"), 0);
            DEFAULT.baseline.Add(MyMapper.s("produce drugs,95"), 0);
            DEFAULT.baseline.Add(MyMapper.s("stonecut,90"), 9);
            DEFAULT.baseline.Add(MyMapper.s("refine,80"), 9);

            DEFAULT.baseline.Add(MyMapper.s("sculpt,100"), 0);

            DEFAULT.baseline.Add(MyMapper.s("unload,120"), 4);
            DEFAULT.baseline.Add(MyMapper.s("load,110"), 4);
            DEFAULT.baseline.Add(MyMapper.s("strip,100"), 4);
            DEFAULT.baseline.Add(MyMapper.s("bury,90"), 4);
            DEFAULT.baseline.Add(MyMapper.s("haul,80"), 2);
            DEFAULT.baseline.Add(MyMapper.s("open,70"), 4);
            DEFAULT.baseline.Add(MyMapper.s("refuel,60"), 4);
            DEFAULT.baseline.Add(MyMapper.s("rearm,50"), 4);
            DEFAULT.baseline.Add(MyMapper.s("cremate,40"), 4);
            DEFAULT.baseline.Add(MyMapper.s("work at,30"), 4);
            DEFAULT.baseline.Add(MyMapper.s("take beer,20"), 4);
            DEFAULT.baseline.Add(MyMapper.s("fill,19"), 4);
            DEFAULT.baseline.Add(MyMapper.s("haul,10"), 7);

            DEFAULT.baseline.Add(MyMapper.s("clear snow,10"), 8);
            DEFAULT.baseline.Add(MyMapper.s("clean,5"), 8);

            DEFAULT.baseline.Add(MyMapper.s("research,0"), 0);

            DEFAULT.baseline.Add(MyMapper.s("manage,100"), 3);



            DEFAULT.ifInterest.Add(MyMapper.s("treat,100"), 1);
            DEFAULT.ifInterest.Add(MyMapper.s("operate,80"), 2);
            DEFAULT.ifInterest.Add(MyMapper.s("treat,70"), 1);
            DEFAULT.ifInterest.Add(MyMapper.s("operate,50"), 2);

            DEFAULT.ifInterest.Add(MyMapper.s("chat with,60"), 3);

            DEFAULT.ifInterest.Add(MyMapper.s("milk,90"), 3);
            DEFAULT.ifInterest.Add(MyMapper.s("shear,85"), 3);
            DEFAULT.ifInterest.Add(MyMapper.s("tame,80"), 9);
            DEFAULT.ifInterest.Add(MyMapper.s("train,70"), 9);

            DEFAULT.ifInterest.Add(MyMapper.s("cook,100"), 2);
            DEFAULT.ifInterest.Add(MyMapper.s("cook,97"), 2);
            DEFAULT.ifInterest.Add(MyMapper.s("butcher,90"), 2);

            DEFAULT.ifInterest.Add(MyMapper.s("modify,100"), 3);
            DEFAULT.ifInterest.Add(MyMapper.s("replace broken components in,90"), 2);
            //DEFAULT.ifInterest.Add(MyMapper.s("build roof,70"), 2);
            //DEFAULT.ifInterest.Add(MyMapper.s("remove roof,60"), 2);
            DEFAULT.ifInterest.Add(MyMapper.s("construct,50"), 2);
            DEFAULT.ifInterest.Add(MyMapper.s("remove floor,10"), 4);
            DEFAULT.ifInterest.Add(MyMapper.s("smooth,5"), 4);

            DEFAULT.ifInterest.Add(MyMapper.s("harvest,100"), 9);
            DEFAULT.ifInterest.Add(MyMapper.s("sow,50"), 9);

            DEFAULT.ifInterest.Add(MyMapper.s("mine,100"), 9);
            DEFAULT.ifInterest.Add(MyMapper.s("drill,50"), 9);

            DEFAULT.ifInterest.Add(MyMapper.s("smith,115"), 9);
            DEFAULT.ifInterest.Add(MyMapper.s("work,75"), 9);
            DEFAULT.ifInterest.Add(MyMapper.s("produce components,50"), 9);
            DEFAULT.ifInterest.Add(MyMapper.s("tailor,110"), 9);
            DEFAULT.ifInterest.Add(MyMapper.s("craft,100"), 9);
            DEFAULT.ifInterest.Add(MyMapper.s("refine chemicals,97"), 9);
            DEFAULT.ifInterest.Add(MyMapper.s("produce drugs,95"), 9);
            DEFAULT.ifInterest.Add(MyMapper.s("stonecut,90"), 9);
            DEFAULT.ifInterest.Add(MyMapper.s("refine,80"), 9);

            DEFAULT.ifInterest.Add(MyMapper.s("sculpt,100"), 9);

            DEFAULT.ifInterest.Add(MyMapper.s("research,0"), 9);



            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("H", MyMapper.s("tame,80"),5));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("h", MyMapper.s("tame,80"), 6));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("H", MyMapper.s("train,70"), 5));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("h", MyMapper.s("train,70"), 6));

            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("G", MyMapper.s("harvest,100"), 5));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("g", MyMapper.s("harvest,100"), 6));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("G", MyMapper.s("sow,50"), 5));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("g", MyMapper.s("sow,50"), 6));

            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("M", MyMapper.s("mine,100"), 5));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("m", MyMapper.s("mine,100"), 6));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("M", MyMapper.s("drill,50"), 5));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("m", MyMapper.s("drill,50"), 6));

            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("C", MyMapper.s("smith,115"), 5));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("c", MyMapper.s("smith,115"), 6));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("C", MyMapper.s("work,75"), 5));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("c", MyMapper.s("work,75"), 6));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("C", MyMapper.s("produce components,50"), 5));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("c", MyMapper.s("produce components,50"), 6));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("C", MyMapper.s("tailor,110"), 5));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("c", MyMapper.s("tailor,110"), 6));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("C", MyMapper.s("craft,100"), 5));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("c", MyMapper.s("craft,100"), 6));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("C", MyMapper.s("refine chemicals,97"), 5));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("c", MyMapper.s("refine chemicals,97"), 6));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("C", MyMapper.s("refine,80"), 5));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("c", MyMapper.s("refine,80"), 6));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("D", MyMapper.s("produce drugs,95"), 5));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("d", MyMapper.s("produce drugs,95"), 6));

            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("A", MyMapper.s("sculpt,100"), 5));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("a", MyMapper.s("sculpt,100"), 6));

            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("R", MyMapper.s("research,0"), 5));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("r", MyMapper.s("research,0"), 6));

            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("X", MyMapper.s("haul,10"), 5));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("x", MyMapper.s("haul,10"), 6));

            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("Y", MyMapper.s("clear snow,10"), 5));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("y", MyMapper.s("clear snow,10"), 6));

            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("Y", MyMapper.s("clean,5"), 5));
            DEFAULT.nameFlagOverrides.Add(new NameFlagOverride("y", MyMapper.s("clean,5"), 6));



            HAULING.minimums.Add(MyMapper.s("haul,10"), 4);



            CLEANING.minimums.Add(MyMapper.s("clean,5"), 4);
            CLEANING.maximums.Add(MyMapper.s("haul,10"), 5);



            FOOD.baseline.Add(MyMapper.s("haul,10"), 4);
            FOOD.baseline.Add(MyMapper.s("cut,0"), 5);
            FOOD.baseline.Add(MyMapper.s("hunt,0"), 6);



            FOOD.ifInterest.Add(MyMapper.s("harvest,100"), 3);
            FOOD.ifInterest.Add(MyMapper.s("sow,50"), 3);



            FOOD.maximums.Add(MyMapper.s("tame,80"), 7);
            FOOD.maximums.Add(MyMapper.s("train,70"), 7);
            FOOD.maximums.Add(MyMapper.s("mine,100"), 7);
            FOOD.maximums.Add(MyMapper.s("drill,50"), 7);
            FOOD.maximums.Add(MyMapper.s("smith,115"), 7);
            FOOD.maximums.Add(MyMapper.s("work,75"), 7);
            FOOD.maximums.Add(MyMapper.s("produce components,50"), 7);
            FOOD.maximums.Add(MyMapper.s("tailor,110"), 7);
            FOOD.maximums.Add(MyMapper.s("sculpt,100"), 7);
            FOOD.maximums.Add(MyMapper.s("craft,100"), 7);
            FOOD.maximums.Add(MyMapper.s("refine chemicals,97"), 7);
            FOOD.maximums.Add(MyMapper.s("produce drugs,95"), 7);
            FOOD.maximums.Add(MyMapper.s("stonecut,90"), 7);
            FOOD.maximums.Add(MyMapper.s("refine,80"), 7);
            FOOD.maximums.Add(MyMapper.s("research,0"), 7);
            FOOD.maximums.Add(MyMapper.s("clear snow,10"), 7);
            FOOD.maximums.Add(MyMapper.s("clean,5"), 7);

        }
    }
}
