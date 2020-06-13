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
        private static Room ParseRoom(XNamespace nameSpace, XElement xmlRoom)
        {
            bool ex = bool.Parse(xmlRoom.Attribute("exists").Value);
            bool oldman = false;
            bool dark = false;
            bool basement = false;
            if (ex)
            {
                oldman = bool.Parse(xmlRoom.Attribute("oldman").Value);
                basement = bool.Parse(xmlRoom.Attribute("basement").Value);
                dark = bool.Parse(xmlRoom.Attribute("dark").Value);
            }
            string border = string.Empty + nameSpace;
            if (xmlRoom.Descendants(nameSpace + "border").Elements().Count<XElement>() > 0)
            {
                border = string.Empty + xmlRoom.Descendants(nameSpace + "border").Elements().First<XElement>().Value;
            }
            Room newRoom = new Room(string.Empty + border, ex, basement, oldman, dark);
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

        private static void ParseDoors(XNamespace nameSpace, XElement xmlRoom, Room newRoom)
        {
            IEnumerable<XElement> doors = (from d in xmlRoom.Descendants(nameSpace + "doors") select d).Elements(); // all <door> tags in <room>

            foreach (XElement door in doors)
            {
                Console.WriteLine();
                string doorLoc = door.Attribute("loc").Value, doorKind = door.Value;
                newRoom.AddDoor(doorLoc, doorKind);
                // Console.Write("door: " + doorLoc + " " + doorKind + " "); // xml debug
            }
        }

        private static void ParseItems(XNamespace nameSpace, XElement xmlRoom, Room newRoom)
        {
            IEnumerable<XElement> items = (from it in xmlRoom.Descendants(nameSpace + "items") select it).Elements(); // all <items> tags in <room>

            foreach (XElement item in items)
            {
                Console.WriteLine(); // xml debug
                float x = float.Parse(item.Attribute("X").Value), y = float.Parse(item.Attribute("Y").Value);
                newRoom.AddItem(x, y, item.Value);
                // Console.Write("item: " + item.Attribute("X").Value + " " + item.Attribute("Y").Value + " " + item.Value); // xml debug 
            }
        }

        private static void ParseEnemies(XNamespace nameSpace, XElement xmlRoom, Room newRoom)
        {
            IEnumerable<XElement> enemies = (from en in xmlRoom.Descendants(nameSpace + "enemies") select en).Elements(); // all <enemy> tags in <room>

            foreach (XElement enemy in enemies)
            {
                Console.WriteLine(); // xml debug
                                     // Console.Write("enemy: " + enemy.Attribute("X").Value + " " + enemy.Attribute("Y").Value + " " + enemy.Value); // xml debug 
                float x = float.Parse(enemy.Attribute("X").Value), y = float.Parse(enemy.Attribute("Y").Value);
                newRoom.AddEnemy(x, y, enemy.Value);
            }
        }

        private static void ParseBlocks(XNamespace nameSpace, XElement xmlRoom, Room newRoom)
        {
            IEnumerable<XElement> rrow = from rr in xmlRoom.Descendants(nameSpace + "rrow") select rr; // all <rrow> tags in <room>

            foreach (XElement trow in rrow)
            {
                int tcount = 0; // xml debug
                foreach (XElement block in trow.Elements()) // .Elements() here b/c object references a parent with list of children and we just want the children.
                {
                    string x = block.Attribute("idx").Value, y = trow.Attribute("idx").Value;
                    tcount++; // xml debug
                    string[] types = block.Attribute("type").Value.Split(',');
                    if (block.Attribute("type").Value.Equals("stairs"))
                    {
                        string[] roomLoc = block.Attribute("room").Value.Split(',');
                        string[] playerPos = block.Attribute("loc").Value.Split(',');
                        bool hidden = bool.Parse(block.Attribute("hidden").Value);
                        Point roomLocation = new Point(int.Parse(roomLoc[0]), int.Parse(roomLoc[1]));
                        Point playerPosition = new Point(int.Parse(playerPos[0]), int.Parse(playerPos[1]));
                        newRoom.AddStairs(x, y, roomLocation, playerPosition, hidden);
                    }
                    else
                    {
                        if (block.Attribute("dir") != null)
                        {
                            string direction = block.Attribute("dir").Value;
                            newRoom.AddBlock(x, y, types[0], block.Value, direction);
                        }
                        else
                        {
                            newRoom.AddBlock(x, y, types[0], block.Value);
                        }
                    }

                }
                // Console.WriteLine("tcount: " + tcount + "\n");
            }
        }

        private static void ParseText(XNamespace nameSpace, XElement xmlRoom, Room newRoom)
        {
            IEnumerable<XElement> text = from txt in xmlRoom.Descendants(nameSpace + "text") select txt; // all <text> tags in <room>

            foreach (XElement node in text)
            {
                newRoom.SetText(node.Value);
            }
        }
    }
}
