using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    class RandomStateGenerator
    {
        private Random randomSelect;
        private IEnemy enemy;
        private int min;
        private int max;
        public RandomStateGenerator(IEnemy enemy, int minStates,  int maxStates)
        {
            randomSelect = new Random();
            this.enemy = enemy;
            min = minStates;
            max = maxStates;
        }

        public void Update()
        {
            switch (randomSelect.Next(min, max))
            {
                case 0:
                    enemy.CurrentState.Stop();
                    break;

                case 1:
                    enemy.CurrentState.Attack();
                    break;

                case 2:
                    enemy.CurrentState.MoveLeft();
                    break;

                case 3:
                    enemy.CurrentState.MoveRight();
                    break;

                case 4:
                    enemy.CurrentState.MoveUp();
                    break;

                case 5:
                    enemy.CurrentState.MoveDown();
                    break;

                case 6:
                    enemy.CurrentState.MoveUpLeft();
                    break;

                case 7:
                    enemy.CurrentState.MoveUpRight();
                    break;

                case 8:
                    enemy.CurrentState.MoveDownLeft();
                    break;

                case 9:
                    enemy.CurrentState.MoveDownRight();
                    break;

                default:
                    break;
            }
        }

    }
}
