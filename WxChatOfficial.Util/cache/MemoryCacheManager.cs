using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace WxChatOfficial.Util.cache
{
    /// <summary>
    /// 作者: TFC
    /// 时间: 2019年4月4日
    /// 用途: 微软自带缓存实现类
    /// </summary>
    public class MemoryCacheManager:ICacheManager
    {
        /**
         * MemoryCache.Default中的Default是微软缓存的默认实例
         * 一般情况下,不建议自己创建MemoryCache
         */

        /// <summary>
        /// 取cache
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public T GetCache<T>(string key)
        {
            return (T) MemoryCache.Default.Get(key);
        }

        /// <summary>
        /// 存cache
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="cacheTimeSpan">缓存过期时间</param>
        public void SetCache(string key, object value, TimeSpan cacheTimeSpan)
        {
            MemoryCache.Default.Add(key, value, new CacheItemPolicy {SlidingExpiration = cacheTimeSpan});
        }

        /// <summary>
        /// 移除cache
        /// </summary>
        /// <param name="key">键</param>
        public void Remove(string key)
        {
            MemoryCache.Default.Remove(key);
        }

        /// <summary>
        /// 清空cache
        /// </summary>
        public void Clear()
        {
            /**
             * MemoryCache不存在清空方法
             * 循环出所有的键,调用本类的Remove方法
             */
            foreach (KeyValuePair<string, object> pair in MemoryCache.Default)
            {
                Remove(pair.Key);
            }
        }

        /// <summary>
        /// 判断缓存中是否存在当前键
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>true存在,false不存在</returns>
        public bool Contains(string key)
        {
            return MemoryCache.Default.Contains(key);
        }
    }
}
