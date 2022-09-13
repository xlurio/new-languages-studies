#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int round_index(float number);
void sort(int *array_to_sort, int first_index, int mid_index, int last_index);

void merge_sort(int *array_to_sort, int first_index, int last_index)
{
    if ((last_index - first_index) > 1)
    {
        float mid_increment = ((float)(last_index - first_index) / 2);
        int mid_index = round_index(mid_increment) + first_index;

        merge_sort(array_to_sort, first_index, mid_index);
        merge_sort(array_to_sort, mid_index, last_index);

        sort(array_to_sort, first_index, mid_index, last_index);
    }
}

int round_index(float number)
{
    int number_multiplied_by_10 = (int)(number * 10);
    int rest_of_division = number_multiplied_by_10 % 10;

    if (rest_of_division > 0)
    {
        return (int)number + 1;
    }

    return (int)number;
}

void sort(int *array_to_sort, int left_index, int mid_index, int last_index)
{
    int result_length = last_index - left_index + 1;
    int *result_array = (int *)malloc(result_length * sizeof(int));

    int result_index = 0;

    int left_end = mid_index - 1;

    while ((left_index <= left_end) && (mid_index <= last_index))
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

    for (left_index; left_index <= left_end; left_index++)
    {
        result_array[result_index] = array_to_sort[left_index];
        result_index++;
    }

    for (mid_index; mid_index <= last_index; mid_index++)
    {
        result_array[result_index] = array_to_sort[mid_index];
        result_index++;
    }

    result_length = result_index;
    int last_result_index = result_length - 1;
    int current_result_item;

    for (int index = 0; index < result_length; index++)
    {
        current_result_item = result_array[last_result_index];
        last_result_index--;

        array_to_sort[last_index] = current_result_item;
        last_index--;
    }
}