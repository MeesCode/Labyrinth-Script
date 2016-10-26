# 1  	Preface

Brainfuck is a very small programing language, consisting of only eight statements. The language is "Turing-complete" which means that (theoretically) it can perform any computation that can be done in (for example) Basic or C.

Labyrinth Script is a programming language that is backwards compatible with BrainFuck. This means that any code that has been mode in Labyrinth Script is also Labyrinth Script code. Labyrinth Script, however, has a lot more features than Labyrinth Script as well as an unique syntax that kind of resembles the programming language Befunge, but functions very differently.

Anyone wanting to learn how to write Labyrinth Script code should familiarize themselves with BrainFuck first. The basics will be explained in this document, but more in-depth tutorials are easily found online.

# 2  	The  Labyrinth Script model

The  Labyrinth Script language uses

* a simple machine model consisting of the program and instruction pointer, as well as
100x100 array of 32-bit integer cells initialized to zero;
* a movable data pointer (initialized to point to the top leftmost cell of the array); and;
* one global variable that can be recovered anywhere independently of the data pointers position. and;
* two streams of bytes for input and output (most often connected to a keyboard and a monitor respectively, and using the ASCII character encoding).



Unlike some small languages, the program memory and data memory are separated. No command can make the data cells affect the program cells.

# 3  	The basics: Labyrinth Script statements

The language consists of the commands listed below.



