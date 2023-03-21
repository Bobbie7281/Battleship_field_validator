namespace Battleship_Field_Tests
{
    public class Battleship_Field_Validation
    {
        private int[,] field = new int[0, 0];
        public int[,] Field
        {
            set { field = value; }
            get { return field; }
        }

        public int GetTotalNumberOfOnes()
        {
            int cellsOccupied = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (field[i, j] == 1)
                    {
                        cellsOccupied++;
                    }
                }
            }
            return cellsOccupied;
        }

        public int GetTotalShipsAccordingToSize(int shipSize)
        {
            int hCounter = 0; //Horizontal Count.
            int vCounter = 0; //Vertical Count.
            int totalShips = 0; //Total Ships encountered.
            bool submarine = false;

            if (shipSize > 1)
            {
                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        //Horizontal Check
                        if (field[x, y] == 1)
                        {
                            hCounter++; //hCounter increments by 1 everytime a 1 is encounter on the field
                        }
                        else
                        {
                            //If a 0 is encountered, hCounter will be compared to shipSize and if both sizes matches, totalShips will be incremented by 1.
                            if (hCounter == shipSize)
                            {
                                totalShips++;
                                hCounter = 0;
                            }
                            hCounter = 0; //hCounter will be reseted to 0 everytime the chain of one's is broken. 
                        }
                        //Vertical Check
                        if (field[y, x] == 1)
                        {
                            vCounter++; //vCounter increments by 1 everytime a 1 is encounter on the field
                        }
                        else
                        {
                            //If a 0 is encountered, vCounter will be compared to shipSize and if both sizes matches, totalShips will be incremented by 1.
                            if (vCounter == shipSize)
                            {
                                totalShips++;
                                vCounter = 0;
                            }
                            vCounter = 0;//vCounter will be reseted to 0 everytime the chain of one's is broken.
                        }
                    }
                    if (hCounter == shipSize || vCounter == shipSize)
                    {
                        totalShips++;
                        hCounter = 0;
                        vCounter = 0;
                    }
                    else
                    {
                        hCounter = 0;
                        vCounter = 0;
                    }
                }
            }
            else
            {
                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        if (field[x, y] == 1)
                        {
                            if (submarine = CheckForSubmarines(x, y))
                            {
                                totalShips++;
                            }
                        }
                    }
                }
            }
            return totalShips;
        }

        public bool CheckForSubmarines(int row, int col)//Submarines will only occupy one cell.
        {
            bool submarine = true;
            bool xAxis = true;
            bool yAxis = false;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    while (xAxis)
                    {
                        xAxis = false;
                        if (row < 9)
                        {
                            if (field[row + j, col] == 1)
                            {
                                submarine = false;
                                break;
                            }
                        }
                        if (row > 0)
                        {
                            if (field[row - j, col] == 1)
                            {
                                submarine = false;
                                break;
                            }
                        }
                    }
                    while (yAxis)
                    {
                        yAxis = false;
                        if (col < 9)
                        {
                            if (field[row, col + j] == 1)
                            {
                                submarine = false;
                                break;
                            }
                        }
                        if (col > 0)
                        {
                            if (field[row, col - j] == 1)
                            {
                                submarine = false;
                                break;
                            }
                        }
                    }
                    yAxis = true;
                }
            }
            return submarine;
        }

        internal bool CheckForDiagonalContacts(int row, int col)
        {
            bool checkForContact = false;

            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        if (row < 9 && col < 9)
                        {
                            if (field[row + 1, col + 1] == 1) { checkForContact = true; }
                        }
                        break;
                    case 1:
                        if (row < 9 && col > 0)
                        {
                            if (field[row + 1, col - 1] == 1) { checkForContact = true; }
                        }
                        break;
                    case 2:
                        if (row > 0 && col > 0)
                        {
                            if (field[row - 1, col - 1] == 1) { checkForContact = true; }
                        }
                        break;
                    case 3:
                        if (row > 0 && col < 9)
                        {
                            if (field[row - 1, col + 1] == 1) { checkForContact = true; }
                        }
                        break;
                }
                if (checkForContact)
                {
                    break;
                }
            }
            return checkForContact;
        }
    }
}