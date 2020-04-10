using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    public class MiniMap
    {
        private List<List<MiniMapRoom>> dungeonLayout;

        public MiniMap()
        {
            this.dungeonLayout = new List<List<MiniMapRoom>>();
            switch (LoZGame.Instance.Dungeon.DungeonNumber)
            {
                case 1:
                    this.CreateDungeonOneMiniMap();
                    break;
                case 2:
                    this.CreateDungeonTwoMiniMap();
                    break;
                default:
                    break;
            }
        }

        public void Draw()
        {
            for (int i = 0; i < dungeonLayout.Count; i++)
            {
                for (int j = 0; j < dungeonLayout[i].Count; j++)
                {
                    this.dungeonLayout[i][j].Draw();
                }
            }
        }

        // Note to grader, we are aware this is some smelly code, but it wasn't apparent to us how to do it any cleaner.
        public void CreateDungeonOneMiniMap()
        {
            this.dungeonLayout[0][0] = new MiniMapRoom(false, null, 0, 0);
            this.dungeonLayout[0][1] = new MiniMapRoom(true, null, 0, 1);
            this.dungeonLayout[0][2] = new MiniMapRoom(true, null, 0, 2);
            this.dungeonLayout[0][3] = new MiniMapRoom(false, null, 0, 3);
            this.dungeonLayout[0][4] = new MiniMapRoom(false, null, 0, 4);
            this.dungeonLayout[0][5] = new MiniMapRoom(false, null, 0, 5);
            this.dungeonLayout[1][0] = new MiniMapRoom(false, null, 1, 0);
            this.dungeonLayout[1][1] = new MiniMapRoom(false, null, 1, 1);
            this.dungeonLayout[1][2] = new MiniMapRoom(true, null, 1, 2);
            this.dungeonLayout[1][3] = new MiniMapRoom(false, null, 1, 3);
            this.dungeonLayout[1][4] = new MiniMapRoom(true, null, 1, 4);
            this.dungeonLayout[1][5] = new MiniMapRoom(true, null, 1, 5);
            this.dungeonLayout[2][0] = new MiniMapRoom(true, null, 2, 0);
            this.dungeonLayout[2][1] = new MiniMapRoom(true, null, 2, 1);
            this.dungeonLayout[2][2] = new MiniMapRoom(true, null, 2, 2);
            this.dungeonLayout[2][3] = new MiniMapRoom(true, null, 2, 3);
            this.dungeonLayout[2][4] = new MiniMapRoom(true, null, 2, 4);
            this.dungeonLayout[2][5] = new MiniMapRoom(false, null, 2, 5);
            this.dungeonLayout[3][0] = new MiniMapRoom(false, null, 3, 0);
            this.dungeonLayout[3][1] = new MiniMapRoom(true, null, 3, 1);
            this.dungeonLayout[3][2] = new MiniMapRoom(true, null, 3, 2);
            this.dungeonLayout[3][3] = new MiniMapRoom(true, null, 3, 3);
            this.dungeonLayout[3][4] = new MiniMapRoom(false, null, 3, 4);
            this.dungeonLayout[3][5] = new MiniMapRoom(false, null, 3, 5);
            this.dungeonLayout[4][0] = new MiniMapRoom(false, null, 4, 0);
            this.dungeonLayout[4][1] = new MiniMapRoom(false, null, 4, 1);
            this.dungeonLayout[4][2] = new MiniMapRoom(true, null, 4, 2);
            this.dungeonLayout[4][3] = new MiniMapRoom(false, null, 4, 3);
            this.dungeonLayout[4][4] = new MiniMapRoom(false, null, 4, 4);
            this.dungeonLayout[4][5] = new MiniMapRoom(false, null, 4, 5);
            this.dungeonLayout[5][0] = new MiniMapRoom(false, null, 5, 0);
            this.dungeonLayout[5][1] = new MiniMapRoom(true, null, 5, 1);
            this.dungeonLayout[5][2] = new MiniMapRoom(true, null, 5, 2);
            this.dungeonLayout[5][3] = new MiniMapRoom(true, null, 5, 3);
            this.dungeonLayout[5][4] = new MiniMapRoom(false, null, 5, 4);
            this.dungeonLayout[5][5] = new MiniMapRoom(false, null, 5, 5);
        }

        public void CreateDungeonTwoMiniMap()
        {

        }
    }
}
