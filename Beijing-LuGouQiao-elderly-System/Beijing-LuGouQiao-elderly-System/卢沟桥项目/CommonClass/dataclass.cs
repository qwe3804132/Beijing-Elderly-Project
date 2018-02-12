using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;

namespace zhuanjia
{
    public static class dataclass
    {
        #region INT文件读写操作
        /// <summary>
        /// 写INI文件
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, Byte[] retVal, int size, string filePath);

        /// <summary>
        /// 写INI文件
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        public static void IniWriteValue(string Section, string Key, string Value, string INIPath)
        {
            WritePrivateProfileString(Section, Key, Value, INIPath);
        }
        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public static string IniReadValue(string Section, string Key, string INIPath)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, INIPath);
            return temp.ToString();
        }
        public static byte[] IniReadValues(string section, string key, string INIPath)
        {
            byte[] temp = new byte[255];
            int i = GetPrivateProfileString(section, key, "", temp, 255, INIPath);
            return temp;
        }
        /// <summary>
        /// 删除ini文件下所有段落
        /// </summary>
        public static void ClearAllSection(string INIPath)
        {
            IniWriteValue(null, null, null, INIPath);
        }
        /// <summary>
        /// 删除ini文件下personal段落下的所有键
        /// </summary>
        /// <param name="Section"></param>
        public static void ClearSection(string Section, string INIPath)
        {
            IniWriteValue(Section, null, null, INIPath);
        }
        #endregion
      
    }
}