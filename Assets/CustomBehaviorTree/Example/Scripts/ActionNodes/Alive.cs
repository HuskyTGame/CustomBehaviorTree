/****************************************************
	文件：Alive.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/26 21:58:44
	功能：日常消耗
*****************************************************/

using System;
using UnityEngine;
using HTUtility;

namespace AI.BehaviorTree.Example
{
    public class Alive : ActionNode
    {
        protected override BTNodeStatus OnExcute(IAgent agent, Blackboard bb)
        {
            AIModel model = ((AIEntity)agent).Model;
            if (CheckOver(model))
            {
                HTLogger.Warning("死亡！");
                return BTNodeStatus.Finished;
            }
            model.Food.Value += BTExampleConsts.DAILY_FOOD_COST * Time.deltaTime;
            model.Water.Value += BTExampleConsts.DAILY_WATER_COST * Time.deltaTime;
            model.Energy.Value += BTExampleConsts.DAILY_ENERGY_COST * Time.deltaTime;
            model.Mood.Value += BTExampleConsts.DAILY_MOOD_COST * Time.deltaTime;
            return BTNodeStatus.Running;
        }
        private bool CheckOver(AIModel model)
        {
            return model.Food.Value <= 0
                || model.Water.Value <= 0
                || model.Energy.Value <= 0
                || model.Mood.Value <= 0;
        }
    }
}
