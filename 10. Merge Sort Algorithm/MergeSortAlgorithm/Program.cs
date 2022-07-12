namespace ListSorterNS;

using System.Collections.Generic;

public class ListSorter {

    public static void Main(string[] args) {

    }

    public static List<int> Sort(List<int> listToSort) {
        if (listToSort.Count < 2) {
            return listToSort;
        }

        int halfLength = listToSort.Count / 2;
        List<int> firstHalf = listToSort.GetRange(0, halfLength);
        List<int> secondHalf = listToSort.GetRange(
            halfLength, listToSort.Count - halfLength
        );
        firstHalf = Sort(firstHalf);
        secondHalf = Sort(secondHalf);

        return Merge(firstHalf, secondHalf);
    }

    private static List<int> Merge(List<int> firstSliceToMerge, 
                                   List<int> secondSliceToMerge) 
    {
        int finalListLength = firstSliceToMerge.Count + secondSliceToMerge.Count;
        List<int> finalList = new List<int>(finalListLength);

        int firstSliceCounter = 0;
        int secondSliceCounter = 0;
        int finalListCounter = 0;

        int currentLeftItem = 0;
        int currentRightItem = 0;

        // Merge slices
        while (
            firstSliceCounter < firstSliceToMerge.Count &&
            secondSliceCounter < secondSliceToMerge.Count)
        {
            currentLeftItem = firstSliceToMerge[firstSliceCounter];
            currentRightItem = secondSliceToMerge[secondSliceCounter];

            if (currentLeftItem < currentRightItem) {
                finalList.Insert(
                    finalListCounter++, 
                    currentLeftItem
                );

                firstSliceCounter++;

            } else {
                finalList.Insert(
                    finalListCounter++,
                    currentRightItem
                );

                secondSliceCounter++;
            }

            while (firstSliceCounter < firstSliceToMerge.Count) {
                currentLeftItem = firstSliceToMerge[firstSliceCounter];

                finalList.Insert(
                    finalListCounter++, 
                    currentLeftItem
                );
            }

            while (secondSliceCounter < secondSliceToMerge.Count) {
                currentRightItem = secondSliceToMerge[secondSliceCounter];

                finalList.Insert(
                    finalListCounter++,
                    currentRightItem
                );
            }
        }

        return finalList;
    }
}