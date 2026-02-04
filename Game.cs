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
