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
        private bool hasSilverArrow;
        private bool hasRedFlame;
        private bool hasBlueFlame;
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
            this.selectionX = 0;
            this.selectionY = 0;
            this.maxBombs = GameData.Instance.InventoryConstants.MaximumBombs;
            this.maxSelectionX = GameData.Instance.InventoryConstants.MaximumSelectionX;
            this.maxSelectionY = GameData.Instance.InventoryConstants.MaximumSelectionY;

            this.numBombs = 4;
            this.numKeys = 0;
            this.numRedPotions = 0;
            this.numBluePotions = 0;
            this.numRupees = 5;
            this.hasBoomerang = LoZGame.Cheats;
            this.hasMagicBoomerang = LoZGame.Cheats;
            this.hasBow = LoZGame.Cheats;
            this.hasSilverArrow = LoZGame.Cheats;
            this.hasRedFlame = LoZGame.Cheats;
            this.hasBlueFlame = LoZGame.Cheats;

            this.hasMap = LoZGame.Cheats;
            this.hasCompass = LoZGame.Cheats;

            this.hasClock = false;
            this.clockLockout = 0;

            this.selectedItem = ItemType.Bomb;
        }

        public void UseItem()
        {
            switch (this.selectedItem)
            {
                case ItemType.Bomb:
                    this.UseBomb();
                    break;
                case ItemType.Arrow:
                    this.UseArrow();
                    break;
                case ItemType.SilverArrow:
                    this.UseSilverArrow();
                    break;
                case ItemType.Boomerang:
                    this.UseBoomerang();
                    break;
                case ItemType.MagicBoomerang:
                    this.UseMagicBoomerang();
                    break;
                case ItemType.RedCandle:
                    this.UseRedCandle();
                    break;
                case ItemType.BlueCandle:
                    this.UseBlueCandle();
                    break;
                case ItemType.Potion:
                    this.UsePotion();
                    break;
                default:
                    break;
            }
        }

        public bool HasKey()
        {
            return this.numKeys > 0;
        }

        public void SelectItem()
        {
            if (this.ValidSelection())
            {
                this.selectedItem = selectionArray[this.selectionY][this.selectionX];
            }
        }

        public bool ValidSelection()
        {
            if (this.selectionY == 0)
            {
                switch (this.selectionX)
                {
                    case 0:
                        return this.numBombs > 0;
                    case 1:
                        return this.hasBoomerang;
                    case 2:
                        return this.hasBow && this.numRupees > 0;
                    case 3:
                        return this.hasBlueFlame;
                    default:
                        return false;
                }
            }
            else
            {
                switch (this.selectionX)
                {
                    case 0:
                        return this.numRedPotions > 0 || this.numBluePotions > 0;
                    case 1:
                        return this.hasMagicBoomerang;
                    case 2:
                        return this.hasBow && this.numRupees > 0;
                    case 3:
                        return this.hasRedFlame;
                    default:
                        return false;
                }
            }
        }

        public int ClockLockout { get { return this.clockLockout; } set { this.clockLockout = value; } }

        public bool HasClock { get { return this.hasClock; } set { this.hasClock = value; } }

        public ItemType SelectedItem { get { return this.selectedItem; } set { this.selectedItem = value; } }

        public int SelectionX { get { return this.selectionX; } }

        public int SelectionY { get { return this.selectionY; } }

        public int Rupees { get { return this.numRupees; } }

        public int Bombs { get { return this.numBombs; } }

        public int Keys { get { return this.numKeys; } }

        public int Potions { get { return this.numBluePotions + this.numRedPotions; } }

        public int RedPotions { get { return this.numRedPotions; } }

        public int BluePotions { get { return this.numBluePotions; } }

        public bool HasBow { get { return this.hasBow; } set { this.hasBow = value; } }

        public bool HasBoomerang { get { return this.hasBoomerang; } set { this.hasBoomerang = value; } }

        public bool HasMagicBoomerang { get { return this.hasMagicBoomerang; } set { this.hasMagicBoomerang = value; } }

        public bool HasSilverArrow { get { return this.hasSilverArrow; } set { this.hasSilverArrow = value; } }

        public bool HasBlueFlame { get { return this.hasBlueFlame; } set { this.hasBlueFlame = value; } }

        public bool HasRedFlame { get { return this.hasRedFlame; } set { this.hasRedFlame = value; } }

        public bool HasMap { get { return this.hasMap; } set { this.hasMap = value; } }

        public bool HasCompass { get { return this.hasCompass; } set { this.hasCompass = value; } }

        public static int ClockLockoutMax { get { return clockLockoutMax; } }

    }
}