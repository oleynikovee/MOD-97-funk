using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
/*by olenikovee*/
namespace DLL_MOD97_Csharp
{
    public class Generate
    {
        public static UInt64 mod97_test(string s, UInt64 len) //where string s-main string with iban,where Uint64 len-size of s
        {
            UInt64 i, j, parts = len / 7;//we need parts for true work of alghoritm mod97
            string rem = "00";

            for (i = 1; i <= parts + Convert.ToUInt64((len % 7 != 0)); ++i)
            {
                rem = rem.Substring(0, 2) + s.Substring(((int)i - 1) * 7,
                   Math.Min(s.Substring(((int)i - 1) * 7).Length, 7));
                j = Convert.ToUInt64(rem) % 97;

                string tmp;
                tmp = (j / 10).ToString(); ;

                tmp += (j % 10).ToString();
                rem = tmp + rem.Substring(2);
            }
            //We use parts of string s,then get control summ from every part,then plus it to all string without used part.
            //Then get control num from string
            //Try it while i<=parts
            //when i<=parts we get answer without mod97;
            //then use return for get control num
            return Convert.ToUInt64(rem) % 97;
        }
    }
}
