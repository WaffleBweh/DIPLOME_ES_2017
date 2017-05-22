/*
    Class           :   ArrayExtensions.cs
    Description     :   Allows the conversion of lists of cells
    Author          :   SEEMULLER Julien
    Date            :   16.05.2017
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemmaCA
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Converts the current array ([,]) to a list
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns></returns>
        public static List<Cell> asList(this Cell[,] inputArray)
        {
            List<Cell> output = new List<Cell>();

            for (int i = 0; i < inputArray.GetLength(0); i++)
            {
                for (int j = 0; j < inputArray.GetLength(1); j++)
                {
                    output.Add(inputArray[i, j]);
                }
            }

            return output;
        }

        /// <summary>
        /// Converts a list to a 2D array
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="nbLines"></param>
        /// <param name="nbCols"></param>
        /// <returns></returns>
        public static Cell[,] asArrayOfArray(this List<Cell> inputArray, int nbLines, int nbCols)
        {
            Cell[,] output = new Cell[nbLines, nbCols];

            int i = 0;

            for (int y = 0; y < nbLines; y++)
            {
                for (int x = 0; x < nbCols; x++)
                {
                    output[y, x] = inputArray[i];
                    i++;
                }
            }

            return output;
        }
    }
}