using Microsoft.Xna.Framework;

namespace LoZClone
{
    public struct InventoryConstants
    {
        private const int MaxBombs = 8;
        private const int MaxSelectionX = 4;
        private const int MaxSelectionY = 2;
        private const int ClockLockoutMax = 600;
        private const int HeartClms = 8;
        private const int InvClms = 4;
        private const int InvSelectionItems = 8;
        private const int ItemSelectOffset = 5;
        private const int HPPerHeart = 4;

        private const int minHealthChance = 5;
        private const int maxHealthChance = 33;

        private const int threeQuarterHeart = 3;
        private const int halfHeart = 2;
        private const int quarterHeart = 1;
        private const int inventoryMapOffSetX = 320;
        private const int inventoryMapOffSetY = 263;
        private const int inventorySelectionOffSetX = 1;
        private const int inventorySelectionOffSetY = 1;
        private const int mapIndicatorOffSetX = 150;
        private const int mapIndicatorOffSetY = 313;
        private const int compassIndicatorOffSetX = 130;
        private const int compassIndicatorOffSetY = 420;
        private const int itemSelectorOffSetX = 415;
        private const int itemSelectorOffSetY = 130;
        private const int selectedItemOffSetX = 200;
        private const int selectedItemrOffSetY = 140;
        private const int miniMapOffSetX = 45;
        private const int heartOffSetX = 550;
        private const int rupeeCtOffSetX = 305;
        private const int keyCtOffSetX = 305;
        private const int bombCtOffSetX = 305;
        private const int levelCtOffSetX = 58;
        private const int primaryEquippedOffSetX = 470;
        private const int secondaryEquippedOffSetX = 392;

        private const float inventoryBackgroundDepth = .99f;
        private const int dungeon1TextRoomX = 0;
        private const int dungeon1TextRoomY = 2;
        private const int dungeon2TextRoomX = 3;
        private const int dungeon2TextRoomY = 1;
        private const int dungeon3TextRoomX = 2;
        private const int dungeon3TextRoomY = 0;
        private const int dungeon4TextRoomX = 0;
        private const int dungeon4TextRoomY = 0;
        private const int dungeon5BombTextRoomX = 3;
        private const int dungeon5BombTextRoomY = 1;
        private const int dungeon5FluteTextRoomX = 1;
        private const int dungeon5FluteTextRoomY = 3;
        private const int dungeon5ArrowTextRoomX = 3;
        private const int dungeon5ArrowTextRoomY = 6;
        private const int dungeon5DigDoggerTextRoomX = 0;
        private const int dungeon5DigDoggerTextRoomY = 2;
        private const int dungeon6BossHintTextRoomX = 3;
        private const int dungeon6BossHintTextRoomY = 0;
        private const int dungeon6MagicRodTextRoomX = 2;
        private const int dungeon6MagicRodTextRoomY = 6;
        private const int dungeon7FreeBombsTextRoomX = 0;
        private const int dungeon7FreeBombsTextRoomY = 4;
        private const int dungeon7SwordTextRoomX = 3;
        private const int dungeon7SwordTextRoomY = 5;
        private const int dungeon7SecretTextRoomX = 0;
        private const int dungeon7SecretTextRoomY = 2;
        private const int dungeon8KeyTextRoomX = 0;
        private const int dungeon8KeyTextRoomY = 3;
        private const int dungeon8SecretTextRoomX = 2;
        private const int dungeon8SecretTextRoomY = 3;
        private const int dungeon9ArrowTextRoomX = 2;
        private const int dungeon9ArrowTextRoomY = 0;
        private const int dungeon9NextRoomTextRoomX = 6;
        private const int dungeon9NextRoomTextRoomY = 0;
        private const int dungeon9MapTextRoomX = 3;
        private const int dungeon9MapTextRoomY = 4;
        private const int dungeon9BombTextRoomX = 6;
        private const int dungeon9BombTextRoomY = 6;

        private const string itemCtStr = "x";
        private const string levelStr = "L E V E L - ";

        public int MaximumBombs => MaxBombs;

        public int MaximumSelectionX => MaxSelectionX;

        public int MaximumSelectionY => MaxSelectionY;

        public int ClockLockoutMaximum => ClockLockoutMax;

        public int HeartColumns => HeartClms;

        public int InventorySelectionItems => InvSelectionItems;

