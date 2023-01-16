
# Sudoku Solver Using Dancing Links Algorithm
## What is sudoku
Sudoku is a logic-based number placement puzzle. The objective is to fill a 9x9 grid with digits so that each column, each row, and each of the nine 3x3 sub-grids that compose the grid contains all of the digits from 1 to 9.

This Sudoku solver is capable of solving grids of various sizes, not just the traditional 9x9 grid.

### Rules of sudoku

This rules will represent the constrains in the algorithm.

* Each cell can only contain a number between 1 to 9.
* Each row must contain all of the digits from 1 to 9.
* Each column must contain all of the digits from 1 to 9.
* Each of the nine 3x3 sub-grids must contain all of the digits from 1 to 9.

Since this projest is capable of solving different sizes of sudoku grids
the number that can be filled in the cells and the size of the subgrids
will be diferent in every size of a sudoku grid.


## Dancing links algorithm
The Dancing Links algorithm is a powerful tool for solving the Exact Cover problem, which is a type of problem where a set of items must be selected from a larger set such that each item can only be used once and all items in the smaller set must be used. 

### How it works
The Dancing Links algorithm solves the Exact Cover problem using backtracking, but with a clever data structure that allows for the efficient manipulation of the matrix of constraints. The data structure is a variation of the sparse matrix representation of a constraint matrix, where each row and column is represented by a doubly-linked list. Each element of the matrix is represented by a node in the linked list, which has links to the nodes above, below, to the left, and to the right of it. This allows for the efficient traversal of the matrix in any direction.
The algorithm starts by selecting the column with the fewest ones, and then choosing a row that has a one in that column. It then removes the row and column from the matrix, and recursively continues the process until a solution is found or no more rows can be selected.
When a solution is found, the algorithm "un-chooses" the rows and columns that were removed, and then proceeds to try the next row with a one in the same column. If no more solutions can be found, the algorithm backtracks and tries the next column.

### How to solve a Sudoku using Dancing Links Algorithm
Sudoku can be represented as a constraint satisfaction problem, where each cell in the grid must be filled with a number between 1 and 9 such that no row, column, or 3x3 sub-grid contains duplicate numbers.
To solve a Sudoku puzzle using the Dancing Links algorithm, we can represent the constraints of the problem as a sparse matrix, where each row represents a possible number in a specific cell, and each column represents a constraint (e.g. a specific row, column, subgrid or cell).
The Dancing Links algorithm can then be used to efficiently search for a solution to the puzzle by selecting a column with the fewest ones and a row that has a "1" in that column, representing the choice of a specific number for a specific cell. This choice is then propagated to the other rows and columns by removing the rows and columns that are now invalid due to the chosen number. The algorithm will then continue to make choices and remove rows and columns until a solution is found or no more choices can be made.

## Important sequances in the algorithm

This is the sequance which happenes while running the solve 
method which solves the sudoku grid.

string -> matrix -> cover matrix -> quadruple chained 
list -> list of solution nodes -> matrix -> string 

### Explanation about each station

Here are some important station of changing data stractures in the 
solving algorithm:

* The input for the algorithm is a string representing the sudoku grid to solve.
* The first step is to convert the string into a matrix, which represents the sudoku grid to solve.
* The next step is to create a cover matrix, which is a sparse matrix that represents the problem being solved. Each row of the matrix corresponds to a constraint, and each column corresponds to a possible solution. The constraints include rows, columns, subgrids, and cells.
* The cover matrix is then converted into a quadruple chained list, which is a linked data structure used to represent the matrix.
* The algorithm then uses the quadruple chained list to find the solution nodes of the sudoku grid.
* The solution nodes are then used to create a matrix, which represents the solved sudoku grid.
* The final step is to convert the matrix into a string, which represents the solved sudoku grid.

## Class Explanations

* input/output:
    * IReader - reading interface.
    * FileReader - reading input from a file.
    * ConsoleReader - reading input from the console.
    * IWriter - writing interface.
    * FileWriter - writing output to a file.
    * ConsoleWriter - writing output ro the console.
    * userCommunication - handles the input/output from the user.
* exceptions:
    * DuplicateValueException - duplications in the rows, columns and subgrids.
    * InvalidCharacterException - invalid character in the grid.
    * InvalidGridSizeException - invalid grid size.
    * UnsolvableGridException - unsolvable grid.
    * FileException - file exception.
* dancing-links:
    * DancingNode - note in the dlx list.
    * ColumnNode - column node in the dlx list.
    * Converter - before solving - converts string grid into a grid matrix into a cover matrix.
        after solving - grid matrix into string grid.
    * DLX - creating a dlx list according to the cover matrix, 
        find the solution nodes, and returns them as a solved grid matrix.
    * DLXSolver - gets string grid to solve, solve it and returns string of the solved grid.
* time:
    * watch - stopwatch class.
* Program - main class.
* Sudoku - takes care of the sequance of the program.
