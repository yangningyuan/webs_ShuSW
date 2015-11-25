using System;
using System.IO;
using System.Text;

namespace Common.Commons
{
    public class TxtFile
    {
        FileStream fs; //声明文件流的对象  
        StreamReader sr; //声明读取器的对象  
        StreamWriter sw; //声明写入器的对象  

        public string ReadTxtFile(string path)
        {
            string str = "";
            try
            {
                //创建文件流  
                fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                sr = new StreamReader(fs, Encoding.UTF8);
                str = sr.ReadToEnd(); //读取文件所有内容  
            }
            catch (Exception)
            {

            }
            finally
            {
                if (fs != null)
                {
                    sr.Close(); //关闭读取器  
                    fs.Close(); //关闭文件流  
                }
            }
            return str;
        }
        public void WriteTxtFile(string path, string txtContent)
        {
            try
            {
                fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                sw = new StreamWriter(fs, Encoding.UTF8);
                sw.Write(txtContent);
            }
            catch (Exception)
            {

            }
            finally
            {
                if (fs != null)
                {
                    sw.Close();
                    fs.Close();
                }
            }
        }
    }
}
