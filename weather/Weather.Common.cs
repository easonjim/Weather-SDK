using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using ComLib;
using Newtonsoft.Json;

namespace weather
{
    public class Weather
    {
        /// <summary>
        /// 城市天气全面版
        /// </summary>
        /// <returns></returns>
        public static string GetData(string id, string name = null, string latitude = null, string longitude = null)
        {
            ComLib.LogLib.Log4NetBase.Log("调用GetData-时间：" + DateTime.Now.ToString());

            var ID = id ?? Data.GetID(name ?? BaiduMap.GetCity(latitude, longitude));
            if (ID.IsNullOrEmpty())
            {
                return "{\"status\":\"201\",\"message\":\"城市代码获取失败\"}";
            }
            string url = string.Format("http://m.weather.com.cn/data/{0}.html", ID);
            HttpHelper request = new HttpHelper();
            HttpItem item = new HttpItem();
            item.URL = url;
            var jsonhtml = request.GetHtml(item).Html;
            if (Regex.IsMatch(jsonhtml, "404") || Regex.IsMatch(jsonhtml, "302"))
            {
                return "{\"status\":\"201\",\"message\":\"数据获取失败\"}";
            }
            return jsonhtml;
        }

        /// <summary>
        /// 实时天气
        /// </summary>
        /// <returns></returns>
        public static string GetSK(string id, string name = null, string latitude = null, string longitude = null)
        {
            ComLib.LogLib.Log4NetBase.Log("调用GeSK-时间：" + DateTime.Now.ToString());

            var ID = id ?? Data.GetID(name ?? BaiduMap.GetCity(latitude, longitude));
            if (ID.IsNullOrEmpty())
            {
                return "{\"status\":\"201\",\"message\":\"城市代码获取失败\"}";
            }
            string url = string.Format("http://www.weather.com.cn/data/sk/{0}.html", ID);
            HttpHelper request = new HttpHelper();
            HttpItem item = new HttpItem();
            item.URL = url;
            var jsonhtml = request.GetHtml(item).Html;
            if (Regex.IsMatch(jsonhtml, "404") || Regex.IsMatch(jsonhtml, "302"))
            {
                return "{\"status\":\"201\",\"message\":\"数据获取失败\"}";
            }
            return jsonhtml;
        }

        /// <summary>
        /// 城市天气
        /// </summary>
        /// <returns></returns>
        public static string GetCityInfo(string id, string name = null, string latitude = null, string longitude = null)
        {
            ComLib.LogLib.Log4NetBase.Log("调用GetCityInfo-时间：" + DateTime.Now.ToString());

            var ID = id ?? Data.GetID(name ?? BaiduMap.GetCity(latitude, longitude));
            if (ID.IsNullOrEmpty())
            {
                return "{\"status\":\"201\",\"message\":\"城市代码获取失败\"}";
            }
            string url = string.Format("http://www.weather.com.cn/data/cityinfo/{0}.html", ID);
            HttpHelper request = new HttpHelper();
            HttpItem item = new HttpItem();
            item.URL = url;
            var jsonhtml = request.GetHtml(item).Html;
            if (Regex.IsMatch(jsonhtml, "404") || Regex.IsMatch(jsonhtml, "302"))
            {
                return "{\"status\":\"201\",\"message\":\"数据获取失败\"}";
            }
            return jsonhtml;
        }

        /// <summary>
        /// 1
        /// </summary>
        public static string 跳转全国雷达()
        {
            ComLib.LogLib.Log4NetBase.Log("调用跳转全国雷达-时间：" + DateTime.Now.ToString());

            string url =
                "http://mobile.weather.com.cn/product/templates/templates_ImgPlay_main.html?dataFile=http://i.weather.com.cn/i/product/json/radarM/JC_RADAR_CHN_JB.html";

            return "{\"status\":\"200\",\"message\":\"ok\",\"data\":\"" + url + "\"}";
        }

        /// <summary>
        /// 2
        /// </summary>
        public static string 跳转全国气象公报()
        {
            ComLib.LogLib.Log4NetBase.Log("调用跳转全国气象公报-时间：" + DateTime.Now.ToString());

            string url = "http://www.weather.com.cn/cnweather/index_top3.shtml";
            return "{\"status\":\"200\",\"message\":\"ok\",\"data\":\"" + url + "\"}";
        }

        /// <summary>
        /// 3
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public static string 跳转实时天气详情(string id, string name = null, string latitude = null, string longitude = null)
        {
            ComLib.LogLib.Log4NetBase.Log("调用跳转实时天气详情-时间：" + DateTime.Now.ToString());

            var ID = id ?? Data.GetID(name ?? BaiduMap.GetCity(latitude, longitude));
            string url = string.Format("http://mobile.weather.com.cn/city/{0}.html",ID);
            return "{\"status\":\"200\",\"message\":\"ok\",\"data\":\"" + url + "\"}";
        }

