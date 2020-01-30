using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asszisztens.Controllers
{
    class InputCheck
    {

        public static string NameCheck(string name)
        {
            var newName = name.Trim();

            if (name == "" || name==null)
                return "Üres név mező!";

            char[] nameArray = newName.ToCharArray();

            for(int i = 0; i<nameArray.Length; i++)
            {
                if(Char.IsPunctuation(nameArray[i]) || Char.IsSymbol(nameArray[i]) || Char.IsNumber(nameArray[i])){
                    return "Csak betűket tartalmazhat a név!";
                }
            }

            if (!Char.IsUpper(nameArray[0]))
            {
                return "Kis kezdőbetű!";
            }

            return "OK";
        }


        public static string TajCheck(string taj)
        {
            var newTaj = taj.Trim();
            char[] tajArray = newTaj.ToCharArray();

            if (newTaj == "" || newTaj == null)
            {
                return "Üres tajszám mező!";
            }

            if (newTaj.Length == 9)
            {
                for(int i=0; i<tajArray.Length; i++)
                {
                    if (!Char.IsNumber(tajArray[i]))
                    {
                        return "Hibás tajszám!";
                    }
                }
            }
            else if(newTaj.Length == 11)
            {
                if(tajArray[3]!='-' && tajArray[7] != '-')
                {
                    return "Hibás tajszám!";
                }
                for (int i = 0; i < tajArray.Length; i++)
                {
                    if (i == 3 || i == 7) continue;

                    if (!Char.IsNumber(tajArray[i]))
                    {
                        return "Hibás tajszám!";
                    }
                }
            }
            else
            {
                return "Hibás tajszám!";
            }

            return "OK";
            


        }
       


    }
}
