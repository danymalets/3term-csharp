using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace ETL
{
    public class XMLParser : IConfigurationParser
    {
        public XMLParser()
        {
        }

        public T Parse<T>(string contents) where T : new()
        {
            T ans = new T();
            Type type = typeof(T);
            contents = contents.Trim(new char[] { ' ', '\n', '\t', '\r' });
            List<(string, bool)> list = new List<(string, bool)>();
            bool isTag = false;
            string temp = "";
            foreach (char c in contents)
            {
                if (c == '>')
                {
                    if (temp.Length > 0)
                    {
                        list.Add((temp, isTag));
                        temp = "";
                    }
                    isTag = false;
                }

                if (c != '<' && c != '>')
                {
                    temp += c;
                }

                if (c == '<')
                {
                    if (temp.Length > 0)
                    {
                        list.Add((temp, isTag));
                        temp = "";
                    }
                    isTag = true;
                }
            }
            string value = "";
            int cnt = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Item2)
                {
                    string key = list[i].Item1;
                    cnt = 0;
                    i++;
                    while (list[i].Item1 != "/" + key)
                    {
                        value += list[i].Item1;
                        cnt++;
                        i++;
                    }
                    value = value.Trim(new char[] { ' ', '\n', '\t', '\r' });
                    if (cnt == 1)
                    {
                        if (value[0] == '\"')
                        {
                            value = value.Remove(0, 1);
                            value = value.Remove(value.Length - 1);
                        }
                        FieldInfo info = type.GetField(key);
                        info.SetValue(ans, Convert.ChangeType(value, info.FieldType));
                    }
                    else
                    {
                        FieldInfo info = type.GetField(key);
                        info.SetValue(ans, typeof(XMLParser)
                            .GetMethod("Parse")
                            .MakeGenericMethod(new Type[] { info.FieldType })
                            .Invoke(null, new object[] { value }));
                    }
                    value = "";
                }
            }
            return ans;
        }
    }
}

