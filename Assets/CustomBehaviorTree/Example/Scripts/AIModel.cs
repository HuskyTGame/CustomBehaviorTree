/****************************************************
	文件：AIModel.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/26 15:28:34
	功能：AI 的数据类
*****************************************************/

using System;
using UnityEngine;
using HTUtility;

namespace AI.BehaviorTree.Example
{
    [Serializable]
    public class AIModel
    {
        public ReactiveProperty<float> Food;
        public ReactiveProperty<float> Water;
        public ReactiveProperty<float> Energy;
        public ReactiveProperty<float> Mood;
        public ReactiveProperty<float> Money;
        public ReactiveProperty<string> Thinking;
        public AIModel(float food, float water, float energy, float mood, float money, string thinking)
        {
            Food = new ReactiveProperty<float>(food);
            Water = new ReactiveProperty<float>(water);
            Energy = new ReactiveProperty<float>(energy);
            Mood = new ReactiveProperty<float>(mood);
            Money = new ReactiveProperty<float>(money);
            Thinking = new ReactiveProperty<string>(thinking);
        }
    }
}
