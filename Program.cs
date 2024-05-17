// Start time 18:40 17/05/2024
// Finish time 20:18 17/05/2024

// Docs used:
// https://www.w3schools.com/cs/cs_user_input.php
// https://www.geeksforgeeks.org/c-sharp-dictionary-with-examples/
// https://stackoverflow.com/questions/13230414/case-insensitive-access-for-generic-dictionary
// https://bigbangtheory.fandom.com/wiki/Rock,_Paper,_Scissors,_Lizard,_Spock

List<string> options = new List<string>()
{
    {"Rock"},
    {"Paper"},
    {"Scissors"},
    {"Lizard"},
    {"Spock" }
};

Dictionary<string, Dictionary<string, string>> possibleOutcomes = new(StringComparer.OrdinalIgnoreCase)
    {
        { "Rock", new Dictionary<string, string> {
            { "Scissors", "Rock beats Scissors!" },
            { "Paper", "Paper covers Rock!" },
            { "Lizard", "Rock crushes Lizard!" }, 
            { "Spock", "Spock vaporises Rock!" } }
        },
        { "Paper", new Dictionary<string, string> {
            { "Rock", "Paper covers Rock!" },
            { "Scissors", "Scissors cuts Paper!" },
            { "Lizard", "Lizard eats Paper!" },
            { "Spock", "Paper disproves Spock" } } 
        },
        { "Scissors", new Dictionary<string, string> {
            { "Paper", "Scissors cuts Paper!" },
            { "Rock", "Rock beats Scissors!" },
            { "Lizard", "Scissors decapitates Lizard!" },
            { "Spock", "Spock smashes Scissors!" } }
        },
        { "Lizard", new Dictionary<string, string> {
            { "Spock", "Lizard poisons Spock!" },
            { "Paper", "Lizard eats Paper!" },
            { "Rock", "Rock crushes Lizard!" } } },
        { "Spock", new Dictionary<string, string> {
            { "Lizard", "Lizard poisons Spock!" },
            { "Scissors", "Spock smashes Scissors!" },
            { "Paper", "Paper disproves Spock" },
            { "Rock", "Spock vaporises Rock!" } 
        }
}};

Random random = new Random();

string playerChoice;
string previousPlayerChoice = string.Empty;

int numberOfTimesComputerHasMiraculouslyChosenPlayerChoice = 0;
bool removeCopyCat = false;

do
{
    Console.WriteLine("Rock, Paper, Scissors, Lizard, Spock?");
    Console.WriteLine($"Player selected {playerChoice = Console.ReadLine() ?? string.Empty}");

    // Early exit if it's not a valid value
    if (!possibleOutcomes.ContainsKey(playerChoice))
    {
        Console.WriteLine("An interesting proposition, but one for another day!");
        break;
    }

    string computerChoice = options.ElementAt(random.Next(0, options.Count)); // Select from the options list by a random index
    Console.WriteLine($"Computer 1 selected: {computerChoice}");

    if (!removeCopyCat)
    {
        Console.WriteLine($"Computer 2 (also known as copy cat) just so happened to select: {(string.IsNullOrEmpty(previousPlayerChoice) ? playerChoice : previousPlayerChoice)}");
        numberOfTimesComputerHasMiraculouslyChosenPlayerChoice++;

        switch (numberOfTimesComputerHasMiraculouslyChosenPlayerChoice)
        {
            case 1:
                MessageFromTheCommentaryBox($"Bazinga! Looks like Computer 2 (also known as copy cat) " +
                    $"went for {playerChoice} there!");
                break;
            case 2:
                MessageFromTheCommentaryBox($"Computer 2 (also known as copy cat) " +
                    $"once again goes for {playerChoice}.");
                break;
            case 3:
                MessageFromTheCommentaryBox($"Player and Computer 2 (also known as copy cat) " +
                    $"goes for {playerChoice}. I don't know what it is folks, but there's something odd about this!");
                break;
            case 4:
                MessageFromTheCommentaryBox($"Computer 2 goes for" +
                    $"{playerChoice}. I'm not sure if you saw it there at home, but the referee is quite literally" +
                    $" starting to raise their eyebrows!");
                break;
            case 5:
                MessageFromTheCommentaryBox($"I can't believe it! The referee has removed Computer 2 from the game! Clearly something is amiss here!");
                removeCopyCat = true;
                break;
        }
    }
    previousPlayerChoice = playerChoice;

    DetermineRound(playerChoice, computerChoice);
}
while (options.Contains(playerChoice ?? string.Empty, StringComparer.OrdinalIgnoreCase)); // Carry on as long as the values are as expected

void DetermineRound(string playerChoice, string computerChoice)
{
    if (playerChoice.ToLower() == computerChoice.ToLower())
    {
        Console.WriteLine("Draw!");
        return;
    }
    Console.WriteLine(possibleOutcomes[playerChoice][computerChoice]);
}

void MessageFromTheCommentaryBox(string message) => Console.WriteLine($"Rock, Paper Scissors World Championship Commentary Team (sponsored by OEM): {message}");