using System;

namespace WxChatOfficial.Util
{
   public class TimeHelper
    {
        /// <summary>
        /// 时间戳转为C#格式时间
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime GetTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime); 
            return dtStart.Add(toNow);
        }

        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string ConvertDateTime(DateTime time)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return Convert.ToString((int)(time - startTime).TotalSeconds);
        }

        /// <summary>
		/// 获取以0点0分0秒开始的日期
		/// </summary>
		/// <param name="d"></param>
		/// <returns></returns>
		public static DateTime GetStartDateTime(DateTime d)
		{
		    if (d.Hour == 0)
		    {
		        return d;
		    }
		    var year = d.Year;
		    var month = d.Month;
		    var day = d.Day;
		    const string hour = "0";
		    const string minute = "0";
		    const string second = "0";
		    d = Convert.ToDateTime($"{year}-{month}-{day} {hour}:{minute}:{second}");
		    return d;
		}

		/// <summary>
		/// 获取以23点59分59秒结束的日期
		/// </summary>
		/// <param name="d"></param>
		/// <returns></returns>
		public static DateTime GetEndDateTime(DateTime d)
		{
		    if (d.Hour == 23)
		    {
		        return d;
		    }
		    var year = d.Year;
		    var month = d.Month;
		    var day = d.Day;
		    const string hour = "23";
		    const string minute = "59";
		    const string second = "59";
		    d = Convert.ToDateTime($"{year}-{month}-{day} {hour}:{minute}:{second}");
		    return d;
		}
    }
}
