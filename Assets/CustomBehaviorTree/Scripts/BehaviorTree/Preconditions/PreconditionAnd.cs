/****************************************************
	文件：PreconditionAnd.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/25 22:36:3
	功能：前提条件  且
*****************************************************/

namespace AI.BehaviorTree
{
    public class PreconditionAnd : IPrecondition
    {
        private IPrecondition mLeftPrecondition;
        private IPrecondition mRightPrecondition;

        public PreconditionAnd(IPrecondition leftPrecondition, IPrecondition rightPrecondition)
        {
            mLeftPrecondition = leftPrecondition;
            mRightPrecondition = rightPrecondition;
        }

        public bool IsTrue(IAgent agent)
        {
            return mLeftPrecondition.IsTrue(agent) && mRightPrecondition.IsTrue(agent);
        }
    }
}
