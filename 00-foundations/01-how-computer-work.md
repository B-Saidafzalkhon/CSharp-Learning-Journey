# How Computers Work

## Main Idea

Understanding how a computer works at its lowest level. Developing an understanding of how processes happen inside a computer, and what specific computer components are needed for.

## What I Learned

1. The principle of how the processor works and how it processes information. The processor executes sets of instructions one after another. Modern processors perform billions of such operations per second. These cycles performed by the processor are called "Fetch-Decode-Execute".

* Fetch - Get the next operation
* Decode - Decode it. Understand what kind of instruction it is
* Execute - Execute it.
  The processor performs billions of such cycles in a very short period of time.

2. Memory hierarchy. Memory in a computer is different, and it differs in size and speed. This is both a useful and necessary topic for understanding how a computer works.

* CPU registers. The fastest memory, because this is literally what the CPU is working with right now.
* Cache memory. Temporary memory where some operations are stored so that everything does not have to be processed again from the beginning.
* RAM. It stores running programs, browser tabs, and their data.
* SSD/HDD disk - This is where permanent data and programs are stored when they are not running or not being used.

3. Number systems. Binary, octal, hexadecimal. A computer basically sees everything as zeros and ones, and it consists of a large number of switches that change zeros and ones when needed. In fact, the logic here is the same as in Boolean algebra.

* Binary — base 2. Digits 0, 1. (A bit is one digit)
* Octal — base 8. Digits 0–7. Used rarely, mostly in older Unix systems.
* Hexadecimal — base 16. Digits 0–9 and letters A–F. Convenient for compactly writing bytes: one byte = two hex digits. Example: 3A = 58 in decimal = 00111010 in binary.
* Byte = 8 bits = 2⁸ = 256 different values.

4. Files, folders, paths. A file is a long sequence of bytes on a disk that has a name. Text, video, image — all of these are files. A file extension (.txt, .pdf, .cs) is a part of the name that tells programs how to open the file. An important nuance: an extension is just text, it can be changed, but the content will not change because of that. The real format is determined by the first bytes of the file, not by the extension.

A path is literally a reference to a file or, in other words, an "address" that shows where a certain file is located. There are 2 types of paths.

1. Absolute path. Directly from the root: C:\Users\User\Project
2. Relative path. From the current location: .\User\Project

## "Aha Moments"

1. Moments of realization that the principles of how computers work are very similar to topics from discrete algebra. Especially the section about Boolean algebra and combinatorial configurations. There are many similarities in the principles.
2. The information about memory hierarchy was also surprising to me. At the same time, it was very logical and interesting. The idea that memory has several levels was new to me, and the information about memory speed was also new.
3. The cycles performed by the processor. A detailed explanation of how it works was informative, because now there is an understanding of how the processor executes instructions in general.

## Useful for the Future

1. Special symbols: Dot (".") - current folder. Two dots ("..") - one level up.
2. Encoding tables (ASCII, Unicode/UTF-8).
