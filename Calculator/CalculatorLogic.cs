using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace Calculator
{
    internal class CalculatorLogic
    {
        private int nextNumberPosition = 0;

        private List<string> items = new List<string>(); // Saves all the inputs from the text field as seperated inputs.
        private List<int> clampPositions = new List<int>(); // Saves the index positions from the () in items list.

        //Adds the number + the last math operator as seperate Items to the list
        public void AddItemsToItemsList(string textBox)
        {
            if (textBox.Length > 1) // When a negative number is written at the start it doesen't breaks the code. Later on it works as intended
            {
                string temp = textBox.Substring(nextNumberPosition, textBox.Length - 1 - nextNumberPosition); // Is needed to ensure that the numbers don't get saved twice
                items.Add(temp);
                items.Add(Char.ToString(textBox[textBox.Length - 1]));
                foreach(string item in items) { Debug.WriteLine(item); }
                nextNumberPosition = textBox.Length; // Sets the position where the string will be read from the next time its called.
            }
        }

        public void AddClampToList (string textBox)
        {
            items.Add(Char.ToString(textBox[textBox.Length - 1]));
            clampPositions.Add(textBox.Length - 1);
            nextNumberPosition++;
            foreach (string item in items) { Debug.WriteLine(item); }
        }

        //This saves everything after the last math operator to the list as one object
        public void AddLastItemToList(string lastItem)
        {
            string temp = lastItem.Substring(nextNumberPosition);
            items.Add(temp);
        }

        public void ClearList()
        {
            items.Clear();
            nextNumberPosition = 0;
        }

        // Main function. Will later select the pairs baised of priority so (*/) > + -
        // When it found such a pair it changes the List directly and makes it smaller each time until the final result is calculated
        public string Calculate()
        {
            if (clampPositions.Count > 1)
                CalculateClamps();

            if (items.Contains("^"))
                FindMathOperatorInList(1, items.Count, new string[] { "^" });
            if (items.Contains("*") || items.Contains("/"))
                FindMathOperatorInList(1, items.Count, new string[] { "*", "/" });
            if (items.Contains("+") || items.Contains("-"))
                FindMathOperatorInList(1, items.Count, new string[] { "+", "-" });

            nextNumberPosition = 0;
            string result = items[0].ToString();
            items.RemoveAt(0);
            return result;
        }

        private void CalculateClamps()
        {
            //Defines the range where the clamps are located. The List ist divided in two to ensure that when there are multiple clamps the closes to each other are selected, so when (( )) the two in the middle will be selected first.
            int openClamp = clampPositions[(clampPositions.Count / 2) - 1];
            int closeClamp = clampPositions[(clampPositions.Count / 2)];

            if (items.Contains("^"))
                FindMathOperatorInList(openClamp, closeClamp, new string[] { "^" });
            if (items.Contains("*") || items.Contains("/"))
                FindMathOperatorInList(openClamp, closeClamp, new string[] { "*", "/" });
            if (items.Contains("+") || items.Contains("-"))
                FindMathOperatorInList(openClamp, closeClamp, new string[] { "+", "-" });
            
            // Replaces the result of the clamp with the open clamp and remvoes the old result and closed clamp.
            items[openClamp] = items[openClamp + 1];
            items.RemoveRange(openClamp + 1, 2);

        } 

        private void FindMathOperatorInList(int start, int end,string[] mathOperators)
        {
            for (int i = start; i < end; i++)
            {
                if (mathOperators.Contains(items[i])) // Checks if the item at position i is part of the selected math operators. If its true then it will be calculated and replaced by the result.
                {
                    ChangeItemList(i - 1, MathOperations(items[i - 1], items[i + 1], items[i]));
                    if (items.Intersect(mathOperators).Any())
                        FindMathOperatorInList(start, end,mathOperators);
                    break;
                }
            }
        }
            // Method which calculates the pairs prior selected in Calculate
        private float MathOperations(string num1, string num2, string operation)
        {
            float[] numbers = new float[2]; // I use floats and not ints because numbers can be decimals or be divided into decimals.
           
            numbers = ConvertNumbers(num1, num2); // Numbers are saved as a string so i have to convert them.
            switch (operation)
            {
                case "+":
                    return numbers[0] + numbers[1];
                case "-":
                    return numbers[0] - numbers[1];
                case "*":
                    return numbers[0] * numbers[1];
                case "/":
                    try // To Ensure that the result will still be calculated and doesen't crash the software -> Could be changed to just display an error Message if something like that happens.
                    {
                        return numbers[0] / numbers[1];
                    }
                    catch (DivideByZeroException)
                    {
                        MessageBox.Show($"Can't divide through 0. {numbers[0]} / {numbers[1]} is replaced by 0 ");
                        return 0;
                    }
                case "^":
                    return float.Parse(Math.Pow(numbers[0], numbers[1]).ToString());
                default: return 0;
            }
          
        }

        private float[] ConvertNumbers(string num1, string num2)
        {
            float[] results = new float[2];

            float int_num1;
            float int_num2;

            //Ensures that even when something went wrong the code still runs. 
            //will be improved so that if only one number is wrong the other one will be taken. But still with a message informing the user.
            bool num1Success = float.TryParse(num1, out int_num1);
            bool num2Success = float.TryParse(num2, out int_num2);
            if (num1Success && num2Success)
            {
                results[0] = int_num1;
                results[1] = int_num2;
                return results;
            }
            else 
            {
                MessageBox.Show($"There was a mistake with your Input so we replaced {num1} + {num2} with 0.");
                results[0] = 0;
                results[1] = 0;
                return results;
            }

        }

        private void ChangeItemList(int startIndex, float newValue)
        {
            items.RemoveRange(startIndex + 1, 2);
            items[startIndex] = newValue.ToString(); // replaces the first element of each pair. For example we have a pair of 2 + 4 it replaces the 2 with the 6
        }
    }
}
