//
//  C008ReverseWords.cpp
//  CodeEvalChallengeCpp
//
//  Created by Raymond Gunawan on 3/7/14.
//  Copyright (c) 2014 Raymond Gunawan. All rights reserved.
//
//
#include <fstream>
#include <sstream>
#include <iostream>
#include <vector>

using namespace std;

int main (int argc, const char * argv[])
{
    std::ifstream inputFile;
    inputFile.open(argv[1]);
    
    if (!inputFile.is_open()) {
        return 1;
    }
    
    while (!inputFile.eof()) {
        string line;
        getline(inputFile, line);
        
        std::istringstream iss(line);
        string token;
        
        vector<string> container;
        
        while (getline(iss, token, ' '))
        {
            container.push_back(token);
        }
        
        bool first = true;
        for (long i = container.size() -1; i > -1; i--) {
            if (first) {
                first = false;
            } else {
                cout << " ";
            }
            
            cout << container.at(i);
        }
        cout << endl;
    }
    
    
    inputFile.close();
    
    return 0;
}