/****************************************************
	文件：DrinkWater.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/26 21:11:2
	功能：喝水（River）+water
*****************************************************/

using UnityEngine;
using HTUtility;

namespace AI.BehaviorTree.Example
{
    public class DrinkWater : ActionNode
    {
        protected override BTNodeStatus OnExcute(IAgent agent, Blackboard bb)
        {
            AIModel model = ((AIEntity)agent).Model;
            if (CheckOver(model))
            {
                HTLogger.Debug("退出喝水");
                return BTNodeStatus.Finished;
            }
            model.Food.Value += BTExampleConsts.WATER_TO_FOOD * Time.deltaTime;
            model.Water.Value += BTExampleConsts.WATER_TO_WATER * Time.deltaTime;
            model.Energy.Value += BTExampleConsts.WATER_TO_ENERGY * Time.deltaTime;
            model.Mood.Value += BTExampleConsts.WATER_TO_MOOD * Time.deltaTime;
            model.Money.Value += BTExampleConsts.WATER_TO_MONEY * Time.deltaTime;
            return BTNodeStatus.Running;
        }
        private bool CheckOver(AIModel model)
        {
            return model.Food.Value <= 15
                || model.Water.Value >= 80
                || model.Money.Value <= 5;
        }
    }
}
