namespace CharArrayDecimalSubtraction;

public class UnitTest1_blank
{
    /*
        Subtract array a from array b and return result
        Do not use inbuilt functions (e.g. int.Parse)
        Do not use types double, decimal, float or functions that return same (e.g. Math.Pow)
        Always has leading digit e.g. 0.1

    */

    private int GetDecimalIndex(char[] a)
    {
        for(var i=0; i<a.Length-1; ++i)
            if(a[i]=='.') return i;

        return -1;
    }

    
    private int GetCharAsInt(char[] a)
    {
        int zero= (int)'0';
        int retVal =0;
        for(int i=0; i<a.Length; ++i)
        {
            if(a[i]=='.') {
                continue;
            }
            
            retVal = (retVal * 10) + ((int)a[i] - zero) ;
        }

        return retVal;
    }

    private char[] CharArrayDecimalSubtraction(char[] a, char[] b)
    {
            var aAsInt = GetCharAsInt(a);
            var bAsInt = GetCharAsInt(b);

            var aDpIndex = GetDecimalIndex(a);
            var bDpIndex = GetDecimalIndex(b);

            var aLength = a.Length;
            var bLength = b.Length;

            var aDps = aDpIndex== -1? 0: aLength - (aDpIndex + 1);
            var bDps = bDpIndex== -1? 0: bLength - (bDpIndex + 1);
            var useDps = Math.Max(aDps,bDps);

//            Console.WriteLine( aAsInt );
//            Console.WriteLine( bAsInt );
            
            //adjust to same multiplication factor
            if(aDps > bDps) {
                for(var f=1; f<aDps-bDps; ++f)
                    bAsInt *= 10;
            }
            if(aDps < bDps) {
                for(var f=0; f<bDps-aDps; ++f)
                    aAsInt *= 10;
            }                    


//            Console.WriteLine( aAsInt );
//            Console.WriteLine( bAsInt );

            // actual subtraction
            var retVal = (aAsInt - bAsInt);
            var isNegative = retVal<0;

            List<char> retList = new List<char>();
            retVal = Math.Abs(retVal);
            int zero= (int)'0';
            while(retVal>0)
            {
                retList.Add( (char)(retVal % 10 + zero) );
                retVal/=10;
            }

            // reverse because we added in largest first
            retList.Reverse();

            if(useDps ==0 ){
                retList.Add('.');
                retList.Add('0');
            }
            else{
                if(retList.Count-useDps == 0) retList.Insert(0,'0'); //leading zero
                retList.Insert(retList.Count-useDps,'.');
            }
            
            if(isNegative) retList.Insert(0,'-');

            return retList.ToArray();
    }
    
    [Fact]
    public void Test1()
    {
        // 5 - 3 = 2.0 
        Assert.Equal(new []{'2','.','0'}, CharArrayDecimalSubtraction(new []{'5'}, new []{'3'}));

        // 3 - 5 = -2.0 
        Assert.Equal(new []{'-','2','.','0'}, CharArrayDecimalSubtraction(new []{'3'}, new []{'5'}));

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