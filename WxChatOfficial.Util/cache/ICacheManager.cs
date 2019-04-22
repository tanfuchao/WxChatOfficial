using System;

namespace WxChatOfficial.Util.cache
{
    /// <summary>
    /// 作者:TFC
    /// 时间:2019年4月4日
    /// 用途:缓存的接口类
    /// </summary>
    public interface ICacheManager
    {
        /// <summary>
        /// 取cache
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        T GetCache<T>(string key);

        /// <summary>
        /// 存cache
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="cacheTimeSpan">缓存过期时间</param>
        void SetCache(string key, object value, TimeSpan cacheTimeSpan);

        /// <summary>
        /// 移除cache
        /// </summary>
        /// <param name="key">键</param>
        void Remove(string key);

        /// <summary>
        /// 清空cache
        /// </summary>
        void Clear();

        /// <summary>
        /// 判断缓存中是否存在当前键
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>true存在,false不存在</returns>
        bool Contains(string key);
    }
}
