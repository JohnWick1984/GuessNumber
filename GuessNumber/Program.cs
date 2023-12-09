using System;

class NumberGuesser
{
    private int targetNumber;
    private int attempts;

    public void PlayGame()
    {
        Console.WriteLine("Добро пожаловать в игру 'Угадай число'!");
        Console.WriteLine("Загадайте число от 1 до 2000.");

        // Загадываем число
        Random random = new Random();
        targetNumber = random.Next(1, 2001);

        int guess;
        attempts = 0;

        do
        {
            guess = GetGuessFromUser();
            attempts++;

            if (guess < targetNumber)
            {
                Console.WriteLine("Загаданное число больше. Попробуйте еще раз.");
            }
            else if (guess > targetNumber)
            {
                Console.WriteLine("Загаданное число меньше. Попробуйте еще раз.");
            }
            else
            {
                Console.WriteLine($"Поздравляем! Вы угадали число {targetNumber} за {attempts} попыток.");
            }

        } while (guess != targetNumber);

        AskForAnotherGame();
    }

    private int GetGuessFromUser()
    {
        int guess;
        bool isValidInput;

        do
        {
            Console.Write("Введите ваше предположение: ");
            isValidInput = int.TryParse(Console.ReadLine(), out guess);

            if (!isValidInput || guess < 1 || guess > 2000)
            {
                Console.WriteLine("Пожалуйста, введите корректное число от 1 до 2000.");
            }

        } while (!isValidInput || guess < 1 || guess > 2000);

        return guess;
    }

    private void AskForAnotherGame()
    {
        Console.Write("Хотите сыграть еще раз? (y/n): ");
        string response = Console.ReadLine().ToLower();

        if (response == "y")
        {
            PlayGame();
        }
        else
        {
            Console.WriteLine("Спасибо за игру. До свидания!");
        }
    }
}

class Program
{
    static void Main()
    {
        NumberGuesser game = new NumberGuesser();
        game.PlayGame();
    }
}
