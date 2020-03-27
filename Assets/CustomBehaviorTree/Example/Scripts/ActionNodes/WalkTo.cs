/****************************************************
	文件：WalkTo.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/26 20:33:45
	功能：移动到目标地点
*****************************************************/

using UnityEngine;
using HTUtility;

namespace AI.BehaviorTree.Example
{
    public class WalkTo : ActionNode
    {
        protected override bool InternalCondition(IAgent agent, Blackboard bb)
        {
            return bb.ContainsValue(BlackboardKey.TargetMovePos);
        }
        protected override BTNodeStatus OnExcute(IAgent agent, Blackboard bb)
        {
            AIEntity entity = (AIEntity)agent;
            Vector3 target = bb.GetValue(BlackboardKey.TargetMovePos, Vector3.one);
            entity.Move(target);
            if (entity.AlreadyReachTarget(target, 1.0f))
            {
                HTLogger.Debug("已经到达目标点：" + target);
                return BTNodeStatus.Finished;
            }
            //HTLogger.Debug("持续向目标点：" + target + "移动中");
            return BTNodeStatus.Running;
        }
    }
}
