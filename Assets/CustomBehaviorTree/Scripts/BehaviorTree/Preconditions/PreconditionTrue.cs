/****************************************************
	文件：PreconditionTrue.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/25 22:35:40
	功能：必定返回 True 的前提条件
*****************************************************/

namespace AI.BehaviorTree
{
    public class PreconditionTrue : IPrecondition
    {
        public bool IsTrue(IAgent agent)
        {
            return true;
        }
    }
}
