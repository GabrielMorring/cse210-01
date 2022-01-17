// See https://aka.ms/new-console-template for more information


static Boolean checkWin(List<int> Tiles)

{
    if (Tiles.Contains(1) && Tiles.Contains(2) && Tiles.Contains(3))
    {
        return true;
    }
    else if (Tiles.Contains(4) && Tiles.Contains(5) && Tiles.Contains(6))
    {
        return true;
    }
    else if (Tiles.Contains(7) && Tiles.Contains(8) && Tiles.Contains(9))
    {
        return true;
    }
    else if (Tiles.Contains(1) && Tiles.Contains(4) && Tiles.Contains(7))
    {
        return true;
    }
    else if (Tiles.Contains(2) && Tiles.Contains(5) && Tiles.Contains(8))
    {
        return true;
    }
    else if (Tiles.Contains(3) && Tiles.Contains(6) && Tiles.Contains(9))
    {
        return true;
    }
    else if (Tiles.Contains(1) && Tiles.Contains(5) && Tiles.Contains(9))
    {
        return true;
    }
    else if (Tiles.Contains(3) && Tiles.Contains(5) && Tiles.Contains(7))
    {
        return true;
    }
    else
    {
        return false;
    }
}

static Boolean checkTie(List<int> Tiles)
{
    if (Tiles.Contains(1) && Tiles.Contains(2) && Tiles.Contains(3) && Tiles.Contains(4) && Tiles.Contains(5) && Tiles.Contains(6) && Tiles.Contains(7) && Tiles.Contains(8) && Tiles.Contains(9))
    {
        return true;
    }
    else 
    {
        return false;
    }
}

static string changePlayer(string player)
{
    if (player == "X")
    {
        return "O";
    }
    else if (player == "O")
    {
        return "X";
    }
    else 
    {
        return "";
    }
}

static void playGame()
{
    List<string> board = new List<string>() {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
    List<int> xTiles = new List<int>();
    List<int> oTiles = new List<int>();
    List<int> totalTiles = new List<int>();
    string currentPlayer = "X";
    string winner = "";
    Boolean prevCheck = false;
    
    Console.WriteLine();

    while (prevCheck == false)
    {        
        Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
        Console.WriteLine("_________");
        Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
        Console.WriteLine("_________");
        Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");
        

        Console.WriteLine();
        Console.WriteLine($"Player {currentPlayer}");
        Console.WriteLine("Enter the number of the place you want to put a tile.");
        
        int newTile = int.Parse(Console.ReadLine());

        int tilePosition = newTile - 1;

        totalTiles.Add(newTile);

        if (currentPlayer == "X")
        {
            xTiles.Add(newTile);
            if (checkWin(xTiles))
            {
                winner = "X";
            }
            board[tilePosition] = "X";
            prevCheck = checkWin(xTiles);
        }
        else if (currentPlayer == "O")
        {
            oTiles.Add(newTile);
            if (checkWin(oTiles))
            {
                winner = "O";
            }
            board[tilePosition] = "O";
            prevCheck = checkWin(oTiles);
        }

        if (winner == "")
        {
            prevCheck = checkTie(totalTiles);
        }

        

        currentPlayer = changePlayer(currentPlayer);  
    
    }
   
    Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
    Console.WriteLine("_________");
    Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
    Console.WriteLine("_________");
    Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");
    
    if (winner == "")
    {
        Console.WriteLine();
        Console.WriteLine("You tied");
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine($"Congradulations, You win player {winner}!");
        Console.WriteLine();
    }
}

static void main()
{
    string action = "a";
    Console.WriteLine("Welcome to Tic-Tac-Toe");
    while (action == "a")
    {
        playGame();
        Console.WriteLine("Would you like to:");
        Console.WriteLine("a) play again");
        Console.WriteLine("b) quit");
        action = Console.ReadLine();
    }
}

main();