using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Player
    {
        public String Name { get; set; }
        protected int _maxDamage;
        public int Health { get; set; }
        public virtual int attack()
        {
            Random random = new Random();
            return random.Next(0, _maxDamage);
        }
        public Player()
        {
            Health = 100;
            _maxDamage = 10;
        }
    }

    public class VipPlayer : Player
    {
        public override int attack()
        {
            Random random = new Random();
            return random.Next(0, _maxDamage) + sword.getDamage();
        }

        public VipPlayer()
        {
            Health = 200;
            _maxDamage = 20;
        }


        public Sword sword
        {
            get;
            set;
        }

        private String _swordIconPath;
        public String swordIconPath
        {
            get
            {
                return _swordIconPath;
            }
            set
            {
                _swordIconPath = sword.icon.getLink();
            }
        }
    }
}
