//SUDOKU
//CHALLENGE DESCRIPTION:
//
//Sudoku is a number-based logic puzzle. It typically comprises of a 9*9 grid with digits so that each column, each row and each of the nine 3*3 sub-grids that compose the grid contains all the digits from 1 to 9. For this challenge, you will be given an N*N grid populated with numbers from 1 through N and you have to determine if it is a valid sudoku solution. You may assume that N will be either 4 or 9. The grid can be divided into square regions of equal size, where the size of a region is equal to the square root of a side of the entire grid. Thus for a 9*9 grid there would be 9 regions of size 3*3 each.
//
//INPUT SAMPLE:
//
//Your program should accept as its first argument a path to a filename. Each line in this file contains the value of N, a semicolon and the sqaure matrix of integers in row major form, comma delimited. E.g.
//
//4;1,4,2,3,2,3,1,4,4,2,3,1,3,1,4,2
//4;2,1,3,2,3,2,1,4,1,4,2,3,2,3,4,1
//OUTPUT SAMPLE:
//
//Print out True/False if the grid is a valid sudoku layout. E.g.
//
//True
//False

#include <iostream>
#include <fstream>
#include <math.h>

class SudokuChecker {
private:
    int N;
    int *across;
    int *down;
    int *sub;
    int curCount=0;
    
public:
    SudokuChecker(int n)
    {
        N = n;
        across = new int[N]();
        down = new int[N]();
        sub = new int[N]();
        
        std::fill_n(across, N, 0);
        std::fill_n(down, N, 0);
        std::fill_n(sub, N, 0);
    }
    
    void process(int i)
    {
        int row = (int) (curCount / N);
        int col = curCount % N;
        
        int sqn = (int) sqrt(N);
        int subCol = (int) col / sqn;
        int subRow = (int) row / sqn;
        int subIndex = (subRow * sqn) + subCol;
        
        int bitShift = 1 << (i-1);
        across[row] |= bitShift;
        down[col] |= bitShift;
        sub[subIndex] |= bitShift;
        
        curCount++;
    }
    
    std::string isValid()
    {
        int validNum = 1;
        for (int i = 0; i < N; i++) {
            validNum |= 1 << (i);
        }
        for (int i = 0; i < N; i++) {
            if (across[i] != validNum || down[i] != validNum || sub[i] != validNum) {
                return "False";
                
            }
        }
        return "True";
    }
};

int main(int argc, const char *argv[])
{
    std::ifstream inputFile;
    inputFile.open(argv[1]);
    char input[1];
    char input2[2];
    SudokuChecker *checker;
    int i;

    do {
        inputFile.read(input, 1);

        if (inputFile.eof()) {
            return 0;
        }
        int n = input[0] - '0';

        checker = new SudokuChecker(n);
        
        for (i = 0; i < n * n; i++) {
            inputFile.read(input2, 2);
            checker->process(input2[1] - '0');
        }
        
        std::cout << checker->isValid() << std::endl;
        
        free(checker);
        checker = NULL;
        
        // new line
        inputFile.read(input, 1);
        
    } while (!inputFile.eof());
    
    inputFile.close();
}