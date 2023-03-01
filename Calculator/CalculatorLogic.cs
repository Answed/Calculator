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
        private bool clampsclosed = false; // To ensure that the programm does not save empty strings after a clamp is closed. So when ) is pressed the next math operator would save an empty string without this bool.

        private List<string> items = new List<string>(); // Saves all the inputs from the text field as seperated inputs.
        private List<int> openClampPositions = new List<int>(); // Saves the index positions from the ( in items list.
        private List<int> closeClampPositions = new List<int>(); // Saves the index positions from the ) in items list.

        //Adds the number + the last math operator as seperate Items to the list
        public void AddItemsToItemsList(string textBox)
        {
            if (textBox.Length > 1) // When a negative number is written at the start it doesen't breaks the code. Later on it works as intended
            {
               if (clampsclosed)
               {
                    items.Add(Char.ToString(textBox[textBox.Length - 1]));
                    nextNumberPosition = textBox.Length; // Sets the position where the string will be read from the next time its called.
                    clampsclosed = false;
               }
               else
               {
                    string temp = textBox.Substring(nextNumberPosition, textBox.Length - 1 - nextNumberPosition); // Is needed to ensure that the numbers don't get saved twice
                    items.Add(temp);
                    items.Add(Char.ToString(textBox[textBox.Length - 1]));
                    nextNumberPosition = textBox.Length; // Sets the position where the string will be read from the next time its called.
               } 
                
               if (items.Last() == ")")
               {
                    closeClampPositions.Add(textBox.Length - 1);
                    clampsclosed = true;
               }
            }
        }

        public void AddClampToList (string textBox)
        {
            items.Add(Char.ToString(textBox[textBox.Length - 1]));
            openClampPositions.Add(textBox.Length - 1);
            nextNumberPosition++;
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
            openClampPositions.Clear();
            closeClampPositions.Clear();    
            nextNumberPosition = 0;
        }

        // Main function. Will later select the pairs baised of priority so (*/) > + -
        // When it found such a pair it changes the List directly and makes it smaller each time until the final result is calculated
        public string Calculate()
        {
            if (openClampPositions.Count > 0)
                FindClampPairs(); // Start of the Clamp calculations
            if (items.Contains("^"))
                FindMathOperatorInList(1, items.Count, new string[] { "^" });
            if (items.Contains("*") || items.Contains("/"))
                FindMathOperatorInList(1, items.Count, new string[] { "*", "/" });
            foreach (string item in items) { Debug.WriteLine(item); }
            if (items.Contains("+") || items.Contains("-"))
                FindMathOperatorInList(1, items.Count, new string[] { "+", "-" });

            nextNumberPosition = 0;
            string result = items[0].ToString();
            items.RemoveAt(0);
            return result;
        }

        private void FindClampPairs()
        {
            int smallest_diff = 50; 
            int[] clampPair = new int[4];

            for (int i = 0; i < openClampPositions.Count; i++)
            {
                for (int y = 0; y < closeClampPositions.Count; y++)
                {
                    if (smallest_diff >= (closeClampPositions[y] - openClampPositions[i]) && openClampPositions[i] <  closeClampPositions[y])
                    {
                        clampPair[0] = openClampPositions[i]; //Saves the Index Value from the open Clamp
                        clampPair[1] = closeClampPositions[y]; // Saves the Index Value from the closed clamp
                        clampPair[2] = i; // Saves the Index value from the open clamp from the openClampPosition List
                        clampPair[3] = y; // Saves the Index value from the open clamp from the closeClampPosition List
                        smallest_diff = closeClampPositions[y] - openClampPositions[i];
                    }
                }
            }

            CalculateClamp(clampPair[0], clampPair[1]);
            RemoveClampsFromList(clampPair[2], clampPair[3]);
            if (openClampPositions.Count > 0)
            {
                FixClampPositions(clampPair, clampPair[1] - clampPair[0] - 1);
                FindClampPairs();
            }

        }

        private void FixClampPositions(int[] clampPair , int clampDiff)
        {
            // Changes the position from every clamp which comes after this pair to the right position.
            // After Calculating a clamp the item list is smaller so every clamp which comes after the clamps calculated has a wrong value.
            // Thats why we subbtract the diff from the clamp pair to ensure that the right position is saved. -> 
            // The clamps are automatically moved in the item list but we also have to change the value of it in the clamp list.
            for (int i  = clampPair[2]; i < openClampPositions.Count; i++)
            {
                if (clampPair[0] < openClampPositions[i])
                    openClampPositions[i] -= clampDiff;
            }
            for (int i = clampPair[3]; i < closeClampPositions.Count; i++)
            {
                if (clampPair[1] < closeClampPositions[i])
                    closeClampPositions[i] -= clampDiff;
            }
        }

        private void RemoveClampsFromList(int openClampPosition, int closeClampPosition)
        {
            openClampPositions.RemoveAt(openClampPosition);
            closeClampPositions.RemoveAt(closeClampPosition);
        }

        private void CalculateClamp(int openClamp, int closeClamp)
        {;
            var power = false;
            var dot = false;
            var line = false;

            Debug.WriteLine($"{openClamp} {closeClamp}");

            for (int i = openClamp; i < closeClamp; i++)
            {
                if (items[i] == "^")
                    power= true;
                if(items[i] == "*" || items[i] == "/")
                    dot= true;
                if (items[i] == "+" || items[i] == "-")
                    line= true;
            }

            Debug.WriteLine($"{power} {dot} {line}");
            if (power)
                FindMathOperatorInList(openClamp, closeClamp, new string[] { "^" });
            if(dot)
                FindMathOperatorInList(openClamp, closeClamp, new string[] { "*", "/" });
            if (line)
                FindMathOperatorInList(openClamp, closeClamp, new string[] { "+", "-" });


            // Replaces the result of the clamp with the open clamp and remvoes the old result and closed clamp.
            items[openClamp] = items[openClamp + 1];
            items.RemoveRange(openClamp + 1, 2);
        } 

        private void FindMathOperatorInList(int start, int end,string[] mathOperators)
        {
            for (int i = start; i < end - 1; i++)
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
