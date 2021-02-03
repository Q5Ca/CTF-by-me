using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public interface Sword
    {
        int getDamage();
        Image icon { get; set; }
    }
    class DarkSword : Sword
    {
        const int _damage = 125;
        public int getDamage()
        {
            return _damage;
        }
        public Image icon
        {
            get;
            set;
        }
    }
    class Kusanagi : Sword
    {
        const int _damage = 150;
        public int getDamage()
        {
            return _damage;
        }
        public Image icon { get; set; }
    }
}
