/****************************************************
	文件：Work.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/26 21:11:56
	功能：工作（Company）+money
*****************************************************/

using UnityEngine;
using HTUtility;

namespace AI.BehaviorTree.Example
{
    public class Work : ActionNode
    {
        protected override BTNodeStatus OnExcute(IAgent agent, Blackboard bb)
        {
            AIModel model = ((AIEntity)agent).Model;
            if (CheckOver(model))
            {
                HTLogger.Debug("退出工作");
                return BTNodeStatus.Finished;
            }
            model.Food.Value += BTExampleConsts.MONEY_TO_FOOD * Time.deltaTime;
            model.Water.Value += BTExampleConsts.MONEY_TO_WATER * Time.deltaTime;
            model.Energy.Value += BTExampleConsts.MONEY_TO_ENERGY * Time.deltaTime;
            model.Mood.Value += BTExampleConsts.MONEY_TO_MOOD * Time.deltaTime;
            model.Money.Value += BTExampleConsts.MONEY_TO_MONEY * Time.deltaTime;
            return BTNodeStatus.Running;
        }
        private bool CheckOver(AIModel model)
        {
            return model.Food.Value <= 20
                || model.Water.Value <= 20
                || model.Energy.Value <= 20
                || model.Mood.Value <= 35;
        }
    }
}
