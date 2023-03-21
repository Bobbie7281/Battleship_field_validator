using Battleship_Field_Tests;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace Battleship_field_validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] field = new int[10, 10]
                     {{1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                      {1, 0, 0, 1, 1, 1, 0, 0, 1, 1},
                      {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                      {1, 0, 0, 0, 0, 0, 1, 0, 0, 0},
                      {0, 0, 0, 0, 1, 0, 1, 0, 0, 0},
                      {0, 1, 1, 0, 0, 0, 1, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 1, 0, 0, 0, 0, 1, 0},
                      {1, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                      {0, 0, 0, 0, 0, 1, 0, 0, 0, 0}};

            List<int> ShipSizes = new List<int>() { 4, 3, 2, 1 };
            List<int> NumberOfShips = new List<int> { 1, 2, 3, 4 };
            int totalShips;
            string allShipsLocatedMsg = "All ships located on the board and properly placed.";
            string edgeContactDetectedMsg = "Some ships have their edges touching. Check the board and try again";
            string cornerContactDetectedMsg = "Some ships have their corners touching. Check the board and try again";

            var obj = new Battleship_Field_Validation();
            obj.Field = field;

            bool edgeContact = false;
            bool cornerContact = false;

            int cellsOccupied = GetTheNumberOfSlotsOccupied();

            if (cellsOccupied == 20)
            {
                edgeContact = CheckForEdgeContact();

                if (edgeContact)
                {
                    Console.WriteLine(edgeContactDetectedMsg);
                }
                else
                {
                    cornerContact = CheckForCornerContact();

                    if (!cornerContact)
                    {
                        Console.WriteLine(allShipsLocatedMsg);
                    }
                    else
                    {
                        Console.WriteLine(cornerContactDetectedMsg);
                    }
                }
            }
            else
            {
                Console.WriteLine("Not all ships detected on the board");
            }

            int GetTheNumberOfSlotsOccupied()
            {
                return obj.GetTotalNumberOfOnes();
            }

            bool CheckForEdgeContact()
            {
                bool edgeContactDeteced = false;

                for (int i = 0; i < ShipSizes.Count; i++)
                {
                    totalShips = 0;
                    totalShips = obj.GetTotalShipsAccordingToSize(ShipSizes[i]);

                    switch (i)
                    {
                        case 0:
                            if (totalShips != NumberOfShips[i]) { edgeContactDeteced = true; }
                            break;
                        case 1:
                            if (totalShips != NumberOfShips[i]) { edgeContactDeteced = true; }
                            break;
                        case 2:
                            if (totalShips != NumberOfShips[i]) { edgeContactDeteced = true; }
                            break;
                        case 3:
                            if (totalShips != NumberOfShips[i]) { edgeContactDeteced = true; }
                            break;
                    }
                    if (edgeContactDeteced) { break; }
                }
                return edgeContactDeteced;
            }
            bool CheckForCornerContact()
            {
                bool cornerContactDeteced = false;

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (field[i, j] == 1)
                        {
                            cornerContactDeteced = obj.CheckForDiagonalContacts(i, j);
                        }
                        if (cornerContactDeteced) { break; }
                    }
                }
                return cornerContactDeteced;
            }
        }
    }
}
