using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizert_Throwback
{
    class Game
    {
        private Dungeon dungeon;
        private Wizert wizert;

        public Game()
        {
        }

       private void Initialize()
        {
            dungeon = new Dungeon();
            wizert = new Wizert(dungeon.InitialWizertRoom);

        }

        private void ResetVariables(bool resetRooms)
        {
            dungeon.ResetDungeon(resetRooms);
            wizert = new Wizert(dungeon.InitialWizertRoom);
        }

        public void Run()
        {
            Initialize();

            do
            {
                wizert.CheckForItems();
                Console.WriteLine();
                while (Wizert.IsAlive && !Wizert.HasWon)
                {
                    Update();
                }

            } while (WillRestart());

        }

        private void Update()
        {
            ExecuteWizertTurn();
        }

        private void ExecuteWizertTurn()
        {
            if (Wizert.IsDead)
                return;

            string wizertInput;
            bool willReprompt = false;

            do
            {
                Console.WriteLine("The darkness feels suffocating...");
                wizert.ListConnectedRooms();
                Console.Write("Will you (p)ress on, Wizert? Or (g)ive up? ");
                wizertInput = Console.ReadLine();

                switch (wizertInput.ToLower())
                {
                    case "p":
                        wizert.Move();
                        wizert.CheckForItems();
                        willReprompt = false;
                        break;
                    case "g":
                        Console.WriteLine("Until next time...");
                        Environment.Exit(0);
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
            bool resetItemLocations = false;

            string endingText = Wizert.HasWon ? "You've made it out alive!" : "Game Over";
            Console.WriteLine(endingText);
            do
            {
                Console.Write("Play again? (y/n): ");
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

            do
            {
                Console.Write("Reset door location (y/n):");
                string restartResponse = Console.ReadLine();
                switch (restartResponse.ToLower())
                {
                    case "y":
                        invalidResponse = false;
                        resetItemLocations = true;
                        break;
                    case "n":
                        invalidResponse = false;
                        resetItemLocations = false;
                        break;
                    default:
                        invalidResponse = true;
                        break;
                }

            } while (invalidResponse);

            ResetVariables(resetItemLocations);

            return willRestart;
        }
    }

    static class GameConstants
    {
        public const int WORLD_SIZE = 25;
        public static readonly NoItems NO_ITEMS = new NoItems();
    }
}