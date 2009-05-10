#include <stdio.h>
void main(){
  /*
	  1 read an input number store it in "x"
	  2 get remainder of x divided by 10 => (last number)
	  3 divide x by 10 => (removes the last number)
	  4 If x is less than 10 exit else go to 2
   */
   int input, sum = 0;
   int originalInput;
   printf("Please enter a number: ");
   scanf("%d", &input);
   
   //store the original input in a temporary variable
   originalInput = input;
   
   while( input > 0 ){
   	sum = sum + ( input % 10 );
	input = input/10;
   } 
   
   printf("\nThe sum of all digits in %d is %d", originalInput, sum);
}
