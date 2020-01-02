namespace ConsoleApp4
{
    public class SolutionGenerateMatrix
    {
        private int[][] _generateMatrix;
        private int _startNumber;

        public int[][] GenerateMatrix(int n)
        {
            _generateMatrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                _generateMatrix[i] = new int[n];

                for (int j = 0; j < n; j++)
                {
                    _generateMatrix[i][j] = 0;
                }
            }

            var size = n;
            _startNumber = 1;
            var startCell = (0, 0);
                
            // generetateHelper(size, startNumber, startCell);

            while (size >= 0)
            {
                generetateHelper(size, startCell);
                size -= 2;
                startCell = (startCell.Item1 +1, startCell.Item2 +1);
            }


            return _generateMatrix;
        }

        private void generetateHelper(int size, (int, int) startCell)
        {
            for (int i = 0; i < size; i++)
            {
                _generateMatrix[startCell.Item1][startCell.Item2++] = _startNumber++;
            }
                
            _startNumber--;
            startCell.Item2--;
                
            for (int i = 0; i < size; i++)
            {
                _generateMatrix[startCell.Item1++][startCell.Item2] = _startNumber++;
            }

            startCell.Item1--;
            _startNumber--;
                
            for (int i = 0; i < size; i++)
            {
                _generateMatrix[startCell.Item1][startCell.Item2--] = _startNumber++;
            }

            startCell.Item2++;
            _startNumber--;
                
            for (int i = 0; i < size-1; i++)
            {
                _generateMatrix[startCell.Item1--][startCell.Item2] = _startNumber++;
            }
                
            startCell.Item1++;


               
        }
    }
}