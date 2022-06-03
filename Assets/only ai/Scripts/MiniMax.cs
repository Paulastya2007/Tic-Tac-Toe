using System; 
using UnityEngine;

public class MiniMax
{

    public int aiPick;
    
    public EndTurnPosition GetBestPosition(int calculateBestRouteFor, int[] gameBoard, int depth)
    {
        int isGameOver = IsGameOver(gameBoard);
        if (IsBoardFull(gameBoard) && isGameOver == 0)  //tie
        {
            return new EndTurnPosition(0);
        }
        else if (isGameOver == 10)  //win
        {
            return new EndTurnPosition(10 - depth);
        }
        else if (isGameOver == -10) //lose
        {
            return new EndTurnPosition(depth - 10);
        }
        depth++;
        EndTurnPosition levelBestPosition = createEndPositionForLevel(calculateBestRouteFor);
        
        for (int boardPosition = 0; boardPosition < gameBoard.Length; boardPosition++)
        {

            if (gameBoard[boardPosition] == 0)
            {
                gameBoard[boardPosition] = calculateBestRouteFor;
               
                EndTurnPosition newPosition = GetBestPosition(calculateBestRouteFor * -1, (int[])gameBoard.Clone(), depth);
                
                if (aiPick != calculateBestRouteFor)
                {
                    if (newPosition.score <= levelBestPosition.score)
                    {
                        levelBestPosition.position = boardPosition;
                        levelBestPosition.score = newPosition.score;
                    }
                }
                else
                {
                    if (newPosition.score >= levelBestPosition.score)
                    {
                        levelBestPosition.position = boardPosition;
                        levelBestPosition.score = newPosition.score;
                    }
                }
               
                gameBoard[boardPosition] = 0;
            }
        }
        return levelBestPosition;
    }

    private EndTurnPosition createEndPositionForLevel(int calculateBestRouteFor)
    {
        EndTurnPosition levelBestPosition = new EndTurnPosition();
       
        if (aiPick != calculateBestRouteFor)
        {
            levelBestPosition.score = int.MaxValue;
        }
        else
        {
            levelBestPosition.score = int.MinValue;
        }
        return levelBestPosition;
    }

    private bool IsBoardFull(int[] gameBoard)
    {
        foreach (int gameNode in gameBoard)
        {
            if (gameNode == 0)
            {
                return false;
            }
        }
        return true;
    }

    private int IsGameOver(int[] gameBoard)
    {
       

        int isWinRow = 0;
        int isWinForwardDiagonal = 0;   
        int isWinBackDiagonal = 0;
        int rowNumber = 1;
        int rowSize = (int)Math.Sqrt(gameBoard.Length);
        int[] isWinColumnArr = new int[rowSize];
        int winCondition = CreateWinCondition(aiPick);
        int loseCondition = winCondition * -1;

        for (int i = 0; i < gameBoard.Length; i++)
        {
            rowNumber = IsNewRow(rowSize, i) ? ++rowNumber : rowNumber;
            isWinRow = ResetWinConditionForRow(isWinRow, rowSize, i);

            CalculateIsColumnWin(gameBoard, rowSize, isWinColumnArr, i);
            isWinRow = CalculateIsRowWin(gameBoard, isWinRow, i);
            isWinBackDiagonal = CalculateIsBackDiagonalWin(gameBoard, isWinBackDiagonal, rowNumber, rowSize, i);
            isWinForwardDiagonal = CalculateIsForwardDiagonalWin(gameBoard, isWinForwardDiagonal, rowNumber, rowSize, i);

            if (isWinForwardDiagonal == winCondition || isWinBackDiagonal == winCondition || isWinRow == winCondition || isWinColumnArr[i % rowSize] == winCondition)
            {
                return 10; //win
            }
            else if (isWinForwardDiagonal == loseCondition || isWinBackDiagonal == loseCondition || isWinRow == loseCondition || isWinColumnArr[i % rowSize] == loseCondition)
            {
                return -10; //lose
            }
        }
        return 0; //tie or nothing (nothing = board isnt full yet)
    }

    private void CalculateIsColumnWin(int[] gameBoard, int rowSize, int[] isWinColumnArr, int i)
    {
        isWinColumnArr[i % rowSize] += gameBoard[i];
    }

    private int CalculateIsRowWin(int[] gameBoard, int isWinRow, int i)
    {
        isWinRow += gameBoard[i];
        return isWinRow;
    }

    private int CalculateIsForwardDiagonalWin(int[] gameBoard, int isWinForwardDiagonal, int rowNumber, int rowSize, int i)
    {
        if (i != 0 && i == ((rowSize - 1) * rowNumber))
        {
            isWinForwardDiagonal += gameBoard[i];
        }
        return isWinForwardDiagonal;
    }

    private int CalculateIsBackDiagonalWin(int[] gameBoard, int isWinBackDiagonal, int rowNumber, int rowSize, int i)
    {
        if ((i == ((rowSize + 1) * (rowNumber - 1))))
        {
            isWinBackDiagonal += gameBoard[i];
        }
        return isWinBackDiagonal;
    }

    private int ResetWinConditionForRow(int isWinRow, int rowSize, int i)
    {
        if (IsNewRow(rowSize, i))
        {
            isWinRow = 0;
        }
        return isWinRow;
    }

    private bool IsNewRow(int rowSize, int i)
    {
        return i != 0 && (i % rowSize) == 0;
    }

    private int CreateWinCondition(int calculateBestRouteFor)
    {
        int win = 3;
        if (calculateBestRouteFor == -1)
        {
            win *= calculateBestRouteFor;
        }
        return win;
    }

}