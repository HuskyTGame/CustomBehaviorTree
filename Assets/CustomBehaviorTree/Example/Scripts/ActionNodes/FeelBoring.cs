/****************************************************
	文件：FeelBoring.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/26 20:28:19
	功能：想去玩（Playground）+mood
*****************************************************/

using HTUtility;

namespace AI.BehaviorTree.Example
{
    public class FeelBoring : ActionNode
    {
        protected override bool InternalCondition(IAgent agent, Blackboard bb)
        {
            AIModel model = ((AIEntity)agent).Model;
            bool ret = model.Food.Value >= 30
                && model.Water.Value >= 30
                && model.Energy.Value >= 30
                && model.Mood.Value <= 40;
            if (ret)
                HTLogger.Debug("通过mood检测");
            else
                HTLogger.Debug("未通过mood检测");
            return ret;
        }
        private string[] mThinkingArray = new string[3] { "好无聊啊，想找点乐子", "烦死了，心情差到爆", "感觉生活就像debug，我需要静静" };
        protected override BTNodeStatus OnExcute(IAgent agent, Blackboard bb)
        {
            AIEntity entity = (AIEntity)agent;
            bb.SetValue(BlackboardKey.TargetMovePos, entity.Playground.position);
            entity.Model.Thinking.Value = mThinkingArray[UnityEngine.Random.Range(0, mThinkingArray.Length)];
            HTLogger.Debug("感觉无趣，设置目标地点：Playground，坐标：" + entity.Playground.position);
            return BTNodeStatus.Finished;
        }
    }
}
