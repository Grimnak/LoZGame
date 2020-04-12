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

        private static readonly int maxBombs = 8;
        private static readonly int maxSelectionX = 4;
        private static readonly int maxSelectionY = 2;

        private IPlayer player;

        private ItemType selectedItem;

        private List<List<ItemType>> selectionArray = new List<List<ItemType>>()
        {
            new List<ItemType>{ ItemType.Bomb, ItemType.Boomerang, ItemType.Arrow, ItemType.BlueCandle},
            new List<ItemType>{ ItemType.Potion, ItemType.MagicBoomerang, ItemType.SilverArrow, ItemType.RedCandle}
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

        private bool hasMap;
        private bool hasCompass;

        public InventoryManager(IPlayer player)
        {
            this.player = player;
            this.selectionX = 0;
            this.selectionY = 0;

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

        public void MoveSelectionDown()
        {
            if (this.selectionY + 1 < maxSelectionY)
            {
                this.selectionY++;
            }
        }

        public void MoveSelectionUp()
        {
            if (this.selectionY > 0)
            {
                this.selectionY--;
            }
        }

        public void MoveSelectionLeft()
        {
            if (this.selectionX > 0)
            {
                this.selectionX--;
            }
        }

        public void MoveSelectionRight()
        {
            if (this.selectionX + 1 < maxSelectionX)
            {
                this.selectionX++;
            }
        }

        public void SelectItem()
        {
            this.selectedItem = selectionArray[this.selectionY][this.selectionX];
        }

        public ItemType SelectedItem { set { this.selectedItem = value; } }

        public int SelectionX { get { return this.selectionX; } }

        public int SelectionY { get { return this.selectionY; } }

        public int Rupees { get { return this.numRupees; } }

        public int Bombs { get { return this.numBombs; } }

        public int Keys { get { return this.numKeys; } }

        public int Potions { get { return this.numKeys; } }

        public bool HasBow { get { return this.hasBow; } set { this.hasBow = value; } }

        public bool HasBoomerang { get { return this.hasBoomerang; } set { this.hasBoomerang = value; } }

        public bool HasMagicBoomerang { get { return this.hasMagicBoomerang; } set { this.hasMagicBoomerang = value; } }

        public bool HasSilverArrow { get { return this.hasSilverArrow; } set { this.hasSilverArrow = value; } }

        public bool HasBlueFlame { get { return this.hasBlueFlame; } set { this.hasBlueFlame = value; } }

        public bool HasRedFlame { get { return this.hasRedFlame; } set { this.hasRedFlame = value; } }

        public bool HasMap { get { return this.hasMap; } set { this.hasMap = value; } }

        public bool HasCompass { get { return this.hasCompass; } set { this.hasCompass = value; } }

    }
}
