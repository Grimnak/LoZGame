namespace LoZClone
{
    using System;
    using System.Collections.Generic;

    public struct EnemyDropTables
    {
        private static List<Tuple<DropManager.DropType, int, int, int>> emptyDropTable = new List<Tuple<DropManager.DropType, int, int, int>>()
        {
        };

        private static List<Tuple<DropManager.DropType, int, int, int>> blueGoriyaDropTable = new List<Tuple<DropManager.DropType, int, int, int>>()
        {
            Tuple.Create(DropManager.DropType.BlueRupee, LoZGame.Instance.Drops.BlueRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.RedPotion, LoZGame.Instance.Drops.RedPotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.BluePotion, LoZGame.Instance.Drops.BluePotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Fairy, LoZGame.Instance.Drops.FairyWeight, 1, 1)
        };

        private static List<Tuple<DropManager.DropType, int, int, int>> blueWizzrobeDropTable = new List<Tuple<DropManager.DropType, int, int, int>>()
        {
            Tuple.Create(DropManager.DropType.BlueRupee, LoZGame.Instance.Drops.BlueRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.RedPotion, LoZGame.Instance.Drops.RedPotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.BluePotion, LoZGame.Instance.Drops.BluePotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Fairy, LoZGame.Instance.Drops.FairyWeight, 1, 1)
        };

        private static List<Tuple<DropManager.DropType, int, int, int>> blueDarknutDropTable = new List<Tuple<DropManager.DropType, int, int, int>>()
        {
            Tuple.Create(DropManager.DropType.BlueRupee, LoZGame.Instance.Drops.BlueRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.RedPotion, LoZGame.Instance.Drops.RedPotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.BluePotion, LoZGame.Instance.Drops.BluePotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Fairy, LoZGame.Instance.Drops.FairyWeight, 1, 1)
        };

        private static List<Tuple<DropManager.DropType, int, int, int>> digdoggerDropTable = new List<Tuple<DropManager.DropType, int, int, int>>()
        {
            Tuple.Create(DropManager.DropType.BlueRupee, LoZGame.Instance.Drops.BlueRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.RedPotion, LoZGame.Instance.Drops.RedPotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.BluePotion, LoZGame.Instance.Drops.BluePotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Fairy, LoZGame.Instance.Drops.FairyWeight, 1, 1)
        };

        private static List<Tuple<DropManager.DropType, int, int, int>> dodongoDropTable = new List<Tuple<DropManager.DropType, int, int, int>>()
        {
            Tuple.Create(DropManager.DropType.BlueRupee, LoZGame.Instance.Drops.BlueRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Bomb, LoZGame.Instance.Drops.BombWeight, 4, 4),
            Tuple.Create(DropManager.DropType.RedPotion, LoZGame.Instance.Drops.RedPotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.BluePotion, LoZGame.Instance.Drops.BluePotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Fairy, LoZGame.Instance.Drops.FairyWeight, 1, 1)
        };

        private static List<Tuple<DropManager.DropType, int, int, int>> dragonDropTable = new List<Tuple<DropManager.DropType, int, int, int>>()
        {
            Tuple.Create(DropManager.DropType.BlueRupee, LoZGame.Instance.Drops.BlueRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.RedPotion, LoZGame.Instance.Drops.RedPotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.BluePotion, LoZGame.Instance.Drops.BluePotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Fairy, LoZGame.Instance.Drops.FairyWeight, 1, 1)
        };

        private static List<Tuple<DropManager.DropType, int, int, int>> gibdoDropTable = new List<Tuple<DropManager.DropType, int, int, int>>()
        {
            Tuple.Create(DropManager.DropType.BlueRupee, LoZGame.Instance.Drops.BlueRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Bomb, LoZGame.Instance.Drops.BombWeight, 4, 4),
            Tuple.Create(DropManager.DropType.RedPotion, LoZGame.Instance.Drops.RedPotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.BluePotion, LoZGame.Instance.Drops.BluePotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Clock, LoZGame.Instance.Drops.ClockWeight, 1, 1)
        };

        private static List<Tuple<DropManager.DropType, int, int, int>> gleeokDropTable = new List<Tuple<DropManager.DropType, int, int, int>>()
        {
            Tuple.Create(DropManager.DropType.BlueRupee, LoZGame.Instance.Drops.BlueRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.RedPotion, LoZGame.Instance.Drops.RedPotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.BluePotion, LoZGame.Instance.Drops.BluePotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Fairy, LoZGame.Instance.Drops.FairyWeight, 1, 1)
        };

        private static List<Tuple<DropManager.DropType, int, int, int>> gohmaDropTable = new List<Tuple<DropManager.DropType, int, int, int>>()
        {
            Tuple.Create(DropManager.DropType.BlueRupee, LoZGame.Instance.Drops.BlueRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.RedPotion, LoZGame.Instance.Drops.RedPotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.BluePotion, LoZGame.Instance.Drops.BluePotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Fairy, LoZGame.Instance.Drops.FairyWeight, 1, 1)
        };

        private static List<Tuple<DropManager.DropType, int, int, int>> manhandlaDropTable = new List<Tuple<DropManager.DropType, int, int, int>>()
        {
            Tuple.Create(DropManager.DropType.BlueRupee, LoZGame.Instance.Drops.BlueRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.RedPotion, LoZGame.Instance.Drops.RedPotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.BluePotion, LoZGame.Instance.Drops.BluePotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Fairy, LoZGame.Instance.Drops.FairyWeight, 1, 1)
        };

        private static List<Tuple<DropManager.DropType, int, int, int>> moldormDropTable = new List<Tuple<DropManager.DropType, int, int, int>>()
        {
            Tuple.Create(DropManager.DropType.BlueRupee, LoZGame.Instance.Drops.BlueRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.RedPotion, LoZGame.Instance.Drops.RedPotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.BluePotion, LoZGame.Instance.Drops.BluePotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Fairy, LoZGame.Instance.Drops.FairyWeight, 1, 1)
        };

        private static List<Tuple<DropManager.DropType, int, int, int>> polsVoiceDropTable = new List<Tuple<DropManager.DropType, int, int, int>>()
        {
            Tuple.Create(DropManager.DropType.BlueRupee, LoZGame.Instance.Drops.BlueRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.YellowRupee, LoZGame.Instance.Drops.YellowRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.RedPotion, LoZGame.Instance.Drops.RedPotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.BluePotion, LoZGame.Instance.Drops.BluePotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Clock, LoZGame.Instance.Drops.ClockWeight, 1, 1)
        };

        private static List<Tuple<DropManager.DropType, int, int, int>> redDarknutDropTable = new List<Tuple<DropManager.DropType, int, int, int>>()
        {
            Tuple.Create(DropManager.DropType.BlueRupee, LoZGame.Instance.Drops.BlueRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Bomb, LoZGame.Instance.Drops.BombWeight, 4, 4),
            Tuple.Create(DropManager.DropType.RedPotion, LoZGame.Instance.Drops.RedPotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.BluePotion, LoZGame.Instance.Drops.BluePotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Clock, LoZGame.Instance.Drops.ClockWeight, 1, 1)
        };

        private static List<Tuple<DropManager.DropType, int, int, int>> redGoriyaDropTable = new List<Tuple<DropManager.DropType, int, int, int>>()
        {
            Tuple.Create(DropManager.DropType.BlueRupee, LoZGame.Instance.Drops.BlueRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Bomb, LoZGame.Instance.Drops.BombWeight, 4, 4),
            Tuple.Create(DropManager.DropType.RedPotion, LoZGame.Instance.Drops.RedPotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.BluePotion, LoZGame.Instance.Drops.BluePotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Clock, LoZGame.Instance.Drops.ClockWeight, 1, 1)
        };

        private static List<Tuple<DropManager.DropType, int, int, int>> redWizzrobeDropTable = new List<Tuple<DropManager.DropType, int, int, int>>()
        {
            Tuple.Create(DropManager.DropType.BlueRupee, LoZGame.Instance.Drops.BlueRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Bomb, LoZGame.Instance.Drops.BombWeight, 4, 4),
            Tuple.Create(DropManager.DropType.RedPotion, LoZGame.Instance.Drops.RedPotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.BluePotion, LoZGame.Instance.Drops.BluePotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Clock, LoZGame.Instance.Drops.ClockWeight, 1, 1)
        };

        private static List<Tuple<DropManager.DropType, int, int, int>> ropeDropTable = new List<Tuple<DropManager.DropType, int, int, int>>()
        {
            Tuple.Create(DropManager.DropType.BlueRupee, LoZGame.Instance.Drops.BlueRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.YellowRupee, LoZGame.Instance.Drops.YellowRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.RedPotion, LoZGame.Instance.Drops.RedPotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.BluePotion, LoZGame.Instance.Drops.BluePotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Clock, LoZGame.Instance.Drops.ClockWeight, 1, 1)
        };

        private static List<Tuple<DropManager.DropType, int, int, int>> stalfosDropTable = new List<Tuple<DropManager.DropType, int, int, int>>()
        {
            Tuple.Create(DropManager.DropType.BlueRupee, LoZGame.Instance.Drops.BlueRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.YellowRupee, LoZGame.Instance.Drops.YellowRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.RedPotion, LoZGame.Instance.Drops.RedPotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.BluePotion, LoZGame.Instance.Drops.BluePotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Clock, LoZGame.Instance.Drops.ClockWeight, 1, 1)
        };

        private static List<Tuple<DropManager.DropType, int, int, int>> vireDropTable = new List<Tuple<DropManager.DropType, int, int, int>>()
        {
            Tuple.Create(DropManager.DropType.BlueRupee, LoZGame.Instance.Drops.BlueRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Bomb, LoZGame.Instance.Drops.BombWeight, 4, 4),
            Tuple.Create(DropManager.DropType.RedPotion, LoZGame.Instance.Drops.RedPotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.BluePotion, LoZGame.Instance.Drops.BluePotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Clock, LoZGame.Instance.Drops.ClockWeight, 1, 1)
        };

        private static List<Tuple<DropManager.DropType, int, int, int>> wallMasterDropTable = new List<Tuple<DropManager.DropType, int, int, int>>()
        {
            Tuple.Create(DropManager.DropType.BlueRupee, LoZGame.Instance.Drops.BlueRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.YellowRupee, LoZGame.Instance.Drops.YellowRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.RedPotion, LoZGame.Instance.Drops.RedPotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.BluePotion, LoZGame.Instance.Drops.BluePotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Clock, LoZGame.Instance.Drops.ClockWeight, 1, 1)
        };

        private static List<Tuple<DropManager.DropType, int, int, int>> zolDropTable = new List<Tuple<DropManager.DropType, int, int, int>>()
        {
            Tuple.Create(DropManager.DropType.BlueRupee, LoZGame.Instance.Drops.BlueRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.YellowRupee, LoZGame.Instance.Drops.YellowRupeeWeight, 1, 1),
            Tuple.Create(DropManager.DropType.RedPotion, LoZGame.Instance.Drops.RedPotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.BluePotion, LoZGame.Instance.Drops.BluePotionWeight, 1, 1),
            Tuple.Create(DropManager.DropType.Clock, LoZGame.Instance.Drops.ClockWeight, 1, 1)
        };

        public List<Tuple<DropManager.DropType, int, int, int>> EmptyDropTable => emptyDropTable;

        public List<Tuple<DropManager.DropType, int, int, int>> BlueDarknutDropTable => blueDarknutDropTable;

        public List<Tuple<DropManager.DropType, int, int, int>> BlueGoriyaDropTable => blueGoriyaDropTable;

        public List<Tuple<DropManager.DropType, int, int, int>> BlueWizzrobeDropTable => blueWizzrobeDropTable;

        public List<Tuple<DropManager.DropType, int, int, int>> DigDoggerDropTable => digdoggerDropTable;

        public List<Tuple<DropManager.DropType, int, int, int>> DodongoDropTable => dodongoDropTable;

        public List<Tuple<DropManager.DropType, int, int, int>> DragonDropTable => dragonDropTable;

        public List<Tuple<DropManager.DropType, int, int, int>> GibdoDropTable => gibdoDropTable;

        public List<Tuple<DropManager.DropType, int, int, int>> GleeokDropTable => gleeokDropTable;

        public List<Tuple<DropManager.DropType, int, int, int>> GohmaDropTable => gohmaDropTable;

        public List<Tuple<DropManager.DropType, int, int, int>> ManhandlaDropTable => manhandlaDropTable;

        public List<Tuple<DropManager.DropType, int, int, int>> MoldormDropTable => moldormDropTable;

        public List<Tuple<DropManager.DropType, int, int, int>> PolsVoiceDropTable => polsVoiceDropTable;

        public List<Tuple<DropManager.DropType, int, int, int>> RedDarknutDropTable => redDarknutDropTable;

        public List<Tuple<DropManager.DropType, int, int, int>> RedGoriyaDropTable => redGoriyaDropTable;

        public List<Tuple<DropManager.DropType, int, int, int>> RedWizzrobeDropTable => redWizzrobeDropTable;

        public List<Tuple<DropManager.DropType, int, int, int>> RopeDropTable => ropeDropTable;

        public List<Tuple<DropManager.DropType, int, int, int>> StalfosDropTable => stalfosDropTable;

        public List<Tuple<DropManager.DropType, int, int, int>> VireDropTable => vireDropTable;

        public List<Tuple<DropManager.DropType, int, int, int>> WallMasterDropTable => wallMasterDropTable;

        public List<Tuple<DropManager.DropType, int, int, int>> ZolDropTable => zolDropTable;
    }
}