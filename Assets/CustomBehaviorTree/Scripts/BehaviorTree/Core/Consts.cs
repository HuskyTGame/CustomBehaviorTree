/****************************************************
	文件：BTNodeStatus.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/25 18:47:22
	功能：行为树常量
*****************************************************/

namespace AI.BehaviorTree
{
    /// <summary>
    /// 行为树节点运行状态
    /// </summary>
	public enum BTNodeStatus
    {
        /// <summary>
        /// 失败
        /// </summary>
		Failed,
        /// <summary>
        /// 运行中
        /// </summary>
        Running,
        /// <summary>
        /// 完成
        /// </summary>
        Finished,
    }
    public enum BlackboardKey
    {
        Default,

        //案例使用的黑板key：
        TargetMovePos,


    }



}
