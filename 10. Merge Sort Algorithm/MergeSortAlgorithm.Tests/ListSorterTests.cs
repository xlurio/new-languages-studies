namespace MergeSortAlgorithm.Tests;

using ListSorterNS;
using System.Collections.Generic;

[TestFixture]
public class ListSorterTests
{

    [Test]
    public void TestSortMethod()
    {
        List<int> arrangement = GivenTheList();
        WhenListIsSorted(arrangement);
        ThenShouldReturnSortedList(arrangement);
    }

    private List<int> GivenTheList() {
        int[] testArray = new int[5] {6, 2, 8, 9, 5};
        return testArray.ToList();
    }

    private void WhenListIsSorted(List<int> arrangement) {
        int lastIndex = arrangement.Count - 1;
        ListSorter.Sort(arrangement, 0, lastIndex);
    }

    private void ThenShouldReturnSortedList(List<int> result) {
        int[] expectedArray = new int[5] {2, 5, 6, 8, 9};
        List<int> expectedResult = expectedArray.ToList();
        Assert.AreEqual(result, expectedResult);
    }
}