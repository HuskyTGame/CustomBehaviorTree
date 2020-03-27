/****************************************************
	文件：BlackboardItem.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/25 18:50:33
	功能：黑板内的单个数据项
*****************************************************/

using UnityEngine;

namespace AI.BehaviorTree
{
    public class BlackboardItem
    {
        /// <summary>
        /// 黑板数据有效的终止时间（部分黑板数据可能有有效期，超过有效期将无效）
        /// </summary>
        private float mExpiredValidTime;
        private object mValue;
        public void SetValue(object value, float validTime = -1.0f)
        {
            if (validTime >= 0)//数据存在有效时间
                //更新 黑板数据有效的终止时间
                mExpiredValidTime = Time.time + validTime;
            else
                mExpiredValidTime = -1.0f;
            mValue = value;
        }
        /// <summary>
        /// 获取黑板数据
        /// </summary>
        /// <typeparam 数据类型="T"></typeparam>
        /// <param 默认数据="defaultValue"></param>
        /// <returns></returns>
        public T GetValue<T>(T defaultValue)
        {
            if (ValidValue())
                return (T)mValue;
            return defaultValue;
        }
        public bool ValidValue()
        {
            return mExpiredValidTime < 0 || mExpiredValidTime >= Time.time;
        }
    }
}
