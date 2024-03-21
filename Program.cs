using System;
using CharacterNamespace;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("-----BEM VINDO AO RPG DO FLAVINHO-----");
        Console.WriteLine("Insira o nome do jogador 1: ");
        string char1Name = Console.ReadLine();
        Console.WriteLine("Insira o nome do jogador 2: ");
        string char2Name = Console.ReadLine();

        Character char1 = new Character(char1Name);
        Character char2 = new Character(char2Name);

        string char1Stats = char1.GetStats();
        string char2Stats = char2.GetStats();

        Console.WriteLine(char1Stats);
        Console.WriteLine(char2Stats);

        while (char1.currentHP > 0 && char2.currentHP > 0)
        {
            if (char1.speed > char2.speed)
            {
                Console.WriteLine("O" + char1.name + "ataca primeiro!");
                Character.ShowMenu();
                string response = Console.ReadLine();
                Character.handleRound(char1, char2, response);
                if (char2.currentHP <= 0)
                {
                    Console.WriteLine("O jogador 1 venceu!");
                    Character.handleResult(char1, char2);
                    return;
                }

                Console.WriteLine("Agora é a vez do " + char2.name);
                Character.ShowMenu();
                string response2 = Console.ReadLine();
                Character.handleRound(char2, char1, response2);
            }
            else
            {
                Console.WriteLine("O" + char2.name + "ataca primeiro!");
                Character.ShowMenu();
                string response2 = Console.ReadLine();
                Character.handleRound(char2, char1, response2);

                if (char1.currentHP <= 0)
                {
                    Console.WriteLine("O jogador 2 venceu!");
                    Character.handleResult(char1, char2);
                    return;
                }

                Console.WriteLine("Agora é a vez do " + char1.name);
                Character.ShowMenu();
                string response = Console.ReadLine();
                Character.handleRound(char2, char1, response);
            

            }

        }
        if (char1.currentHP > 0)
        {
            Console.WriteLine("O " + char1.name + " ganhou!");
        }
        else if (char2.currentHP > 0)
        {
            Console.WriteLine("O " + char2.name + " ganhou!");
        }
        Console.ReadLine();
    }
}
