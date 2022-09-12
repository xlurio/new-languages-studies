# Unit Tests

## Introduction

This is where are the unit tests studies.


## Test Case

To create declare a test case, you can use the `TEST()` macro:

```
TEST(TestSuiteName, TestName) {
  ... test body ...
}
```


## Assertions

You can find all possible assertions [here](https://google.github.io/googletest/reference/assertions.html). You can use it like:

```
TEST(TestSuiteName, TestName) {
  EXPECT_EQ(val1,val2)
}
```


## SetUp Method

If necessary, write a default constructor or SetUp() function to prepare the objects for each test:

```
class FooTest : public ::testing::Test {
    protected:
        void SetUp(){
            ... before each test ...
        }
}
```


## TearDown Method

If necessary, write a destructor or TearDown() function to release any resources you allocated in SetUp():

```
class FooTest : public ::testing::Test {
    protected:
        void SetUp(){
            ... before each test ...
        }
        void TearDown(){
            ... after each test ...
        }
}
```


## Main function

Compiling and running the tests:

- Create a `CMakeLists.txt` with the following content:

```
cmake_minimum_required(VERSION 3.14)
project(my_project)

# GoogleTest requires at least C++14
set(CMAKE_CXX_STANDARD 14)

include(FetchContent)
FetchContent_Declare(
  googletest
  GIT_REPOSITORY https://github.com/google/googletest.git
  GIT_TAG release-1.12.1
)
# For Windows: Prevent overriding the parent project's compiler/linker settings
set(gtest_force_shared_crt ON CACHE BOOL "" FORCE)
FetchContent_MakeAvailable(googletest)
```

- Assuming your test suite is in a file names `test_example.cc`, append the following content to the `CMakeList.txt` file:

```
enable_testing()

add_executable(
  test_example
  test_example.cc
)
target_link_libraries(
  test_example
  GTest::gtest_main
)

include(GoogleTest)
gtest_discover_tests(test_example)
```

- Now run the following commands:

```
$ cmake -S . -B build
$ cmake --build build
$ cd build && ctest
```