namespace Novice.Example_1
{
    using System;
    using System.Text;

    public class Refactored
    {
        public static void Main()
        {
            string inputText = "ыуао ра шц цшукао экмоы о324 243к23ы";
            string message = Refactored.CalculateLetterCount(inputText);
            Console.WriteLine(message);
            Console.ReadKey();
        }

        private static string CalculateLetterCount(string text)
        {
            StringBuilder sb = new StringBuilder();
            string template = "letter:{0}; count:{1}";
            for (int i = 0; i < text.Length; i++)
            {
                char current = text[i];
                if (Refactored.GetPreviousIndex(text, current, i - 1) == -1)
                {
                    int count = Refactored.GetCount(text, current, i + 1);
                    sb.AppendLine(string.Format(template, current, count));
                }
            }
            return sb.ToString().Trim(Environment.NewLine.ToCharArray());
        }

        private static int GetPreviousIndex(string str, char symbol, int indexFrom)
        {
            int result = -1;
            for (int i = indexFrom; i >= 0; i--)
            {
                if (str[i] == symbol)
                {
                    result = i;
                }
            }
            return result;
        }

        private static int GetCount(string str, char symbol, int indexFrom)
        {
            int count = 1;
            for (int i = indexFrom; i < str.Length; i++)
            {
                if (str[i] == symbol)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
