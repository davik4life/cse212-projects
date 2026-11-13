using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        var wordSet = new HashSet<string>(words);
        var pairs = new List<string>();

        foreach (var word in wordSet)
        {
            if (word[0] == word[1])
                continue;

            string reversed = new string(new[] { word[1], word[0] });

            if (wordSet.Contains(reversed) &&
                string.CompareOrdinal(word, reversed) > 0)
            {
                pairs.Add($"{word} & {reversed}");
            }
        }

        return pairs.ToArray();
    }
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');

            if (fields.Length <= 3)
                continue;

            string degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }
    public static bool IsAnagram(string word1, string word2)
    {
        var letterCounts = new Dictionary<char, int>();

        foreach (char character in word1)
        {
            if (character == ' ')
                continue;

            char letter = char.ToLowerInvariant(character);

            if (!letterCounts.ContainsKey(letter))
                letterCounts[letter] = 0;

            letterCounts[letter]++;
        }

        foreach (char character in word2)
        {
            if (character == ' ')
                continue;

            char letter = char.ToLowerInvariant(character);

            if (!letterCounts.ContainsKey(letter))
                letterCounts[letter] = 0;

            letterCounts[letter]--;
        }

        return letterCounts.Values.All(count => count == 0);
    }
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var response = client.GetAsync(uri).GetAwaiter().GetResult();

        response.EnsureSuccessStatusCode();

        var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var featureCollection =
            JsonSerializer.Deserialize<FeatureCollection>(json, options);

        if (featureCollection?.Features == null)
            return [];

        var earthquakes = new List<string>();

        foreach (var feature in featureCollection.Features)
        {
            if (feature?.Properties == null)
                continue;

            string place = feature.Properties.Place ?? "Unknown location";
            string magnitude = feature.Properties.Mag?.ToString() ?? "Unknown";

            earthquakes.Add($"{place} - Mag {magnitude}");
        }

        return earthquakes.ToArray();
    }
}