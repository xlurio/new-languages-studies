#include "basic_input.h"

void main(void)
{
    char name[16];

    puts("What is your name?");
    scanf("%s", name);
    printf("Hello, %s!", name);
}