using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Asszisztens.Test
{
    public class AsszisztensTeszt
    {
        [Theory]
        [InlineData("Ádám", "OK")]
        [InlineData("ádám", "Kis kezdőbetű!")]
        [InlineData(" Ádám", "OK")]
        [InlineData("", "Üres név mező!")]
        [InlineData("4dám", "Csak betűket tartalmazhat a név!")]
        [InlineData("!dám", "Csak betűket tartalmazhat a név!")]
        public void Check_Name_Test(string testName, string expected)
        {
            string actual = Controllers.InputCheck.NameCheck(testName);

            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData("123-456-789", "OK")]
        [InlineData("123456789", "OK")]
        [InlineData(" 000-000-000", "OK")]
        [InlineData(" 123456789", "OK")]
        [InlineData("000-000-00", "Hibás tajszám!")]
        [InlineData("000-000000", "Hibás tajszám!")]
        [InlineData("000000-000", "Hibás tajszám!")]
        [InlineData("AAA-AAA-AAA", "Hibás tajszám!")]
        [InlineData("AAAAAAAAA", "Hibás tajszám!")]
        public void Check_Taj_Test(string testTaj, string expected)
        {
            string actual = Controllers.InputCheck.TajCheck(testTaj);

            Assert.Equal(expected, actual);
        }


    }
}
