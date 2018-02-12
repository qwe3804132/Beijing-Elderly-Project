//字符串处理类 wzc gzk 20131228
//静态调用
using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Net;
using System.Drawing.Imaging;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Xml.Linq;
using System.ComponentModel;

using System.IO;
//using System.Collections;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Data;
namespace zhuanjia
{
    public static class textclass
    {
        private static Regex RegPhone = new Regex("^[0-9]+[-]?[0-9]+[-]?[0-9]$");
        private static Regex RegNumber = new Regex("^[0-9]+$");
        private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
        private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
        private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$"); //等价于^[+-]?\d+[.]?\d+$
        private static Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
        private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");

        #region 防注入字符串过滤
        /// <summary>
        /// 防注入式攻击
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string fangzhuru(string str)
        {
            str = str.Replace("&", "&amp;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt");
            str = str.Replace("'", "''");
            str = str.Replace("*", "");
            str = str.Replace("\n", "<br/>");
            str = str.Replace("\r\n", "<br/>");
            str = str.Replace("?", "");
            str = str.Replace("select", "");
            str = str.Replace("insert", "");
            str = str.Replace("update", "");
            str = str.Replace("delete", "");
            str = str.Replace("create", "");
            str = str.Replace("drop", "");
            str = str.Replace("delcare", "");
            if (str.Trim().ToString() == "") { str = "无"; }
            return str.Trim();
        }
        #endregion
        #region 获取IP
        /// <summary>
        /// 获取IP
        /// </summary>
        /// <param name="Context"></param>
        /// <returns></returns>
        public static string getip()
        {
            string ip = "";

            //if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null) // 服务器， using proxy 
            //{
            //得到真实的客户端地址
            //    ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString(); // Return real client IP. 
            //}
            //else//如果没有使用代理服务器或者得不到客户端的ip not using proxy or can't get the Client IP 
            //{
            //    //得到服务端的地址
            //    ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString(); //While it can't get the Client IP, it will return proxy IP. 
            //}
            //ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            ip = HttpContext.Current.Request.UserHostAddress;
            return ip;
        }
        /// <summary>
        /// 获取主机名
        /// </summary>
        /// <param name="Context"></param>
        /// <returns></returns>
        public static string getHostName()
        {
            string strHostName = System.Net.Dns.GetHostName();
            return strHostName;
        }
        #endregion

