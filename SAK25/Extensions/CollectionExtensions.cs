namespace SAK25.Extensions;

/// <summary>
/// Extension methods for collections.
/// Always specifies the complexity of the method.
/// </summary>
public static class CollectionExtensions
{
    /// <summary>
    /// [O(n)] Retrieves a random element in an enumerable.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t"></param>
    /// <returns></returns>
    public static T RandomElement<T>(this IEnumerable<T> t)
    {
        var arr = t.ToArray();
        return arr[Random.Shared.Next(arr.Length)];
    }

    /// <summary>
    /// [O(1)] Retrieves a random element in an array.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t"></param>
    /// <returns></returns>
    public static T RandomElement<T>(this T[] t)
        => t[Random.Shared.Next(t.Length)];

    /// <summary>
    /// [O(n)] Fills a character array with a character.
    /// Default is '0'.
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    public static char[] Fill(this char[] arr, char c = '0')
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = c;
        }

        return arr;
    }

    /// <summary>
    /// [O(xSize*ySize)] Fills a two-dimensional character array with a character.
    /// Default is '0'.
    /// </summary>
    /// <param name="array">A two-dimensional character array of size [xSize][ySize]</param>
    /// <param name="xSize"></param>
    /// <param name="ySize"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    public static char[][] Fill (this char[][] array, int xSize, int ySize, char c = '0')
    {
        for (int i = 0; i < xSize; i++)
        {
            if (array[i] == null)
            {
                array[i] = new char[ySize];
            }

            array[i] = array[i].Fill(c);
        }

        return array;
    }

    /// <summary>
    /// Transforms a string IEnumerable into an integer array.
    /// Does not affect the original collection.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
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