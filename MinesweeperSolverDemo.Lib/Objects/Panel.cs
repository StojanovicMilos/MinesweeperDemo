namespace MinesweeperSolverDemo.Lib.Objects
{
    public class Panel
    {
        public int Id { get; }
        public int X { get; }
        public int Y { get; }
        public bool IsMine { get; set; }
        public int AdjacentMines { get; set; }
        public bool IsRevealed { get; set; }
        public bool IsFlagged { get; set; }

        public Panel(int id, int x, int y)
        {
            Id = id;
            X = x;
            Y = y;
        }
    }
}
