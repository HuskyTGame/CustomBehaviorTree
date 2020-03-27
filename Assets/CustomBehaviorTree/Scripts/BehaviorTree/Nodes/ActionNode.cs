/****************************************************
	文件：ActionNode.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/25 23:8:27
	功能：行为节点（行为树叶节点）
*****************************************************/

namespace AI.BehaviorTree
{
    public class ActionNode : NodeBase
    {
        /// <summary>
        /// 行为状态，在行为节点内部的状态
        /// </summary>
        public enum ActionStateEnum
        {
            /// <summary>
            /// 第一次执行当前行为
            /// </summary>
            FirstIn,
            /// <summary>
            /// 非第一次执行当前行为
            /// </summary>
            NotFirstIn,
        }

        /// <summary>
        /// 当前行为节点内部的状态，默认为 Ready 状态
        /// </summary>
        private ActionStateEnum mCurrentState = ActionStateEnum.FirstIn;

        protected override BTNodeStatus OnUpdate(IAgent agent, Blackboard bb)
        {
            //内部条件检测未通过
            if (InternalCondition(agent, bb) == false) return BTNodeStatus.Failed;

            //第一次执行此行为
            if(mCurrentState == ActionStateEnum.FirstIn)
            {
                OnEnter(agent, bb);
                mCurrentState = ActionStateEnum.NotFirstIn;
            }
            BTNodeStatus status = BTNodeStatus.Finished;
            //非第一次执行此行为
            if (mCurrentState==ActionStateEnum.NotFirstIn)
            {
                status = OnExcute(agent, bb);
            }
            //若当前行为为持续性行为
            if (status == BTNodeStatus.Running)
            {
                return status;//返回 Running
            }
            //当前行为已结束（非持续性行为）
            else
            {
                //善后工作（执行退出 + 标志位重置）
                OnReset(agent, bb);
                return status;//返回 Finished
            }
        }
        protected override void OnReset(IAgent agent, Blackboard bb)
        {
            if (mCurrentState == ActionStateEnum.NotFirstIn)
            {
                OnExit(agent, bb);//执行退出
                mCurrentState = ActionStateEnum.FirstIn;//标志位重置
            }
        }

        /// <summary>
        /// 内部条件
        /// </summary>
        /// <param AI 实体="agent"></param>
        /// <param 黑板数据="bb"></param>
        /// <returns></returns>
        protected virtual bool InternalCondition(IAgent agent, Blackboard bb)
        {
            return true;
        }

        #region 行为节点  生命周期函数
        protected virtual void OnEnter(IAgent agent, Blackboard bb) { }
        protected virtual BTNodeStatus OnExcute(IAgent agent, Blackboard bb)
        {
            return BTNodeStatus.Finished;
        }
        protected virtual void OnExit(IAgent agent, Blackboard bb) { }
        #endregion
    }
}
