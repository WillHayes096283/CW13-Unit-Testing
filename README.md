# CW13-Unit-Testing
* Date: 4/21/2023
* Author: William Hayes

## Compiling Instructions
Down the Visual Studio solution or press the open in Visual Studios button on GitHub.

To see the tests, into UnitTest1.cs in the BankTest project, select Test in the top menu bar, and click on the run all tests button. Every unit test should pass, showing that the BankAccount class methods are behaving properly.

## Purpose
The purpose of this program is to showcase the usage of unit tests in Visual Studios. This runs through 3 unit tests for the Credit() and Debit() methods of the BankAccount class.

## Unit Tests
The unit tests check for the following:

For Debit()
* Check that the Debit() method works for a valid debit amount.
* Check that the Debit() method throws a ArgumentOutOfRangeException if the debit amount is negative. 
* Check that the Debit() method throws a ArgumentOutOfRangeException if the debit amount is more than the balance amount.

For Credit()
* Check that the Credit() method throws an Exception if the account is frozen.
* Check that the Credit() method throws an ArgumentOutOfRangeException if the credit amount is negative.
* Check that the Credit() method works for a valid credit amount and unfrozen account.

## Notes
*Had an issue with catching the System.Exception for the Credit_WhenAmountIsNegative_ShouldThrowOutOfRangeException() test. I figure out it was because I didn't build the solution.
