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

        public int CurrentHealth { get; set; }

        public HealthManager(int health)
        {
            this.maxHealth = health;
            this.CurrentHealth = health;
        }

        public void DamageHealth(int amountLost)
        {
            this.CurrentHealth -= amountLost;
        }

        public void GainHealth(int amountGained)
        {
            this.CurrentHealth += amountGained;
            if (this.CurrentHealth > maxHealth)
            {
                this.CurrentHealth = maxHealth;
            }
        }
    }
}
