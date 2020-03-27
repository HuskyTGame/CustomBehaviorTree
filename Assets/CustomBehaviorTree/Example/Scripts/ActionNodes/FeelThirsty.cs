/****************************************************
	文件：FeelThirsty.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/26 20:23:6
	功能：想去喝水（River）+water
*****************************************************/

using HTUtility;

namespace AI.BehaviorTree.Example
{
    public class FeelThirsty : ActionNode
    {
        protected override bool InternalCondition(IAgent agent, Blackboard bb)
        {
            AIModel model = ((AIEntity)agent).Model;
            bool ret = model.Food.Value >= 15
                && model.Water.Value <= 50
                && model.Money.Value >= 20;
            if (ret)
                HTLogger.Debug("通过water检测");
            else
                HTLogger.Debug("未通过water检测");
            return ret;
        }
        private string[] mThinkingArray = new string[3] { "虽然很渴，但我拒绝肥宅快乐水", "真渴！！！", "白开水，你在哪？" };
        protected override BTNodeStatus OnExcute(IAgent agent, Blackboard bb)
        {
            AIEntity entity = (AIEntity)agent;
            bb.SetValue(BlackboardKey.TargetMovePos, entity.River.position);
            entity.Model.Thinking.Value = mThinkingArray[UnityEngine.Random.Range(0, mThinkingArray.Length)];
            HTLogger.Debug("感觉口渴，设置目标地点：River，坐标：" + entity.River.position);
            return BTNodeStatus.Finished;
        }
    }
}
