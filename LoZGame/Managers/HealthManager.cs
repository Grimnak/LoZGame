using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoZClone
{
    public class HealthManager
    {
        private int maxHealth;
        private int currentHealth;

        public int MaxHealth
        {
            get { return maxHealth; }
            set { maxHealth = value; }
        }

        public int CurrentHealth
        {
            get { return currentHealth; }
            set { currentHealth = value; }
        }

        public HealthManager(int health)
        {
            maxHealth = health;
            currentHealth = health;
        }

        public void DamageHealth(int amountLost)
        {
            currentHealth -= amountLost;
        }

        public void GainHealth(int amountGained)
        {
            CurrentHealth += amountGained;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }

        public void ResetHealth()
        {
            currentHealth = maxHealth;
        }
    }
}
