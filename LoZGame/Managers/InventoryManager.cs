namespace LoZClone
{
    using System.Collections.Generic;

    public partial class InventoryManager
    {
        public enum ItemType
        {
            Bomb,
            Arrow,
            SilverArrow,
            Boomerang,
            MagicBoomerang,
            RedCandle,
            BlueCandle,
            Potion
        }

        private IPlayer player;

        private ItemType selectedItem;

        private List<List<ItemType>> selectionArray = new List<List<ItemType>>()
        {
            new List<ItemType> { ItemType.Bomb, ItemType.Boomerang, ItemType.Arrow, ItemType.BlueCandle },
            new List<ItemType> { ItemType.Potion, ItemType.MagicBoomerang, ItemType.SilverArrow, ItemType.RedCandle }
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
            hasBoomerang = LoZGame.Cheats;
            hasMagicBoomerang = LoZGame.Cheats;
            hasBow = LoZGame.Cheats;
            hasArrow = LoZGame.Cheats;
            hasSilverArrow = LoZGame.Cheats;
            hasRedFlame = LoZGame.Cheats;
            hasBlueFlame = LoZGame.Cheats;
            hasLadder = LoZGame.Cheats;
            ladderInUse = false;

            hasMap = LoZGame.Cheats;
            hasCompass = LoZGame.Cheats;

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
                case ItemType.SilverArrow:
                    UseSilverArrow();
                    break;
                case ItemType.Boomerang:
                    UseBoomerang();
                    break;
                case ItemType.MagicBoomerang:
                    UseMagicBoomerang();
                    break;
                case ItemType.RedCandle:
                    UseRedCandle();
                    break;
                case ItemType.BlueCandle:
                    UseBlueCandle();
                    break;
                case ItemType.Potion:
                    UsePotion();
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
                        return numBombs > 0;
                    case 1:
                        return hasBoomerang;
                    case 2:
                        return hasBow && hasArrow && numRupees > 0;
                    case 3:
                        return hasBlueFlame;
                    default:
                        return false;
                }
            }
            else
            {
                switch (selectionX)
                {
                    case 0:
                        return numRedPotions > 0 || numBluePotions > 0;
                    case 1:
                        return hasMagicBoomerang;
                    case 2:
                        return hasBow && hasSilverArrow && numRupees > 0;
                    case 3:
                        return hasRedFlame;
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

        public int Rupees { get { return numRupees; } }

        public int Bombs { get { return numBombs; } }

        public int Keys { get { return numKeys; } }

        public int Potions { get { return numBluePotions + numRedPotions; } }

        public int RedPotions { get { return numRedPotions; } }

        public int BluePotions { get { return numBluePotions; } }

        public bool HasBow { get { return hasBow; } set { hasBow = value; } }

        public bool HasBoomerang { get { return hasBoomerang; } set { hasBoomerang = value; } }

        public bool HasMagicBoomerang { get { return hasMagicBoomerang; } set { hasMagicBoomerang = value; } }

        public bool HasArrow { get { return hasArrow; } set { hasArrow = value; } }

        public bool HasSilverArrow { get { return hasSilverArrow; } set { hasSilverArrow = value; } }

        public bool HasBlueFlame { get { return hasBlueFlame; } set { hasBlueFlame = value; } }

        public bool HasRedFlame { get { return hasRedFlame; } set { hasRedFlame = value; } }

        public bool HasMap { get { return hasMap; } set { hasMap = value; } }

        public bool HasCompass { get { return hasCompass; } set { hasCompass = value; } }

        public bool HasLadder { get { return hasLadder; } set { hasLadder = value; } }

        public bool LadderInUse { get { return ladderInUse; } set { ladderInUse = value; } }

        public static int ClockLockoutMax { get { return clockLockoutMax; } }

    }
}