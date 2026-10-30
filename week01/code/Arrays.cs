public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create a new array with room for 'length' multiples.
        // Step 2: Visit every array index, starting at index zero.
        // Step 3: Multiply 'number' by (index + 1) so the first value is 'number'.
        // Step 4: Save each multiple in its corresponding array position.
        // Step 5: Return the populated array.
        double[] multiples = new double[length];
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start

        // Step 1: Determine the total number of elements in the list.
        int count = data.Count;

        // Step 2: Find the starting index of the elements
        // that need to be moved to the beginning.
        int startIndex = count - amount;

        // Step 3: Copy the last 'amount' elements into a
        // temporary list while preserving their order.
        List<int> rotatedElements = data.GetRange(startIndex, amount);

        // Step 4: Remove those elements from the original list.
        data.RemoveRange(startIndex, amount);

        // Step 5: Insert the saved elements at the beginning
        // of the original list to complete the right rotation.
        data.InsertRange(0, rotatedElements);
    }
}
