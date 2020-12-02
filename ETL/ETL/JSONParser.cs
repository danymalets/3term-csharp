using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ETL
{
    public class JSONParser : IConfigurationParser
    {
        public JSONParser()
        {
        }

        public T Parse<T>(string contents) where T : new()
        {
            T ans = new T();
            Type type = typeof(T);
            contents = contents.Trim(new char[] { ' ', '\n', '\t', '\r' });
            if (contents[0] == '{')
            {
                int depth = 0;
                int arg = 0;
                string key = "", value = "";
                bool inStr = false;
                foreach (char c in contents)
                {
                    if ((c == '}' || c == ',') && depth == 1)
                    {
                        key = key.Trim(new char[] { ' ', '\n', '\t', '\r' });
                        value = value.Trim(new char[] { ' ', '\n', '\t', '\r' });

                        key = key.Remove(0, 1);
                        key = key.Remove(key.Length - 1);

                        if (value[0] == '{')
                        {
                            value = value.Remove(0, 1);
                            value = value.Remove(value.Length - 1);

                            FieldInfo info = type.GetField(key);
                            info.SetValue(ans, typeof(JSONParser)
                                .GetMethod("Parse")
                                .MakeGenericMethod(new Type[] { info.FieldType })
                                .Invoke(null, new object[] { value }));
                        }
                        else
                        {
                            if (value[0] == '\"')
                            {
                                value = value.Remove(0, 1);
                                value = value.Remove(value.Length - 1);
                            }
                            FieldInfo info = type.GetField(key);
                            info.SetValue(ans, Convert.ChangeType(value, info.FieldType));
                        }

                        key = value = "";
                    }
                    if (c == '\"')
                    {
                        inStr = !inStr;
                    }
                    else if (c == '{')
                    {
                        depth++;
                    }
                    else if (c == '}')
                    {
                        depth--;
                    }
                    else if (c == ',')
                    {
                        arg = 0;
                    }
                    else if (c == ':')
                    {
                        arg = 0;
                    }

                    if (arg == 1)
                    {
                        key += c;
                    }
                    else if (arg == 2)
                    {
                        value += c;
                    }

                    if ((c == ',' || c == '{') && depth == 1 && !inStr)
                    {
                        arg = 1;
                    }
                    else if (c == ':' && depth == 1 && !inStr)
                    {
                        arg = 2;
                    }
                }
            }
            return ans;
        }
    }
}

