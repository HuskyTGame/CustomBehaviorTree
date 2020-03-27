/****************************************************
	文件：SequenceNode.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/26 0:39:51
	功能：序列节点（组合节点）
*****************************************************/

namespace AI.BehaviorTree
{
    public class SequenceNode : NodeBase
    {
        /// <summary>
        /// 当前运行的子节点的索引（初始默认值为 -1）
        /// </summary>
        private int mCurrentChildIndex = -1;

        protected override BTNodeStatus OnUpdate(IAgent agent, Blackboard bb)
        {
            if (mChildren.Count == 0) return BTNodeStatus.Finished;
            //第一次执行该序列节点
            if (mCurrentChildIndex < 0)
                mCurrentChildIndex = 0;

            BTNodeStatus status;
            //遍历当前子节点、以及剩余子节点
            for (int i = mCurrentChildIndex; i < mChildren.Count; i++)
            {
                status = mChildren[i].Update(agent, bb);//更新子节点运行状态
                if (status != BTNodeStatus.Finished)
                {
                    return status;
                }
                //子节点运行成功则继续
                mCurrentChildIndex += 1;//更新  当前运行的子节点的索引
            }
            return BTNodeStatus.Finished;
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
