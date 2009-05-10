#include <stdio.h>

/* function prototypes */

/* main entry point */
void main(){
  int *ptr;
  int input = 11;
  ptr = &input;
  printf(" Value is %d Pointer is %d ", input, &input);
  printf(" value is %d and pointer is %d and address of ptr is %d final value is %d " *ptr, ptr, &ptr, ptr);
}

/* function definitions */
