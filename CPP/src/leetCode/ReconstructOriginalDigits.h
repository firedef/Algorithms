//
// Created by firedef on 7/13/22.
//

#ifndef CPP_RECONSTRUCTORIGINALDIGITS_H
#define CPP_RECONSTRUCTORIGINALDIGITS_H

#include <string>
#include <array>

class ReconstructOriginalDigits {
public:
    static std::string Solve(const std::string& s) {
        std::array<uint16_t, 26> counts{};  // char counts in string
        std::array<uint16_t, 10> nums{};    // number counts
        
        // count chars
        for (const char c : s) counts[c-'a']++;

        // all even numbers have unique letter 
        nums[0] = counts['z' - 'a']; // Zero
        nums[2] = counts['w' - 'a']; // tWo
        nums[4] = counts['u' - 'a']; // foUr
        nums[6] = counts['x' - 'a']; // siX
        nums[8] = counts['g' - 'a']; // eiGht

        // count odd numbers
        nums[7] = counts['s' - 'a'] - nums[6];                        // Seven - Six
        nums[5] = counts['v' - 'a'] - nums[7];                        // fiVe - seVen
        nums[3] = counts['h' - 'a'] - nums[8];                        // tHree - eigHt
        nums[1] = counts['o' - 'a'] - nums[2] - nums[4] - nums[0];    // One - twO - fOur - zerO
        nums[9] = counts['i' - 'a'] - nums[6] - nums[5] - nums[8];    // nIne - sIx - fIve - eIght
        
        std::string str;
        for (char i = 0; i < 10; ++i) str += std::string(nums[i], static_cast<char>('0' + i));
        
        return str;
    }
};

#endif //CPP_RECONSTRUCTORIGINALDIGITS_H
