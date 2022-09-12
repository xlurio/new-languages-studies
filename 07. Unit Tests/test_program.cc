extern "C"
{
#include "program_to_test.h"
}

#include <gtest/gtest.h>

TEST(TestSumNumbers, test_sum_numbers)
{
    const float EXPECTED_RESULT = 3.0f;
    const float RESULT = sum_numbers(1.0f, 2.0f);

    EXPECT_FLOAT_EQ(EXPECTED_RESULT, RESULT);
}