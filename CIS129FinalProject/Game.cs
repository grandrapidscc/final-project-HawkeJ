using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizert_Remaster {
    class Game {
        private Dungeon dungeon;
        private Wizert wizert;

        public Game() {

        }

        private void Initialize() {
            dungeon = new Dungeon();
            wizert = new Wizert(0);
        }

        private void ResetVariables(bool resetRooms) {
            dungeon.ResetDungeon(resetRooms);
            wizert = new Wizert(0);
        }

        public void Run() {
            Initialize();

            do {
                Console.WriteLine();

                while (Wizert.IsAlive && !Wizert.HasWon) {
                    Update();
                }
            } while (WillRestart());
        }

        private void Update() {
            ExecuteWizertTurn();
        }

        private void ExecuteWizertTurn() {
            if(Wizert.IsDead)
                return;

            string playerInput;
            bool willReprompt = false;
            
            do
            {
                Console.Write("North, East, South, or West?");
                playerInput = Console.ReadLine();

                switch (playerInput.ToLower())
                {

                    case "n":
                        wizert.Move();
                        wizert.CheckFor(enemy);
                        willReprompt = false;
                        break;
                    case "e":
                        wizert.Move();
                        wizert.CheckFor(enemy);
                        willReprompt = false;
                        break;
                    case "s":
                        wizert.Move();
                        wizert.CheckFor(enemy);
                        willReprompt = false;
                        break;
                    case "w":
                        wizert.Move();
                        wizert.CheckFor(enemy);
                        willReprompt = false;
                        break;
                    default:
                        Console.WriteLine("Invalid command\n");
                        willReprompt = true;
                        break;
                }

                Console.WriteLine();

            } while (willReprompt);
        }

        private bool WillRestart()
        {
            bool invalidResponse = false;
            bool willRestart = false;
        
            string endingText = Wizert.HasWon ? "Congratulations! You escaped!" : "Oh no! You died!";
            Console.WriteLine(endingText);
            do
            {
                Console.Write("Play Again? (y/n):");
                string restartResponse = Console.ReadLine();
                switch (restartResponse.ToLower())
                {
                    case "y":
                        willRestart = true;
                        invalidResponse = false;
                        break;
                    case "n":
                        willRestart = false;
                        invalidResponse = false;
                        break;
                    default:
                        invalidResponse = true;
                        break;
                }

            } while (invalidResponse);
        }
    }
}