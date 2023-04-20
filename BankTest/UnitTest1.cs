/*
 * @file: UnitTest1.cs
 * @date: 4/20/2023
 * @author: William Hayes
 * @brief: This file contains the unit tests the bank.cs file methods.
 * 
 * This file contains unit tests that check the behavior of the BankAccount
 * Debit() and Credit() methods. The Debit() method should: subtract the valid debit amount
 * an account's balance and throw an ArgumentOutOfRangeException if the debit amount is greater
 * than the balance or is negative. The Credit() method should: update the balance correctly,
 * throw an exception is the account is frozen, and throw an ArgumentOutOfRangeException if the
 * credit amount is negative.
 */
using BankAccountNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BankTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Debit(debitAmount);

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("No exception was thrown.");
        }


        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void Credit_WhenAccountIsFrozen_ShouldThrowException()
        {
            double beginningBalance = 11.99;
            double creditAmount = 100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            account.ToggleFreeze();

            account.Credit(creditAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Credit_WhenAmountIsNegative_ShouldThrowOutOfRangeException()
        {
            double beginningBalance = 11.99;
            double creditAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            account.Credit(creditAmount);
        }


        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            double beginningBalance = 11.99;
            double creditAmount = 5.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            account.Credit(creditAmount);

            double actual = account.Balance;
            double expected = 16.99;

            Assert.AreEqual(expected, actual, 0.001, "Account not credited correctly");
        }
    }
}
