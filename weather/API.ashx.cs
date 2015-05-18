using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace weather
{
    /// <summary>
    /// API 的摘要说明
    /// </summary>
    public class API : IHttpHandler
    {
        private string Method 
        {
            get { return ComLib.QueryStringHelper.GetStringByQueryString("method"); }
        }

        private string Type
        {
            get { return ComLib.QueryStringHelper.GetStringByQueryString("type"); }
        }

        private string Value
        {
            get
            {
                return ComLib.QueryStringHelper.GetStringByQueryString("value");
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            ComLib.LogLib.Log4NetBase.Log("API调用-时间：" + DateTime.Now.ToString() + " IP：" + context.Request.UserHostAddress + " UserAgent：" + context.Request.UserAgent);

            switch (Type)
            {
                case "location"://通过经纬度
                    if (!Value.Contains(","))
                    {
                        context.Response.Write("{\"status\":\"201\",\"message\":\"参数错误\"}");
                        ComLib.LogLib.Log4NetBase.Log("API响应-时间：" + DateTime.Now.ToString());
                        context.Response.End();
                    }
                    switch (Method)
                    {
                        case "data":
                            context.Response.Write(Weather.GetData(null, null, Value.Split(',')[0], Value.Split(',')[1]));
                            break;
                        case "sk":
                            context.Response.Write(Weather.GetSK(null, null, Value.Split(',')[0], Value.Split(',')[1]));
                            break;
                        case "cityinfo":
                            context.Response.Write(Weather.GetCityInfo(null, null, Value.Split(',')[0], Value.Split(',')[1]));
                            break;
                        default:
                            context.Response.Write("{\"status\":\"201\",\"message\":\"参数错误\"}");
                            break;
                    }
                    break;
                case"city"://通过城市名
                    switch (Method)
                    {
                        case "data":
                            context.Response.Write(Weather.GetData(null, Value));
                            break;
                        case "sk":
                            context.Response.Write(Weather.GetSK(null, Value));
                            break;
                        case "cityinfo":
                            context.Response.Write(Weather.GetCityInfo(null, Value));
                            break;
                        default:
                            context.Response.Write("{\"status\":\"201\",\"message\":\"参数错误\"}");
                            break;
                    }
                    break;
                case "id"://通过编号
                    switch (Method)
                    {
                        case "data":
                            context.Response.Write(Weather.GetData(Value));
                            break;
                        case "sk":
                            context.Response.Write(Weather.GetSK(Value));
                            break;
                        case "cityinfo":
                            context.Response.Write(Weather.GetCityInfo(Value));
                            break;
                        default:
                            context.Response.Write("{\"status\":\"201\",\"message\":\"参数错误\"}");
                            break;
                    }
                    break;
                case "getid"://通过城市名获取代码
                    context.Response.Write(Data.ResponseID(Value));
                    break;
                case "getname"://通过代码获取城市名
                    context.Response.Write(Data.ResponseName(Value));
                    break;
                case "html":
                    switch (Method)
                    {
                        case "1":
                            context.Response.Write(Weather.跳转全国雷达());
                            break;
                        case "2":
                            context.Response.Write(Weather.跳转全国气象公报());
                            break;
                        case "3":
                            context.Response.Write(Weather.跳转实时天气详情(Value));
                            break;
                        case "4":
                            context.Response.Write(Weather.跳转网页雷达(Value));
                            break;
                        case "5":
                            context.Response.Write(Weather.跳转卫星云图());
                            break;
                        case "6":
                            context.Response.Write(Weather.跳转温度实况());
                            break;
                        case "7":
                            context.Response.Write(Weather.跳转风速实况());
                            break;
                        case "8":
                            context.Response.Write(Weather.跳转灾难预警());
                            break;
                        case "9":
                            context.Response.Write(Weather.跳转城市雷达(Value));
                            break;
                        case "10":
                            context.Response.Write(Weather.跳转城市趋势(Value));
                            break;
                        case "11":
                            context.Response.Write(Weather.跳转城市指数(Value));
                            break;
                        case "12":
                            context.Response.Write(Weather.跳转降雨量());
                            break;
                        default:
                            context.Response.Write("{\"status\":\"201\",\"message\":\"参数错误\"}");
                            break;
                    }
                    break;
                default:
                    context.Response.Write("{\"status\":\"201\",\"message\":\"参数错误\"}");
                    break;
            }

            ComLib.LogLib.Log4NetBase.Log("API响应-时间：" + DateTime.Now.ToString());
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}