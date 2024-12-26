namespace SAK25.Extensions;

public static class CollectionExtensions
{

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
    /// Correctly joins an array of characters into a string
    /// </summary>
    /// <param name="chars"></param>
    /// <returns>['s', 't', 'r', 'i', 'n', 'g'] => "string"</returns>
    public static string ToStringProper(this IEnumerable<char> chars)
    {
        string res = "";

        foreach (char c in chars)
        {
            res += c;
        }

        return res;
    }

    /// <summary>
    /// Correctly joins an array of characters into a string
    /// </summary>
    /// <param name="chars"></param>
    /// <returns>['s', 't', 'r', 'i', 'n', 'g'] => "string"</returns>
    public static string ToStringJoined(this int[] nrs)
    {
        string res = "";

        for (int i = 0; i<nrs.Length; i++)
        {
            res += nrs[i] + (i < nrs.Length - 1 ? "," : "");
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