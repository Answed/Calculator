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

        private List<string> items = new List<string>();

        //Adds the number + the last math operator as seperate Items to the list
        public void AddItemsToItemsList(string textBox)
        {
            if (textBox.Length > 1) // When a negative number is written at the start it doesen't breaks the code. Later on it works as intended
            {
                string temp = textBox.Substring(nextNumberPosition, textBox.Length - 1 - nextNumberPosition); // Is needed to ensure that the numbers don't get saved twice
                items.Add(temp);
                items.Add(Char.ToString(textBox[textBox.Length - 1]));
                nextNumberPosition = textBox.Length; // Sets the position where the string will be read from the next time its called.
            }
        }
        //This saves everything after the last math operator to the list as one object
        public void AddLastItemToList(string lastItem)
        {
            string temp = lastItem.Substring(nextNumberPosition);
            items.Add(temp);
        }

        // Main function. Will later select the pairs baised of priority so (*/) > + -
        // When it found such a pair it changes the List directly and makes it smaller each time until the final result is calculated
        public string Calculate()
        {
            for (int i = 1; i < items.Count; i += 2)
            {
                if (items[i] == "+")
                {
                    ChangeItemList(i - 1, i + 1, MathOperations(items[i-1], items[i + 1], 1));
                    break;
                }
            }

            if (items.Count > 1)
                return Calculate();
            else return items[0];
        }
        
        // Mehtod i use for converting a pair and adding it. The result will be directly saved in the list
        private float MathOperations(string num1, string num2, int operation)
        {
            float[] numbers = new float[2];
           
            numbers = ConvertNumbers(num1, num2);
            switch (operation)
            {
                case 1:
                    return numbers[0] + numbers[1];
                case 2:
                    return numbers[0] - numbers[1];
                case 3:
                    return numbers[0] * numbers[1];
                case 4:
                    return numbers[0] / numbers[1];
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
                Debug.WriteLine(int_num1 + " " + int_num2);
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

        private void ChangeItemList(int startIndex, int endIndex, float newValue)
        {
            items.RemoveRange(startIndex, endIndex);
            items[startIndex] = newValue.ToString(); // replaces the first element of each pair. For example we have a pair of 2 + 4 it replaces the 2 with the 6
        }
    }
}
