//
//  C036MessageDecoding.cpp
//  CodeEvalChallengeCpp
//
//  Created by Raymond Gunawan on 3/10/14.
//  Copyright (c) 2014 Raymond Gunawan. All rights reserved.
//

#include <iostream>
#include <fstream>
#include <sstream>
#include <math.h>

int Value(std::string line, int start, int length)
{
    int power = 0;
    int output = 0;
    for (int i = start + length-1; i >= start; i--) {
        int charVal = line[i] - '0';
        output += charVal * pow(2, power);
        power ++;
    }
    
    return output;
}

int isNum(std::string line, int index)
{
    int val = line[index] - '0';
    return val >=0 && val < 10;
}


int SkipKey(std::string line)
{
    int i;
    
    for (i = 0; i < line.size(); i++) {
        if (isNum(line, i)) {
            return i;
        }
    }
    
    return -1;
}

int GetKeyOffset(int keyLength)
{
    int output = 0;
    
    for (int i = keyLength-1; i > -1; i--) {
        output += pow(2, i) - 1;
    }
    
    return output;
}

int ReadSection(std::string line, int start)
{
    const int keyLengthDigits = 3;
    int keyLength = Value(line, start, keyLengthDigits);
 
    if (keyLength == 0) {
        return -1;
    }
    
    int index = start + keyLengthDigits;
    
    int messageKey;
    
    int keyOffset = GetKeyOffset(keyLength);
    
    do {
        int messageKeyRaw = Value(line, index, keyLength);
        messageKey = messageKeyRaw + keyOffset;
        
        index += keyLength;
        
        if (messageKeyRaw == (pow(2, keyLength)-1)) {
            return index;
        }
        
        std::cout << line [messageKey];
    } while (index < line.length());
    
    return -1;
}

int main(int argc, const char * argv[])
{
    std::ifstream inputFile;
    inputFile.open(argv[1]);
    
    if (inputFile.is_open()) {
        while (!inputFile.eof()) {
            std::string line;
            std::getline(inputFile, line);
            
            int nextSection = SkipKey(line);
            
            do {
                nextSection = ReadSection(line, nextSection);
                if (nextSection == -1) {
                    std::cout << std::endl;
                }
            } while (nextSection != -1);
        }
    }
    
    return 0;
}

