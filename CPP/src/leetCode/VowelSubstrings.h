//
// Created by firedef on 7/13/22.
//

#ifndef CPP_VOWELSUBSTRINGS_H
#define CPP_VOWELSUBSTRINGS_H

#include <string>

class VowelSubstrings {
public:
    static int Solve(const std::string& word) {
        int len = static_cast<int>(word.size());
        int c = 0;
        
        const uint32_t consonantMask = (
                (1 << ('a' - 'a')) | 
                (1 << ('e' - 'a')) | 
                (1 << ('i' - 'a')) | 
                (1 << ('o' - 'a')) | 
                (1 << ('u' - 'a')));
        
        // bitset for all lowercase letters (utf-8)
        // replacement for unordered_set
        uint32_t presentChars = 0;
        int vowels = 0; // vowel count

        char ch;
        for (int left = 0; left < len; ++left) {
            for (int right = left; right < len; ++right) {
                ch = word[right];
                
                uint32_t mask = 1 << (ch - 'a'); // specific bit for current char
                
                if ((mask & consonantMask) == 0) break; // if not a vowel, break
                
                // if bit is not set (vowel not present), then increment vowel count and set bit
                if ((presentChars & mask) == 0) {
                    presentChars |= mask;
                    vowels++;
                }

                if (vowels == 5) c++; // increment counter if all vowels are present
            }
            
            // clear bitset
            presentChars = vowels = 0;
        }
        
        return c;
    }
};

#endif //CPP_VOWELSUBSTRINGS_H
