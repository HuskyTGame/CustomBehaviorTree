/****************************************************
	文件：IPrecondition.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/25 22:31:58
	功能：前提条件接口
*****************************************************/

namespace AI.BehaviorTree
{
    public interface IPrecondition
    {
        bool IsTrue(IAgent agent);
    }
}
