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
        List<int> result = WhenListIsSorted(arrangement);
        ThenShouldReturnSortedList(result);
    }

    private List<int> GivenTheList() {
        int[] testArray = new int[5] {6, 2, 8, 9, 5};
        return testArray.ToList();
    }

    private List<int> WhenListIsSorted(List<int> arrangement) {
        return ListSorter.Sort(arrangement);
    }

    private void ThenShouldReturnSortedList(List<int> result) {
        int[] expectedArray = new int[5] {2, 5, 6, 8, 9};
        List<int> expectedResult = expectedArray.ToList();
        Assert.AreEqual(result, expectedResult);
    }
}