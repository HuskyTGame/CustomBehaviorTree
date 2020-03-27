/****************************************************
	文件：EatFood.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/26 21:10:52
	功能：吃食物（Restaurant）+food
*****************************************************/

using UnityEngine;
using HTUtility;

namespace AI.BehaviorTree.Example
{
    public class EatFood : ActionNode
    {
        protected override BTNodeStatus OnExcute(IAgent agent, Blackboard bb)
        {
            AIModel model = ((AIEntity)agent).Model;
            if (CheckOver(model))
            {
                HTLogger.Debug("退出吃东西");
                return BTNodeStatus.Finished;
            }
            model.Food.Value += BTExampleConsts.FOOD_TO_FOOD * Time.deltaTime;
            model.Water.Value += BTExampleConsts.FOOD_TO_WATER * Time.deltaTime;
            model.Energy.Value += BTExampleConsts.FOOD_TO_ENERGY * Time.deltaTime;
            model.Mood.Value += BTExampleConsts.FOOD_TO_MOOD * Time.deltaTime;
            model.Money.Value += BTExampleConsts.FOOD_TO_MONEY * Time.deltaTime;
            return BTNodeStatus.Running;
        }
        private bool CheckOver(AIModel model)
        {
            return model.Food.Value >= 80
                || model.Water.Value <= 15
                || model.Money.Value <= 5;
        }
    }
}
