using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommClass
{
    class Encryption
    {
        const int MaxWidth = 20;
        const ushort c1 = 52845;
        const ushort c2 = 11719;
        const string ConvertTable = "#$0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private string ReverseString(String Source)
        {
            string strResult = "";
            for (int i = Source.Length - 1; i >= 0; i--)
            {
                strResult = strResult + Source.Substring(i, 1);
            }
            return strResult;
        }

        private string IntToBin(int Source)
        {
            return Convert.ToString(Source, 2);
        }

        private string BinToInt(string Source)
        {
            return Convert.ToInt32(Source, 2).ToString();
        }

        //加密算法
        public string Encrypt(string Source, ushort Key)
        {
            int strLength;
            string str = Source;
            if (str.Length == 0)
            {
                return "";
            }
            //按最大长度补足字符串，不足的长度重复字符串补足
            strLength = str.Length;
            while (str.Length < MaxWidth)
            {
                if (MaxWidth - str.Length > str.Length)
                    str = str + str.Substring(0, str.Length);
                else
                    str = str + str.Substring(0, MaxWidth - str.Length);
            }

            //在第一位字符后面放置字符串长度
            str = str.Substring(0, 1) + ((char)strLength) + str.Substring(1, str.Length - 1);

            string s2 = "";
            string s1 = "";
            //每位字符转为ASCII码值并与KEY运算后转为二进制字符串
            //二进制统一定为16位长，不足补0。然后反转字符串
            for (int i = 1; i <= str.Length; i++)
            {
                string strTmp = "";
                s1 = IntToBin(((int)str[i - 1] ^ (Key >> 3)));
                for (int j = 1; j <= 16 - s1.Length; j++)
                {
                    strTmp = strTmp + "0";
                }
                //不足16位补"0"
                s2 = s2 + ReverseString(strTmp + s1);
                //key动态变动
                Key = (ushort)(((int)str[i - 1] + Key) * c1 + c2);
            }

            //将转换后的字符串分为6位一组，最后不够6位的补随机的0或1
            if (s2.Length % 6 != 0)
            {
                Random r = new Random();
                for (int i = 1; i <= 6 - s2.Length % 6; i++)
                {
                    s2 = s2 + r.Next(1).ToString();
                }
            }

            //每6位组成一个二进制数（0－63，可取ConvertTable中的所有字符)，转为十进制后做为索引值取ConvertTable中的字符，组成字符串
            string s = "";
            for (int i = 1; i <= s2.Length / 6; i++)
            {
                s1 = s2.Substring((i - 1) * 6, 6);
                s = s + ConvertTable[Convert.ToInt32(BinToInt(s1))];
            }

            return s;
        }


        //解密算法
        public string Decrypt(string Source, ushort Key)
        {
            string str = Source;
            if (str.Length == 0)
                return "";

            string s2 = "";
            int index;
            string strTmp = "";

            string s1 = "";
            //取字符串中每个字符在ConvertTable中的索引值，转化为二进制字符串后组成新的字符串
            for (int i = 1; i <= str.Length; i++)
            {
                index = ConvertTable.IndexOf(str[i - 1]);
                s2 = IntToBin(index);
                //转换后不足6位前面补"0"
                strTmp = "";
                for (int j = 1; j <= 6 - s2.Length; j++)
                {
                    strTmp = strTmp + "0";
                }
                s1 = s1 + strTmp + s2;
            }

            string s = "";
            char s3;
            //分成16位一组
            for (int i = 1; i <= s1.Length / 16; i++)
            {
                strTmp = s1.Substring((i - 1) * 16);
                if (strTmp.Length > 16)
                    s2 = ReverseString(s1.Substring((i - 1) * 16, 16));
                else
                    s2 = ReverseString(strTmp);
                s3 = (char)(Convert.ToInt32(BinToInt(s2)) ^ (Key >> 3));
                s = s + s3;
                Key = (ushort)(((int)s3 + Key) * c1 + c2);
            }
            //取第二位，为字符串长度
            s3 = s[1];
            //去掉第二位后重新组成字符串
            s = s[0] + s.Substring(2);
            //根据长度截取字符串
            s = s.Substring(0, Convert.ToInt32((int)s3));

            return s;
        }


    }
}
