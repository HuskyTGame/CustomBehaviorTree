/****************************************************
	文件：HaveRest.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/26 21:11:36
	功能：回家休息（Home）+Energy
*****************************************************/

using UnityEngine;
using HTUtility;

namespace AI.BehaviorTree.Example
{
    public class HaveRest : ActionNode
    {
        protected override BTNodeStatus OnExcute(IAgent agent, Blackboard bb)
        {
            AIModel model = ((AIEntity)agent).Model;
            if (CheckOver(model))
            {
                HTLogger.Debug("退出休息");
                return BTNodeStatus.Finished;
            }
            model.Food.Value += BTExampleConsts.ENERGY_TO_FOOD * Time.deltaTime;
            model.Water.Value += BTExampleConsts.ENERGY_TO_WATER * Time.deltaTime;
            model.Energy.Value += BTExampleConsts.ENERGY_TO_ENERGY * Time.deltaTime;
            model.Mood.Value += BTExampleConsts.ENERGY_TO_MOOD * Time.deltaTime;
            model.Money.Value += BTExampleConsts.ENERGY_TO_MONEY * Time.deltaTime;
            return BTNodeStatus.Running;
        }
        private bool CheckOver(AIModel model)
        {
            return model.Food.Value <= 10
                || model.Water.Value <= 10
                || model.Energy.Value >= 80
                || model.Money.Value <= 5;
        }
    }
}
