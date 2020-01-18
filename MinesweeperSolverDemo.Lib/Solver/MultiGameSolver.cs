using System;
using System.Collections.Generic;
using System.Linq;
using MinesweeperSolverDemo.Lib.Enums;
using MinesweeperSolverDemo.Lib.Objects;

namespace MinesweeperSolverDemo.Lib.Solver
{
    public class MultiGameSolver : GameSolver
    {
        public int BoardWidth { get; }
        public int BoardHeight { get; }
        public int MinesCount { get; }
        public int BoardsCount { get; }

        public int GamesCompleted { get; set; }
        public int GamesFailed { get; set; }

        public MultiGameSolver()
        {
            int height = 0, width = 0, mines = 0, boards = 0;
            while (width <= 0)
            {
                width = GetWidth();
                WidthErrors(width);
            }

            while (height <= 0)
            {
                height = GetHeight();
                HeightErrors(height);
            }

            while (mines <= 0)
            {
                mines = GetMines();
                MinesErrors(mines);
            }

            while (boards <= 0)
            {
                boards = GetBoards();
                BoardsErrors(boards);
            }

            BoardWidth = width;
            BoardHeight = height;
            MinesCount = mines;
            BoardsCount = boards;
        }

        public void Run()
        {
            Random random = new Random();
            List<BoardStats> stats = new List<BoardStats>();
            Console.WriteLine("Solving Games...");
            for(int i = 0; i < BoardsCount; i++)
            {
                GameBoard board = new GameBoard(BoardWidth, BoardHeight, MinesCount);
                SingleGameSolver solver = new SingleGameSolver(board, random);
                var boardStats = solver.Solve();
                stats.Add(boardStats);

                if(solver.Board.Status == GameStatus.Completed)
                {
                    GamesCompleted++;
                }
                else if(solver.Board.Status == GameStatus.Failed)
                {
                    GamesFailed++;
                }
            }

            Console.WriteLine("Games Completed: " + GamesCompleted);
            Console.WriteLine("Games Failed: " + GamesFailed);

            //Calculate stats
            var totalMines = stats.Sum(x => x.Mines);
            var totalFlaggedMines = stats.Sum(x => x.FlaggedMinePanels);
            var totalFlaggedMinesPercent = Math.Round(((totalFlaggedMines / totalMines) * 100F), 2);
            Console.WriteLine("Mines Flagged: " + totalFlaggedMinesPercent + "%");

            var totalPanels = stats.Sum(x => x.TotalPanels);
            var revealedPanels = stats.Sum(x => x.PanelsRevealed);
            var totalRevealedPanelsPercent = Math.Round((revealedPanels / totalPanels) * 100F, 2);
            Console.WriteLine("Panels Revealed: " + totalRevealedPanelsPercent + "%");
        }
    }
}
