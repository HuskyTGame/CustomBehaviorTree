/****************************************************
	文件：GameFacade.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/26 16:4:48
	功能：外观类
*****************************************************/

using System;
using UnityEngine;
using HTUtility;

namespace AI.BehaviorTree.Example
{
    public class GameFacade : HTSingleton<GameFacade>
    {
        private BehaviorTreeExample mExample;

        public void Init(BehaviorTreeExample behaviorTreeExample)
        {
            mExample = behaviorTreeExample;
        }

        public void SubscribeUIFood(float value)
        {
            mExample.SetFoodValue(value);
        }
        public void SubscribeUIWater(float value)
        {
            mExample.SetWaterValue(value);
        }
        public void SubscribeUIEnergy(float value)
        {
            mExample.SetEnergyValue(value);
        }
        public void SubscribeUIMood(float value)
        {
            mExample.SetMoodValue(value);
        }
        public void SubscribeUIMoney(float value)
        {
            mExample.SetMoneyValue(value);
        }
        public void SubscribeTxtThinking(string txt)
        {
            mExample.SetTxtThinking(txt);
        }

        public void SubscribeBtnStart(UnityEngine.Events.UnityAction call)
        {
            mExample.SubscribeBtnStart(call);
        }
        public void SubscribeBtnPause(UnityEngine.Events.UnityAction call)
        {
            mExample.SubscribeBtnPause(call);
        }
        public void SubscribeBtnReset(UnityEngine.Events.UnityAction call)
        {
            mExample.SubscribeBtnReset(call);
        }
    }
}
