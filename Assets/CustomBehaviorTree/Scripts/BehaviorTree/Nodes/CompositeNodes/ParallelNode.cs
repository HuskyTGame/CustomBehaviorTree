/****************************************************
	文件：ParallelNode.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/25 23:45:37
	功能：平行节点（组合节点）
*****************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace AI.BehaviorTree
{
    public class ParallelNode : NodeBase
    {
        /// <summary>
        /// 子节点需要完成多少个，平行节点才返回 Finished
        /// </summary>
        private int mNeedFinishedNumInChildren;
        /// <summary>
        /// 子节点运行状态列表
        /// </summary>
        private List<BTNodeStatus> mChildrenStatusList;
        /// <summary>
        /// 子节点中执行完成的个数
        /// </summary>
        protected int mFinishedNum;
        /// <summary>
        /// 子节点中执行失败的个数
        /// </summary>
        protected int mFailedNum;

        /// <summary>
        /// 平行节点（参数：子节点需要完成多少个，平行节点才返回 Finished）
        /// </summary>
        /// <param 子节点需要完成多少个，平行节点才返回Finished="needFinishedNumInChildren"></param>
        public ParallelNode(int needFinishedNumInChildren)
        {
            mNeedFinishedNumInChildren = needFinishedNumInChildren;
            mChildrenStatusList = new List<BTNodeStatus>();
            mFinishedNum = 0;
            mFailedNum = 0;
        }

        protected override BTNodeStatus OnUpdate(IAgent agent, Blackboard bb)
        {
            if (mChildren.Count == 0) return BTNodeStatus.Finished;
            mNeedFinishedNumInChildren = Mathf.Clamp(mNeedFinishedNumInChildren, 1, mChildren.Count);
            //第一次设置（初始化）子节点运行状态列表
            if (mChildrenStatusList.Count != mChildren.Count)
            {
                for (int i = 0; i < mChildren.Count; i++)
                {
                    mChildrenStatusList.Add(BTNodeStatus.Running);
                }
            }
            mFinishedNum = 0;//重置  子节点中执行完成的个数
            mFailedNum = 0;//重置  子节点中执行失败的个数
            BTNodeStatus status;
            for (int i = 0; i < mChildren.Count; i++)
            {
                status = mChildrenStatusList[i];
                //1--子节点行为为持续性行为
                if (status == BTNodeStatus.Running)
                {
                    status = mChildren[i].Update(agent, bb);//更新子节点行为状态
                }
                //2--子节点行为已结束（非持续性行为/恰好结束的持续性行为）
                if (status == BTNodeStatus.Finished)
                {
                    //更新  子节点行为状态  到  子节点运行状态列表
                    mChildrenStatusList[i] = BTNodeStatus.Finished;
                    mFinishedNum += 1;
                    //满足子节点需要完成的次数
                    if (mFinishedNum == mNeedFinishedNumInChildren)
                    {
                        return BTNodeStatus.Finished;//返回 Finished
                    }
                }
                //3--子节点行为失败（第一次更新该子节点时可能出现）
                if (status == BTNodeStatus.Failed)
                {
                    mFailedNum += 1;
                    //若失败次数足够多
                    if (mFailedNum > mChildren.Count - mNeedFinishedNumInChildren)
                    {
                        return BTNodeStatus.Failed;//返回 Failed
                    }
                }
            }
            return BTNodeStatus.Running;//返回 Running
        }
        protected override void OnReset(IAgent agent, Blackboard bb)
        {
            for (int i = 0; i < mChildren.Count; i++)
            {
                mChildren[i].Reset(agent, bb);
            }
            mChildrenStatusList.Clear();
        }
    }
}
