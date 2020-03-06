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
            this.maxHealth = health;
            this.currentHealth = health;
        }

        public void DamageHealth(int amountLost)
        {
            this.currentHealth -= amountLost;
        }

        public void GainHealth(int amountGained)
        {
            this.CurrentHealth += amountGained;
            if (this.currentHealth > maxHealth)
            {
                this.currentHealth = maxHealth;
            }
        }
    }
}
