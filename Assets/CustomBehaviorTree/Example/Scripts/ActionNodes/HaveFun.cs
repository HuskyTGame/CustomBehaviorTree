/****************************************************
	文件：HaveFun.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/26 21:11:46
	功能：玩（Playground）+mood
*****************************************************/

using UnityEngine;
using HTUtility;

namespace AI.BehaviorTree.Example
{
    public class HaveFun : ActionNode
    {
        protected override BTNodeStatus OnExcute(IAgent agent, Blackboard bb)
        {
            AIModel model = ((AIEntity)agent).Model;
            if (CheckOver(model))
            {
                HTLogger.Debug("退出娱乐");
                return BTNodeStatus.Finished;
            }
            model.Food.Value += BTExampleConsts.MOOD_TO_FOOD * Time.deltaTime;
            model.Water.Value += BTExampleConsts.MOOD_TO_WATER * Time.deltaTime;
            model.Energy.Value += BTExampleConsts.MOOD_TO_ENERGY * Time.deltaTime;
            model.Mood.Value += BTExampleConsts.MOOD_TO_MOOD * Time.deltaTime;
            model.Money.Value += BTExampleConsts.MOOD_TO_MONEY * Time.deltaTime;
            return BTNodeStatus.Running;
        }
        private bool CheckOver(AIModel model)
        {
            return model.Food.Value <= 28
                || model.Water.Value <= 28
                || model.Energy.Value <= 28
                || model.Mood.Value >= 80;
        }
    }
}
