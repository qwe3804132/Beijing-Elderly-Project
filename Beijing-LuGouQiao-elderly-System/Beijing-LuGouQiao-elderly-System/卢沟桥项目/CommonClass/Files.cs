using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;

namespace zhuanjia
{
    public static class Files
    {
        /// <summary>
        /// 生成静态页面
        /// </summary>
        /// <param name="strNewsHtml"></param>
        /// <param name="strOldHtml"></param>
        /// <param name="strModeFilePath"></param>
        /// <param name="strPageFilePath"></param>
        /// <returns></returns>
        public static bool CreatHtmlPage(string[] strNewsHtml, string[] strOldHtml, string strModeFilePath, string strPageFilePath)
        {
            bool Flage = false;
            StreamReader ReaderFile = null;
            StreamWriter WrirteFile = null;
            string FilePath = HttpContext.Current.Server.MapPath(strModeFilePath);
            Encoding Code = Encoding.GetEncoding("utf-8");
            string strFile = string.Empty;
            try
            {
                ReaderFile = new StreamReader(FilePath, Code);
                strFile = ReaderFile.ReadToEnd();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ReaderFile.Close();
            }
            try
            {
                int intLengTh = strNewsHtml.Length;
                for (int i = 0; i < intLengTh; i++)
                {
                    strFile = strFile.Replace(strOldHtml[i], strNewsHtml[i]);
                }
                WrirteFile = new StreamWriter(HttpContext.Current.Server.MapPath(strPageFilePath), false, Code);
                WrirteFile.Write(strFile);
                Flage = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                WrirteFile.Flush();
                WrirteFile.Close();
            }
            return Flage;
        }
        /// <summary>
        /// 更新静态页面中内容
        /// </summary>
        /// <param name="strNewsHtml"></param>
        /// <param name="strStartHtml"></param>
        /// <param name="strEndHtml"></param>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static bool UpdateHtmlPage(string strNewsHtml, string strStartHtml, string strEndHtml, string strHtml)
        {
            bool Flage = false;
            StreamReader ReaderFile = null;
            StreamWriter WrirteFile = null;
            string FilePath = HttpContext.Current.Server.MapPath(strHtml);
            Encoding Code = Encoding.GetEncoding("utf-8");
            string strFile = string.Empty;
            try
            {
                ReaderFile = new StreamReader(FilePath, Code);
                strFile = ReaderFile.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ReaderFile.Close();
            }
            try
            {
                int intLengTh = strNewsHtml.Length;
                int intStart = strFile.IndexOf(strStartHtml);
                int intEnd = strFile.IndexOf(strEndHtml)+strEndHtml.Length;
                string strOldHtml = strFile.Substring(intStart, intEnd - intStart);
                strFile = strFile.Replace(strOldHtml, strStartHtml + strNewsHtml + strEndHtml);
                WrirteFile = new StreamWriter(FilePath, false, Code);
                WrirteFile.Write(strFile);
                Flage = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                WrirteFile.Flush();
                WrirteFile.Close();
            }
            return Flage;
        }



        /// <summary>
        /// 拷贝文件夹
        /// </summary>
        /// <param name="sourceDirectory"></param>
        /// <param name="destDirectory"></param>
        public static void copyDirectory(string sourceDirectory, string destDirectory)
        {
            //判断源目录和目标目录是否存在，如果不存在，则创建一个目录
            if (!Directory.Exists(sourceDirectory))
            {
                Directory.CreateDirectory(sourceDirectory);
            }
            if (!Directory.Exists(destDirectory))
            {
                Directory.CreateDirectory(destDirectory);
            }
            //拷贝文件
            copyFile(sourceDirectory, destDirectory);

            //拷贝子目录       
            //获取所有子目录名称
            string[] directionName = Directory.GetDirectories(sourceDirectory);

            foreach (string directionPath in directionName)
            {
                //根据每个子目录名称生成对应的目标子目录名称
                string directionPathTemp = destDirectory + "\\" + directionPath.Substring(sourceDirectory.Length + 1);

                //递归下去
                copyDirectory(directionPath, directionPathTemp);
            }
        }
        /// <summary>
        /// 拷贝文件
        /// </summary>
        /// <param name="sourceDirectory"></param>
        /// <param name="destDirectory"></param>
        public static void copyFile(string sourceDirectory, string destDirectory)
        {
            //获取所有文件名称
            string[] fileName = Directory.GetFiles(sourceDirectory);

            foreach (string filePath in fileName)
            {
                //根据每个文件名称生成对应的目标文件名称
                string filePathTemp = destDirectory + "\\" + filePath.Substring(sourceDirectory.Length + 1);

                //若不存在，直接复制文件；若存在，覆盖复制
                if (File.Exists(filePathTemp))
                {
                    File.Copy(filePath, filePathTemp, true);
                }
                else
                {
                    File.Copy(filePath, filePathTemp);
                }
            }
        }    
    }

}