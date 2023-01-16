using sudoku.dancingLinks;
using sudoku.validating;
using sudoku.exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace testing;

/* class to test the sudoku project */
[TestClass]
public class UnitTest
{
    // tests a correct 9X9 sudoku grid
    [TestMethod]
    public void TestCorrect9X9SudokuGrid()
    {
        // arange
        string input = "800000070006010053040600000000080400003000700020005038000000800004050061900002000";
        string output = "831529674796814253542637189159783426483296715627145938365471892274958361918362547";

        // act
        DLXSolver dLXSolver = new DLXSolver();
        string result = dLXSolver.Solve(input);

        // assert
        Assert.AreEqual(output, result);
    }

    // test an unsolable 9X9 sudoku grid
    [TestMethod]
    public void TestUnsolvable9X9SudokuGrid()
    {
        // arange
        string input = "800000070006010053040600000000080400003000700020005038000000800004050061900002005";

        // act
        DLXSolver dLXSolver = new DLXSolver();

        // assert
        Assert.ThrowsException<UnsolvableGridException>(() => dLXSolver.Solve(input));
    }

    // tests only zeroes 9X9 sudoku grid
    [TestMethod]
    public void TestOnlyZeroes9X9SudokuGrid()
    {
        // arange
        string input = "000000000000000000000000000000000000000000000000000000000000000000000000000000000";
        string output = "123456789687139254495278136712893465956714823348625917261347598879561342534982671";

        // act
        DLXSolver dLXSolver = new DLXSolver();
        string result = dLXSolver.Solve(input);

        // assert
        Assert.AreEqual(output, result);
    }

    // tests a correct 16X16 sudoku grid
    [TestMethod]
    public void TestCorrect16X16SudokuGrid()
    {
        // arange
        string input = "10023400<06000700080007003009:6;0<00:0010=0;00>0300?200>000900<0=000800:0<201?000;76000@000?005=000:05?0040800;0@0059<00100000800200000=00<580030=00?0300>80@000580010002000=9?000<406@0=00700050300<0006004;00@0700@050>0010020;1?900=002000>000>000;0200=3500<";
        string output = "15:2349;<@6>?=78>@8=5?7<43129:6;9<47:@618=?;35>236;?2=8>75:94@<1=4>387;:5<261?@98;76412@9:>?<35=<91:=5?634@8>2;7@?259<>31;7=:68462@>;94=?1<587:37=91?235;>8:@<46583;1:<7264@=9?>?:<4>6@8=9372;152358<>:?6794;1=@:7=<@359>8;1642?;1?968=4@25<7>3:4>6@7;12:?=3589<";

        // act
        DLXSolver dLXSolver = new DLXSolver();
        string result = dLXSolver.Solve(input);

        // assert
        Assert.AreEqual(output, result);
    }

    // test an unsolable 16X16 sudoku grid
    [TestMethod]
    public void TestUnsolvable16X16SudokuGrid()
    {
        // arange
        string input = "10023400<06000700080007003009:6;0<00:0010=0;00>0300?200>000900<0=000800:0<201?000;76000@000?005=000:05?0040800;0@0059<00100000800200000=00<580030=00?0300>80@000580010002000=9?000<406@0=00700050300<0006004;00@0700@050>0010020;1?900=002000>000>000;0200=35004";

        // act
        DLXSolver dLXSolver = new DLXSolver();

        // assert
        Assert.ThrowsException<UnsolvableGridException>(() => dLXSolver.Solve(input));
    }

    // tests only zeroes 16X16 sudoku grid
    [TestMethod]
    public void TestOnlyZeroes16X16SudokuGrid()
    {
        // arange
        string input = "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
        string output = "123456789:;<=>?@?=@714;<368>29:5<;:>2=9?145@368768593:>@27?=14;<9123?@475<>8:;6=:6?;815=@34972<>>@<=926;?17:53484578>3<:=26;@19?3?127<84:>@6;=598<=6@?15;934>72:79>@:;268=15?<3454;:=>39<?278@16236145=>78<?9:@;=:8?67@14;93<5>2@>9<;8:265=14?73;745<9?3>@:268=1";

        // act
        DLXSolver dLXSolver = new DLXSolver();
        string result = dLXSolver.Solve(input);

        // assert
        Assert.AreEqual(output, result);
    }

