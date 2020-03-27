/****************************************************
	文件：NodeBase.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/25 22:47:16
	功能：行为树节点（基类）
*****************************************************/

using System.Collections.Generic;

namespace AI.BehaviorTree
{
    public abstract class NodeBase
    {
        /// <summary>
        /// 父节点
        /// </summary>
        protected NodeBase mParent;
        /// <summary>
        /// 子节点列表
        /// </summary>
        protected List<NodeBase> mChildren = new List<NodeBase>();
        /// <summary>
        /// 前提条件（外在前提）
        /// </summary>
        protected IPrecondition mPrecondition;

        public NodeBase()
        {
        }

        /// <summary>
        /// 添加子节点
        /// </summary>
        /// <param 子节点="node"></param>
        public NodeBase AddChild(params NodeBase[] nodeArray)
        {
            for (int i = 0; i < nodeArray.Length; i++)
            {
                nodeArray[i].mParent = this;
                mChildren.Add(nodeArray[i]);
            }
            return this;
        }
        /// <summary>
        /// 设置节点的前提条件（外在前提）
        /// </summary>
        /// <param 前提条件="precondition"></param>
        public NodeBase SetPrecondition(IPrecondition precondition)
        {
            mPrecondition = precondition;
            return this;
        }
        public BTNodeStatus Update(IAgent agent, Blackboard bb)
        {
            //没有通过（外在）前提条件
            if (mPrecondition != null && mPrecondition.IsTrue(agent) == false)
                return BTNodeStatus.Failed;
            return OnUpdate(agent, bb);
        }
        public void Reset(IAgent agent, Blackboard bb)
        {
            OnReset(agent, bb);
        }
        protected virtual BTNodeStatus OnUpdate(IAgent agent, Blackboard bb)
        {
            return BTNodeStatus.Finished;
        }
        protected virtual void OnReset(IAgent agent, Blackboard bb) { }
    }
}
