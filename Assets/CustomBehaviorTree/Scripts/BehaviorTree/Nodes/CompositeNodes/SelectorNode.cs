/****************************************************
	文件：SelectorNode.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/26 1:1:33
	功能：选择节点（组合节点）
*****************************************************/

namespace AI.BehaviorTree
{
    public class SelectorNode : NodeBase
    {
        /// <summary>
        /// 当前运行的子节点的索引（初始默认值为 -1）
        /// </summary>
        private int mCurrentChildIndex = -1;
        protected override BTNodeStatus OnUpdate(IAgent agent, Blackboard bb)
        {
            if (mChildren.Count == 0) return BTNodeStatus.Finished;
            //第一次执行该选择节点
            if (mCurrentChildIndex < 0)
                mCurrentChildIndex = 0;

            BTNodeStatus status;
            //遍历当前子节点、以及剩余子节点
            for (int i = mCurrentChildIndex; i < mChildren.Count; i++)
            {
                status = mChildren[i].Update(agent, bb);//更新子节点运行状态
                if (status != BTNodeStatus.Failed)
                {
                    return status;
                }
                //子节点运行失败则继续
                mCurrentChildIndex += 1;//更新  当前运行的子节点的索引
            }
            return BTNodeStatus.Failed;
        }
        protected override void OnReset(IAgent agent, Blackboard bb)
        {
            if (mCurrentChildIndex >= 0 && mCurrentChildIndex < mChildren.Count)
            {
                for (int i = 0; i <= mCurrentChildIndex; i++)
                {
                    mChildren[i].Reset(agent, bb);
                }
            }
            else if (mCurrentChildIndex == mChildren.Count)
            {
                for (int i = 0; i < mChildren.Count; i++)
                {
                    mChildren[i].Reset(agent, bb);
                }
            }
            mCurrentChildIndex = -1;//重置  当前运行的子节点的索引
        }
    }
}
