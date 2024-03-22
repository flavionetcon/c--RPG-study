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
            Console.WriteLine("----A��es----");
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
            Console.WriteLine(this.name + " atacou " + target.name + " " + "\n" + "O ataque causou " + damage + " de dano!");
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
                Console.WriteLine(this.name + " j� est� com a vida cheia!");
            }
        }

        public static void handleRound(string response, Character char1, Character target)
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
                    Console.WriteLine("Op��o inv�lida!");
                    break;
            }
        }
        public static void handleResult(Character char1, Character char2)
        {
            Console.WriteLine("----------------------------");
            if (char1.currentHP >= 0)
            {
                Console.WriteLine("O " + char1.name + " ganhou!");
            }
            else if (char2.currentHP >= 0)
            {
                Console.WriteLine("O " + char2.name + " ganhou!");
            }
            Console.WriteLine("----------------------------");
        }

        public static void handleAction(int order, Character char1, Character target)
        {
            switch (order)
            {
                case 1: 
                    Console.WriteLine("O" + char1.name + "ataca primeiro!");
                    break;
                default: 
                    Console.WriteLine("Agora � a vez do " + target.name);
                    break;
            }
            Character.ShowMenu();
            string response = Console.ReadLine();
            Character.handleRound(response, char1, target);

        }

    }
}