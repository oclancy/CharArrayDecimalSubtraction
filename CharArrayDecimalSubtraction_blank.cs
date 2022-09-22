namespace GResearch.CharArrayDecimalSubtraction;

public class UnitTest1
{
    /*
        Subtract array a from array b and return result
        Do not use inbuilt functions (e.g. int.Parse)
        Do not use types double, decimal, float or functions that return same (e.g. Math.Pow)
    */


    private char[] CharArrayDecimalSubtraction(char[] a, char[] b)
    {
        return new[]{'0'};
    }
    
    [Fact]
    public void Test1()
    {
        // 5 - 3 = 2.0 
        Assert.Equal(new []{'2','.','0'}, CharArrayDecimalSubtraction(new []{'5'}, new []{'3'}));

        // 11.0 - 10.0 = 1.0 
        Assert.Equal(new []{'1','.','0'}, CharArrayDecimalSubtraction(new []{'1','1','.','0'}, new []{'1','0','.','0'}));

        // 10.0 - 9.0 = 1.0 (diff array length)
        Assert.Equal(new []{'1','.','0'}, CharArrayDecimalSubtraction(new []{'1','0','.','0'}, new []{'9','.','0'}));

        // 10.9 - 10.8 = 0.1
        Assert.Equal(new []{'0','.','8'}, CharArrayDecimalSubtraction(new []{'1','0','.','9'}, new []{'1','0','.','1'}));

        // 10.9 - 10.08 = 0.82 (diff decimal places)
        Assert.Equal(new []{'0','.','8','2'}, CharArrayDecimalSubtraction(new []{'1','0','.','9'}, new []{'1','0','.','0','8'}));


    }
}