        /// <summary>
        /// 4
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public static string 跳转网页雷达(string id, string name = null, string latitude = null, string longitude = null)
        {
            ComLib.LogLib.Log4NetBase.Log("调用跳转网页雷达-时间：" + DateTime.Now.ToString());

            var jsonhtml = GetSK(id, name, latitude, longitude);
            if (!jsonhtml.Contains("失败"))
            {
                var json = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonhtml);
                var temp = JsonConvert.DeserializeObject<Dictionary<string, object>>(json["weatherinfo"].ToString());
                string url = string.Format("http://www.weather.com.cn/html/radar/{0}.shtml", temp["Radar"].ToString());
                return "{\"status\":\"200\",\"message\":\"ok\",\"data\":\"" + url + "\"}";
            }
            return "{\"status\":\"201\",\"message\":\"Error\"}";
        }

        /// <summary>
        /// 5
        /// </summary>
        public static string 跳转卫星云图()
        {
            ComLib.LogLib.Log4NetBase.Log("调用跳转卫星云图-时间：" + DateTime.Now.ToString());

            string url = "http://mobile.weather.com.cn/product/templates/templates_ImgPlay_main.html?dataFile=http://i.weather.com.cn/i/product/json/jsl/JC_YT_DL_WXZXCSYT.html";
            return "{\"status\":\"200\",\"message\":\"ok\",\"data\":\"" + url + "\"}";
        }

        /// <summary>
        /// 6
        /// </summary>
        public static string 跳转温度实况()
        {
            ComLib.LogLib.Log4NetBase.Log("调用跳转温度实况-时间：" + DateTime.Now.ToString());

            string url = "http://mobile.weather.com.cn/product/templates/templates_ImgPlay_main.html?dataFile=http://i.weather.com.cn/i/product/json/jsl/JC_JSL_1HT.html";
            return "{\"status\":\"200\",\"message\":\"ok\",\"data\":\"" + url + "\"}";
        }

        /// <summary>
        /// 7
        /// </summary>
        public static string 跳转风速实况()
        {
            ComLib.LogLib.Log4NetBase.Log("调用跳转风速实况-时间：" + DateTime.Now.ToString());

            string url = "http://mobile.weather.com.cn/product/templates/templates_ImgPlay_main.html?dataFile=http://i.weather.com.cn/i/product/json/jsl/JC_JSL_1HW.html";
            return "{\"status\":\"200\",\"message\":\"ok\",\"data\":\"" + url + "\"}";
        }

        /// <summary>
        /// 8
        /// </summary>
        public static string 跳转灾难预警()
        {
            ComLib.LogLib.Log4NetBase.Log("调用跳转灾难预警-时间：" + DateTime.Now.ToString());

            string url = "http://mobile.weather.com.cn/list.html";
            return "{\"status\":\"200\",\"message\":\"ok\",\"data\":\"" + url + "\"}";
        }

        /// <summary>
        /// 9
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public static string 跳转城市雷达(string id, string name = null, string latitude = null, string longitude = null)
        {
            ComLib.LogLib.Log4NetBase.Log("调用跳转城市雷达-时间：" + DateTime.Now.ToString());

            var ID = id ?? Data.GetID(name ?? BaiduMap.GetCity(latitude, longitude));
            string url = string.Format("http://mobile.weather.com.cn/product/templates/templates_ImgPlay_main.html?dataFile=http://i.weather.com.cn/i/product/json/radarM/p_{0}.html", ID);
            return "{\"status\":\"200\",\"message\":\"ok\",\"data\":\"" + url + "\"}";
        }

        /// <summary>
        /// 10
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public static string 跳转城市趋势(string id, string name = null, string latitude = null, string longitude = null)
        {
            ComLib.LogLib.Log4NetBase.Log("调用跳转城市趋势-时间：" + DateTime.Now.ToString());

            var ID = id ?? Data.GetID(name ?? BaiduMap.GetCity(latitude, longitude));
            string url = string.Format("http://mobile.weather.com.cn/weather/{0}.html", ID);
            return "{\"status\":\"200\",\"message\":\"ok\",\"data\":\"" + url + "\"}";
        }

        /// <summary>
        /// 11
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public static string 跳转城市指数(string id, string name = null, string latitude = null, string longitude = null)
        {
            ComLib.LogLib.Log4NetBase.Log("调用跳转城市指数-时间：" + DateTime.Now.ToString());

            var ID = id ?? Data.GetID(name ?? BaiduMap.GetCity(latitude, longitude));
            string url = string.Format("http://mobile.weather.com.cn/observe/{0}.html", ID);
            return "{\"status\":\"200\",\"message\":\"ok\",\"data\":\"" + url + "\"}";
        }
        
        /// <summary>
        /// 12
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public static string 跳转降雨量()
        {
            string url = "http://mobile.weather.com.cn/product/templates/templates_ImgPlay_main.html?dataFile=http://i.weather.com.cn/i/product/json/jsl/JC_JSL_1HR.html";
            return "{\"status\":\"200\",\"message\":\"ok\",\"data\":\"" + url + "\"}";
        }
    }
}