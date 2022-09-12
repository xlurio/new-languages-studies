#include "merge_sort.h"

int main()
{
    int array_to_sort[] = {4, 2, 5, 1, 3};
    int array_length = sizeof(array_to_sort);

    merge_sort(array_to_sort, 0, array_length + 1);

    for (int index = 0; index < array_length; index++)
    {
        printf("%i\t", array_to_sort[index]);
    }

    return 0;
}
