
bool play = false;
bool ValidNumOfBombs = false;
bool ValidMove = false;
string WannaPlay;
int ChosenNumberOfBombs = 0;
int PlayerCoord;
string move;
string newcoord;
int PlayerCoordRow = 0;
int PlayerCoordColumn = 0;
int TestPlayerCoordRow = 0;
int TestPlayerCoordColumn = 0;
string Contents = "empty";


Console.WriteLine("Do you want to play the bomb game? - Y for yes N for no"); // asks the user if they want to play 
WannaPlay = Console.ReadLine();  // creates a variable to store their answer to the question about if they want to play 

if (WannaPlay == "Y") 
{
    play = true;

    string[,] grid = new string[10, 10]; // creates a 2d array called grid
    for (int i = 0; i < 10 * 10; i++) grid[i % 10, i / 10] = "empty"; // loop I found from stack overflow which changes every item in the 2d array to "empty" https://stackoverflow.com/questions/9894084/2d-array-set-all-values-to-specific-value

    grid[1, 1] = "start";
    grid[9, 9] = "finish";

    while (ValidNumOfBombs == false) // this is the first while loop and is used to check that player has  put in a reasonable amount of bombs within the game so it is playable but also not really easy
    {
        Console.WriteLine("How many bombs would you like in the game - between 5-20"); // asks them how many bombs they want in the game
        ChosenNumberOfBombs = int.Parse(Console.ReadLine()); // creates a variable to store how many bombs the user wants in their game

        if (ChosenNumberOfBombs >= 5 && ChosenNumberOfBombs <= 20) // the if statement make sure that the amount of bombs that the user wants is reasonable
        {
            ValidNumOfBombs = true;
        }
        else
        {
            Console.WriteLine("that is an invalid amount of bombs");
        }
    }
    for (int i = 1; i <= ChosenNumberOfBombs; i = i + 1) // this for loop changes (number of  bombs the user has chose) random indexes within the array to "bomb" to signify that there is a bomb
    {
        Random rnd = new Random(); // got this of stack overflow https://stackoverflow.com/questions/33080397/how-to-pick-a-random-place-from-a-2d-array 
        int row = rnd.Next(0, 10);  // makes a random number between 0 and 10 for the row of the bombs
        int column = rnd.Next(0, 10); // makes a random number between 0 and 10 for the column of the bombs


        if (grid[row, column] == "empty")
        {
            grid[row, column] = "bomb";
        }
        else
        {
            i = i - 1;
        }

    }
  
    while (play == true)  // this is the main while loop that keeps the game playing and t stop when they die or finish
    {
        while (ValidMove == false) // this is the third while loop and is used to make sure that the player is entering valid moves so that the game actually plays, if it is an invalid move the loop repeats to ask them again
        {

            Console.WriteLine("your current coordinates are [{0},{1}]", PlayerCoordRow, PlayerCoordColumn); // displays the user's current co-ordinates so that they kno where they are 
            Console.WriteLine("which way do you want go? - N for north E for east S for south W for west"); // asks them which way they want to go
            move = Console.ReadLine(); // creates a variable to store their move


            if (move == "N")
            {
                TestPlayerCoordRow = PlayerCoordRow - 1; // this moves the players location up 1 row
            }
            else if (move == "S")
            {
                TestPlayerCoordRow = PlayerCoordRow + 1; // this moves the players location down 1 row
            }
            else if (move == "E")
            {
                TestPlayerCoordColumn = PlayerCoordColumn + 1; // this moves the players location right 1 column

            }
            else if (move == "W")
            {
                TestPlayerCoordColumn = PlayerCoordColumn - 1; // this moves the players location left 1 column
            }
            else
            {
                Console.WriteLine("invalid option"); // if the player types in anything over than what is used to change direction then it says invalid move
            }

            try // this will try to do an action in this case the action is trying to access a point in the array
            {
                Contents = grid[TestPlayerCoordRow, TestPlayerCoordColumn];
                PlayerCoordRow = TestPlayerCoordRow;
                PlayerCoordColumn = TestPlayerCoordColumn;
                ValidMove = true;
            }

            catch // if it is unabe to access a point in the array instead of displaying an error message and messing up the code the catch function will stop it from happening and do whatever code is put in there
            {
                Console.WriteLine("invalid move");
                TestPlayerCoordRow = PlayerCoordRow;
                TestPlayerCoordColumn = PlayerCoordColumn;

                // Console.WriteLine(TestPlayerCoordRow); // debugging
                // Console.WriteLine(TestPlayerCoordColumn);  // debugging


            }

        }
        // check bomb

        if (Contents == "bomb") // if the point in the array that the player is in is a bomb it will say that they have died and stop the main while loop which will stop the program
        {
            Console.WriteLine("There was a bomb you have died");
            play = false;
        }
        if (Contents == "finish") // check finsih
        {
            Console.WriteLine("You have made it to the finish - Congratulations"); // if the point in the array that the player is in is finish it will say that they have won and stop the main while loop which will stop the program
            play = false;
        }
        ValidMove = false; // this reset valid move so the loop starts again
    }

}
else
{
    Console.WriteLine("sorry you dont want to play"); // incase the player says no to the question of if they want to play the game this code will just say that they are sorry that they dont want to play the game and nothing else happens
}