        #region 获得随机字符串
        /// <summary>
        /// 从字符串里随机得到，规定个数的字符串.
        /// </summary>
        /// <param name="CodeCount">个数</param>
        /// <returns></returns>
        public static string GetRandomCode(int CodeCount)
        {
            string allChar = "2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] allCharArray = allChar.Split(',');
            string RandomCode = "";
            int temp = -1;
            Random rand = new Random();
            for (int i = 0; i < CodeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(temp * i * ((int)DateTime.Now.Ticks));
                }

                int t = rand.Next(allCharArray.Length - 1);

                while (temp == t)
                {
                    t = rand.Next(allCharArray.Length - 1);
                }

                temp = t;
                RandomCode += allCharArray[t];
            }
            return RandomCode;
        }
        /// <summary>
        /// 从字符串里随机得到，规定个数的字符串.
        /// </summary>
        /// <param name="allChar">给定字符串</param>
        /// <param name="CodeCount">个数</param>
        /// <returns></returns>
        public static string GetRandomCode(string allChar, int CodeCount)
        {
            //string allChar = "1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,i,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z"; 
            string[] allCharArray = allChar.Split(',');
            string RandomCode = "";
            int temp = -1;
            Random rand = new Random();
            for (int i = 0; i < CodeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(temp * i * ((int)DateTime.Now.Ticks));
                }

                int t = rand.Next(allCharArray.Length - 1);

                while (temp == t)
                {
                    t = rand.Next(allCharArray.Length - 1);
                }

                temp = t;
                RandomCode += allCharArray[t];
            }
            return RandomCode;
        }
        #endregion

        #region 数字字符串检查
        /// <summary>
        /// 判断是否电话
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsPhone(string inputData)
        {
            Match m = RegPhone.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 检查Request查询字符串的键值，是否是数字，最大长度限制
        /// </summary>
        /// <param name="req">Request</param>
        /// <param name="inputKey">Request的键值</param>
        /// <param name="maxLen">最大长度</param>
        /// <returns>返回Request查询字符串</returns>
        public static string FetchInputDigit(HttpRequest req, string inputKey, int maxLen)
        {
            string retVal = string.Empty;
            if (inputKey != null && inputKey != string.Empty)
            {
                retVal = req.QueryString[inputKey];
                if (null == retVal)
                    retVal = req.Form[inputKey];
                if (null != retVal)
                {
                    retVal = SqlText(retVal, maxLen);
                    if (!IsNumber(retVal))
                        retVal = string.Empty;
                }
            }
            if (retVal == null)
                retVal = string.Empty;
            return retVal;
        }
        /// <summary>
        /// 是否数字字符串
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsNumber(string inputData)
        {
            Match m = RegNumber.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// 是否数字字符串 可带正负号
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsNumberSign(string inputData)
        {
            Match m = RegNumberSign.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 是否是浮点数
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsDecimal(string inputData)
        {
            Match m = RegDecimal.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 是否是浮点数 可带正负号
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsDecimalSign(string inputData)
        {
            Match m = RegDecimalSign.Match(inputData);
            return m.Success;
        }

        #endregion

        #region  string格式验证
        /// <summary>
        /// 验证是否是汉字
        /// </summary>
        /// <param name="str_chinese"></param>
        /// <returns></returns>
        public static bool IsChinese(string str_chinese)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_chinese, @"^[\u4e00-\u9fa5]+$");
        }
        /// <summary>
        /// 检测是否有中文字符
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsHasCHZN(string inputData)
        {
            Match m = RegCHZN.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// 是否邮件地址
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsEmail(string inputData)
        {
            Match m = RegEmail.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 判断是否是数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumeric(string str)
        {
            return Regex.IsMatch(str, @"^-?\d+(\.\d)?$");
        }
        /// <summary>
        /// 判断是否固定电话
        /// </summary>
        /// <param name="str_telephone"></param>
        /// <returns></returns>
        public static bool IsTelephone(string str_telephone)
        {

            return System.Text.RegularExpressions.Regex.IsMatch(str_telephone, @"^(\d{3,4}-)?\d{6,8}$");

        }
        /// <summary>
        /// 邮政编码验证
        /// </summary>
        /// <param name="str_postalcode"></param>
        /// <returns></returns>
        public static bool IsPostalcode(string str_postalcode)
        {

            return System.Text.RegularExpressions.Regex.IsMatch(str_postalcode, @"^\d{6}$");

        }
        /// <summary>
        /// 验证手机号码
        /// </summary>
        /// <param name="str_handset"></param>
        /// <returns></returns>
        public static bool IsHandset(string str_handset)
        {

            return System.Text.RegularExpressions.Regex.IsMatch(str_handset, @"^[1]+\d{10}");

        }

        /// <summary>
        /// 判断是否是数字
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        public static bool IsNumeric(TextBox textBox)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 身份证号合法性验证 通过校验位
        /// </summary>
        /// <param name="sfzh"></param>
        /// <returns></returns>
        public static bool sfzhyanzheng(string ssfzh)
        {
            ssfzh = ssfzh.Trim();
            if (ssfzh.Length == 18)
            //根据校验位检查身份证号
            {
                string s3 = "";
                int s2 = Convert.ToInt32(ssfzh.Substring(0, 1)) * 7 + Convert.ToInt32(ssfzh.Substring(1, 1)) * 9 + Convert.ToInt32(ssfzh.Substring(2, 1)) * 10 + Convert.ToInt32(ssfzh.Substring(3, 1)) * 5
                   + Convert.ToInt32(ssfzh.Substring(4, 1)) * 8 + Convert.ToInt32(ssfzh.Substring(5, 1)) * 4 + Convert.ToInt32(ssfzh.Substring(6, 1)) * 2 + Convert.ToInt32(ssfzh.Substring(7, 1)) * 1
                   + Convert.ToInt32(ssfzh.Substring(8, 1)) * 6 + Convert.ToInt32(ssfzh.Substring(9, 1)) * 3 + Convert.ToInt32(ssfzh.Substring(10, 1)) * 7 + Convert.ToInt32(ssfzh.Substring(11, 1)) * 9
                   + Convert.ToInt32(ssfzh.Substring(12, 1)) * 10 + Convert.ToInt32(ssfzh.Substring(13, 1)) * 5 + Convert.ToInt32(ssfzh.Substring(14, 1)) * 8 + Convert.ToInt32(ssfzh.Substring(15, 1)) * 4
                   + Convert.ToInt32(ssfzh.Substring(16, 1)) * 2;
                s2 = s2 % 11;
                switch (s2)
                {
                    case 0:
                        s3 = "1";
                        break;
                    case 1:
                        s3 = "0";
                        break;
                    case 2:
                        s3 = "X";
                        break;
                    default:
                        s3 = Convert.ToString(12 - Convert.ToInt32(s2)).Trim();
                        break;
                }
                if (s3 != ssfzh.Substring(17, 1))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 其他

        /// <summary>
        /// 检查字符串最大长度，返回指定长度的串
        /// </summary>
        /// <param name="sqlInput">输入字符串</param>
        /// <param name="maxLength">最大长度</param>
        /// <returns></returns>			
        public static string SqlText(string sqlInput, int maxLength)
        {
            if (sqlInput != null && sqlInput != string.Empty)
            {
                sqlInput = sqlInput.Trim();
                if (sqlInput.Length > maxLength)//按最大长度截取字符串
                    sqlInput = sqlInput.Substring(0, maxLength);
            }
            return sqlInput;
        }

        /// <summary>
        /// 转换成 HTML code
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>string</returns>
        public static string Encode(string str)
        {
            str = str.Replace("&", "&amp;");
            str = str.Replace("'", "''");
            str = str.Replace("\"", "&quot;");
            str = str.Replace(" ", "&nbsp;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace("\n", "<br>");
            return str;
        }
        /// <summary>
        ///解析html成 普通文本
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>string</returns>
        public static string Decode(string str)
        {
            str = str.Replace("<br>", "\n");
            str = str.Replace("&gt;", ">");
            str = str.Replace("&lt;", "<");
            str = str.Replace("&nbsp;", " ");
            str = str.Replace("&quot;", "\"");
            return str;
        }
        /// <summary>
        /// 清楚string中字符",","<",">","-","-","/","=","%"," " 
        /// </summary>
        /// <param name="sqlText"></param>
        /// <returns></returns>
        public static string SqlTextClear(string sqlText)
        {
            if (sqlText == null)
            {
                return null;
            }
            if (sqlText == "")
            {
                return "";
            }
            sqlText = sqlText.Replace(",", "");//去除,
            sqlText = sqlText.Replace("<", "");//去除<
            sqlText = sqlText.Replace(">", "");//去除>
            sqlText = sqlText.Replace("--", "");//去除--
            sqlText = sqlText.Replace("'", "");//去除'
            sqlText = sqlText.Replace("\"", "");//去除"
            sqlText = sqlText.Replace("=", "");//去除=
            sqlText = sqlText.Replace("%", "");//去除%
            sqlText = sqlText.Replace(" ", "");//去除空格
            return sqlText;
        }
        #endregion

        #region 检查输入的参数是不是某些定义好的特殊字符：这个方法目前用于密码输入的安全检查
        /// <summary>
        /// 检查输入的参数是不是某些定义好的特殊字符：这个方法目前用于密码输入的安全检查
        /// </summary>
        public static bool isContainSpecChar(string strInput)
        {
            string[] list = new string[] { "123456", "654321" };
            bool result = new bool();
            for (int i = 0; i < list.Length; i++)
            {
                if (strInput == list[i])
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        #endregion



        #region RMB大小写换算
        /// <summary> 
        /// 转换人民币大小金额 
        /// </summary> 
        /// <param name="num">金额</param> 
        /// <returns>返回大写形式</returns> 
        public static string CmycurD(decimal num)
        {
            string str1 = "零壹贰叁肆伍陆柒捌玖";            //0-9所对应的汉字 
            string str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分"; //数字位所对应的汉字 
            string str3 = "";    //从原num值中取出的值 
            string str4 = "";    //数字的字符串形式 
            string str5 = "";  //人民币大写金额形式 
            int i;    //循环变量 
            int j;    //num的值乘以100的字符串长度 
            string ch1 = "";    //数字的汉语读法 
            string ch2 = "";    //数字位的汉字读法 
            int nzero = 0;  //用来计算连续的零值是几个 
            int temp;            //从原num值中取出的值 

            num = Math.Round(Math.Abs(num), 2);    //将num取绝对值并四舍五入取2位小数 
            str4 = ((long)(num * 100)).ToString();        //将num乘100并转换成字符串形式 
            j = str4.Length;      //找出最高位 
            if (j > 15) { return "溢出"; }
            str2 = str2.Substring(15 - j);   //取出对应位数的str2的值。如：200.55,j为5所以str2=佰拾元角分 

            //循环取出每一位需要转换的值 
            for (i = 0; i < j; i++)
            {
                str3 = str4.Substring(i, 1);          //取出需转换的某一位的值 
                temp = Convert.ToInt32(str3);      //转换为数字 
                if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
                {
                    //当所取位数不为元、万、亿、万亿上的数字时 
                    if (str3 == "0")
                    {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    }
                    else
                    {
                        if (str3 != "0" && nzero != 0)
                        {
                            ch1 = "零" + str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                    }
                }
                else
                {
                    //该位是万亿，亿，万，元位等关键位 
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 != "0" && nzero == 0)
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            if (str3 == "0" && nzero >= 3)
                            {
                                ch1 = "";
                                ch2 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                if (j >= 11)
                                {
                                    ch1 = "";
                                    nzero = nzero + 1;
                                }
                                else
                                {
                                    ch1 = "";
                                    ch2 = str2.Substring(i, 1);
                                    nzero = nzero + 1;
                                }
                            }
                        }
                    }
                }
                if (i == (j - 11) || i == (j - 3))
                {
                    //如果该位是亿位或元位，则必须写上 
                    ch2 = str2.Substring(i, 1);
                }
                str5 = str5 + ch1 + ch2;

                if (i == j - 1 && str3 == "0")
                {
                    //最后一位（分）为0时，加上“整” 
                    str5 = str5 + '整';
                }
            }
            if (num == 0)
            {
                str5 = "零元整";
            }
            return str5;
        }

        /// <summary> 
        /// 一个重载，将字符串先转换成数字在调用CmycurD(decimal num) 
        /// </summary> 
        /// <param name="num">用户输入的金额，字符串形式未转成decimal</param> 
        /// <returns></returns> 
        public static string CmycurD(string numstr)
        {
            try
            {
                decimal num = Convert.ToDecimal(numstr);
                return CmycurD(num);
            }
            catch
            {
                return "非数字形式！";
            }
        }
        #endregion

        #region 数组、list类型的拆分和连接
        /// <summary>
        /// 将已知字符串按指定字符拆分组成list型
        /// </summary>
        /// <param name="str">要拆分的字符串</param>
        /// <param name="speater">指定字符</param>
        /// <param name="toUpper">受否转换大写</param>
        /// <returns></returns>
        public static List<string> GetStrArray(string str, char speater, bool toUpper)
        {
            List<string> list = new List<string>();
            string[] ss = str.Split(speater);
            foreach (string s in ss)
            {
                if (!string.IsNullOrEmpty(s) && s != speater.ToString())
                {
                    string strVal = s;
                    if (toUpper)
                    {
                        strVal = s.ToUpper();
                    }
                    list.Add(strVal);
                }
            }
            return list;
        }
        /// <summary>
        /// 将已知字符串按“，”拆分为数组
        /// </summary>
        /// <param name="str">要拆分的字符串</param>
        /// <returns></returns>
        public static string[] GetStrArray(string str)
        {
            return str.Split(new char[',']);
        }
        /// <summary>
        /// 将已知list用指定字符连接成string
        /// </summary>
        /// <param name="list">需要连接的list</param>
        /// <param name="speater">连接字符</param>
        /// <returns></returns>
        public static string GetArrayStr(List<string> list, string speater)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                {
                    sb.Append(list[i]);
                }
                else
                {
                    sb.Append(list[i]);
                    sb.Append(speater);
                }
            }
            return sb.ToString();
        }
        #endregion

        #region 删除最后一个字符之后的字符

        /// <summary>
        /// 删除最后结尾的一个逗号
        /// </summary>
        public static string DelLastComma(string str)
        {
            return str.Substring(0, str.LastIndexOf(","));
        }

        /// <summary>
        /// 删除最后结尾的指定字符后的字符
        /// </summary>
        public static string DelLastChar(string str, string strchar)
        {
            return str.Substring(0, str.LastIndexOf(strchar));
        }

        #endregion

        #region string半全角转换
        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSBC(string input)
        {
            //半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        /// <summary>
        ///  转半角的函数(SBC case)
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns></returns>
        public static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }
        #endregion

        #region 时间日期操作函数
        /// <summary>
        /// 把秒转换成分钟
        /// </summary>
        /// <returns></returns>
        public static int SecondToMinute(int Second)
        {
            decimal mm = (decimal)((decimal)Second / (decimal)60);
            return Convert.ToInt32(Math.Ceiling(mm));
        }

        /// <summary>
        /// 8位日期 (20130928)的格式,转DateTime类型
        /// </summary>
        /// <param name="StrSource"></param>
        /// <returns></returns>
        public static DateTime StringToDate(string dateStr)
        {
            try
            {
                return DateTime.ParseExact(dateStr, "yyyyMMdd", System.Globalization.CultureInfo.GetCultureInfo("en-US"), System.Globalization.DateTimeStyles.None);

            }
            catch
            {

                return DateTime.MinValue;
            }
        }
        /// <summary>
        /// 返回某年某月最后一天
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns>日</returns>
        public static int GetMonthLastDate(int year, int month)
        {
            DateTime lastDay = new DateTime(year, month, new System.Globalization.GregorianCalendar().GetDaysInMonth(year, month));
            int Day = lastDay.Day;
            return Day;
        }

        /// <summary>
        /// 计算时间差DateTime2 - DateTime1
        /// </summary>
        /// <param name="DateTime1"></param>
        /// <param name="DateTime2"></param>
        /// <returns></returns>
        public static string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            try
            {
                //TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
                //TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
                //TimeSpan ts = ts1.Subtract(ts2).Duration();
                TimeSpan ts = DateTime2 - DateTime1;
                if (ts.Days >= 1)
                {
                    dateDiff = DateTime1.Month.ToString() + "月" + DateTime1.Day.ToString() + "日";
                }
                else
                {
                    if (ts.Hours > 1)
                    {
                        dateDiff = ts.Hours.ToString() + "小时前";
                    }
                    else
                    {
                        dateDiff = ts.Minutes.ToString() + "分钟前";
                    }
                }
            }
            catch
            { }
            return dateDiff;
        }
        /// <summary>
        /// 判断是否是8位日期(20130928)的格式,并返回string类型
        /// </summary>
        /// <param name="StrSource"></param>
        /// <returns></returns>
        public static bool IsDate(string dateStr)
        {
            try
            {
                DateTime.ParseExact(dateStr, "yyyyMMdd", System.Globalization.CultureInfo.GetCultureInfo("en-US"), System.Globalization.DateTimeStyles.None);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 日期格式字符串判断,并返回转换为DateTime类型后的数据。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDateTime(string str, out DateTime dt)
        {
            try
            {
                if (!string.IsNullOrEmpty(str))
                {
                    dt = DateTime.Parse(str);
                    return true;
                }
                else
                {
                    dt = DateTime.MinValue;
                    return false;
                }
            }
            catch
            {
                dt = DateTime.MinValue;
                return false;
            }
        }
        /// <summary>
        /// Int转换为时间间隔
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static string IntToTime(int a)
        {
            int tm = (int)(a / 60);
            int tmm = a % 60;
            string s = String.Format("{0}小时{1}分钟", tm, tmm);
            return s;
        }
        /// <summary>
        /// DES多重加密解密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String Decrypt_DES(String str)
        {
            str = str.Trim();
            System.Security.Cryptography.TripleDESCryptoServiceProvider des = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
            Int32 x;
            Byte[] inputByteArray = new Byte[str.Length / 2];
            for (x = 0; x < str.Length / 2; x++)
                inputByteArray[x] = (Byte)(Convert.ToInt32(str.Substring(x * 2, 2), 16));
            des.Key = Convert.FromBase64String("uwniTq6wza2nU3/cCVxTScpjhlv1Tl5s");
            des.IV = Convert.FromBase64String("ld6Et92CmbQ=");
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Security.Cryptography.CryptoStream cs = new System.Security.Cryptography.CryptoStream(ms, des.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.StringBuilder ret = new System.Text.StringBuilder();
            return System.Text.Encoding.Unicode.GetString(ms.ToArray());
        }
        /// <summary>
        /// DES多重加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String Encrypt_DES(String str)
        {
            System.Security.Cryptography.TripleDESCryptoServiceProvider des = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
            Byte[] inputByteArray = System.Text.Encoding.Unicode.GetBytes(str);
            des.Key = Convert.FromBase64String("uwniTq6wza2nU3/cCVxTScpjhlv1Tl5s");
            des.IV = Convert.FromBase64String("ld6Et92CmbQ=");
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.Security.Cryptography.CryptoStream cs = new System.Security.Cryptography.CryptoStream(ms, des.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (Byte b in ms.ToArray())
                sb.AppendFormat("{0:X2}", b);
            return sb.ToString();
        }
        /// <summary>
        /// DEC 加密过程
        /// </summary>
        /// <param name="pToEncrypt">被加密的字符串</param>
        /// <param name="sKey">密钥（只支持8个字节的密钥）</param>
        /// <returns>加密后的字符串</returns>
        public static string desjiami(string pToEncrypt)
        {
            string sKey = "arw@wgr@";
            //访问数据加密标准(DES)算法的加密服务提供程序 (CSP) 版本的包装对象
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);　//建立加密对象的密钥和偏移量
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);　 //原文使用ASCIIEncoding.ASCII方法的GetBytes方法

            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);//把字符串放到byte数组中

            MemoryStream ms = new MemoryStream();//创建其支持存储区为内存的流　
            //定义将数据流链接到加密转换的流
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            //上面已经完成了把加密后的结果放到内存中去

            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }
        //// <summary>
        /// DEC 解密过程
        /// </summary>
        /// <param name="pToDecrypt">被解密的字符串</param>
        /// <param name="sKey">密钥（只支持8个字节的密钥，同前面的加密密钥相同）</param>
        /// <returns>返回被解密的字符串</returns>
        public static string desjiemi(string pToDecrypt)
        {
            try
            {
                string sKey = "arw@wgr@";
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
                for (int x = 0; x < pToDecrypt.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }

                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);　//建立加密对象的密钥和偏移量，此值重要，不能修改
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);

                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                //建立StringBuild对象，createDecrypt使用的是流对象，必须把解密后的文本变成流对象
                StringBuilder ret = new StringBuilder();
                return System.Text.Encoding.Default.GetString(ms.ToArray());
            }
            catch
            {
                return "被解密的字符串无效";
            }

        }
        /// <summary>
        /// 测试用写文本
        /// </summary>
        /// <param name="logInfor"></param>
        public static void WriteCacheLog(string logPath, string logInfor)
        {
            try
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(logPath, true, Encoding.GetEncoding("GB2312"));
                sw.WriteLine(DateTime.Now.ToString() + "   " + logInfor);
                sw.Close();
                sw.Dispose();
            }
            catch
            {

                //调试的时候注意是否对该文件有写权限

            }
        }
        public static DataTable GetNewDataTable(DataTable dt, string condition)
        {
            DataTable newdt = new DataTable();
            newdt = dt.Clone();
            DataRow[] dr = dt.Select(condition);
            for (int i = 0; i < dr.Length; i++)
            {
                newdt.ImportRow((DataRow)dr[i]);
            }
            return newdt;   //返回的查询结果 
        }  
        #endregion

        #region 添加文字水印
        /// <summary>         
        /// 添加文字水印         
        /// </summary>         
        /// <param name="text">水印文字</param>         
        /// <param name="file">图片文件</param>         
        public static bool AttachText(string text, string file)
        {
          
            if (!File.Exists(file))
            {
                return false;
            }
            FileInfo oFile = new FileInfo(file);
            string strTempFile = Path.Combine(oFile.DirectoryName, Guid.NewGuid().ToString() + oFile.Extension);
            oFile.CopyTo(strTempFile);
            System.Drawing.Image img = System.Drawing.Image.FromFile(strTempFile);
            ImageFormat thisFormat = img.RawFormat;
            int nHeight = img.Height;
            int nWidth = img.Width;
            Bitmap outBmp = new Bitmap(nWidth, nHeight);
            Graphics g = Graphics.FromImage(outBmp);
            g.Clear(Color.White);
            // 设置画布的描绘质量        
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(img, new Rectangle(0, 0, nWidth, nHeight), 0, 0, nWidth, nHeight, GraphicsUnit.Pixel);
            int[] sizes = new int[] { 16, 14, 12, 10, 8, 6, 4 };
            Font crFont = null;
            SizeF crSize = new SizeF();
            //通过循环这个数组，来选用不同的字体大小   
            //如果它的大小小于图像的宽度，就选用这个大小的字体     
            for (int i = 0; i < 7; i++)
            {
                //设置字体，这里是用arial，黑体       
                crFont = new Font("arial", sizes[i], FontStyle.Bold);
                //Measure the Copyright string in this Font             
                crSize = g.MeasureString(text, crFont);
                if ((ushort)crSize.Width < (ushort)nWidth)
                { break; }
            }
            //因为图片的高度可能不尽相同, 所以定义了       
            //从图片底部算起预留了5%的空间     
            int yPixlesFromBottom = (int)(nHeight * .08);
            //现在使用版权信息字符串的高度来确定要绘制的图像的字符串的y坐标    
            float yPosFromBottom = ((nHeight - yPixlesFromBottom) - (crSize.Height / 2));
            //计算x坐标          
            float xCenterOfImg = (nWidth / 2);
            //封装文本布局信息（如对齐、文字方向和 Tab 停靠位），显示操作（如省略号插入和国家标准 (National) 数字替换）和 OpenType 功能。
            StringFormat StrFormat = new StringFormat();
            StrFormat.Alignment = StringAlignment.Center;
            //SolidBrush:定义单色画笔。画笔用于填充图形形状，如矩形、椭圆、扇形、多边形和封闭路径。
            //这个画笔为描绘阴影的画笔，呈灰色
            SolidBrush semiTransBrush2 = new SolidBrush(Color.FromArgb(100, 10, 10, 10));
            SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(100, 255, 255, 255));
            
            float yPosOfWm = -outBmp.Height ;
            float xPosOfWm = -outBmp.Width;
            int ss = 255;
            int ds = 0;
            g.RotateTransform(-45);
            while (xPosOfWm < outBmp.Width)
            {
                yPosOfWm = -outBmp.Height;
                ds = 0;
                while (yPosOfWm < outBmp.Height * 1.5)
                {
                    if (ss > 1)
                    {
                        ss = ss - 1;
                    }
                    //grPhoto.DrawString("河北省人事考试局",                                    //string of text
                    //                           crFont,                                         //font
                    //                            new SolidBrush(Color.FromArgb(ss++/2, 0, 0, 0)),                            //Brush
                    //                           new PointF(xPosOfWm + 2, yPosOfWm + 2),  //Position
                    //                           StrFormat);

                    //第二次绘制这个图形，建立在第一次描绘的基础上
                    if (ds == 0)
                    {
                        g.DrawString(text,                 //string of text
                                                   crFont,                                   //font
                                                   semiTransBrush2,                       //Brush
                                                   new PointF(xPosOfWm+1, yPosOfWm+1)  //Position
                                                  );
                        g.DrawString(text,                 //string of text
                                                   crFont,                                   //font
                                                   semiTransBrush,                       //Brush
                                                   new PointF(xPosOfWm, yPosOfWm)  //Position
                                                  );
                        ds = 1;
                    }
                    else
                    {
                        g.DrawString(text,                 //string of text
                                                   crFont,                                   //font
                                                   semiTransBrush2,                       //Brush
                                                   new PointF(xPosOfWm - 180+1, yPosOfWm+1)  //Position
                                                  );
                        g.DrawString(text,                 //string of text
                                                   crFont,                                   //font
                                                   semiTransBrush,                       //Brush
                                                   new PointF(xPosOfWm - 180, yPosOfWm)  //Position
                                                  );
                        ds = 0;
                    }
                    yPosOfWm += 80;
                }
                xPosOfWm += 250;
            }
            ////绘制版权字符串           
            //g.DrawString(text,             //版权字符串文本            
            //    crFont,                             //字体           
            //    semiTransBrush2,                           //Brush        
            //    new PointF(xCenterOfImg + 1, yPosFromBottom + 1),  //位置     
            //    StrFormat);              //设置成白色半透明          
            //SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(153, 255, 255, 255));
            ////第二次绘制版权字符串来创建阴影效果           
            ////记住移动文本的位置1像素           
            //g.DrawString(text,                 //版权文本     
            //    crFont,                                   //字体 
            //    semiTransBrush,                           //Brush    
            //    new PointF(xCenterOfImg, yPosFromBottom),  //位置     
            //    StrFormat);
            g.Dispose();              // 以下代码为保存图片时，设置压缩质量         
            EncoderParameters encoderParams = new EncoderParameters();
            long[] quality = new long[1];
            quality[0] = 100;
            EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            encoderParams.Param[0] = encoderParam;              //获得包含有关内置图像编码解码器的信息的ImageCodecInfo 对象。
            ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo jpegICI = null;
            for (int x = 0; x < arrayICI.Length; x++)
            {
                if (arrayICI[x].FormatDescription.Equals("JPEG"))
                {
                    jpegICI = arrayICI[x];//设置JPEG编码          
                    break;
                }
            } if (jpegICI != null)
            { outBmp.Save(file, jpegICI, encoderParams); }
            else { outBmp.Save(file, thisFormat); }
            img.Dispose();
            outBmp.Dispose();
            File.Delete(strTempFile);
            return true;
        }
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源路径</param>
        /// <param name="thumbnailPath">缩略图路径</param>
        /// <param name="width">指定宽度</param>
        /// <param name="height">指定高度</param>
        /// <returns></returns>
        public static bool MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height)
        {
            //获取原始图片 
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);
            //缩略图画布宽高 
            int towidth = width;
            int toheight = height;
            //原始图片写入画布坐标和宽高(用来设置裁减溢出部分) 
            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;
            //原始图片画布,设置写入缩略图画布坐标和宽高(用来原始图片整体宽高缩放) 
            int bg_x = 0;
            int bg_y = 0;
            int bg_w = towidth;
            int bg_h = toheight;
            //倍数变量 
            double multiple = 0;
            //获取宽长的或是高长与缩略图的倍数 
            if (originalImage.Width >= originalImage.Height) multiple = (double)originalImage.Width / (double)width;
            else multiple = (double)originalImage.Height / (double)height;
            //上传的图片的宽和高小等于缩略图 
            if (ow <= width && oh <= height)
            {
                //缩略图按原始宽高 
                bg_w = originalImage.Width;
                bg_h = originalImage.Height;
                //空白部分用背景色填充 
                bg_x = Convert.ToInt32(((double)towidth - (double)ow) / 2);
                bg_y = Convert.ToInt32(((double)toheight - (double)oh) / 2);
            }
            //上传的图片的宽和高大于缩略图 
            else
            {
                //宽高按比例缩放 
                bg_w = Convert.ToInt32((double)originalImage.Width / multiple);
                bg_h = Convert.ToInt32((double)originalImage.Height / multiple);
                //空白部分用背景色填充 
                bg_y = Convert.ToInt32(((double)height - (double)bg_h) / 2);
                bg_x = Convert.ToInt32(((double)width - (double)bg_w) / 2);
            }
            //新建一个bmp图片,并设置缩略图大小. 
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);
            //新建一个画板 
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
            //设置高质量插值法 
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            //设置高质量,低速度呈现平滑程度 
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //清空画布并设置背景色 
            g.Clear(System.Drawing.ColorTranslator.FromHtml("#F2F2F2"));
            //在指定位置并且按指定大小绘制原图片的指定部分 
            //第一个System.Drawing.Rectangle是原图片的画布坐标和宽高,第二个是原图片写在画布上的坐标和宽高,最后一个参数是指定数值单位为像素 
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, width, height), new System.Drawing.Rectangle(x, y, ow, oh), System.Drawing.GraphicsUnit.Pixel);
            try
            {
                //获取图片类型 
                string fileExtension = System.IO.Path.GetExtension(originalImagePath).ToLower();
                //按原图片类型保存缩略图片,不按原格式图片会出现模糊,锯齿等问题. 
                switch (fileExtension)
                {
                    case ".gif": bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Gif); break;
                    case ".jpg": bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                    case ".bmp": bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Bmp); break;
                    case ".png": bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Png); break;
                }
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
                return true;
            }
            catch (System.Exception e)
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
                return false;
                throw e;
            }
        }
        #endregion
    }
}

