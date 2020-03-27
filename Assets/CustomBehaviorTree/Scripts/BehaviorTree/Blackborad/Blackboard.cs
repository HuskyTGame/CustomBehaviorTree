/****************************************************
	文件：Blackboard.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/25 18:50:42
	功能：黑板（包含行为树各个节点之间需要传递的信息）
*****************************************************/

using System.Collections.Generic;

namespace AI.BehaviorTree
{
    public class Blackboard
    {
        /// <summary>
        /// 缓存所有黑板数据项
        /// </summary>
        private Dictionary<int, BlackboardItem> mItems;

        public Blackboard()
        {
            mItems = new Dictionary<int, BlackboardItem>();
        }

        /// <summary>
        /// 设置黑板数据，若设置了有效时间，则有效时间到了之后数据将失效
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param 有效时间="validTime"></param>
        public void SetValue(BlackboardKey key, object value, float validTime = -1.0f)
        {
            SetValue((int)key, value, validTime);
        }
        /// <summary>
        /// 获取黑板数据
        /// </summary>
        public T GetValue<T>(BlackboardKey key, T defaultValue)
        {
            return GetValue<T>((int)key, defaultValue);
        }
        /// <summary>
        /// 删除黑板数据
        /// </summary>
        public bool DeleteValue(BlackboardKey key)
        {
            return DeleteValue((int)key);
        }
        /// <summary>
        /// 黑板中是否包含指定数据
        /// </summary>
        public bool ContainsValue(BlackboardKey key)
        {
            return ContainsValue((int)key);
        }
        /// <summary>
        /// 尝试从黑板中获取指定数据
        /// </summary>
        public bool TryGetValue<T>(BlackboardKey key, out T value)
        {
            return TryGetValue<T>((int)key, out value);
        }

        /// <summary>
        /// 设置黑板数据，若设置了有效时间，则有效时间到了之后数据将失效
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param 有效时间="validTime"></param>
        public void SetValue(int key, object value, float validTime = -1.0f)
        {
            BlackboardItem item;
            if (mItems.TryGetValue(key, out item) == false)
            {
                item = new BlackboardItem();
                mItems.Add(key, item);
            }
            item.SetValue(value, validTime);
        }
        /// <summary>
        /// 获取黑板数据
        /// </summary>
        public T GetValue<T>(int key, T defaultValue)
        {
            BlackboardItem item;
            if (mItems.TryGetValue(key, out item) == false)
            {
                return defaultValue;
            }
            return item.GetValue<T>(defaultValue);
        }
        /// <summary>
        /// 删除黑板数据
        /// </summary>
        public bool DeleteValue(int key)
        {
            return mItems.Remove(key);
        }
        /// <summary>
        /// 黑板中是否包含指定数据
        /// </summary>
        public bool ContainsValue(int key)
        {
            if (mItems.ContainsKey(key) == false)
                return false;
            return mItems[key].ValidValue();
        }
        /// <summary>
        /// 尝试从黑板中获取指定数据
        /// </summary>
        public bool TryGetValue<T>(int key, out T value)
        {
            BlackboardItem item;
            if (mItems.TryGetValue(key, out item) == false || item.ValidValue() == false)
            {
                value = default(T);
                return false;
            }
            value = item.GetValue<T>(default(T));
            return true;
        }
    }
}
