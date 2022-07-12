//
// Created by firedef on 7/13/22.
//

#ifndef CPP_PALINDROMENUMBER_H
#define CPP_PALINDROMENUMBER_H

/**
 * https://leetcode.com/problems/palindrome-number/
 * Given an integer x, return true if x is palindrome integer.
 * An integer is a palindrome when it reads the same backward as forward.
 * For example, 121 is a palindrome while 123 is not.
 **/
class PalindromeNumber {
public:
    static bool Solve(int x) {
        // base of number (10 for decimal, 16 for hex, 2 for binary, etc.)
        const int numBase = 10;
        
        // numbers less than 0 are never palindromic
        if (x < 0) return false;
        
        // index = ((int) floor(x/numBase)) * numBase
        int index = 1;
        while (x / index >= numBase) index *= numBase;

        int left, right;
        while (x) {                     // while x greater then 0
            left = x / index;           // get current left digit from number
            right = x % numBase;        // get current right digit from number

            if (left != right) return false;
            
            x = (x % index) / numBase;  // remove left and right digits
            index /= numBase * numBase; // step back by 2 digits
        }
        
        return true;
    }
};

#endif //CPP_PALINDROMENUMBER_H