        public int ItemSelectorOffset => ItemSelectOffset;

        public int InventoryColumns => InvClms;

        public int HealthPerHeart => HPPerHeart;

        public int ThreeQuarterHeart => threeQuarterHeart;

        public int HalfHeart => halfHeart;

        public int QuarterHeart => quarterHeart;

        public int InventoryMapOffsetX => inventoryMapOffSetX;

        public int InventoryMapOffsetY => inventoryMapOffSetY;

        public int InventorySelectionOffsetX => inventorySelectionOffSetX;

        public int InventorySelectionOffsetY => inventorySelectionOffSetY;

        public int MapIndicatorOffsetX => mapIndicatorOffSetX;

        public int MapIndicatorOffsetY => mapIndicatorOffSetY;

        public int CompassIndicatorOffsetX => compassIndicatorOffSetX;

        public int CompassIndicatorOffsetY => compassIndicatorOffSetY;

        public int ItemSelectorOffsetX => itemSelectorOffSetX;

        public int ItemSelectorOffsetY => itemSelectorOffSetY;

        public int SelectedItemOffsetX => selectedItemOffSetX;

        public int SelectedItemOffsetY => selectedItemrOffSetY;

        public int MiniMapOffsetX => miniMapOffSetX;

        public int MiniMapOffsetY => 46 + LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset;

        public int HeartOffsetX => heartOffSetX;

        public int HeartOffsetY => 105 + (LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset);

        public int RupeeCtOffsetX => rupeeCtOffSetX;

        public int RupeeCtOffsetY => 58 + (LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset);

        public int KeyCtOffsetX => keyCtOffSetX;

        public int KeyCtOffsetY => 101 + (LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset);

        public int BombCtOffsetX => bombCtOffSetX;

        public int BombCtOffsetY => 125 + (LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset);

        public int LevelCtOffsetX => levelCtOffSetX;

        public int LevelCtOffsetY => 15 + (LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset);

        public int PrimaryEquippedOffsetX => primaryEquippedOffSetX;

        public int PrimaryEquippedOffsetY => 85 + (LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset);

        public int SecondaryEquippedOffsetX => secondaryEquippedOffSetX;

        public int SecondaryEquippedOffsetY => 85 + (LoZGame.Instance.ScreenHeight - LoZGame.Instance.InventoryOffset);

        public float InventoryBackgroundDepth => inventoryBackgroundDepth;

        public int Dungeon1TxtRoomX => dungeon1TextRoomX;

        public int Dungeon1TxtRoomY => dungeon1TextRoomY;

        public Vector2 Dungeon1TxtDrawLoc => new Vector2(100, LoZGame.Instance.InventoryOffset + 100);

        public int Dungeon2TxtRoomX => dungeon2TextRoomX;

        public int Dungeon2TxtRoomY => dungeon2TextRoomY;

        public Vector2 Dungeon2TxtDrawLoc => new Vector2(185, LoZGame.Instance.InventoryOffset + 100);

        public int Dungeon3TxtRoomX => dungeon3TextRoomX;

        public int Dungeon3TxtRoomY => dungeon3TextRoomY;

        public Vector2 Dungeon3TxtDrawLoc => new Vector2(150, LoZGame.Instance.InventoryOffset + 100);

        public int Dungeon4TxtRoomX => dungeon4TextRoomX;

        public int Dungeon4TxtRoomY => dungeon4TextRoomY;

        public Vector2 Dungeon4TxtDrawLoc => new Vector2(130, LoZGame.Instance.InventoryOffset + 100);

        public int Dungeon5PurchaseBombTxtX => dungeon5BombTextRoomX;

        public int Dungeon5PurchaseBombTxtY => dungeon5BombTextRoomY;

        public int Dungeon5FluteTxtRoomX => dungeon5FluteTextRoomX;

        public int Dungeon5FluteTxtRoomY => dungeon5FluteTextRoomY;

        public Vector2 Dungeon5FluteTxtDrawLoc => new Vector2(185, LoZGame.Instance.InventoryOffset + 100);

        public int Dungeon5ArrowTxtRoomX => dungeon5ArrowTextRoomX;

        public int Dungeon5ArrowTxtRoomY => dungeon5ArrowTextRoomY;

        public Vector2 Dungeon5ArrowTxtDrawLoc => new Vector2(100, LoZGame.Instance.InventoryOffset + 100);

