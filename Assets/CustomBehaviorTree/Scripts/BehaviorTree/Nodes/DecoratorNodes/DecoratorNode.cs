/****************************************************
	文件：DecoratorNode.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/26 1:37:9
	功能：修饰节点（基类）（修饰节点只有一个子节点）
*****************************************************/

namespace AI.BehaviorTree
{
    public class DecoratorNode : NodeBase
    {
        /// <summary>
        /// 当前修饰节点的子节点（修饰节点只有一个子节点）
        /// </summary>
        public NodeBase Child => mChildren[0];
        public DecoratorNode(NodeBase child)
        {
            AddChild(child);
        }
    }
}
