namespace CharacterNamespace
{
    class Character
    {
        public string name;
        private int totalHP;
        public int currentHP;
        private int attack;
        public int speed;
        private Random rnd;

        public Character(string name)
        {
            this.name = name;
            rnd = new Random();
            this.currentHP = 10 * rnd.Next(5, 10);
            this.totalHP = this.currentHP;
            this.attack = rnd.Next(5, 10);
            this.speed = rnd.Next(1, 100);
        }

        public static void ShowMenu()
        {
            Console.WriteLine("----Ações----");
            Console.WriteLine("1 - Atacar");
            Console.WriteLine("2 - Curar-se");
        }

        public string GetStats()
        {
            return "-------RPG DO FLAVINHO-------" + "\n" +
                "Nome: " + this.name + "\n" +
                "HP: " + this.currentHP + '/' + this.totalHP + "\n" +
                "ATK: " + this.attack + '\n' +
                "SPD: " + this.speed + '\n';
        }

        public void Attack(Character target)
        {
            rnd = new Random();
            int attackAccuracy = rnd.Next(1, 100);
            if (!(attackAccuracy > this.speed))
            {
                Console.WriteLine(this.name + " " + "errou o ataque!");
                return;
            }
            int damage = this.attack * rnd.Next(1, 10);
            Console.WriteLine(this.name + " atacou " + target.name + " " + "O ataque causou " + damage + " de dano!");
            target.currentHP -= damage;
            Console.WriteLine(target.name + " agora tem " + target.currentHP + " de vida");
        }

        public void Heal()
        {
            if (this.currentHP < this.totalHP)
            {
                int maxHeal = this.totalHP - this.currentHP;
                int healed = rnd.Next(1, maxHeal + 1);
                this.currentHP += healed;
                Console.WriteLine(this.name + " curou " + healed + " pontos de vida!");
                Console.WriteLine("Agora " + this.name + "possui " + this.currentHP + "pontos de vida!");
            }
            else
            {
                Console.WriteLine(this.name + " já está com a vida cheia!");
            }
        }

        public static void handleRound(Character char1, Character target, string response)
        {
            switch (response)
            {
                case "1":
                    char1.Attack(target);
                    break;
                case "2":
                    char1.Heal();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
        public static void handleResult(Character char1, Character char2)
        {
            if (char1.currentHP >= 0)
            {
                Console.WriteLine("O " + char1.name + " ganhou!");
            }
            else if (char2.currentHP >= 0)
            {
                Console.WriteLine("O " + char2.name + " ganhou!");
            }
        }

    }
}