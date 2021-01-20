using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game Configuration Data - Sets of data
    const string menuHint = "You may type menu at any time";
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "police", "prisoner", "holster", "arrest", "attack", "officer", "handcuffs" };
    string[] level3Passwords = { "help", "interstellar","black hole", "ignition" };

    // Game State - Variables and stuff
    int level;
    enum Screen { MainMenu, Pass, Win };
    Screen currentScreen = Screen.MainMenu;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void Update()
    {
        
    }

    // Menu
    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Avaible server´s for hacking:");
        Terminal.WriteLine("Type ´1´ for the local library");
        Terminal.WriteLine("Type ´2´ for the police station");
        Terminal.WriteLine("Type ´3´ for the NASA");
        Terminal.WriteLine("Enter your selection: ");
    }

    // User input
    void OnUserInput(string input)
    {
        if (input == "menu") // we can always go to the menu
        {
            ShowMainMenu();
        }
        else if (input == "quit")
        {
            Terminal.WriteLine("If on the web, please close the tab");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Pass)
        {
            RunPassCheck(input);
        }
    }

    // Just a basic menu - level select and overflow protek
    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPass();
        }
        else if (input == "007") // easter egg
        {
            Terminal.WriteLine("Welcome back Mr.Bond!");
        }
        else                    // overflow protek
        {
            Terminal.WriteLine("Please select a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    //Start Game
    void AskForPass()
    {
        currentScreen = Screen.Pass;
        Terminal.ClearScreen();
        SetRandomPass();
        Terminal.WriteLine("Enter you password, hint: " + password.Anagram());
    }

    void SetRandomPass()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    //Check Pass
    void RunPassCheck(string input)
    {

        if (level == 1)
        {
            if (input == password)
            {
                DisplayWinScreen();
            }
            else
            {
                AskForPass();
            }
        }
        if (level == 2)
        {
            if (input == password)
            {
                DisplayWinScreen();
            }
            else
            {
                AskForPass();
            }
        }
        if (level == 3)
        {
            if (input == password)
            {
                DisplayWinScreen();
            }
            else
            {
                AskForPass();
            }
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine("Type ´menu´ to go back ");
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
            Terminal.WriteLine("Have a book");
            Terminal.WriteLine(@"
    ________
   /      //
  /      //
 /______//
(______(/
"               );
                break;
            case 2:
            Terminal.WriteLine("Fancy a drive?");
            Terminal.WriteLine(@"
   -           __
 --          ~( @\   \
---   _________]_[__/_>________
     /  ____ \ <>     |  ____  \
    =\_/ __ \_\_______|_/ __ \__D
________(__)_____________(__)____
");
                break;
            case 3:
                Terminal.WriteLine("What secret would you like to know?");
                Terminal.WriteLine(@"
 _ __   __ _ ___  __ _ 
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___/\__,_|
                       
");
                break;
            default:
                Debug.LogError("Invalid level");
                break;

        }
        
    }
}