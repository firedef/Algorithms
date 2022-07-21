//
// Created by firedef on 7/21/22.
//

#ifndef CPP_EQUATIONSOLUTIONS_H
#define CPP_EQUATIONSOLUTIONS_H

#include <vector>
#include <unordered_map>
#include <iostream>

/*
 * Print all positive integer solutions to the equation a3 + b3 and d are integers between 1 and 1000. 
*/
class EquationSolutions {
public:
    static void solve(int n = 1000) {
        std::unordered_map<int, std::vector<std::pair<int, int>>> map{};
        std::vector<std::tuple<int, int>> solutions{};

        for (int a = 0; a < n; ++a)
            for (int b = 0; b < n; ++b)
                map[a * a * a + b * b * b].push_back({a,b});

        for (const auto &a: map)
            for (const auto &right: a.second)
                for (const auto &left: a.second) {
                    //if ((right.first == left.first && right.second == left.second) || (right.first == left.second && right.second == left.first)) continue;
                    printf("%d**3 + %d**3 == %d**3 + %d**3\n", right.first, right.second, left.first, left.second);
                }
    }
};

#endif //CPP_EQUATIONSOLUTIONS_H
