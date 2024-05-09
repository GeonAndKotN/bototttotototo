using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bototttotototo.Game.Dungeon
{
    public class Monster : RoomContent, IActor, IDamageTaker
    {
        public event EventHandler OnDied;
        public event EventHandler OnAction;
        public event EventHandler<int> OnDamageTaken;
        public EnemyStats Stats { get; }
        public int Health { get => Stats.Health; set => Stats.Health = value; }
        public Monster(EnemyStats stats)
        {
            Stats = stats;
        }

        public void TakeDamage(int Value)
        {
            Health -= Value;
            OnDamageTaken.Invoke(this, Value);
        }
        public void Act()
        {
            OnAction.Invoke(this, new EventArgs());
        }
        public void Die()
        {
            OnDied.Invoke(this, new EventArgs());
        }
    }
    public interface IActor
    {
        event EventHandler OnAction;
        void Act();
    }

    public interface IDamageTaker
    {
        int Health { get; set; }
        event EventHandler<int> OnDamageTaken;
        event EventHandler OnDied;
        void TakeDamage(int value);
        void Die();
    }
}

