// See https://aka.ms/new-console-template for more information

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Rock, paper, scissors game");
        
        bool keepPlaying = true;
        while (keepPlaying) {
            var userChoice = SelectChoice();

            Console.WriteLine($"You chose {userChoice} ({GetChoiceTitle(userChoice[0])})");

            var oponentChoice = GetOpponentChoice();
            Console.WriteLine($"Opponent chose {oponentChoice} ({GetChoiceTitle(oponentChoice)})");

            GetWinner(userChoice[0], oponentChoice);

            keepPlaying = AskPlayAgain();
        }

        Console.WriteLine("See you next time!");
        
    }

    private static string GetChoiceTitle(Char choice) {
        var options = new { R = "Rock", P = "Paper", S = "Scissors" };

        switch (choice) {
            case 'R':
                return options.R;
            case 'P':
                return options.P;
            case 'S':
                return options.S;
            default:
                return "Invalid choice";
        }
    }

    static string SelectChoice() {
        Console.WriteLine("\nEnter your choice (R = Rock, P = Paper, S = scissors): ");
        var userChoice = Console.ReadLine();

        if (userChoice == null) {
            Console.WriteLine("Invalid input");
            userChoice = SelectChoice().ToUpper();
        }

        userChoice = userChoice.ToUpper();

        if( userChoice != "R" && userChoice != "P" && userChoice != "S") {
            Console.WriteLine("Invalid input. Select R, P or S");
            userChoice = SelectChoice().ToUpper();
        }

        return userChoice;
    }

    static char GetOpponentChoice() {
        char[] options = ['R', 'P', 'S'];
        Random random = new Random();

        int randomIndex = random.Next(0, options.Length);

        return options[randomIndex];
    }

    static void GetWinner(char userChoice, char computerChoice ) {
        if( userChoice == computerChoice ) {
            Console.WriteLine("It is a tied");
            return;
        }

        switch(userChoice ) {
            case 'R':
                if( computerChoice == 'P' ) {
                    Console.WriteLine("You Lost :(");
                    return;
                }
                if( computerChoice == 'S' ) {
                    Console.WriteLine("Congratulations, You Won!");
                    return;
                }
                break;
            
            case 'S':
                if( computerChoice == 'R' ) {
                    Console.WriteLine("You Lost :(");
                    return;
                }
                if( computerChoice == 'P' ) {
                    Console.WriteLine("Congratulations, You Won!");
                    return;
                }
                break;
            case 'P':
                if( computerChoice == 'S' ) {
                    Console.WriteLine("You Lost :(");
                    return;
                }
                if( computerChoice == 'R' ) {
                    Console.WriteLine("Congratulations, You Won!");
                    return;
                }
                break;
        }
    }

    static bool AskPlayAgain() {
        Console.WriteLine("Would you like to play again? (y/n)");
        var answer = Console.ReadLine();

        if( answer == null || answer == "") {
            return AskPlayAgain();
        }

        char shortAnswer = answer.ToUpper()[0];

        if( shortAnswer == 'Y' ) return true;
        if( shortAnswer == 'N' ) return false;

        return AskPlayAgain();
    }
}
