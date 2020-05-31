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
         * this method will parse a given XML document and return 
         * an object describing the layout of a particular dungeon
         * 
         * args:
         * filePath => relative path to XML doc
         */
        public static List<List<Room>> Parse(string filePath)
        {
            List<List<Room>> dungeon = new List<List<Room>>();

            XDocument xmlDungeon = XDocument.Load(filePath);
            XElement root = xmlDungeon.Root;
            XNamespace nameSpace = root.GetDefaultNamespace();

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

        private static Room ParseRoom(XNamespace nameSpace, XElement xmlRoom)
        {
            bool ex = bool.Parse(xmlRoom.Attribute("exists").Value);
            bool oldman = false;
            bool basement = false;
            if (ex)
            {
                oldman = bool.Parse(xmlRoom.Attribute("oldman").Value);
                basement = bool.Parse(xmlRoom.Attribute("basement").Value);
            }
            string border = string.Empty + nameSpace;
            if (xmlRoom.Descendants(nameSpace + "border").Elements().Count<XElement>() > 0)
            {
                border = string.Empty + xmlRoom.Descendants(nameSpace + "border").Elements().First<XElement>().Value;
            }
            Room newRoom = new Room(string.Empty + border, ex, basement, oldman);
            if (ex)
            {
                ParseDoors(nameSpace, xmlRoom, newRoom);
                ParseItems(nameSpace, xmlRoom, newRoom);
                ParseEnemies(nameSpace, xmlRoom, newRoom);
                ParseBlocks(nameSpace, xmlRoom, newRoom);
                ParseText(nameSpace, xmlRoom, newRoom);
            }
            return newRoom;
        }
    }
}