/*
    Class           :   ArrayExtensions.cs
    Description     :   Allows the conversion of multidimensional arrays and lists
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
        /// <param name="inputArray">The 2d array to convert</param>
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
        /// <param name="inputList">The list to convert</param>
        /// <param name="nbLines">The number of lines of the outputted 2d array</param>
        /// <param name="nbCols">The number of columns of the outputted 2d array</param>
        /// <returns></returns>
        public static Cell[,] asArrayOfArray(this List<Cell> inputList, int nbLines, int nbCols)
        {
            Cell[,] output = new Cell[nbLines, nbCols];

            // Check if the input is valid (check if the number of elements is superior or equal
            // to the number of lines times the number of columns
            if (inputList.Count >= nbLines * nbCols)
            {
                int i = 0;

                for (int y = 0; y < nbLines; y++)
                {
                    for (int x = 0; x < nbCols; x++)
                    {
                        output[y, x] = inputList[i];
                        i++;
                    }
                }
            }
            else
            {
                // Else we throw the user an error
                throw new System.ArgumentException("The number of elements is inferior to the size of the outputted 2d array", "original");
            }

            return output;
        }
    }
}