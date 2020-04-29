namespace LoZClone
{
    using System.Collections.Generic;

    public partial class InventoryManager
    {
        public enum ItemType
        {
            Bomb,
            Arrow,
            Boomerang,
            Candle,
            Flute,
            Potion,
            Rod,
            None
        }

        private IPlayer player;

        private ItemType selectedItem;

        private List<List<ItemType>> selectionArray = new List<List<ItemType>>()
        {
            new List<ItemType> { ItemType.Bomb, ItemType.Boomerang, ItemType.Arrow, ItemType.Candle },
            new List<ItemType> { ItemType.Potion, ItemType.Rod, ItemType.None, ItemType.Flute }
        };

        private int selectionX;
        private int selectionY;

        private int numBombs;
        private int numRupees;
        private int numKeys;
        private int numRedPotions;
        private int numBluePotions;
        private bool hasBoomerang;
        private bool hasMagicBoomerang;
        private bool hasBow;
        private bool hasArrow;
        private bool hasRod;
        private bool hasSilverArrow;
        private bool hasRedFlame;
        private bool hasBlueFlame;
        private bool hasLadder;
        private bool ladderInUse;
        private int maxBombs;
        private int maxSelectionX;
        private int maxSelectionY;
        private static int clockLockoutMax = GameData.Instance.InventoryConstants.ClockLockoutMaximum;

        private bool hasMap;
        private bool hasCompass;

        private bool hasClock;
        private int clockLockout;

        private bool hasFlute;
        private int fluteLockout;

        public InventoryManager(IPlayer player)
        {
            this.player = player;
            selectionX = 0;
            selectionY = 0;
            maxBombs = GameData.Instance.InventoryConstants.MaximumBombs;
            maxSelectionX = GameData.Instance.InventoryConstants.MaximumSelectionX;
            maxSelectionY = GameData.Instance.InventoryConstants.MaximumSelectionY;

            numBombs = 4;
            numKeys = 0;
            numRedPotions = 0;
            numBluePotions = 0;
            numRupees = 5;
           
            hasClock = false;
            clockLockout = 0;

            selectedItem = ItemType.Bomb;
        }

        public InventoryManager(InventoryManager copiedManager)
        {
            this.player = copiedManager.player;
            this.selectionX = copiedManager.selectionX;
            this.selectionY = copiedManager.selectionY;
            this.maxBombs = copiedManager.maxBombs;
            this.maxSelectionX = copiedManager.maxSelectionX;
            this.maxSelectionY = copiedManager.maxSelectionY;
            this.numBombs = copiedManager.numBombs;
            this.numKeys = copiedManager.numKeys;
            this.numRedPotions = copiedManager.numRedPotions;
            this.numBluePotions = copiedManager.numBluePotions;
            this.numRupees = copiedManager.numRupees;
            this.hasBoomerang = copiedManager.hasBoomerang;
            this.hasRod = copiedManager.hasRod;
            this.hasMagicBoomerang = copiedManager.hasMagicBoomerang;
            this.hasBow = copiedManager.hasBow;
            this.hasSilverArrow = copiedManager.hasSilverArrow;
            this.hasRedFlame = copiedManager.hasRedFlame;
            this.hasBlueFlame = copiedManager.hasBlueFlame;
            this.hasLadder = copiedManager.hasLadder;
            this.ladderInUse = copiedManager.ladderInUse;
            this.hasMap = copiedManager.hasMap;
            this.hasCompass = copiedManager.hasCompass;
            this.hasClock = copiedManager.hasClock;
            this.clockLockout = copiedManager.clockLockout;
            this.selectedItem = copiedManager.selectedItem;
        }

        public void UseItem()
        {
            switch (selectedItem)
            {
                case ItemType.Bomb:
                    UseBomb();
                    break;
                case ItemType.Arrow:
                    UseArrow();
                    break;
                case ItemType.Boomerang:
                    UseBoomerang();
                    break;
                case ItemType.Candle:
                    UseCandle();
                    break;
                case ItemType.Potion:
                    UsePotion();
                    break;
                case ItemType.Flute:
                    UseFlute();
                    break;
                case ItemType.Rod:
                    UseRod();
                    break;
                default:
                    break;
            }
        }

        public bool HasKey()
        {
            return numKeys > 0;
        }

        private void SelectItem()
        {
            if (ValidSelection())
            {
                selectedItem = selectionArray[selectionY][selectionX];
            }
        }

        public bool ValidSelection()
        {
            if (selectionY == 0)
            {
                switch (selectionX)
                {
                    case 0:
                        return numBombs > 0 || LoZGame.Cheats;
                    case 1:
                        return hasBoomerang || hasMagicBoomerang || LoZGame.Cheats;
                    case 2:
                        return (hasBow && (hasArrow || hasSilverArrow) && numRupees > 0) || LoZGame.Cheats;
                    case 3:
                        return hasBlueFlame || hasRedFlame || LoZGame.Cheats;
                    default:
                        return false;
                }
            }
            else
            {
                switch (selectionX)
                {
                    case 0:
                        return numRedPotions > 0 || numBluePotions > 0 || LoZGame.Cheats;
                    case 1:
                        return HasRod || LoZGame.Cheats;
                    case 2:
                        return false;
                    case 3:
                        return HasFlute || LoZGame.Cheats;
                    default:
                        return false;
                }
            }
        }

        public int ClockLockout { get { return clockLockout; } set { clockLockout = value; } }

        public bool HasClock { get { return hasClock; } set { hasClock = value; } }

        public ItemType SelectedItem { get { return selectedItem; } set { selectedItem = value; } }

        public int SelectionX { get { return selectionX; } }

        public int SelectionY { get { return selectionY; } }

        public int Rupees { get { return LoZGame.Cheats ? 99 : numRupees; } }

        public int Bombs { get { return LoZGame.Cheats ? 8 : numBombs; } }

        public int Keys { get { return numKeys; } }

        public int Potions { get { return LoZGame.Cheats ? 16 : numBluePotions + numRedPotions; } }

        public int RedPotions { get { return LoZGame.Cheats ? 8 : numRedPotions; } }

        public int BluePotions { get { return LoZGame.Cheats ? 8 : numBluePotions; } }

        public bool HasBow { get { return hasBow || LoZGame.Cheats; } set { hasBow = value; } }

        public bool HasBoomerang { get { return hasBoomerang || LoZGame.Cheats; } set { hasBoomerang = value; } }

        public bool HasMagicBoomerang { get { return hasMagicBoomerang || LoZGame.Cheats; } set { hasMagicBoomerang = value; } }

        public bool HasFlute { get { return hasFlute || LoZGame.Cheats; } set { hasFlute = value; } }

        public bool HasRod { get { return hasRod || LoZGame.Cheats; } set { hasRod = value; } }

        public bool HasArrow { get { return hasArrow || LoZGame.Cheats; } set { hasArrow = value; } }

        public bool HasSilverArrow { get { return hasSilverArrow || LoZGame.Cheats; } set { hasSilverArrow = value; } }

        public bool HasBlueFlame { get { return hasBlueFlame || LoZGame.Cheats; } set { hasBlueFlame = value; } }

        public bool HasRedFlame { get { return hasRedFlame || LoZGame.Cheats; } set { hasRedFlame = value; } }

        public bool HasMap { get { return hasMap || LoZGame.Cheats; } set { hasMap = value; } }

        public bool HasCompass { get { return hasCompass || LoZGame.Cheats; } set { hasCompass = value; } }

        public bool HasLadder { get { return hasLadder || LoZGame.Cheats; } set { hasLadder = value; } }

        public bool LadderInUse { get { return ladderInUse; } set { ladderInUse = value; } }

        public static int ClockLockoutMax { get { return clockLockoutMax; } }

    }
}