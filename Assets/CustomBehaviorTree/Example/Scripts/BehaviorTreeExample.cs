/****************************************************
	文件：BehaviorTreeExample.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/26 2:7:9
	功能：行为树  小例子
*****************************************************/

using System;
using UnityEngine;
using UnityEngine.UI;
using HTUtility;

namespace AI.BehaviorTree.Example
{
    public class BehaviorTreeExample : MonoBehaviour
    {
        private const string TXT_NUM = "Txt_Num";

        private Text mTxt_Num_Food;
        private Text mTxt_Num_Water;
        private Text mTxt_Num_Energy;
        private Text mTxt_Num_Mood;

        public Text Txt_Num_Money;
        public Slider Slider_Food;
        public Slider Slider_Water;
        public Slider Slider_Energy;
        public Slider Slider_Mood;
        public Text Txt_Thinking;
        public Button Btn_Start;
        public Button Btn_Pause;
        public Button Btn_Reset;

        private void Awake()
        {
            Init();
        }
        private void Init()
        {
            LoggerService.Instance.Init();
            HTLogger.Info("LoggerService init done.");
            mTxt_Num_Food = GetTextFromSlider(Slider_Food, TXT_NUM);
            mTxt_Num_Water = GetTextFromSlider(Slider_Water, TXT_NUM);
            mTxt_Num_Energy = GetTextFromSlider(Slider_Energy, TXT_NUM);
            mTxt_Num_Mood = GetTextFromSlider(Slider_Mood, TXT_NUM);
            GameFacade.Instance.Init(this);
            HTLogger.Info("GameFacade init done.");
        }
        public void SubscribeBtnStart(UnityEngine.Events.UnityAction call)
        {
            Btn_Start.onClick.AddListener(call);
        }
        public void SubscribeBtnPause(UnityEngine.Events.UnityAction call)
        {
            Btn_Pause.onClick.AddListener(call);
        }
        public void SubscribeBtnReset(UnityEngine.Events.UnityAction call)
        {
            Btn_Reset.onClick.AddListener(call);
        }
        private Text GetTextFromSlider(Slider parent, string txtName)
        {
            return parent.transform.Find(txtName).GetComponent<Text>();
        }
        public void SetFoodValue(float value)
        {
            SetSliderAndTextValue(value, Slider_Food, mTxt_Num_Food);
        }
        public void SetWaterValue(float value)
        {
            SetSliderAndTextValue(value, Slider_Water, mTxt_Num_Water);
        }
        public void SetEnergyValue(float value)
        {
            SetSliderAndTextValue(value, Slider_Energy, mTxt_Num_Energy);
        }
        public void SetMoodValue(float value)
        {
            SetSliderAndTextValue(value, Slider_Mood, mTxt_Num_Mood);
        }
        private void SetSliderAndTextValue(float value, Slider slider, Text txt)
        {
            value = Mathf.RoundToInt(Mathf.Clamp(value, 0, 100));
            txt.text = value + "/100";
            slider.value = value * 1.0f / 100.0f;
        }
        public void SetMoneyValue(float value)
        {
            value = Mathf.RoundToInt(value);
            Txt_Num_Money.text = value.ToString();
        }
        public void SetTxtThinking(string txt)
        {
            Txt_Thinking.text = txt;
        }
    }


    public class LoggerService : HTSingleton<LoggerService>
    {
        public class UnityDebugListener : ILoggerListener
        {
            public void Log(string msg)
            {
                Debug.Log(msg);
            }
        }
        public class UnityWarningListener : ILoggerListener
        {
            public void Log(string msg)
            {
                Debug.LogWarning(msg);
            }
        }
        public class UnityErrorListener : ILoggerListener
        {
            public void Log(string msg)
            {
                Debug.LogError(msg);
            }
        }
        public void Init()
        {
            UnityDebugListener unityDebugListener = new UnityDebugListener();
            UnityWarningListener unityWarningListener = new UnityWarningListener();
            UnityErrorListener unityErrorListener = new UnityErrorListener();
            HTLogger.Instance.Init(true);
            HTLogger.Instance.AddListener(HTLogger.Channel.Info, unityDebugListener);
            HTLogger.Instance.AddListener(HTLogger.Channel.Todo, unityDebugListener);
            HTLogger.Instance.AddListener(HTLogger.Channel.Debug, unityDebugListener);
            HTLogger.Instance.AddListener(HTLogger.Channel.Warning, unityWarningListener);
            HTLogger.Instance.AddListener(HTLogger.Channel.Error, unityErrorListener);
        }
    }
}
