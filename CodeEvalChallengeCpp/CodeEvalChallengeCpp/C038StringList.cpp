//
//  C038StringList.cpp
//  CodeEvalChallengeCpp
//
//  Created by Raymond Gunawan on 3/11/14.
//  Copyright (c) 2014 Raymond Gunawan. All rights reserved.
//
//
//STRING LIST
//CHALLENGE DESCRIPTION:
//
//Credits: Challenge contributed by Max Demian.
//
//You are given a number N and a string S. Print all of the possible ways to write a string of length N from the characters in string S, comma delimited in alphabetical order.
//
//INPUT SAMPLE:
//
//The first argument will be the path to the input filename containing the test data. Each line in this file is a separate test case. Each line is in the format: N,S i.e. a positive integer, followed by a string (comma separated). E.g.
//
//1,aa
//2,ab
//3,pop
//OUTPUT SAMPLE:
//
//Print all of the possible ways to write a string of length N from the characters in string S comma delimited in alphabetical order, with no duplicates. E.g.
//
//a
//aa,ab,ba,bb
//ooo,oop,opo,opp,poo,pop,ppo,ppp

#include <iostream>
#include <set>

void writeChar(std::set<char> chars, int &count, std::string curText, int curLevel, int maxLevel)
{
    for (auto item : chars) {
        auto output = curText + item;
        if (curLevel == maxLevel) {
            if (count > 0) {
                std::cout << ',';
            }
            count++;
            std::cout << output;
        } else {
            writeChar(chars, count, output, curLevel + 1, maxLevel);
        }
    }
}

int main (const int argc, const char * argv[])
{
    auto inputFile = fopen(argv[1], "r");
    int c = 0;

    while ((c = fgetc(inputFile)) != EOF) {
        int length = 0;
        do {
            length = 10 * length + (c - '0');
        } while ((c = fgetc(inputFile)) != ',');

        std::set<char> chars;
        
        while ((c = fgetc(inputFile)) != '\n')  {
            chars.insert(c);
        }
        
        int count = 0;
        writeChar(chars, count, "", 0, length-1);
        
        std::cout << std::endl;
    }
}