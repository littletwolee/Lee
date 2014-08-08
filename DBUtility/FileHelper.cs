using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
namespace DBUtility
{
    public abstract class FileHelper
    {
        public FileHelper() { }
        /// <summary>
        /// 保存文件（从URL参数中获取文件名、当前指针，将文件流保存到当前指针后）
        /// 如果是第一次上传，则当前指针为0，代码执行与续传一样，只不过指针没有偏移
        /// </summary>
        public static bool SaveUpLoadFile(string fileName, long npos,int upLoadLength,Stream filestream)
        {
            bool flag = false;
            string path = System.Web.HttpContext.Current.Server.MapPath(@"/files/UpLoad/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            fileName = path + fileName;

            FileStream fStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //偏移指针
            fStream.Seek(npos, SeekOrigin.Begin);

            //从客户端的请求中获取文件流
            BinaryReader bReader = new BinaryReader(filestream);
            try
            {
                byte[] data = new byte[upLoadLength];
                bReader.Read(data, 0, upLoadLength);
                fStream.Write(data, 0, upLoadLength);
                flag = true;
            }
            catch
            {
                //TODO 添加异常处理
            }
            finally
            {
                //释放流
                fStream.Close();
                bReader.Close();
            }
            return flag;
        }
    }
}
