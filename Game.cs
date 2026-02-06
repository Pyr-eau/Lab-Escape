using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventure
{
    internal class Game
    {
        // game attributes
        public List<string> INV;
        //Static Items
        public const string SCALPEL = "Scalpel";
        public const string REVOLVER = "Revolver";
        public const string CROWBAR = "Crowbar";
        public const string LVL5CARD = "Level 5 Access Card";
        public const string LVL4Card = "Level 4 Access Card";
        public const string LVL3CARD = "Level 3 Access Card";
        public const string APPLE = "Uncontaminated Apple";
        public const string NOTEBOOK = "Notebook";
        public const string HAZMAT = "Hazmat Suit";

        public void NewGame()
        {
            INV = new List<string>();
            Lab19();
        }
        //Start room
        public void Lab19()
            {
            string name = "Lab Room 19";
            string desc = "Your designated lab room. Your lab partners are collapsed\n" +
                            "around the central operating table with blood pooling from\n" +
                            "their mouthes. Lime-green gas begins to fill the room\n"+
                            "You are alone.";
            List<string> actions = new List<string>
            {
                "Use the door labled 'exit'",
                "Search the room",
                "Search your partners' pockets",
                "Check pockets"
            };
            //draw room
            DrawRoom(name, desc, actions);
            int playerchoice = GetPlayerChoice(actions.Count);
            Console.Clear();

            switch (playerchoice)
            {
                case 1: DrawAction("You leave Lab Room 19 and enter the hallway");
                    Hallway();
                    break;
                case 2: AddtoINV(APPLE);
                        Lab19();
                        break;
                case 3:
                    Death("Greed draws you to the pockets of your dead colleagues. Empty.\n" +
                        "The gas inside the room begins to fill your lungs until you're\n" +
                        "on the floor as blood exits your mouth, knocking Death's door.\n" +
                        "You have died. ");
                        break;
                case 4:
                    ShowINV();
                     Lab19();
                    break;
                     

            }

            }
          public void Hallway() 
  {
      string name = "Hallway";
      string desc = "The facility's hallway, you see doors line the walls, Lab Room 18 and the storage room\n" +
                      "stand out to you, the rest of the doors have runny, red liquid running underneath themselves,\n" +
                      "at the end of the hallway lie the elevator and stairs which could take you up and down the facility. It's quiet.\n" +
                      "You are alone.";
      List<string> actions = new List<string>
      {
          "Go back to Lab Room 19",
          "Use the door to Lab Room 18",
          "Use the door to Storage Room",
          "Use the elevator",
          "Check pockets"
      };
      DrawRoom(name, desc, actions);
      int playerChoice = GetPlayerChoice(actions.Count);
      Console.Clear();

      switch (playerChoice) 
      {
          case 1:
              DrawAction("You turn towards your labroom door, but you peek the gas seeping through underneath, it's best not to reenter.");
              Hallway();
              break;
          case 2: DrawAction("You enter Lab Room 18");
              //draw room 18
              break;
          case 3: DrawAction("You enter the storage room");
              //draw storage room
              break;
          case 4: DrawAction("You enter the elevator");
              //draw elevator
              if (INV.Contains(LVL3CARD)) {
                  DrawAction("You swipe a Level 2 access card into the lift\n" +
                  "the button to the top floor is out of order, but you should make it from the floor above."); }
              else {
                  DrawAlert("The elevator has an ID scanner, you must've left yours in your labroom.");
                      Hallway(); }
              break;
          case 5: DrawAction("You scan the hallway, all you see is more hallway.");
              Hallway();
                  break;
          case 6: ShowINV();
              Hallway();
              break;
      }
  }
        public void DrawRoom(string name, string desc, List<string> actions)
        {
            Cn();
            Console.Write("Location: ");
            White();
            Console.WriteLine(name);
            Console.WriteLine(desc);
            Console.WriteLine();
            Yellow();
            Console.WriteLine("actions:");
            White();
            for (int i = 1; i <= actions.Count; i++)
                Console.WriteLine(i + "_" + actions[i - 1]);
            Console.WriteLine();
        }

        public void AddtoINV(string item)
        { if (INV.Contains(item)) DrawAction("You search but find nothing but dust.");
            else { INV.Add(item);
                DrawAction("Got " + item); } }

        //display INV
        public void ShowINV()
        {
            if (INV.Count < 1) DrawAlert("Your pockets are empty...");
            else
            {
                Cn();
                Console.WriteLine("====INV====");
                White();
                foreach (string item in INV)
                    Console.WriteLine(item);
                Console.WriteLine();
            }
        }
        //Shortcut colors
        public void White() { Console.ForegroundColor = ConsoleColor.White; }
        public void Yellow() { Console.ForegroundColor = ConsoleColor.Yellow; }
        public void Green() { Console.ForegroundColor = ConsoleColor.Green; }
        public void Red() { Console.ForegroundColor = ConsoleColor.DarkRed; }
        public void Cn() { Console.ForegroundColor = ConsoleColor.Cyan; }

        public int GetPlayerChoice(int numberofchoices)
        {
            Cn();
            Console.WriteLine("===== What is your choice? =====");
            Console.WriteLine("Enter Choice (1-" + numberofchoices + "): ");
            //get choice, check if int is >0
            White();
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= numberofchoices)
            { return choice; }
            else
            {
                DrawAlert("Can't accept choice");
                return GetPlayerChoice(numberofchoices);
            }
        }

                public void Death(string reason)
                {
                    //death screen
                    Red();
                    Console.WriteLine("======================");
                    Console.WriteLine("=======YOU DIED=======");
                    Console.WriteLine("======================");
                    White();
                    Console.WriteLine();
                    Console.WriteLine(reason);
                    Console.WriteLine();
                }
        public void Win(string reason)
        {
            Console.WriteLine("======================");
            Console.WriteLine("=========WIN==========");
            Console.WriteLine("======================");
            White();
            Console.WriteLine();
            Console.WriteLine(reason);
            Console.WriteLine();
        }
        public void DrawAlert(string error)
        {
            Red();
            Console.WriteLine("====="+ error + "=====");
            White();
            Console.ReadLine();
        }
        public void DrawAction(string action)
        {
            Yellow();
            Console.WriteLine("=====" + action + "=====");
            White();
            Console.ReadLine();
        }

    }
}

