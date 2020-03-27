/****************************************************
	文件：PreconditionNot.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/25 22:40:24
	功能：前提条件  非
*****************************************************/

namespace AI.BehaviorTree
{
    public class PreconditionNot : IPrecondition
    {
        private IPrecondition mPrecondition;

        public PreconditionNot(IPrecondition precondition)
        {
            mPrecondition = precondition;
        }

        public bool IsTrue(IAgent agent)
        {
            return !mPrecondition.IsTrue(agent);
        }
    }
}