    // tests a correct 25X25 sudoku grid
    [TestMethod]
    public void TestCorrect25X25SudokuGrid()
    {
        // arange
        string input = "000=0C000@0H07I00B0090>;0<0;09=5GF2@C010I:00000?0000?A0;0000F2000030CD0H60I:0600?A00E<>0005G0200@0000@00000I:H0E0A4800>;0F0=0130000070:40000089<00G00=5G0000CD130:H600A00080<>00<0002000F0@CD100:H000E?A4BE00000900F005010@CI:000I0067E000B00>;0=0G00030CD00:0600?A009000200GF0100CD000C:0070000E0>;00005002=0GF0300D100:00E000B0800089<>002=50000C000000040E0000000>0805G020C01000I:060A4009<0;0000F2@0003000:0000:0000?0;000>0000000030CD03@I0060004BE0>00020000200GF00@0060000B00A4>00000000>G000001000H07000A0BE02=00D00@C007I000E?0<00090;00<00F200D03@0067I000400?A40890>;2=0G00@000H600:060I0A0000>009<G00=500D130000000:H0E?00B90008F205G";
        string output = "GF2=5CD13@:H67IA4BE?9<>;8<>;89=5GF2@CD13I:H67BE?A4BE?A4;89<>F2=5G13@CD:H67I:H67I?A4BE<>;895GF2=3@CD13@CD167I:HBE?A489<>;GF2=513@CDH67I:4BE?A;89<>5GF2=5GF2=@CD13I:H67?A4BE89<>;9<>;82=5GF3@CD17I:H64BE?A4BE?A>;89<GF2=5D13@CI:H67I:H67E?A4B9<>;8=5GF213@CD7I:H6BE?A489<>;2=5GFD13@CD13@C:H67IA4BE?>;89<=5GF2=5GF23@CD17I:H6E?A4B;89<>89<>;F2=5G13@CD67I:HA4BE?A4BE?<>;895GF2=CD13@7I:H6?A4BE9<>;8=5GF2@CD1367I:H67I:H4BE?A;89<>F2=5GCD13@CD13@I:H67?A4BE<>;892=5GF2=5GF13@CD67I:HBE?A4>;89<;89<>GF2=5D13@CH67I:?A4BEF2=5GD13@CH67I:4BE?A<>;89>;89<5GF2=CD13@:H67IE?A4BE?A4B89<>;2=5GF3@CD1H67I:H67I:A4BE?>;89<GF2=5@CD13@CD137I:H6E?A4B9<>;8F2=5G";

        // act
        DLXSolver dLXSolver = new DLXSolver();
        string result = dLXSolver.Solve(input);

        // assert
        Assert.AreEqual(output, result);
    }


    // test an unsolable 25X25 sudoku grid
    [TestMethod]
    public void TestUnsolvable25X25SudokuGrid()
    {
        // arange
        string input = "0;0G0H00E4?=<0030DF000007097@A8000G0H:0E200<00BD05BD003@0000C0060IE4H:12?000?0<1500DF90@006;CG80000HIE400<000=0F00BA007@86000:0E4H0<10?00F03@0>00G000C06;000H0IE2?=00030D07@A00A>0700860000H:I120=<0000F300F500009;0000:0E40<10?00200<F5000000@0800C00:IE400000D05000>070G86000H:I000IE0?=0103BD007@009C080;G860004H:010?=<0030D970A>0A0970000;I0400<020=F500D50B0F0000>60C0800IE4=<00?F00BD>97@A06;CG40000?=<120<02?00000@A090CG86;000:I4000E00=0100B0F000A>;0000CG0000E4H:<12?0DF00B>00@070A00;0G060I04H0<0000F53B00@0>00CG0H:0E0?00020D050D003BA>070G86;004H002?=<10=<020B0F570A09;CG86I00H:E00:I00?00F500D>90@06;008;C086:0E4000020B0F530>90G";

        // act
        DLXSolver dLXSolver = new DLXSolver();

        // assert
        Assert.ThrowsException<UnsolvableGridException>(() => dLXSolver.Solve(input));
    }

    // tests only zeroes 25X25 sudoku grid
    [TestMethod]
    public void TestOnlyZeroes25X25SudokuGrid()
    {
        // arange
        string input = "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
        string output = "123456789:;<=>?@ABCDEFGHIDBGH<15;FI48:EC3?>962@=7AF;8EI2?@CG15DAB4=H7<39:6>9:=>@3DA<H276GF15I8E4?B;C?A67C4>E=B39IH@2:F;G158<DE1234IH5896D<:>;G@A?7BC=FCDIF>@16G?=357H829<B;4AE:=@9BH:27;>F1A8G645ECD3I?<;<AG?D3=EFC4B9I71:H>6258@5678:<4BAC?2@;ED3=IFG1>9H4I123?B958DE><:GCA6;@H7F=GH@<9FI16=BC357ED2?8:>4A;:E?CA>@27;HF1=8BI459<G3D6>8F=;CG3D<IA469H71@:?E25B75D6BHE4:A@G2?;<>3F=I81C934E1289?H5:=;F<A6CB@>IDG7AFCIDG=>167@E35:982HB;<4?H>:@GBFD278I?1A=;<45C693E<=B?8;CI3E9HG46>FD17A:@25695;7A:<4@>BC2D?EG3IF=H182349156F?D<:8C=I@;>AH7EBGIC>AE78GB15;9D3FH6:2=<?@4BGHDF9;CI2E>7@15<?=48A6:3@?<:=EAH>3G6FB4987D15C;I287;56=<:@4A?HI2CBEG39DF>1";

        // act
        DLXSolver dLXSolver = new DLXSolver();
        string result = dLXSolver.Solve(input);

        // assert
        Assert.AreEqual(output, result);
    }

    // tests a sudoku grid with incorrect character in it
    [TestMethod]
    public void TestInorrectCharacters9X9SudokuGrid()
    {
        // arange
        string input = "#00000070006010053040600000000080400003000700020005038000000800004050061900002000";

        // act
        Validator validator = new Validator();

        // assert
        Assert.ThrowsException<InvalidCharacterException>(() => validator.ValidateStringGrid(input));
    }

    // tests a sudoku grid with an incorrect size
    [TestMethod]
    public void TestInorrectSizeOfSudokuGrid()
    {
        // arange
        string input = "1000";

        // act
        Validator validator = new Validator();

        // assert
        Assert.ThrowsException<InvalidGridSizeException>(() => validator.ValidateStringGrid(input));
    }

    // tests a sudoku grid with a duplication in row, column or cell
    [TestMethod]
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
        Assert.ThrowsException<DuplicateValueException>(() => validator.ValidateGrid(grid));
    }
}
