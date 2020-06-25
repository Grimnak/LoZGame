namespace LoZClone
{
    using System.Collections.Generic;
    using System.IO;

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
        private bool hasMagicShield;
        private bool hasMagicKey;
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
            this.hasArrow = copiedManager.hasArrow;
            this.hasSilverArrow = copiedManager.hasSilverArrow;
            this.hasRedFlame = copiedManager.hasRedFlame;
            this.hasBlueFlame = copiedManager.hasBlueFlame;
            this.hasFlute = copiedManager.hasFlute;
            this.hasLadder = copiedManager.hasLadder;
            this.ladderInUse = copiedManager.ladderInUse;
            this.hasMap = copiedManager.hasMap;
            this.hasCompass = copiedManager.hasCompass;
            this.hasClock = copiedManager.hasClock;
            this.clockLockout = copiedManager.clockLockout;
            this.selectedItem = copiedManager.selectedItem;
            this.hasMagicShield = copiedManager.hasMagicShield;
            this.hasMagicKey = copiedManager.hasMagicKey;
        }

        public InventoryManager(IPlayer player)
        {
            string[] inventorySave = File.ReadAllLines("../../../../etc/profiles/Profile#" + LoZGame.Instance.SelectedProfile + ".txt");

            this.player = player;
            this.player.Health.CurrentHealth = int.Parse(inventorySave[1]);
            this.player.Health.MaxHealth = int.Parse(inventorySave[2]);
            this.player.CurrentWeapon = LoZGame.Instance.Profiles.ParseWeapon(player, inventorySave[3]);
            this.maxBombs = int.Parse(inventorySave[4]);
            this.maxSelectionX = int.Parse(inventorySave[5]);
            this.maxSelectionY = int.Parse(inventorySave[6]);
            this.selectionX = int.Parse(inventorySave[7]);
            this.selectionY = int.Parse(inventorySave[8]);
            this.numBombs = int.Parse(inventorySave[9]);
            this.numKeys = int.Parse(inventorySave[10]);
            this.numRedPotions = int.Parse(inventorySave[11]);
            this.numBluePotions = int.Parse(inventorySave[12]);
            this.numRupees = int.Parse(inventorySave[13]);
            this.hasBoomerang = bool.Parse(inventorySave[14]);
            this.hasRod = bool.Parse(inventorySave[15]);
            this.hasMagicBoomerang = bool.Parse(inventorySave[16]);
            this.hasBow = bool.Parse(inventorySave[17]);
            this.hasArrow = bool.Parse(inventorySave[18]);
            this.hasSilverArrow = bool.Parse(inventorySave[19]);
            this.hasRedFlame = bool.Parse(inventorySave[20]);
            this.hasBlueFlame = bool.Parse(inventorySave[21]);
            this.hasFlute = bool.Parse(inventorySave[22]);
            this.hasLadder = bool.Parse(inventorySave[23]);
            this.ladderInUse = bool.Parse(inventorySave[24]);
            this.hasMap = bool.Parse(inventorySave[25]);
            this.hasCompass = bool.Parse(inventorySave[26]);
            this.hasClock = bool.Parse(inventorySave[27]);
            this.clockLockout = int.Parse(inventorySave[28]);
            this.selectedItem = LoZGame.Instance.Profiles.ParseSelectedItem(inventorySave[29]);
            this.hasMagicShield = bool.Parse(inventorySave[30]);
            this.player.AcquiredMagicShield = bool.Parse(inventorySave[31]);
            this.hasMagicKey = bool.Parse(inventorySave[32]);
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

        public int Rupees { get { return LoZGame.Cheats ? 999 : numRupees; } set { numRupees = value; } }

        public int Bombs { get { return LoZGame.Cheats ? 8 : numBombs; } }

        public int MaxBombs { get { return maxBombs; } set { maxBombs = value; } }

        public int Keys { get { return numKeys; } }

        public int Potions { get { return LoZGame.Cheats ? 16 : numBluePotions + numRedPotions; } }

        public int RedPotions { get { return LoZGame.Cheats ? 8 : numRedPotions; } }

        public int BluePotions { get { return LoZGame.Cheats ? 8 : numBluePotions; } }

        public bool HasBow { get { return hasBow || LoZGame.Cheats; } set { hasBow = value; } }

        public bool HasBoomerang { get { return hasBoomerang || LoZGame.Cheats; } set { hasBoomerang = value; } }

        public bool HasMagicBoomerang { get { return hasMagicBoomerang || LoZGame.Cheats; } set { hasMagicBoomerang = value; } }

        public bool HasFlute { get { return hasFlute || LoZGame.Cheats; } set { hasFlute = value; } }

        public bool HasMagicShield { get { return hasMagicShield || LoZGame.Cheats; } set { hasMagicShield = value; } }

        public bool HasRod { get { return hasRod || LoZGame.Cheats; } set { hasRod = value; } }

        public bool HasArrow { get { return hasArrow || LoZGame.Cheats; } set { hasArrow = value; } }

        public bool HasSilverArrow { get { return hasSilverArrow || LoZGame.Cheats; } set { hasSilverArrow = value; } }

        public bool HasBlueFlame { get { return hasBlueFlame || LoZGame.Cheats; } set { hasBlueFlame = value; } }

        public bool HasRedFlame { get { return hasRedFlame || LoZGame.Cheats; } set { hasRedFlame = value; } }

        public bool HasMap { get { return hasMap || LoZGame.Cheats; } set { hasMap = value; } }

        public bool HasCompass { get { return hasCompass || LoZGame.Cheats; } set { hasCompass = value; } }

        public bool HasLadder { get { return hasLadder || LoZGame.Cheats; } set { hasLadder = value; } }

        public bool HasMagicKey { get { return hasMagicKey || LoZGame.Cheats; } set { hasMagicKey = value; } }

        public bool LadderInUse { get { return ladderInUse; } set { ladderInUse = value; } }

        public static int ClockLockoutMax { get { return clockLockoutMax; } }

    }
}