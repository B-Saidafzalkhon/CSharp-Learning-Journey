# Exercise 1

1. Sum of Digits in a Number

   * Solution: We run a `while` loop while the number is greater than 0. We use the `% 10` operation to get the last digit, add it to the sum container using `+=`, and then remove the last digit by dividing the number by 10. This process repeats until all digits have been processed.

# Exercise 2

2. Palindrome

   * Solution: We read a string from the user, remove spaces, and ignore letter case. Then we use two pointers: one starts from the left side, and the other starts from the right side. We also create a Boolean variable to check whether the string is a palindrome. While the left pointer is less than the right pointer, the loop continues. On each iteration, we check whether the characters are equal. If they are not equal, we immediately exit the loop and set the Boolean variable to `false`. If they are equal, we continue moving inward: the left pointer increases by 1, and the right pointer decreases by 1. After that, we check the Boolean variable and display the corresponding result.
