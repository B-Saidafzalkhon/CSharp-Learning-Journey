# Logic Practice

Additional algorithmic exercises focused on training problem-solving
and decision-making, beyond the structured syntax practice of the main phases.

Each exercise emphasizes thinking about *how* to approach the problem
before writing code — patterns over syntax.

---

## 1. Sum of Digits in a Number

**Goal:** Given a positive integer, compute the sum of its digits 
without converting it to a string.

**Approach:**
Use a `while` loop while the number is greater than 0.
On each iteration:
- Get the last digit via `% 10`
- Add it to the running sum
- Remove the last digit via integer division `/ 10`

The tandem of `% 10` and `/ 10` is the key insight: one extracts, 
the other shifts.

---

## 2. Palindrome Check

**Goal:** Check if a string reads the same forwards and backwards,
ignoring spaces and letter case.

**Approach:** Two-pointer technique.

Initialize two pointers — `left` at index 0, `right` at the last index.
Move them toward each other while comparing characters at each step.

- If `str[left] != str[right]` at any point → not a palindrome, exit early
- If pointers meet without mismatches → palindrome

Preparation step: trim, remove spaces, convert to lowercase.

This pattern (two pointers converging) reappears in many algorithmic
problems — anagram check, finding pairs in sorted arrays, etc.

---

## 3. Prime Numbers up to N

**Goal:** Print all prime numbers from 2 to N.

**Approach:**
Outer loop iterates each candidate from 2 to N. 
Inner loop checks divisors from 2 to √N.

**Why √N is enough:**
If `n` has divisors, they come in pairs `(d, n/d)`. 
One of each pair is always ≤ √n, the other ≥ √n. 
If we check all divisors up to √n and find none, 
there are no divisors at all — the number is prime.

**Measured impact (N = 1,000,000):**
- Without optimization (check up to `n - 1`): ~49.6 seconds
- With √N optimization: ~5.2 seconds
- **~10× speedup** from a single condition change