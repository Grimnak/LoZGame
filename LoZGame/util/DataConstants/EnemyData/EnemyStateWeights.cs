namespace LoZClone
{
    using System.Collections.Generic;
    using static RandomStateGenerator;

    public struct EnemyStateWeights
    {
        private static Dictionary<StateType, int> oldManStateList = new Dictionary<StateType, int>()
        {
            //{ StateType.Attack, 1 },
            { StateType.Idle, 99 }
        };

        private static Dictionary<StateType, int> darknutStateList = new Dictionary<StateType, int>()
        {
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveWest, 1 }
        };

        private static Dictionary<StateType, int> dragonStateList = new Dictionary<StateType, int>()
        {
            { StateType.Attack, 1 },
            { StateType.Idle, 1 },
            { StateType.MoveEast, 2 },
            { StateType.MoveWest, 2 }
        };

        private static Dictionary<StateType, int> dodongoStateList = new Dictionary<StateType, int>()
        {
            { StateType.MoveWest, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 },
            { StateType.Attack, 1 }
        };

        private static Dictionary<StateType, int> firesnakeStateList = new Dictionary<StateType, int>()
        {
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveWest, 1 },
            { StateType.MoveNorthEast, 1 },
            { StateType.MoveNorthWest, 1 },
            { StateType.MoveSouthEast, 1 },
            { StateType.MoveSouthWest, 1 }
        };

        private static Dictionary<StateType, int> gelStateList = new Dictionary<StateType, int>()
        {
            { StateType.MoveWest, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 }
        };

        private static Dictionary<StateType, int> goriyaStateList = new Dictionary<StateType, int>()
        {
            { StateType.Attack, 1 },
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveWest, 1 }
        };

        private static Dictionary<StateType, int> blueGoriyaStateList = new Dictionary<StateType, int>()
        {
            { StateType.Attack, 1 },
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveWest, 1 }
        };

        private static Dictionary<StateType, int> keeseStateList = new Dictionary<StateType, int>()
        {
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveWest, 1 },
            { StateType.MoveNorthEast, 1 },
            { StateType.MoveNorthWest, 1 },
            { StateType.MoveSouthEast, 1 },
            { StateType.MoveSouthWest, 1 }
        };

        private static Dictionary<StateType, int> ropeStateList = new Dictionary<StateType, int>()
        {
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveWest, 1 }
        };

        private static Dictionary<StateType, int> stalfosStateList = new Dictionary<StateType, int>()
        {
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveWest, 1 }
        };

        private static Dictionary<StateType, int> wallMasterStateList = new Dictionary<StateType, int>()
        {
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveWest, 1 }
        };

        private static Dictionary<StateType, int> zolStateList = new Dictionary<StateType, int>()
        {
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveWest, 1 }
        };

        private static Dictionary<StateType, int> vireStateList = new Dictionary<StateType, int>()
        {
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 }
        };

        private static Dictionary<StateType, int> manhandlaBodyStateList = new Dictionary<StateType, int>()
        {
            {StateType.MoveNorthEast, 1 },
            {StateType.MoveNorthWest, 1 },
            {StateType.MoveSouthEast, 1 },
            {StateType.MoveSouthWest, 1 }
        }; 
        
        private static Dictionary<StateType, int> manhandlaHeadStateList = new Dictionary<StateType, int>()
        {
            {StateType.Attack, 1 },
            {StateType.Idle, 4 }
        };

        public Dictionary<StateType, int> OldManStateList => oldManStateList;

        public Dictionary<StateType, int> DarknutStatelist => darknutStateList;

        public Dictionary<StateType, int> DragonStatelist => dragonStateList;

        public Dictionary<StateType, int> DodongoStatelist => dodongoStateList;

        public Dictionary<StateType, int> FireSnakeStatelist => firesnakeStateList;

        public Dictionary<StateType, int> GelStatelist => gelStateList;

        public Dictionary<StateType, int> GoriyaStatelist => goriyaStateList;

        public Dictionary<StateType, int> BlueGoriyaStatelist => blueGoriyaStateList;

        public Dictionary<StateType, int> KeeseStatelist => keeseStateList;

        public Dictionary<StateType, int> RopeStatelist => ropeStateList;

        public Dictionary<StateType, int> StalfosStatelist => stalfosStateList;

        public Dictionary<StateType, int> ZolStatelist => zolStateList;

        public Dictionary<StateType, int> WallMasterStatelist => wallMasterStateList;

        public Dictionary<StateType, int> VireStateList => vireStateList;

        public Dictionary<StateType, int> ManhandlaBodyStateList => manhandlaBodyStateList;

        public Dictionary<StateType, int> ManhandlaHeadStateList => manhandlaHeadStateList;
    }
}
