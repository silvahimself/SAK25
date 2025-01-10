namespace SAK25.Extensions;

public static class CollectionExtensions
{
    public static T RandomElement<T>(this IEnumerable<T> t)
        => t.ElementAt(Random.Shared.Next(t.Count()));
    
    public static T RandomElement<T>(this T[] t)
        => t[Random.Shared.Next(t.Length)];

    public static char[] Fill(this char[] arr, char c = '0')
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = c;
        }

        return arr;
    }

    public static char[][] Fill (this char[][] array, int size, char c = '0')
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == null)
            {
                array[i] = new char[size];
            }

            array[i] = array[i].Fill(c);
        }

        return array;
    }

    public static int[] ParseArray(this IEnumerable<string> data)
    {
        int[] res = new int[data.Count()];

        for (int i = 0; i < res.Length; i++)
        {
            res[i] = int.Parse(data.ElementAt(i));
        }

        return res;
    }

    /// <summary>
    /// Receives an array of integers and counts the occurrences of each, returning it in a 
    /// Dictionary format.
    /// </summary>
    /// <param name="numbers">The array to group.</param>
    /// <returns>A dictionary where the keys represent the numbers and the values represent the number of times the number occurs.</returns>
    public static Dictionary<int, int> GroupedInDictionary(int[] numbers)
    {
        var result = new Dictionary<int, int>();

        foreach (var number in numbers)
        {
            var exists = result.TryGetValue(number, out int count);

            if (exists)
                result[number] = count + 1;
            else
                result.Add(number, 1);
        }

        return result;
    }
}