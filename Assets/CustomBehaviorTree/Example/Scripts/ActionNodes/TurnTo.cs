/****************************************************
	文件：TurnTo.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/26 20:37:54
	功能：转向目标方向
*****************************************************/

using UnityEngine;
using HTUtility;

namespace AI.BehaviorTree.Example
{
    public class TurnTo : ActionNode
    {
        protected override bool InternalCondition(IAgent agent, Blackboard bb)
        {
            return bb.ContainsValue(BlackboardKey.TargetMovePos);
        }
        protected override BTNodeStatus OnExcute(IAgent agent, Blackboard bb)
        {
            AIEntity entity = (AIEntity)agent;
            Vector3 target = bb.GetValue(BlackboardKey.TargetMovePos, Vector3.zero);
            entity.Turn(target);
            if (entity.AlreadyTurnToTarget(target, 0.1f))
            {
                HTLogger.Debug("已经转向目标点：" + target + "方向");
                return BTNodeStatus.Finished;
            }
            HTLogger.Debug("持续向目标点：" + target + "方向转向中");
            return BTNodeStatus.Running;
        }
    }
}
