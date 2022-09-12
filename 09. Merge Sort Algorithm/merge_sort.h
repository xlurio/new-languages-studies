#include <stdio.h>
#include <stdlib.h>

void sort(int *array_to_sort, int left_index, int mid_index, int last_index);

void merge_sort(int *array_to_sort, int first_index, int last_index)
{
    if (first_index < last_index)
    {
        return;
    }

    const int MID_INDEX = last_index / 2;

    merge_sort(array_to_sort, first_index, MID_INDEX);
    merge_sort(array_to_sort, MID_INDEX, last_index);
    sort(array_to_sort, first_index, MID_INDEX, last_index);
}

void sort(int *array_to_sort, int left_index, int mid_index, int last_index)
{
    int result_length = last_index + 1;
    int *result_array = (int *)malloc(result_length * sizeof(int));

    int result_index = 0;

    while (left_index < mid_index)
    {
        while (mid_index <= last_index)
        {
            if (array_to_sort[left_index] < array_to_sort[mid_index])
            {
                result_array[result_index] = array_to_sort[left_index];
                left_index++;
            }
            else
            {
                result_array[result_index] = array_to_sort[mid_index];
                mid_index++;
            }

            result_index++;
        }
    }

    for (left_index; left_index < mid_index; left_index++)
    {
        result_array[result_index] = array_to_sort[left_index];
        result_index++;
    }

    for (mid_index; mid_index <= last_index; mid_index++)
    {
        result_array[result_index] = array_to_sort[mid_index];
        result_index++;
    }

    int last_result_index = sizeof(result_array) - 1;
    int current_result_item;

    for (int index = 0; index < result_length; index++)
    {
        current_result_item = result_array[result_length];
        result_length--;

        array_to_sort[last_index] = current_result_item;
        last_index--;
    }
}