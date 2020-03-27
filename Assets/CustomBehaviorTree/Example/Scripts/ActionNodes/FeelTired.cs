/****************************************************
	文件：FeelTired.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/26 20:25:57
	功能：想回家休息（Home）+Energy
*****************************************************/

using HTUtility;

namespace AI.BehaviorTree.Example
{
    public class FeelTired : ActionNode
    {
        protected override bool InternalCondition(IAgent agent, Blackboard bb)
        {
            AIModel model = ((AIEntity)agent).Model;
            bool ret = model.Food.Value >= 30
                && model.Water.Value >= 30
                && model.Energy.Value <= 40
                && model.Money.Value >= 20;
            if (ret)
                HTLogger.Debug("通过energy检测");
            else
                HTLogger.Debug("未通过energy检测");
            return ret;
        }
        private string[] mThinkingArray = new string[3] { "是时候上床睡觉了", "充实的一天", "累成狗......" };
        protected override BTNodeStatus OnExcute(IAgent agent, Blackboard bb)
        {
            AIEntity entity = (AIEntity)agent;
            bb.SetValue(BlackboardKey.TargetMovePos, entity.Home.position);
            entity.Model.Thinking.Value = mThinkingArray[UnityEngine.Random.Range(0, mThinkingArray.Length)];
            HTLogger.Debug("感觉疲惫，设置目标地点：Home，坐标：" + entity.Home.position);
            return BTNodeStatus.Finished;
        }
    }
}
