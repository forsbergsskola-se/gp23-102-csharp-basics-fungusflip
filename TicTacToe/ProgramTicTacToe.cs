using System.Runtime.CompilerServices;

bool player1 = true;

bool firstRound = true;

bool winCon = false;

char player1Input = '0'; 

char player2Input = '0';

char[][] Board = new char[][]
{
    new char[] { '1', '2', '3' },
    new char[] { '4', '5', '6' },
    new char[] { '7', '8', '9' }
};


//Whole ass Code Block
while (winCon == false)
{

    //Writes out board
    foreach (char[] row1 in Board)
    {
        Console.WriteLine("");
        foreach (char slot in row1)
        {
            Console.Write("[" + slot + "]");
        }
        
    }
    
    
    //Picks Piece for Player1 and "
    if (firstRound == true)
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Player 1, What do you want as your PlayerPiece?");
    
        player1Input = ' '; 
    
        while (true) 
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            player1Input = keyInfo.KeyChar;

            if (char.IsLetter(player1Input))
            {
                break;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid input. Please enter a valid symbol (e.g., X or O).");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Now, Player 2. What do you want as your PlayerPiece?");

        player2Input = ' ';

        while (true) 
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            player2Input = keyInfo.KeyChar;

            if (char.IsLetter(player2Input))
            {
                break; 
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid input. Please enter a valid symbol (e.g., X or O).");
            }
        }

        firstRound = !firstRound;
    }

    
    
    
    //Ask player for input
    Console.WriteLine("");
    Console.WriteLine($"Where do you want to put your piece {(player1 ? "Player 1" : "Player 2")}?"); 
    
    
    
    //Handle Input for Player
    Input:
    var inputPosition = Console.ReadLine();
    if (int.TryParse(inputPosition, out var position) && 10 > position)
    {
    }
    else
    {
        Console.WriteLine("Invalid Input. Most be a Number between 1-9");
        goto Input;
    }

    
    // Determine the row and column from the position
    int row = (position - 1) / 3;
    int col = (position - 1) % 3;

    //No putting in same place
    if (Board[row][col] != player1Input && Board[row][col] != player2Input)
    {
        // Only allow placement if the cell is not already taken
        Board[row][col] = player1 ? player1Input : player2Input;
        player1 = !player1; // Switch players
    }
    else
    {
        Console.WriteLine("Invalid move. The position is already occupied.");
    }

    if (CheckWinCon(player1Input) == true)
    {
        Console.WriteLine("");
        Console.WriteLine("Player 1 Wins");
        winCon = true;
    }
    else if (CheckWinCon(player2Input) == true)
    {
        Console.WriteLine("");
        Console.WriteLine("Player 2 Wins");
        winCon = true;
    }
}

// CheckWinCon
bool CheckWinCon(char player)
{
    // Check rows, columns, and diagonals
    for (int i = 0; i < 3; i++)
    {
        if (Board[i][0] == player && Board[i][1] == player && Board[i][2] == player)
            return true;

        if (Board[0][i] == player && Board[1][i] == player && Board[2][i] == player)
            return true;
    }

    if (Board[0][0] == player && Board[1][1] == player && Board[2][2] == player)
        return true;

    if (Board[0][2] == player && Board[1][1] == player && Board[2][0] == player)
        return true;

    return false;
}