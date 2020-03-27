/****************************************************
	文件：PreconditionOr.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/25 22:36:13
	功能：前提条件  或
*****************************************************/

namespace AI.BehaviorTree
{
    public class PreconditionOr : IPrecondition
    {
        private IPrecondition mLeftPrecondition;
        private IPrecondition mRightPrecondition;

        public PreconditionOr(IPrecondition leftPrecondition, IPrecondition rightPrecondition)
        {
            mLeftPrecondition = leftPrecondition;
            mRightPrecondition = rightPrecondition;
        }

        public bool IsTrue(IAgent agent)
        {
            return mLeftPrecondition.IsTrue(agent) || mRightPrecondition.IsTrue(agent);
        }
    }
}
