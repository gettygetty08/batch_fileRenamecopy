using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bacth_filerenamecopy
{
    class Program
    {
        static void Main(string[] args)
        {

            string 作業用パス = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName;
            string 結合用フォルダ名 = "結合用フォルダ";

            var 作業フォルダ = new DirectoryInfo(作業用パス);
            var 結合用フォルダ = 作業フォルダ.CreateSubdirectory(結合用フォルダ名);

            var directories = 作業フォルダ.EnumerateDirectories().Where(x => x.GetFiles().Count() > 0 && x.Name != 結合用フォルダ.Name).ToArray();

            foreach (var dirinfo in directories)
            {
                var files = dirinfo.GetFiles();
                foreach (var fileinfo in files)
                {
                    fileinfo.CopyTo(Path.Combine(結合用フォルダ.FullName, dirinfo.Name + fileinfo.Name), overwrite: true);
                }
            }


        }
    }
}
