using System;

namespace Novice
{
    public class Original
    {
        public static void Main()
        {
            string str = "ыуао ра шц цшукао экмоы о324 243к23ы";
            string str1 = "";
            string str2 = "";
            int count = 0;

            char[] array = str.ToCharArray();
            int b = 0;

            for (int i = 0; i < array.Length; i++)
            {
                count = 0;
                b = 0;
                if (i != 0)
                {
                    for (int k = i; k > 0; k--)
                    {
                        if ((array[i]) == (array[k - 1]))
                        {
                            b = 1;
                            break;
                        }
                    }
                }
                if (b != 1)
                {
                    for (int j = i; j < array.Length; j++)
                    {

                        if (array[i] == array[j])
                        {
                            count++;
                            str1 = array[i].ToString();
                        }
                        else { str1 = array[i].ToString(); }
                    }
                }
                if (b != 1) { str2 += str1 + "-" + count.ToString() + "\n"; }
            }
            Console.WriteLine(str2);
        }
    }
}
