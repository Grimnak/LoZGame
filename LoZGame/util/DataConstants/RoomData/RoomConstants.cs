﻿namespace LoZClone
{
    public struct RoomConstants
    {
        private const float BlockDepth= .2f;
        private const int BlockHeightOffset = 8;
        private const float TileD = .001f;

        private const int UpDownDoorXLoc = 363;
        private const int LeftDoorXLoc = 19;

        private const string Unlocked = "Unlocked";
        private const string Hidden = "hidden";
        private const string Cosmetic = "Cosmetic";
        private const string Locked = "Locked";
        private const string Puzzle = "Puzzle";
        private const string Special = "Special";


        public float BlockTileDepth => BlockDepth;

        public int BlockTileHeightOffset => BlockHeightOffset;

        public float TileDepth => TileD;

        public int UpDownDoorXLocation => UpDownDoorXLoc;

        public int LeftDoorXLocation => LeftDoorXLoc;

        public int UpDoorYLocation => LoZGame.Instance.InventoryOffset + 12;

        public int RightDoorXLocation => LoZGame.Instance.ScreenWidth - BlockSpriteFactory.Instance.DoorOffset - BlockSpriteFactory.Instance.TileHeight + 11;

        public int RightLeftDoorYLocation => LoZGame.Instance.InventoryOffset + 195;

        public string UnlockedStr => Unlocked;

        public string HiddenStr => Hidden;

        public string CosmeticStr => Cosmetic;

        public string LockedStr => Locked;

        public string PuzzleStr => Puzzle;

        public string SpecialStr => Special;
    }
}