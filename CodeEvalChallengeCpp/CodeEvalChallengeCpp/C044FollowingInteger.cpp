//
//  C044FollowingInteger.cpp
//  CodeEvalChallengeCpp
//
//  Created by Raymond Gunawan on 3/12/14.
//  Copyright (c) 2014 Raymond Gunawan. All rights reserved.
//

//FOLLOWING INTEGER
//CHALLENGE DESCRIPTION:
//
//Credits: This challenge has appeared in a past google competition
//
//You are writing out a list of numbers.Your list contains all numbers with exactly Di digits in its decimal representation which are equal to i, for each i between 1 and 9, inclusive. You are writing them out in ascending order. For example, you might be writing every number with two '1's and one '5'. Your list would begin 115, 151, 511, 1015, 1051. Given N, the last number you wrote, compute what the next number in the list will be. The number of 1s, 2s, ..., 9s is fixed but the number of 0s is arbitrary.
//
//INPUT SAMPLE:
//
//Your program should accept as its first argument a path to a filename. Each line in this file is one test case. Each test case will contain an integer n < 10^6. E.g.
//
//115
//842
//8000
//OUTPUT SAMPLE:
//
//For each line of input, generate a line of output which is the next integer in the list. E.g.
//
//151
//2048
//80000


#include <iostream>
#include <fstream>
#include <vector>

void sortedPush(std::vector<int> &options, int toPush)
{
    for (auto option = options.begin(); option != options.end(); option++) {
        if (*option >= toPush) {
            options.insert(option, toPush);
            return;
        }
    }
    
    options.push_back(toPush);
}

int pickLargerOption(int current, std::vector<int> &options)
{
    for (auto option = options.begin(); option != options.end(); option++) {
        if (*option > current) {
            return *option;
        }
    }
    return -1;
}

std::string getOtherDigits(std::vector<int> &options)
{
    std::string output;
    
    for (int option : options) {
        output += std::to_string(option);
    }
    
    options.clear();
    return output;
}

std::string printOptions(std::vector<int> &options)
{
    std::string output;
    
    for (int option : options) {
        output += std::to_string(option);
    }
    
    return output;
}

void remove(std::vector<int> &options, int toRemove)
{
    for (auto i = options.begin(); i != options.end(); i++) {
        if (*i == toRemove) {
            options.erase(i);
            return;
        }
    }
}

int popSmallestNonZero(std::vector<int> &options)
{
    for (auto i = options.begin(); i != options.end(); i++) {
        if (*i > 0) {
            int output = *i;
            options.erase(i);
            return output;
        }
    }
    
    return -1;
}

std::string getNext(std::string cur)
{
    std::vector<int> options;
    for (long i = cur.size() - 1; i > -1; i--) {
        int current = cur[i] - '0';
        sortedPush(options, current);
        cur.erase(i);
        int nextOption = pickLargerOption(current, options);
        if (nextOption != -1) {
            cur += std::to_string(nextOption);
            remove(options, nextOption);
            cur += getOtherDigits(options);
            return cur;
        }
    }

    cur = std::to_string(popSmallestNonZero(options));
    sortedPush(options, 0);
    cur += getOtherDigits(options);
    
    return cur;
}

int main(int argc, const char *argv[])
{
    std::ifstream inputFile;
    inputFile.open(argv[1]);
    
    std::string line;
    
    while(getline(inputFile, line)) {
        auto next = getNext(line);
        std::cout << next << std::endl;
    }
    
    return 0;
}
