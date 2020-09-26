using System.Globalization;
using System.Xml;

namespace vlkGIS.langs
{
    public class Language
    {
        XmlDocument infodoc;
        XmlNodeList nodeList;

        public Language(string langCode)
        {
            getLang(langCode);
        }

        public void getLang(string langCode)
        {
            infodoc = new XmlDocument();
            infodoc.Load("langs\\" + langCode + ".xml");
            nodeList = infodoc.SelectNodes("lang/data");
        }

        // ПОЛУЧЕНИЕ СТРОКИ ПО КЛЮЧУ
        public string getString(string name)
        {
            for (int i = 0; i < nodeList.Count; i++)
                if (nodeList[i].Attributes[0].Value == name)
                    return nodeList[i].Attributes[1].Value;

            return "";
        }

        public CultureInfo getCultureInfo(string langCode)
        {
            return CultureInfo.CreateSpecificCulture(langCode);
        }
    }
}
