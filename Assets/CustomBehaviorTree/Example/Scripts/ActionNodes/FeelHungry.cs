/****************************************************
	文件：FeelHungry.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/26 20:12:57
	功能：想去吃食物（Restaurant）+food
*****************************************************/

using HTUtility;

namespace AI.BehaviorTree.Example
{
    public class FeelHungry : ActionNode
    {
        protected override bool InternalCondition(IAgent agent, Blackboard bb)
        {
            AIModel model = ((AIEntity)agent).Model;
            bool ret = model.Food.Value <= 50
                && model.Water.Value >= 15
                && model.Money.Value >= 20;
            if (ret)
                HTLogger.Debug("通过food检测");
            else
                HTLogger.Debug("未通过food检测");
            return ret;
        }
        private string[] mThinkingArray = new string[3] { "饿死了，觅食、觅食...", "中餐还是西餐？...", "饿的可以吃下一头牛" };
        protected override BTNodeStatus OnExcute(IAgent agent, Blackboard bb)
        {
            AIEntity entity = (AIEntity)agent;
            bb.SetValue(BlackboardKey.TargetMovePos, entity.Restaurant.position);
            entity.Model.Thinking.Value = mThinkingArray[UnityEngine.Random.Range(0, mThinkingArray.Length)];
            HTLogger.Debug("感觉饥饿，设置目标地点：Restaurant，坐标：" + entity.Restaurant.position);
            return BTNodeStatus.Finished;
        }
    }
}
