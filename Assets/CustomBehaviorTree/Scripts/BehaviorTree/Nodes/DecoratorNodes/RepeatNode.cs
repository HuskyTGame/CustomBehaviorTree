/****************************************************
	文件：RepeatNode.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/26 1:43:52
	功能：循环节点（修饰节点）
*****************************************************/

namespace AI.BehaviorTree
{
    public class RepeatNode : DecoratorNode
    {
        /// <summary>
        /// 总的循环次数
        /// </summary>
        private int mTotalLoopNum;
        /// <summary>
        /// 当前循环的次数
        /// </summary>
        private int mCurrentLoopNum;

        /// <summary>
        /// 循环节点（修饰节点），若循环次数 ≤ 0，则循环无穷次
        /// </summary>
        /// <param 子节点="child"></param>
        /// <param 总的循环次数="loopNum"></param>
        public RepeatNode(NodeBase child, int loopNum = 1) : base(child)
        {
            mTotalLoopNum = loopNum;
            mCurrentLoopNum = 1;
        }

        protected override BTNodeStatus OnUpdate(IAgent agent, Blackboard bb)
        {
            BTNodeStatus status;
            while (true)
            {
                status = Child.Update(agent, bb);
                if (status != BTNodeStatus.Finished)
                    return status;
                //若循环次数<= 0，则无限循环
                if (mTotalLoopNum > 0)
                {
                    //当前子节点运行状态 Finished：
                    //达到总循环次数
                    if (mCurrentLoopNum == mTotalLoopNum)
                        return BTNodeStatus.Finished;
                }
                Child.Reset(agent, bb);//重置
                mCurrentLoopNum += 1;//循环次数+1
            }
        }
        protected override void OnReset(IAgent agent, Blackboard bb)
        {
            Child.Reset(agent, bb);
            mCurrentLoopNum = 1;
        }
    }
}
