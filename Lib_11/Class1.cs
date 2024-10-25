using System;
using System.Xml.Linq;

namespace Lib_11
{
    public class Class1
    {
        public static void Func(int[,] matrix, out string result)
        {
            int res= 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int increment = 1;
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i, j] < matrix[i, j + 1])
                    {
                        increment++;
                    }
                }
                if (increment == matrix.GetLength(1))
                {
                    res++;
                }
            }
            result=res.ToString();
        }
    }
}
