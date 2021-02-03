using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Monster
    {
        public int Health { get; set; }
        protected int _maxDamage;
        public int attack()
        {
            Random random = new Random();
            return random.Next(0, _maxDamage);
        }
    }

    public class OneHeadMonster : Monster
    {
        public OneHeadMonster()
        {
            Health = 100;
            _maxDamage = 10;
        }
    }

    public class TwoHeadMonster : Monster
    {
        public TwoHeadMonster()
        {
            Health = 200;
            _maxDamage = 20;
        }
    }
}
