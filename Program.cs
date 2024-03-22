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
                Character.handleAction(1, char1, char2);
                if (char2.currentHP <= 0)
                {
                    Character.handleResult(char1, char2);
                    break;
                }
                    Character.handleAction(2, char2, char1);
            }
            else
            {
                Character.handleAction(1, char2, char1);
                if (char1.currentHP <= 0)
                {
                    Character.handleResult(char1, char2);
                    break;
                }
                Character.handleAction(2, char1, char2);
            }
        }
        Console.ReadLine();
    }
}
