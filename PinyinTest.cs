using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Microsoft.International.Converters.PinYinConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WzhePinYin;

namespace ConsoleApplication1
{
    class PinyinTest
    {
        static void Main(string[] args)
        {
            /*
            ChineseCharExtensionsTest a = new ChineseCharExtensionsTest();
            a.TestIsChinese();
            Console.WriteLine("OK1");
            a.TestGetPinyins();
            Console.WriteLine("OK2");
            */
            String value1 = ByMsLibrary(shortText);
            String value2 = ByWzheLibrary(shortText);
            String value3 = ByMsLibrary(longText);
            String value4 = ByWzheLibrary(longText);
        }

        private static Char[] shortText = "前面三辆囚车中分别监禁的是三个男子，都作书生打扮，一个是白发".ToArray();

        private static Char[] longText = File.ReadAllText(@"全集史上第一混乱.txt").ToArray();

        private static String ByMsLibrary(Char[] chrArray)
        {
            return String.Join(" ",
                chrArray.Where(ch => ChineseChar.IsValidChar(ch)).Select(ch => new ChineseChar(ch).Pinyins[0]));
        }

        private static String ByWzheLibrary(Char[] chrArray)
        {
            return String.Join(" ",
                chrArray.Where(ch => ch.IsChinese()).Select(ch => ch.GetPinyins()[0]));
        }
    }


    public class ChineseCharExtensionsTest
    {
        public void TestIsChinese()
        {
            var invalidCases = AllChars()
                .Where(c => c.IsChinese() != ChineseChar.IsValidChar(c))
                .Select(c => new
                {
                    Value = c,
                    Expected = ChineseChar.IsValidChar(c),
                    Actual = c.IsChinese()
                });
            Assert.AreEqual(String.Empty, String.Join("\n", invalidCases));
        }

        public void TestGetPinyins()
        {
            var invalidCases = AllChars()
                .Where(c => ChineseChar.IsValidChar(c))
                .Select(c => new
                {
                    Value = c,
                    Expected = new HashSet<String>(
                        new ChineseChar(c).Pinyins
                            .Where(p => p != null)
                            .Select(p => p.Substring(0, p.Length - 1))),
                    Actual = new HashSet<String>(c.GetPinyins())
                })
                .Where(o => !o.Expected.SetEquals(o.Actual))
                .Select(o => new
                {
                    Value = o.Value,
                    Expected = String.Join(", ", o.Expected),
                    Actual = String.Join(",", o.Actual)
                });
            Assert.AreEqual(String.Empty, String.Join("\n", invalidCases));
        }

        private static IEnumerable<Char> AllChars()
        {
            for (Char value = Char.MinValue; value != Char.MaxValue; value += (Char)1)
            {
                yield return value;
            }
        }
    }
}

