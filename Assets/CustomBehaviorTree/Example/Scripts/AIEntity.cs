/****************************************************
	文件：AIEntity.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/26 2:33:34
	功能：AI 实体
*****************************************************/

using System;
using UnityEngine;
using HTUtility;

namespace AI.BehaviorTree.Example
{
    public class AIEntity : MonoBehaviour, IAgent
    {
        public enum MovementState
        {
            Idle,
            Turn,
            Move,
        }

        private bool mIsActive;
        private Vector3 mMoveTargetPos;
        private Vector3 mTurnTargetPos;
        private MovementState mCurrentMovementState;
        private Blackboard mBlackboard;
        private NodeBase mRootNode;
        private Vector3 mBornPos;
        private Quaternion mBornQuaternion;

        public AIModel Model;

        public float MoveSpeed;
        public float RotateSpeed;
        public Transform Restaurant;
        public Transform River;
        public Transform Home;
        public Transform Playground;
        public Transform Company;

        private void Init()
        {
            mIsActive = false;
            mMoveTargetPos = Vector3.zero;
            mTurnTargetPos = Vector3.zero;
            Model = new AIModel(100, 100, 100, 100, 100, "初来乍到");
            mCurrentMovementState = MovementState.Idle;
            mBornPos = transform.position;
            mBornQuaternion = transform.rotation;
            SubscribeUI();
            BuildBehaviorTree();
        }
        private void Reset()
        {
            mIsActive = false;
            mMoveTargetPos = Vector3.zero;
            mTurnTargetPos = Vector3.zero;
            Model.Food.Value = 100;
            Model.Water.Value = 100;
            Model.Energy.Value = 100;
            Model.Mood.Value = 100;
            Model.Money.Value = 100;
            Model.Thinking.Value = "初来乍到";
            mCurrentMovementState = MovementState.Idle;
            mRootNode.Reset(this, mBlackboard);
            transform.position = mBornPos;
            transform.rotation = mBornQuaternion;
        }
        private void Awake()
        {

        }
        private void Start()
        {
            Init();
        }
        private void Update()
        {
            if (mIsActive == false) return;
            UpdateMovement();
            UpdateTurnAround();
            BTStarter.Instance.UpdateBT(mRootNode, this, mBlackboard);
        }

        private void BuildBehaviorTree()
        {
            mBlackboard = new Blackboard();
            mRootNode = new RepeatNode(
                new ParallelNode(1)
                        .AddChild(new SelectorNode()
                                .AddChild(new SequenceNode()
                                        .AddChild(new FeelBoring(), new WalkTo(), new HaveFun())
                                , new SequenceNode()
                                        .AddChild(new FeelHungry(), new WalkTo(), new EatFood())
                                , new SequenceNode()
                                        .AddChild(new FeelThirsty(), new WalkTo(), new DrinkWater())
                                , new SequenceNode()
                                        .AddChild(new FeelTired(), new WalkTo(), new HaveRest())
                                , new SequenceNode()
                                        .AddChild(new FeelPoor(), new WalkTo(), new Work())
                                )
                        , new Alive())
                , 0);
            HTLogger.Info("AI 行为树构建完成！");
        }
        private void UpdateMovement()
        {
            if (mCurrentMovementState != MovementState.Move) return;
            if (PrepareToMove(mMoveTargetPos) == false) return;
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
            //HTLogger.Debug("当前位置：" + transform.position);
            AlreadyReachTarget(mMoveTargetPos, 0.3f);
        }
        private void UpdateTurnAround()
        {
            switch (mCurrentMovementState)
            {
                case MovementState.Idle:
                    break;
                case MovementState.Turn:
                    UpdateTurnTo(mTurnTargetPos);
                    break;
                case MovementState.Move:
                    UpdateTurnTo(mMoveTargetPos);
                    break;
                default:
                    break;
            }
            AlreadyTurnToTarget(mTurnTargetPos, 0.1f);
        }
        private void UpdateTurnTo(Vector3 targetPos)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetPos - transform.position), Time.deltaTime * RotateSpeed);
        }
        private void SubscribeUI()
        {
            Model.Food.Subscribe(v => GameFacade.Instance.SubscribeUIFood(v));
            Model.Water.Subscribe(v => GameFacade.Instance.SubscribeUIWater(v));
            Model.Energy.Subscribe(v => GameFacade.Instance.SubscribeUIEnergy(v));
            Model.Mood.Subscribe(v => GameFacade.Instance.SubscribeUIMood(v));
            Model.Money.Subscribe(v => GameFacade.Instance.SubscribeUIMoney(v));
            Model.Thinking.Subscribe(v => GameFacade.Instance.SubscribeTxtThinking(v));
            GameFacade.Instance.SubscribeBtnStart(() =>
            {
                mIsActive = true;
            });
            GameFacade.Instance.SubscribeBtnPause(() =>
            {
                mIsActive = false;
            });
            GameFacade.Instance.SubscribeBtnReset(() =>
            {
                Reset();
            });
        }
        public void SetAIState(bool isActive)
        {
            mIsActive = isActive;
        }
        public void Move(Vector3 targetPos)
        {
            mMoveTargetPos = targetPos;
            mCurrentMovementState = MovementState.Move;
        }
        public void Move(Transform targetTrans)
        {
            Move(targetTrans.position);
        }
        public void Turn(Vector3 targetPos)
        {
            mTurnTargetPos = targetPos;
            mCurrentMovementState = MovementState.Turn;
        }
        public void Turn(Transform targetTrans)
        {
            Turn(targetTrans.position);
        }
        public bool PrepareToMove(Vector3 moveTarget)
        {
            Vector3 toTarget = moveTarget - transform.position;
            return Vector3.Dot(toTarget.normalized, transform.forward) > 0.95f && Vector3.Distance(transform.position, moveTarget) > 0.5f;
        }
        public bool AlreadyReachTarget(Vector3 moveTarget, float precision = 0.3f)
        {
            Vector3 toTarget = moveTarget - transform.position;
            if (Vector3.Distance(transform.position, moveTarget) < precision)
            {
                mCurrentMovementState = MovementState.Idle;
                return true;
            }
            return false;
        }
        public bool AlreadyTurnToTarget(Vector3 turnTarget, float precision = 0.1f)
        {
            Vector3 toTarget = turnTarget - transform.position;
            if (Vector3.Dot(toTarget.normalized, transform.forward) < precision)
            {
                mCurrentMovementState = MovementState.Idle;
                return true;
            }
            return false;
        }
    }
}
