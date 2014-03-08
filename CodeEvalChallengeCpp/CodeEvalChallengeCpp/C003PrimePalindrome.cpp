//
//  C003PrimePalindrome.cpp
//  CodeEvalChallengeCpp
//
//  Created by Raymond Gunawan on 3/7/14.
//  Copyright (c) 2014 Raymond Gunawan. All rights reserved.
//
//
//#include <iostream>
//
//bool isPrime(int toCheck)
//{
//    for (int i = 2; i < toCheck; i++) {
//        if (toCheck % i ==0) {
//            return false;
//        }
//    }
//    return true;
//}
//
//bool isPalindrome(int toCheck)
//{
//    int hundred = (int) toCheck / 100;
//    int singles = toCheck % 10;
//    return hundred == singles;
//}
//
//int main(int argc, const char * argv[])
//{
//    for (int i = 1000; i > 0; i--) {
//        if (isPrime(i) && isPalindrome(i)) {
//            std::cout << i << std::endl;
//            break;
//        }
//    }
//    
//    return 0;
//}