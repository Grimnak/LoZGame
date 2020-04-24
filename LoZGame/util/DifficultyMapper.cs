using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    public class DifficultyMapper : EnumClass
    {
        public static DifficultyMapper EASY = new DifficultyMapper(-1, "EASY");
        public static DifficultyMapper NORMAL = new DifficultyMapper(0, "NORMAL");
        public static DifficultyMapper HARD = new DifficultyMapper(1, "HARD");
        public static DifficultyMapper NIGHTMARE = new DifficultyMapper(3, "NIGHTMARE");

        private DifficultyMapper(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public static DifficultyMapper GetMyType(int id)
        {
            switch (id)
            {
                case -1: return EASY;
                case 0: return NORMAL;
                case 1: return HARD;
                case 3: return NIGHTMARE;
                default: return null;
            }
        }

        public static List<DifficultyMapper> GetMyTypes()
        {
            return new List<DifficultyMapper>
            {
            EASY,
            NORMAL,
            HARD,
            NIGHTMARE
            };
        }
    }
}
