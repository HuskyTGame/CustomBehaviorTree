/****************************************************
	文件：BTStarter.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/26 19:29:34
	功能：行为树启动器（在帧循环中开启行为树）
*****************************************************/

using HTUtility;

namespace AI.BehaviorTree
{
    public class BTStarter : HTSingleton<BTStarter>
    {
        public void UpdateBT(NodeBase rootNode, IAgent agent, Blackboard bb)
        {
            BTNodeStatus status = rootNode.Update(agent, bb);
            //HTLogger.Debug(string.Format("根节点为：{0}的行为树运行状态为：{1}", rootNode, status));
        }
    }
}
