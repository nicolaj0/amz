using System;

public class TicTacToe
{
    private int[] rows;
    private int[] columns;
    private int diagonal;
    private int antiDiagonal;

    /** Initialize your data structure here. */
    public TicTacToe(int n)
    {
       
        rows = new int[n];
        columns = new int[n];
       
    }

    public int Move(int row, int col, int player)
    {
      

        int toAdd = player == 1 ? 1 : -1;

        rows[row] += toAdd;
        columns[row] += toAdd;

        if (row == col)
        {
            diagonal += toAdd;
        }
        if (col == (columns.Length - row - 1))
        {
            antiDiagonal += toAdd;
        }
        int size = rows.Length;
        if (Math.Abs(rows[row]) == size ||
            Math.Abs(columns[col]) == size ||
            Math.Abs(diagonal) == size  ||
            Math.Abs(antiDiagonal) == size)
        {
            return player;
        }
    
        return 0;

    }
}