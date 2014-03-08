////
////  main.cpp
////  CodeEvalChallengeCpp
////
////  Created by Raymond Gunawan on 3/7/14.
////  Copyright (c) 2014 Raymond Gunawan. All rights reserved.
////
//
//#include <iostream>
//#include <fstream>
//#include <string>
//#include <sstream>
//#include <vector>
//
//using namespace std;
//
//int main(int argc, const char * argv[])
//{
//    
//    ifstream myReadFile;
//    myReadFile.open(argv[1]);
//    string line;
//    if (myReadFile.is_open()) {
//        while (!myReadFile.eof()) {
//            
//            getline(myReadFile, line);
//            
//            std::istringstream iss(line);
//            std::string token;
//            
//            getline(iss, token, ' ');
//            int div0 = atoi(token.c_str());
//            getline(iss, token, ' ');
//            int div1 = atoi(token.c_str());
//            getline(iss, token, ' ');
//            int limit = atoi(token.c_str());
//            
//            
//            if(div0 ==0 || div1 == 0)
//                break;
//            
//            bool first = true;
//            for (int i = 1; i <= limit; i++) {
//                if (first) {
//                    first = !first;
//                } else {
//                    cout << " ";
//                }
//                
//                if ((i % div0 == 0) && (i % div1 == 0)) {
//                    cout << "FB";
//                }
//                else
//                if (i % div0 == 0) {
//                    cout << "F";
//                }
//                else
//                if (i % div1 == 0) {
//                    cout << "B";
//                }
//                else {
//                    cout << i;
//                }
//            }
//            cout << endl;
//        }
//    }
//    myReadFile.close();
//    
//    return 0;
//}
//
//
