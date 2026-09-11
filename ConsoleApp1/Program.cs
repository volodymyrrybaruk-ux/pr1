using System;
using System.Collections.Generic;

namespace AdventureGame
{
    public interface IWeapon
    {
        string GetName();
        int GetDamage();
        void Attack(Character character);
    }

    public abstract class Character
    {
        protected string Name;
        protected int Health;
        protected IWeapon Weapon;

        protected Character(string name, int health)
        {
            Name = name;
            Health = health;
            Weapon = null;
        }

        public void SetWeapon(IWeapon weapon)
        {
            Weapon = weapon;
            Console.WriteLine($"{Name} екіпірував(ла) зброю: {weapon.GetName()}");
        }

        public void Attack()
        {
            if (Weapon == null)
            {
                Console.WriteLine($"{Name} не має зброї! Спочатку потрібно використати SetWeapon().");
                return;
            }

            Console.Write($"[{GetRole()}] ");
            Weapon.Attack(this);
        }

        public abstract string GetRole();

        public string GetName()
        {
            return Name;
        }

        public int GetHealth()
        {
            return Health;
        }
    }

    public class Sword : IWeapon
    {
        public string GetName()
        {
            return "Меч";
        }

        public int GetDamage()
        {
            return 25;
        }

        public void Attack(Character character)
        {
            Console.WriteLine($"{character.GetName()} завдає рубаючого удару мечем (шкода: {GetDamage()})");
        }
    }

    public class Bow : IWeapon
    {
        public string GetName()
        {
            return "Лук";
        }

        public int GetDamage()
        {
            return 18;
        }

        public void Attack(Character character)
        {
            Console.WriteLine($"{character.GetName()} випускає стрілу з лука (шкода: {GetDamage()})");
        }
    }

    public class Staff : IWeapon
    {
        public string GetName()
        {
            return "Магічний посох";
        }

        public int GetDamage()
        {
            return 30;
        }

        public void Attack(Character character)
        {
            Console.WriteLine($"{character.GetName()} кидає вогняну кулю з посоха (шкода: {GetDamage()})");
        }
    }

    public class Dagger : IWeapon
    {
        public string GetName()
        {
            return "Кинджал";
        }

        public int GetDamage()
        {
            return 15;
        }

        public void Attack(Character character)
        {
            Console.WriteLine($"{character.GetName()} завдає швидкого удару кинджалом (шкода: {GetDamage()})");
        }
    }

    public class Warrior : Character
    {
        public Warrior(string name) : base(name, 150)
        {
        }

        public override string GetRole()
        {
            return "Воїн";
        }
    }

    public class Mage : Character
    {
        public Mage(string name) : base(name, 90)
        {
        }

        public override string GetRole()
        {
            return "Маг";
        }
    }

    public class Archer : Character
    {
        public Archer(string name) : base(name, 100)
        {
        }

        public override string GetRole()
        {
            return "Лучник";
        }
    }

    public class Rogue : Character
    {
        public Rogue(string name) : base(name, 110)
        {
        }

        public override string GetRole()
        {
            return "Розбійник";
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<Character> party = new List<Character>
            {
                new Warrior("Богдан"),
                new Mage("Ліра"),
                new Archer("Остап"),
                new Rogue("Тінь")
            };

            Console.WriteLine("=== ЕКІПІРОВКА ПЕРСОНАЖІВ ===");
            Console.WriteLine();

            party[0].SetWeapon(new Sword());
            party[1].SetWeapon(new Staff());
            party[2].SetWeapon(new Bow());
            party[3].SetWeapon(new Dagger());

            Console.WriteLine();
            Console.WriteLine("=== ПЕРШИЙ РАУНД БОЮ ===");
            Console.WriteLine();

            foreach (Character character in party)
            {
                character.Attack();
            }

            Console.WriteLine();
            Console.WriteLine("=== ЗМІНА ЗБРОЇ ===");
            Console.WriteLine();

            Console.WriteLine("Воїн Богдан змінює меч на лук...");
            party[0].SetWeapon(new Bow());

            Console.WriteLine();
            Console.WriteLine("=== ДРУГИЙ РАУНД БОЮ ===");
            Console.WriteLine();

            foreach (Character character in party)
            {
                character.Attack();
            }

            Console.WriteLine();
            Console.WriteLine("=== ПЕРСОНАЖ БЕЗ ЗБРОЇ ===");
            Console.WriteLine();

            Character newbie = new Mage("Новачок");

            Console.WriteLine($"{newbie.GetName()} має роль: {newbie.GetRole()}");
            Console.WriteLine($"Здоров'я: {newbie.GetHealth()}");

            newbie.Attack();

            Console.WriteLine();
            Console.WriteLine("Гру завершено!");
            Console.WriteLine("Натисніть будь-яку клавішу...");

            Console.ReadKey();
        }
    }
}