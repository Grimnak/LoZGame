namespace LoZClone
{
    using System.Collections.Generic;
    using global::LoZGame.Interfaces;

    /*
     * A Room object represents a single dungeon room in-game.
     * All instance fields are private so that the dungeon rooms cannot
     * be adjusted prior to the level being loaded.
     */
    public partial class Room
    {
        private bool exists;
        private string border;
        private string text;
        private List<IItemSprite> items; // a list for any and all items in a room
        private List<IEnemy> enemies; // a list for any and all enemies in a room
        private List<ITile> tiles; // a list for any and all tiles in a room
        private List<Door> doors; // a list for any and all doors in a room

        /*
         * args:
         * ns => namespace of XML dungeon doc
         * ex => whether the room is null or not
         */
        public Room(string ns, bool ex)
        {
            this.exists = ex;
            this.border = ns; // ns = LEVEL-1 || LEVEL-2
        }

        /// <summary>
        /// Gets a value indicating whether the room contains anything.
        /// </summary>
        public bool Exists
        {
            get { return this.exists; }
        }

        /*
         * this method exists in case we want to change the text during runtime
         * for any reason and also since most rooms will not normally have text
         * args:
         * txt => a particular string to be displayed in a room
         */
        public void SetText(string txt)
        {
            this.text = txt;
        }

        /*
         * args:
         * x => tile X location
         * y => tile Y location
         * type => type/kind of enemy at X/Y
         */
        public void AddEnemy(int x, int y, string type)
        {
            switch (type)
            {
                // TODO
                case "Goriya":
                    break;
                default:
                    break;
            }
        }

        /*
         * args:
         * x => tile X location
         * y => tile Y location
         * name => the item's name
         */
        public void AddItem(int x, int y, string name)
        {
            // TODO
            switch (name)
            {
                case "Bow":
                    break;
                case "HeartContainer":
                    break;
                case "Key":
                    break;
                case "Compass":
                    break;
                case "Boomerang":
                    break;
                case "TriForce":
                    break;
                default:
                    break;
            }
        }

        /*
         * args:
         * x => tile X location
         * y => tile Y location
         * type => type of tile
         * name => name of tile sprite
         */
        public void AddTile(int x, int y, string type, string name)
        {
            // TODO
            switch (type)
            {
                case "Movable":
                    break;

                case "Walkable":
                    break;

                default:
                    break;
            }
        }

        /*
         * args:
         * location => N/E/S/W
         * kind => which kind of door sprite
         */
        public void AddDoor(string location, string kind)
        {
            this.doors.Add(new Door(location, kind)); // appending a new Door (Door.cs) to a room object's list of doors
        }
    }
}
