using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bototttotototo.Game.Dungeon
{
    public class Monster
    {
        public EventHandler<Monster> OnDied;
        public EventHandler<Monster> OnAction;
        public EnemyStats Stats { get; private set; }
        public Monster(EnemyStats stats)
        {
            Stats = stats;
        }

        public void TakeDamage()
        {

        }
        public void Act()
        {
            OnAction.Invoke(this, this);
        }

        public void Die()
        {
            OnDied.Invoke(this, this);
        }
    }
}