        public int Dungeon5DigDoggerTxtRoomX => dungeon5DigDoggerTextRoomX;

        public int Dungeon5DigDoggerTxtRoomY => dungeon5DigDoggerTextRoomY;

        public Vector2 Dungeon5DigDoggerTxtDrawLoc => new Vector2(100, LoZGame.Instance.InventoryOffset + 100);

        public int Dungeon6BossHintTxtRoomX => dungeon6BossHintTextRoomX;

        public int Dungeon6BossHintTxtRoomY => dungeon6BossHintTextRoomY;

        public int Dungeon6MagicRodTxtRoomX => dungeon6MagicRodTextRoomX;

        public int Dungeon6MagicRodTxtRoomY => dungeon6MagicRodTextRoomY;

        public Vector2 Dungeon6BossHintTxtDrawLoc => new Vector2(175, LoZGame.Instance.InventoryOffset + 100);

        public Vector2 Dungeon6MagicRodTxtDrawLoc => new Vector2(135, LoZGame.Instance.InventoryOffset + 100);

        public int Dungeon7FreeBombsTxtRoomX => dungeon7FreeBombsTextRoomX;

        public int Dungeon7FreeBombsTxtRoomY => dungeon7FreeBombsTextRoomY;

        public int Dungeon7SwordTxtRoomX => dungeon7SwordTextRoomX;

        public int Dungeon7SwordTxtRoomY => dungeon7SwordTextRoomY;

        public int Dungeon7SecretTxtRoomX => dungeon7SecretTextRoomX;

        public int Dungeon7SecretTxtRoomY => dungeon7SecretTextRoomY;

        public Vector2 Dungeon7SecretTxtDrawLoc => new Vector2(130, LoZGame.Instance.InventoryOffset + 100);

        public Vector2 Dungeon7FreeBombsTxtDrawLoc => new Vector2(150, LoZGame.Instance.InventoryOffset + 100);

        public Vector2 Dungeon7SwordTxtDrawLoc => new Vector2(130, LoZGame.Instance.InventoryOffset + 100);

        public int Dungeon8KeyTxtRoomX => dungeon8KeyTextRoomX;

        public int Dungeon8KeyTxtRoomY => dungeon8KeyTextRoomY;

        public int Dungeon8SecretTxtRoomX => dungeon8SecretTextRoomX;

        public int Dungeon8SecretTxtRoomY => dungeon8SecretTextRoomY;

        public Vector2 Dungeon8SecretTxtDrawLoc => new Vector2(130, LoZGame.Instance.InventoryOffset + 100);

        public Vector2 Dungeon8KeyTxtDrawLoc => new Vector2(150, LoZGame.Instance.InventoryOffset + 100);

        public int Dungeon9ArrowTxtRoomX => dungeon9ArrowTextRoomX;

        public int Dungeon9ArrowTxtRoomY => dungeon9ArrowTextRoomY;
        
        public int Dungeon9NextRoomTxtRoomX => dungeon9NextRoomTextRoomX;

        public int Dungeon9NextRoomTxtRoomY => dungeon9NextRoomTextRoomY;

        public int Dungeon9MapTxtRoomX => dungeon9MapTextRoomX;

        public int Dungeon9MapTxtRoomY => dungeon9MapTextRoomY;

        public int Dungeon9PurchaseBombTxtX => dungeon9BombTextRoomX;

        public int Dungeon9PurchaseBombTxtY => dungeon9BombTextRoomY;

        public Vector2 Dungeon9ArrowTxtDrawLoc => new Vector2(100, LoZGame.Instance.InventoryOffset + 100);

        public Vector2 Dungeon9NextRoomTxtDrawLoc => new Vector2(210, LoZGame.Instance.InventoryOffset + 100);

        public Vector2 Dungeon9MapTxtDrawLoc => new Vector2(230, LoZGame.Instance.InventoryOffset + 100);

        public Vector2 PurchaseBombTxtDrawLoc => new Vector2(135, LoZGame.Instance.InventoryOffset + 100);

        public Vector2 PurchasePriceTxtDrawLoc => new Vector2(430, LoZGame.Instance.InventoryOffset + 270);

        public string ItemCtStr => itemCtStr;

        public string LevelStr => levelStr;

        public int MinHealthChance => minHealthChance;

        public int MaxHealthChance => maxHealthChance;

    }
}
