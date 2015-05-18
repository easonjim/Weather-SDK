using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace weather
{
    public class Data
    {
        private readonly static string _weatherData = ComLib.FileManage.ReadFile(HttpContext.Current.Server.MapPath("/Data/weather.txt"));

        public static string GetID(string name)
        {
            return Regex.Match(_weatherData, string.Format(@"(\d.*)={0}", name)).Groups[1].Value;
        }

        public static string ResponseID(string name)
        {
            ComLib.LogLib.Log4NetBase.Log("调用ResponseID-时间：" + DateTime.Now.ToString());

            var ID = GetID(name);
            if (ID.IsNullOrEmpty())
            {
                return "{\"status\":\"201\",\"message\":\"数据获取失败\"}";
            }
            else
            {
                return "{\"status\":\"200\",\"message\":\"ok\",\"data\":\"" + ID + "\"}";
            }
        }

        public static string GetName(string ID)
        {
            return Regex.Match(_weatherData, string.Format(@"{0}=(\w.*)[^\n]", ID)).Groups[1].Value; ;
        }

        public static string ResponseName(string id)
        {
            ComLib.LogLib.Log4NetBase.Log("调用ResponseName-时间：" + DateTime.Now.ToString());

            var name = GetName(id);
            if (name.IsNullOrEmpty())
            {
                return "{\"status\":\"201\",\"message\":\"数据获取失败\"}";
            }
            else
            {
                return "{\"status\":\"200\",\"message\":\"ok\",\"data\":\"" + name + "\"}";
            }
        }
    }
}