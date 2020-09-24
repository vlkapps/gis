using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace vlkGIS
{
    public class IniFile
    {
        private readonly string path; // Имя файла.

        [DllImport("kernel32")]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32")]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public IniFile(string IniPath)
        {
            path = new FileInfo(IniPath).FullName.ToString();
        }

        // ЧТЕНИЕ INI И ВОЗВРАЩЕНИЕ КЛЮЧА
        public string Read(string Section, string Key, string def)
        {
            StringBuilder RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, def, RetVal, 255, path);
            return RetVal.ToString();
        }

        // ЗАПИСЬ КЛЮЧА
        public void Write(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, path);
        }
    }
}
