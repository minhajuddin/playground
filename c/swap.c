#include <stdio.h>

/* function prototypes */
void swap( int *first, int *second );

/* function to swap two numbers */
void swap( int *first, int *second ){
 int temp = first;
  first = second;
  second = temp;
}

void main(){
 int first, second;
 printf("Please enter two numbers:\n");
 scanf("%d%d", &first, &second);
 
 swap( &first, &second);
 
 printf("The swapped numbers are %d, %d", first, second);
}  
