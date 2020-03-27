/****************************************************
	文件：FeelPoor.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/26 20:30:30
	功能：想去工作（Company）+money
*****************************************************/

using HTUtility;

namespace AI.BehaviorTree.Example
{
    public class FeelPoor : ActionNode
    {
        protected override bool InternalCondition(IAgent agent, Blackboard bb)
        {
            HTLogger.Debug("通过money检测");
            return true;
        }
        private string[] mThinkingArray = new string[3] { "感觉还行，干点小活", "money、money！...", "bug我来了，蜜汁自信~" };
        protected override BTNodeStatus OnExcute(IAgent agent, Blackboard bb)
        {
            AIEntity entity = (AIEntity)agent;
            bb.SetValue(BlackboardKey.TargetMovePos, entity.Company.position);
            entity.Model.Thinking.Value = mThinkingArray[UnityEngine.Random.Range(0, mThinkingArray.Length)];
            HTLogger.Debug("感觉贫穷，设置目标地点：Company，坐标：" + entity.Company.position);
            return BTNodeStatus.Finished;
        }
    }
}
