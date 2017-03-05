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

            HAULING.baseline.Add(MyMapper.s("haul,10"), 2);

            CLEANING.baseline.Add(MyMapper.s("clean,5"), 6);

            FOOD.baseline.Add(MyMapper.s("cut,0"), 7);

        }
    }
}
