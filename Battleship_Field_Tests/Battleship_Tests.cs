namespace Battleship_Field_Tests
{
    public class Battleship_Tests
    {
        int[,] field = new int[10, 10]
                     {{0, 0, 0, 0, 0, 1, 1, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                      {0, 0, 0, 0, 1, 1, 1, 0, 1, 0},
                      {1, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                      {1, 0, 1, 0, 0, 0, 0, 0, 1, 0},
                      {1, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                      {1, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                      {0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                      {1, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
        [Fact]
        public void Should_Return_A_Total_Of_Twenty_Ones()
        {
            int expectedTotal = 20; //1 battleship 4 cells, 2 Cruisers 3 cells, 3 destroyers 2 cells, 4 submarines 1 cell. 

            var obj = new Battleship_Field_Validation();
            obj.Field = field;
            int actualTotal = obj.GetTotalNumberOfOnes();

            Assert.Equal(expectedTotal, actualTotal);

        }
        [Fact]
        /*This test method should return all the ships that are supposed to be on the board. 
        All asserts will pass if the expected number of ships is returned by the method GetTotalShipsAccordingToSize.
        This will also mean that all the required ships are on the board and their edges are not touching. */
        public void Should_Return_Total_Ships_According_To_Given_Size()
        {
            List<int> ShipsSize = new List<int>() { 4, 3, 2, 1 };
            List<int> Ships = new List<int>()     { 1, 2, 3, 4 };

            var obj = new Battleship_Field_Validation();
            obj.Field = field;

            for (int i = 0; i < ShipsSize.Count; i++)
            {
                int actualTotal = obj.GetTotalShipsAccordingToSize(ShipsSize[i]);
                int expectedTotalShips = Ships[i];

                switch (i)
                {
                    case 0:
                        Assert.Equal(expectedTotalShips, actualTotal);
                        break;
                    case 1:
                        Assert.Equal(expectedTotalShips, actualTotal);
                        break;
                    case 2:
                        Assert.Equal(expectedTotalShips, actualTotal);
                        break;
                    case 3:
                        Assert.Equal(expectedTotalShips, actualTotal);
                        break;
                }
            }
        }
        [Fact]
        public void Check_One_Occupied_Cell()
        {
            var obj = new Battleship_Field_Validation();
            obj.Field = field;
            bool expected = true;

            bool actual = obj.CheckForSubmarines(6, 8);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Should_Return_False_If_Corners_Are_Not_Touching()
        {
            var obj = new Battleship_Field_Validation();
            obj.Field = field;
            bool expected = false;

            bool actual = obj.CheckForDiagonalContacts(7, 2);

            Assert.Equal(expected, actual);
        }
    }
}