namespace LoZClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using Microsoft.Xna.Framework;

    public static partial class XMLHandler
    {
        /*
        * This methodd will parse a MiniMap Color for a givendungeeon
        * 
        * args:
        * nameSpace => namespace of the root of the xml
        */
        public static Color ParseMapColor(string filePath)
        {
            XDocument xmlDungeon = XDocument.Load(filePath);
            XElement root = xmlDungeon.Root;
            int red = int.Parse(root.Attribute("mapColorRed").Value);
            int green = int.Parse(root.Attribute("mapColorGreen").Value);
            int blue = int.Parse(root.Attribute("mapColorBlue").Value);
            int alpha = int.Parse(root.Attribute("mapColorAlpha").Value);
            return new Color(red, green, blue, alpha);
        }

        /*
        * This methodd will parse a spritebatch tint for a given dungeon
        * 
        * args:
        * nameSpace => namespace of the root of the xml
        */
        public static Color ParseColor(string filePath)
        {
            XDocument xmlDungeon = XDocument.Load(filePath);
            XElement root = xmlDungeon.Root;
            int red = int.Parse(root.Attribute("dungeonColorRed").Value);
            int green = int.Parse(root.Attribute("dungeonColorGreen").Value);
            int blue = int.Parse(root.Attribute("dungeonColorBlue").Value);
            int alpha = int.Parse(root.Attribute("dungeonColorAlpha").Value);
            return new Color(red, green, blue, alpha);
        }

        /*
        * This methodd will parse a given name for a given dungeon
        * 
        * args:
        * nameSpace => namespace of the root of the xml
        */
        public static string ParseName(string filePath)
        {
            XDocument xmlDungeon = XDocument.Load(filePath);
            XElement root = xmlDungeon.Root;
            return root.Attribute("xmlns").Value;
        }

        /*
        * This methodd will parse a boss location for a given dungeon
        * 
        * args:
        * nameSpace => namespace of the root of the xml
        */
        public static Point ParseBossLocation(string filePath)
        {
            XDocument xmlDungeon = XDocument.Load(filePath);
            XElement root = xmlDungeon.Root;
            int x = int.Parse(root.Attribute("bossX").Value);
            int y = int.Parse(root.Attribute("bossY").Value);
            return new Point(x, y);
        }

        /*
        * This methodd will parse a starting location for the player given a dungeon
        * 
        * args:
        * nameSpace => namespace of the root of the xml
        */
        public static Point ParseStartLocation(string filePath)
        {
            XDocument xmlDungeon = XDocument.Load(filePath);
            XElement root = xmlDungeon.Root;
            int x = int.Parse(root.Attribute("startX").Value);
            int y = int.Parse(root.Attribute("startY").Value);
            return new Point(x, y);
        }

        /*
        * This methodd will parse the max x and y dimension for a dungeon layout given a dungeon
        * 
        * args:
        * nameSpace => namespace of the root of the xml
        */
        public static Point ParseMaxSize(string filePath)
        {
            XDocument xmlDungeon = XDocument.Load(filePath);
            XElement root = xmlDungeon.Root;
            int x = int.Parse(root.Attribute("maxX").Value);
            int y = int.Parse(root.Attribute("maxY").Value);
            return new Point(x, y);
        }

        /*
         * this method will parse a given XML document and return 
         * an object describing the layout of a particular dungeon
         * 
         * args:
         * filePath => relative path to XML doc
         */
        public static List<List<Room>> ParseLayout(string filePath)
        {
            XDocument xmlDungeon = XDocument.Load(filePath);
            XElement root = xmlDungeon.Root;
            XNamespace nameSpace = root.GetDefaultNamespace();

            List<List<Room>> dungeon = new List<List<Room>>();

            IEnumerable<XElement> rows = from r in xmlDungeon.Descendants(nameSpace + "drow") select r; // all <drow> tags
            foreach (XElement row in rows)
            {
                List<Room> RoomRow = ParseRow(nameSpace, row);
                dungeon.Add(RoomRow);
            }
            return dungeon;
        }

        /*
         * This methodd will parse a given XML row element and return
         * an object describing the layout of a particular row of a dungeon
         * 
         * args:
         * nameSpace => namespace of the root of the xml
         */
        private static List<Room> ParseRow(XNamespace nameSpace, XElement row)
        {
            List<Room> newRow = new List<Room>();
            IEnumerable<XElement> xmlRoomRow = from r in row.Descendants(nameSpace + "room") select r; // all <room> tags within row
            foreach (XElement xmlRoom in xmlRoomRow)
            {
                Room newRoom = ParseRoom(nameSpace, xmlRoom);
                newRow.Add(newRoom);
            }
            return newRow;
        }
    }
}