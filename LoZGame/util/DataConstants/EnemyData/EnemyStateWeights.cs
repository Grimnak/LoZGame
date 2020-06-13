namespace LoZClone
{
    using System.Collections.Generic;
    using static RandomStateGenerator;

    public struct EnemyStateWeights
    {
        private static Dictionary<StateType, int> gleeokHeadStateList = new Dictionary<StateType, int>()
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

        private static Dictionary<StateType, int> gleeokHeadOffStateList = new Dictionary<StateType, int>()
        {
            { StateType.Attack, 16 },
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveWest, 1 },
            { StateType.MoveNorthEast, 1 },
            { StateType.MoveNorthWest, 1 },
            { StateType.MoveSouthEast, 1 },
            { StateType.MoveSouthWest, 1 }
        };

        private static Dictionary<StateType, int> oldManStateList = new Dictionary<StateType, int>()
        {
            // { StateType.Attack, 1 },
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

        private static Dictionary<StateType, int> ganonTeleportingStateList = new Dictionary<StateType, int>()
        {
            { StateType.Attack, 1 },
            { StateType.Teleport, 1 },
            { StateType.Idle, 2 }
        };

        private static Dictionary<StateType, int> ganonParalyzedStateList = new Dictionary<StateType, int>()
        {
            { StateType.Idle, 1 }
        };

        private static Dictionary<StateType, int> gelStateList = new Dictionary<StateType, int>()
        {
            { StateType.MoveWest, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 }
        };

        private static Dictionary<StateType, int> gohmaStateList = new Dictionary<StateType, int>()
        {
            { StateType.Attack, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveWest, 1 },
            { StateType.OpenEye, 1 },
            { StateType.CloseEye, 1 }
        };

        private static Dictionary<StateType, int> goriyaStateList = new Dictionary<StateType, int>()
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

        private static Dictionary<StateType, int> patraStateList = new Dictionary<StateType, int>()
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

        private static Dictionary<StateType, int> gibdoStateList = new Dictionary<StateType, int>()
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

        private static Dictionary<StateType, int> redWizzrobeStateList = new Dictionary<StateType, int>()
        {
            { StateType.Attack, 1 },
            { StateType.Teleport, 1 },
            { StateType.Idle, 4 }
        };

        private static Dictionary<StateType, int> blueWizzrobeStateList = new Dictionary<StateType, int>()
        {
            { StateType.Attack, 1 },
            { StateType.Teleport, 1 },
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveWest, 1 },
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
            { StateType.MoveSouth, 1 },
            { StateType.JumpEast, 2 },
            { StateType.JumpWest, 2 }
        };

        private static Dictionary<StateType, int> bubbleStateList = new Dictionary<StateType, int>()
        {
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveWest, 1 }
        };

        private static Dictionary<StateType, int> manhandlaBodyStateList = new Dictionary<StateType, int>()
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

        private static Dictionary<StateType, int> digDoggerStateList = new Dictionary<StateType, int>()
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

        private static Dictionary<StateType, int> manhandlaHeadStateList = new Dictionary<StateType, int>()
        {
            { StateType.Attack, 1 },
            { StateType.Idle, 4 }
        };

        private static Dictionary<StateType, int> likelikeStateList = new Dictionary<StateType, int>()
        {
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveWest, 1 },
        };

        private static Dictionary<StateType, int> polsVoiceStateList = new Dictionary<StateType, int>()
        {
            { StateType.MoveNorth, 1 },
            { StateType.MoveSouth, 1 },
            { StateType.MoveEast, 1 },
            { StateType.MoveWest, 1 },
            { StateType.JumpEast, 2 },
            { StateType.JumpWest, 2 },
            { StateType.JumpNorth, 1 }
        };

        public Dictionary<StateType, int> OldManStateList => oldManStateList;

        public Dictionary<StateType, int> DarknutStateList => darknutStateList;

        public Dictionary<StateType, int> DragonStateList => dragonStateList;

        public Dictionary<StateType, int> PatraStateList => patraStateList;

        public Dictionary<StateType, int> DodongoStateList => dodongoStateList;

        public Dictionary<StateType, int> FireSnakeStateList => firesnakeStateList;

        public Dictionary<StateType, int> GelStateList => gelStateList;

        public Dictionary<StateType, int> GoriyaStateList => goriyaStateList;

        public Dictionary<StateType, int> GohmaStateList => gohmaStateList;

        public Dictionary<StateType, int> KeeseStateList => keeseStateList;

        public Dictionary<StateType, int> RopeStateList => ropeStateList;

        public Dictionary<StateType, int> StalfosStateList => stalfosStateList;

        public Dictionary<StateType, int> ZolStateList => zolStateList;

        public Dictionary<StateType, int> WallMasterStateList => wallMasterStateList;

        public Dictionary<StateType, int> RedWizzrobeStateList => redWizzrobeStateList;

        public Dictionary<StateType, int> BlueWizzrobeStateList => blueWizzrobeStateList;

        public Dictionary<StateType, int> VireStateList => vireStateList;

        public Dictionary<StateType, int> BubbleStateList => bubbleStateList;

        public Dictionary<StateType, int> ManhandlaBodyStateList => manhandlaBodyStateList;

        public Dictionary<StateType, int> ManhandlaHeadStateList => manhandlaHeadStateList;

        public Dictionary<StateType, int> GleeokHeadStateList => gleeokHeadStateList;

        public Dictionary<StateType, int> GleeokHeadOffStateList => gleeokHeadOffStateList;

        public Dictionary<StateType, int> GibdoStateList => gibdoStateList;

        public Dictionary<StateType, int> LikelikeStateList => likelikeStateList;

        public Dictionary<StateType, int> PolsVoiceStateList => polsVoiceStateList;

        public Dictionary<StateType, int> DigDoggerStateList => digDoggerStateList;

        public Dictionary<StateType, int> GanonTeleportingStateList => ganonTeleportingStateList;

        public Dictionary<StateType, int> GanonParalyzedStateList => ganonParalyzedStateList;
    }
}