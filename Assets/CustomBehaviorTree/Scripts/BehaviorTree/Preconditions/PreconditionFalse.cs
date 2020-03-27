/****************************************************
	文件：PreconditionFalse.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/25 22:35:52
	功能：必定返回 false 的前提条件
*****************************************************/

namespace AI.BehaviorTree
{
    public class PreconditionFalse : IPrecondition
    {
        public bool IsTrue(IAgent agent)
        {
            return false;
        }
    }
}
