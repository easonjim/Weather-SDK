using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComLib;
using Newtonsoft.Json;

namespace weather
{
    public class BaiduMap
    {
        private static readonly string _key = "904a05c94a91dc12712225f8a9dd6a62";

        public static string GetCity(string latitude, string longitude)
        {
            string url =
                string.Format(
                    "http://api.map.baidu.com/geocoder/v2/?ak={0}&location={1},{2}&output=json&pois=0",
                    _key, latitude, longitude);
            HttpHelper request = new HttpHelper();
            HttpItem item = new HttpItem();
            item.URL = url;
            var jsonhtml = request.GetHtml(item).Html;
            if (!jsonhtml.IsNullOrEmpty())
            {
                var jsonobj = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonhtml);
                if (jsonobj != null && jsonobj["status"].ToString() == "0")
                {
                    var temp =
                        JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonobj["result"].ToString());
                    if (temp != null)
                    {
                        var temp1 =
                            JsonConvert.DeserializeObject<Dictionary<string, object>>(temp["addressComponent"].ToString());
                        if (temp1 != null)
                        {
                            return temp1["city"].ToString().Replace("市", "");
                        }
                    }
                }
            }
            return "";
        }
    }
}