<table>
  <tr>
    <td>Character</td>
    <td>Explanation</td>
    <td>In other words</td>
  </tr>
  <tr>
    <td>></td>
    <td>increment the data pointers x position.</td>
    <td>Move the cursor one cell right.</td>
  </tr>
  <tr>
    <td><</td>
    <td>decrement the data pointers x position.</td>
    <td>Move the cursor one cell left.</td>
  </tr>
  <tr>
    <td>+</td>
    <td>increment the integer at the data pointer.</td>
    <td>Increase the value of the current cell by 1</td>
  </tr>
  <tr>
    <td>-</td>
    <td>decrement the integer at the data pointer.</td>
    <td>Decrease the value of the current cell by 1</td>
  </tr>
  <tr>
    <td>.</td>
    <td>output a character, the ASCII value of which being the byte at the data pointer.</td>
    <td>Write the ASCII character of the current cell on screen / to file</td>
  </tr>
  <tr>
    <td>:</td>
    <td>output the raw data of the 32-bit integer cell at the data pointer.</td>
    <td>Write letters instead of ASCII characters</td>
  </tr>
  <tr>
    <td>\</td>
    <td>Output a newline character.</td>
    <td>Make the program press the enter key.</td>
  </tr>
  <tr>
    <td>,</td>
    <td>accept one character of input, storing its value in the integer at the data pointer.</td>
    <td>Input a byte and store it in the current cell.</td>
  </tr>
  <tr>
    <td>[</td>
    <td>if the integer at the data pointer is zero, then instead of moving the instruction pointer forward to the next command, jump it forward to the command after the next ] command.</td>
    <td>"While" the current cell is nonzero, perform the statements between the brackets.</td>
  </tr>
  <tr>
    <td>]</td>
    <td>if the integer at the data pointer is nonzero, then instead of moving the instruction pointer forward to the next command, jump it back to the command after the previous [ command.</td>
    <td>End of a while loop</td>
  </tr>
  <tr>
    <td>r</td>
    <td>flips the direction in which instructions are read 90 degrees to the right.</td>
    <td>The code will now be read in a different direction.</td>
  </tr>
  <tr>
    <td>l</td>
    <td>flips the direction in which instructions are read 90 degrees to the left.</td>
    <td>The code will now be read in a different direction.</td>
  </tr>
  <tr>
    <td>?</td>
    <td>Behaves like 'r’ when the data pointer is zero, otherwise continue reading in the same direction. This essentially creates a branch out of the normal command flow.</td>
    <td>If the current cell is zero, flip right. Else, continue in the same direction.</td>
  </tr>
  <tr>
    <td>v</td>
    <td>Decrements the data pointers y position.</td>
    <td>Move the cursor one cell down.</td>
  </tr>
  <tr>
    <td>^</td>
    <td>Increments the data points y position.</td>
    <td>Move the cursor one cell up.</td>
  </tr>
  <tr>
    <td>#</td>
    <td>Store the integer of the current data pointer as the global variable.</td>
    <td>Save current cell globally.</td>
  </tr>
  <tr>
    <td>@</td>
    <td>Recover the value of the global data variable as the current data pointers integer.</td>
    <td>Recover current cell globally.</td>
  </tr>
  <tr>
    <td>\*+</td>
    <td>Take the sum of the integer at the current data pointer and the global variable and store this as the integer at the current data pointer.</td>
    <td>Add the global variable and the current cell.
A = A + B</td>
  </tr>
  <tr>
    <td>\*-</td>
    <td>Take the subtraction of the global variable from the integer at the current data pointer and store this as the integer at the current data pointer.</td>
    <td>Subtract the global variable from the current cell.
A= A - B</td>
  </tr>
  <tr>
    <td>\*\*</td>
    <td>Take the multiplication of the integer at the current data pointer and the global variable and store this as the integer at the current data pointer.</td>
    <td>Multiply the global variable and the current cell.
A = A * C</td>
  </tr>
  <tr>
    <td>\*^</td>
    <td>Take the integer at the current data pointer and the global variable and store the integer to the power of the global variable as the integer at the current data pointer.</td>
    <td>Take the current cell to the power of the global variable.
A = pow(A, C) = AC</td>
  </tr>
  <tr>
    <td>\*%</td>
    <td>Take the integer at the current data pointer and the global variable and store the integer  modulo the global variable as the integer at the current data pointer.</td>
    <td>Take the current cell modulo the global variable.
A = mod(A, C) = A % C </td>
  </tr>
  <tr>
    <td>~</td>
    <td>Terminate the program.</td>
    <td>Stop.</td>
  </tr>
</table>


## 3.1	Labyrinth Script programs

A  Labyrinth Script program is a sequence of these commands. Other characters can be placed in between the commands and are ignored. The commands are executed sequentially except at the end of a [] loop; an instruction pointer begins at the first command, and each command it points to is executed, after which it normally moves forward to the next command.

The program terminates when the instruction pointer moves past the last command.

# 4  Your first program in Labyrinth Script

## 4.1	Read-and-write (cat)

Your first program will take input from the user, and then output that same value on the output. This program is also known as *cat*, named after the unix command. The full syntax of this program is:

```
,[.,]
```

### 4.1.1	Explanation

This program had five characters: , [ . , ]

1. The first character is the comma. This reads one ASCII value from the keyboard.

2. The second character is the open square bracket [. This is the start of the while loop that ends with the closing square bracket ]. If the memory cell the program is pointing at contains the value zero at the moment of execution, the while loop will end and the program will continue after the closing square bracket. If there is no further code, the program ends.

3. The third character is the decimal point. This will write the current value of the memory cell to the screen. Note that we requested the user to input a character before the while loop. if we hadn't, the program would have ended right away without printing anything.

4. The fourth character is again the comma. Having printed the output, the user is again asked to input a value.

5. The 5th and last character of this "program" closes the while loop. If at some moment the program finds a memory cell containing 0 at the moment the opening bracket is executed, the program will continue after this closing bracket.



Note the order within the while loop: first a character is printed, then a new character is read. This is because of the while loop. In order for the loop to even start, the user must first have input a character.

## 4.2	Hello World!

The 'Hello World' program is used as a demonstration of a simple program: putting a statement on-screen.

In  Labyrinth Script this is not a simple task. The nature of Labyrinth Script (each letter must be defined in advance by assigning the appropriate ASCII value to a cell) makes the program rather large.


```
++++++++++[>+++++++>++++++++++>+++>+<<<<-] >++.>+.+++++++..+++.>++.
<<+++++++++++++++.>.+++.------.--------.>+.>.
```

By utilizing the ‘r’ and ‘l’ commands, one can manually change the flow if the program. Like we saw in the specification, ‘r’ makes the command flow turn right, and ‘l’ makes it go left.

This would be the equivalent of the previous hello world program:
```
++++++++++[>+++++++>+++++++++r
                             +
                             >
                             +
                             +
                             l+>+<<<<-] >++.>+.+++++++..+++.>++.
<<+++++++++++++++.>.+++.------.--------.>+.>.
```

Notice how, when we reach the end of the first line, the program is continued on the next line. This is a consequence of maintaining backward compatibility with BrainFuck. This also makes the ‘r’ and ‘l’ commands redundant in this example.

### 4.2.1	Explanation of the Hello World program

Since Labyrinth Script can only output letters by printing their corresponding ASCII Codes, the hello world program has to assign the correct values to some cells.

In this case the program assigns the values 70, 100, 30 and 10 to some cells, since these are close to the desired ASCII values. The program then proceeds to add and subtract from these cells to get the specific values it needs to print.

To get more info on this we highly recommend anyone not too familiar with BrainFuck to read some simple tutorials.

# 5	Some Labyrinth Script specific statements**

## 5.1 IF-statement

In comparison to BrainFuck are if statements really easy to do in Labyrinth Script. We saw in the specification that we can use the ‘?’ command ass a conditional statement where the control flow will make a right turn when the value of the current cell is zero. In other cases the control flow will continue going like it was before.

```
+++---?+:~
      +
      +
      :
      ~
```

Output: 2

The value of the cell at the ‘?’ command is zero because we add three and immediately subtract three. If the flow would have continued normally the output would have been "1", but since the control flow took a right turn the output is “2”.

Notice how the usage of tildes is actually redundant, it is good practice to end every possible path with a tilde so the chance of something going wrong is minimized.  

## 5.2 The global variable

To make easy arithmetic possible it is necessary to be able to access two number at the same time. Since in BrainFuck you can only access the vale under data pointer you can never do an easy computation. Labyrinth Script solves this problem by giving the user the possibility to use a global variable that you can access at any time.

To store a value as the global variable you can use the ‘#’ command. This command saves the value of the current cell as the global variable.

To assign the value of the global variable to the current cell one uses the ‘@’ command.

This is an example of the usage of the global variable:

```
+++#---@:
```

Output: 3

Here is the same code explained with some more detail:

```
+++   ADD 3 TO THE CURRENT CELL
#     SAVE THE VALUE (3) AS THE GLOBAL VARIABLE
---   SUBTRACT 3 FROM THE CURRENT CELL (0)
@     ASSIGN THE VALUE (3) OF THE GLOBAL VARIABLE
:     PRINT
```

# 5.3 Arithmetic

BrainFuck does not allow for any arithmetic besides increasing or decreasing the cell under the data pointer. Labyrinth Script however allows for the usage of the arithmetic modifier ‘\*’. This modifier will stay active until any arithmetic statement is executed, these statements include ‘+’, ‘-’, ‘%’, ‘%’, ‘^’ and ‘\*’.

Every arithmetic statement behaves in the same way:

```
current_cell = statement(current_cell, global_variable);
```

Where "current_cell" is the integer value of of the cell under the data pointer, and “global_variable” the value of the global variable.

Here are some examples of arithmetic statements in action:

```
++#+*+:	3+2=5
++#+*-:	3-2=1
++#+**:	3*2=6
++#+*%:	3%2=1
++#+*^:	3^2=9
```

# 6  	Simple Labyrinth Script programs

## 6.1	Make a lowercase letter uppercase

### 6.1.1    Description

This small piece will request the user to enter a key. If the key entered is <Enter> (ASCII 10), the loop does not start. Otherwise, the program will subtract 32 from the value and outputs the result. The user can again enter a key. Note that this is an example of an if-then.

### 6.1.2    Code

```
++#+++**#         STORE VALUE 10 GLOBALLY
,*-[*-*---.,*-]   SUBTRACT BOTH 10 AND 22 FROM THE INPUT
```

## 6.2    Fibonacci numbers

### 6.2.1    Description

This program prints Fibonacci numbers. For more about the Fibonacci sequence see[ Wikipedia](http://en.wikipedia.org/wiki/Fibonacci_number).

### 6.2.2	Code

```
+:\>+:\<            SET FIRST TWO CELLS ONE
[#>>*+<#>*+:\<]     ADD THE PREVIOUS TWO CELLS TO THE CURRENT ONE
```

This code will quickly run out of memory, since it only uses 100 of possible 10,000 memory cells available. This is not really a problem since after only a couple of iterations integer overflow will occur.

## 6.3 FizzBuzz

### 6.3.1    Description

FizzBuzz has been used as an interview screening device for computer programmers. Creating a list of the first 100 FizzBuzz numbers is a trivial problem for any would-be computer programmer, so interviewers can easily sort out those with insufficient programming ability.

The idea is to print a list of 100 consecutive numbers starting at 1, and replacing every number divisible by 3 with Fizz, divisible by 5 with Buzz and everything divisible by 3 and 5 with FizzBuzz.

In this example we only print F, B and FB for the sake of convenience.

### 6.3.2 Code

```
v+++#+*^++++++^           SET F
>v+++#+*^++^              SET B
<+++++ +++++#**>          SET AMOUNT OF LOOPS (100)
<vv+++#>@++>+++++**<<^^   SET 3 5 AND 15

[>+#>@>@>@<<vv#^^>>*%?<<<vv#^^>>*%?<<<vv#^^>>*%?<:\<-]~
                     <            <            < Fizz
                     <            < Buzz       l<v.\^-]~
                     < FizzBuzz   lv.\^<-]~
                     l<v.>.\^<-]~
```

### 6.3.3 Explanation

We won’t go into too much detail, but you can see that a program written in Labyrinth Script can look pretty unreadable.

The first four lines set the ASCII value for F and B, the amount of loops and the values 3, 5 and 15. Those last 3 values will be used to determine whether the current number should be replaced, we use the modulo operator for this.

The three branches from the main loop are if statements that each print out ‘FB’, ‘F’ or ‘B’.

You can see another ‘:’ at the end of the main loop which will print the number if none of the IF-branches are followed.

This is a good example of a program that has only one loop, but four different ways to end the loop. Since the "Buzz" branch is the last branch that will be called, this is the only branch that needs a tilde behind it to stop the control flow from overflowing. But since it is good practice to add a tilde after every end of a branch we will add them anyway. This can help us in the future when we want the program to output more numbers.
