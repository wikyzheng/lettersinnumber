using LetterInNumber;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace LetterNumber.Test
{
    public class LetterNumberTest
    {
        [Fact]
        public void GetCombinationsTest()
        {
            Common.GetCombinations("1,2,3", false).Item2.ShouldBe("1AD,1AE,1AF,1BD,1BE,1BF,1CD,1CE,1CF");

            Common.GetCombinations("1,2,3,3", true).Item2.ShouldBe("1AD,1AE,1AF,1BD,1BE,1BF,1CD,1CE,1CF");

            Common.GetCombinations("2,3,3", false).Item2.ShouldBe("ADD,ADE,ADF,AED,AEE,AEF,AFD,AFE,AFF,BDD,BDE,BDF,BED,BEE,BEF,BFD,BFE,BFF,CDD,CDE,CDF,CED,CEE,CEF,CFD,CFE,CFF");

            Common.GetCombinations("22,50", true).Item2.ShouldBe("0AJ,0AK,0AL,0BJ,0BK,0BL,0CJ,0CK,0CL");
        }
    }
}
