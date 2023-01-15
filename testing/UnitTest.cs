using sudoku.dancingLinks;
using sudoku.validating;
using sudoku.exceptions;
namespace testing;

/* class to test the sudoku project */
public class UnitTest
{
    [Fact]
    public void TestCorrect9X9SudokuGrid()
    {
        // arange
        string input = "800000070006010053040600000000080400003000700020005038000000800004050061900002000";
        string output = "831529674796814253542637189159783426483296715627145938365471892274958361918362547";

        // act
        DLXSolver dLXSolver = new DLXSolver();
        string result = dLXSolver.Solve(input);
         
        // assert
        Assert.Equal(output, result);
    }

    [Fact]
    public void TestCorrect16X16SudokuGrid()
    {
        // arange
        string input = "10023400<06000700080007003009:6;0<00:0010=0;00>0300?200>000900<0=000800:0<201?000;76000@000?005=000:05?0040800;0@0059<00100000800200000=00<580030=00?0300>80@000580010002000=9?000<406@0=00700050300<0006004;00@0700@050>0010020;1?900=002000>000>000;0200=3500<";
        string output = "15:2349;<@6>?=78>@8=5?7<43129:6;9<47:@618=?;35>236;?2=8>75:94@<1=4>387;:5<261?@98;76412@9:>?<35=<91:=5?634@8>2;7@?259<>31;7=:68462@>;94=?1<587:37=91?235;>8:@<46583;1:<7264@=9?>?:<4>6@8=9372;152358<>:?6794;1=@:7=<@359>8;1642?;1?968=4@25<7>3:4>6@7;12:?=3589<";

        // act
        DLXSolver dLXSolver = new DLXSolver();
        string result = dLXSolver.Solve(input);

        // assert
        Assert.Equal(output, result);
    }

    [Fact]
    public void TestInorrect9X9SudokuGrid()
    {
        // arange
        string input = "#00000070006010053040600000000080400003000700020005038000000800004050061900002000";

        // act
        Validator validator = new Validator();

        // assert
        Assert.Throws<InvalidCharacterException>(() => validator.ValidateStringGrid(input));
    }

    [Fact]
    public void TestInorrectSizeOfSudokuGrid()
    {
        // arange
        string input = "1000";

        // act
        Validator validator = new Validator();

        // assert
        Assert.Throws<InvalidGridSizeException>(() => validator.ValidateStringGrid(input));
    }

    [Fact]
    public void TestDuplicatesIn9X9SudokuGrid()
    {
        // arange
        string input = "880000070006010053040600000000080400003000700020005038000000800004050061900002000";

        // act
        Validator validator = new Validator();
        Converter converter = new Converter(input);
        converter.StringToMatrix();
        byte[,] grid = converter.Matrix;

        // assert
        Assert.Throws<DuplicateValueException>(() => validator.ValidateGrid(grid));
    }
}
