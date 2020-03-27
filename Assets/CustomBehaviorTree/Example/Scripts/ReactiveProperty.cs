/****************************************************
	文件：ReactiveProperty.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/26 15:41:28
	功能：响应式属性
*****************************************************/

using System;
using UnityEngine;
using HTUtility;

namespace AI.BehaviorTree.Example
{
    public class ReactiveProperty<T>
    {
        private T mValue;
        public T Value
        {
            get => mValue;
            set
            {
                if (mValue.Equals(value) == false)
                {
                    mValue = value;
                    mOnValueChanged?.Invoke(value);
                }
            }
        }
        private Action<T> mOnValueChanged;
        public void Subscribe(Action<T> onValueChanged)
        {
            mOnValueChanged = onValueChanged;
            onValueChanged?.Invoke(mValue);
        }
        public ReactiveProperty(T initialValue)
        {
            mValue = initialValue;
        }
    }
}
