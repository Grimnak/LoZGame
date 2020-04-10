namespace LoZClone
{
    using System.Collections.Generic;
    using static RandomStateGenerator;
    struct DefaultEnemyStates
    {
        public static readonly Dictionary<StateType, int> DragonStateList = new Dictionary<StateType, int>()
        {
            { StateType.Attack, 1 },
            { StateType.Idle, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveWest, 1 }
        };

        public static readonly Dictionary<StateType, int> DodongoStateList = new Dictionary<StateType, int>()
        {
            { StateType.MoveWest, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 },
            { StateType.Attack, 1 }
        };

        public static readonly Dictionary<StateType, int> FiresnakeStateList = new Dictionary<StateType, int>()
        {
            { StateType.MoveNorthEast, 1 },
            { StateType.MoveNorthWest, 1 },
            { StateType.MoveSouthEast, 1 },
            { StateType.MoveSouthWest, 1 }
        };

        public static readonly Dictionary<StateType, int> GelStateList = new Dictionary<StateType, int>()
        {
            { StateType.MoveWest, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 }
        };

        public static readonly Dictionary<StateType, int> GoriyaStateList = new Dictionary<StateType, int>()
        {
            { StateType.Attack, 1 },
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveWest, 1 }
        };

        public static readonly Dictionary<StateType, int> KeeseStateList = new Dictionary<StateType, int>()
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

        public static readonly Dictionary<StateType, int> RopeStateList = new Dictionary<StateType, int>()
        {
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveWest, 1 }
        };

        public static readonly Dictionary<StateType, int> StalfosStateList = new Dictionary<StateType, int>()
        {
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveWest, 1 }
        };

        public static readonly Dictionary<StateType, int> WallMasterStateList = new Dictionary<StateType, int>()
        {
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveWest, 1 }
        };

        public static readonly Dictionary<StateType, int> ZolStateList = new Dictionary<StateType, int>()
        {
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveWest, 1 }
        };
    }
}
