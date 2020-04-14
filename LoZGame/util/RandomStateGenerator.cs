namespace LoZClone
{
    using System;
    using System.Collections.Generic;

    public class RandomStateGenerator
    {
        private Random randomSelect;
        private IEnemy enemy;

        public enum StateType
        {
            Idle,
            Attack,
            MoveNorth,
            MoveSouth,
            MoveEast,
            MoveWest,
            MoveNorthEast,
            MoveNorthWest,
            MoveSouthEast,
            MoveSouthWest,
        }

        public RandomStateGenerator(IEnemy enemy)
        {
            randomSelect = LoZGame.Instance.Random;
            this.enemy = enemy;
        }

        public void Update(Dictionary<StateType, int> StateSelect)
        {
            int totalWeight = 0;
            
            // determines total weight of passed possible tates
            foreach (KeyValuePair<StateType, int> weight in StateSelect)
            {
                totalWeight += weight.Value;
            }

            // chooses a random value in the bounds of all weights
            int randomWeight = randomSelect.Next(0, totalWeight);

            // initializes values for randomly selectig a state
            int checkedWeight = 0;
            StateType selectedState = StateType.Idle;
            foreach (KeyValuePair<StateType, int> weight in StateSelect)
            {
                if (randomWeight < checkedWeight + weight.Value)
                {
                    selectedState = weight.Key;
                    break;
                }
                else
                {
                    checkedWeight += weight.Value;
                }
            }

            // switches state based on previous state
            switch (selectedState)
            {
                case StateType.Idle:
                    enemy.CurrentState.Stop();
                    break;

                case StateType.Attack:
                    enemy.CurrentState.Attack();
                    break;

                case StateType.MoveWest:
                    enemy.CurrentState.MoveLeft();
                    break;
                case StateType.MoveEast:
                    enemy.CurrentState.MoveRight();
                    break;
                case StateType.MoveNorth:
                    enemy.CurrentState.MoveUp();
                    break;
                case StateType.MoveSouth:
                    enemy.CurrentState.MoveDown();
                    break;
                case StateType.MoveNorthEast:
                    enemy.CurrentState.MoveUpLeft();
                    break;
                case StateType.MoveNorthWest:
                    enemy.CurrentState.MoveUpRight();
                    break;
                case StateType.MoveSouthEast:
                    enemy.CurrentState.MoveDownLeft();
                    break;
                case StateType.MoveSouthWest:
                    enemy.CurrentState.MoveDownRight();
                    break;
                default:
                    enemy.CurrentState.Stop();
                    break;
            }
        }
    }
}