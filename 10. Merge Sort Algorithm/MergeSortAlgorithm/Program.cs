namespace ListSorterNS;

using System.Collections.Generic;

public class ListSorter {

    public static void Main(string[] args) {

    }

    public static void Sort(List<int> listToSort, int firstIndex, 
                                 int lastIndex)
    {
        int mid;
        if (firstIndex < lastIndex) {
            mid = (firstIndex + lastIndex) / 2;
            Sort(listToSort, firstIndex, mid);
            Sort(listToSort, mid + 1, lastIndex);
            Merge(listToSort, firstIndex, mid + 1, lastIndex);
        }
    }

    private static void Merge(List<int> listToMerge, int leftIndex, 
                                   int rightIndex, int lastIndex) 
    {
        int currentLeftItem;
        int currentRightItem;
        int currentTemporaryItem;

        int temporaryListLength = listToMerge.Count;
        List<int> temporaryList = new List<int>(temporaryListLength);

        int endOfLeftSplit = rightIndex - 1;
        int finalLength = lastIndex - leftIndex + 1;

        while(leftIndex <= endOfLeftSplit && rightIndex <= lastIndex) {
            currentLeftItem = listToMerge[leftIndex];
            currentRightItem = listToMerge[rightIndex];

            if (currentLeftItem < currentRightItem) {
                temporaryList.Add(currentLeftItem);

                leftIndex++;
            } else {
                temporaryList.Add(currentRightItem);

                rightIndex++;
            }
        }

        while (leftIndex <= endOfLeftSplit) {
            currentLeftItem = listToMerge[leftIndex];
            temporaryList.Add(currentLeftItem);

            leftIndex++;
        }

        while (rightIndex <= lastIndex) {
            currentRightItem = listToMerge[rightIndex];
            temporaryList.Add(currentRightItem);

            rightIndex++;
        }

        int lastTemporaryIndex = temporaryList.Count - 1;

        for (int i = 0; i < finalLength; i++) {
            currentTemporaryItem = temporaryList[lastTemporaryIndex--];
            listToMerge[lastIndex--] = currentTemporaryItem;
        }
    }
}