extern "C"
{
#include "merge_sort.h"
}

#include <gmock/gmock.h>
#include <gtest/gtest.h>

TEST(TestMergeSort, test_sorting)
{
    const int EXPECTED_RESULT[] = {1, 2, 3, 4, 5};

    int RESULT[] = {4, 2, 5, 1, 3};
    merge_sort(RESULT, 0, 4);

    EXPECT_THAT(RESULT, ::testing::ElementsAreArray(EXPECTED_RESULT));
}