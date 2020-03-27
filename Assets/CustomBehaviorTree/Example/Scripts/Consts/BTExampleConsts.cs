/****************************************************
	文件：BTExampleConsts.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/3/26 20:1:45
	功能：案例中的常量
*****************************************************/

namespace AI.BehaviorTree.Example
{
    public class BTExampleConsts
    {
        public const float DAILY_FOOD_COST = -1.0f;
        public const float DAILY_WATER_COST = -2.0f;
        public const float DAILY_ENERGY_COST = -1.0f;
        public const float DAILY_MOOD_COST = -1.0f;

        public const float FOOD_TO_FOOD = 10.0f;
        public const float FOOD_TO_WATER = -4.0f;
        public const float FOOD_TO_ENERGY = 2.0f;
        public const float FOOD_TO_MOOD = 2.0f;
        public const float FOOD_TO_MONEY = -5.0f;

        public const float WATER_TO_FOOD = -2.0f;
        public const float WATER_TO_WATER = 10.0f;
        public const float WATER_TO_ENERGY = 2.0f;
        public const float WATER_TO_MOOD = 1.0f;
        public const float WATER_TO_MONEY = -2.0f;

        public const float ENERGY_TO_FOOD = -1.0f;
        public const float ENERGY_TO_WATER = -1.0f;
        public const float ENERGY_TO_ENERGY = 10.0f;
        public const float ENERGY_TO_MOOD = 1.0f;
        public const float ENERGY_TO_MONEY = -1.0f;

        public const float MOOD_TO_FOOD = -3.0f;
        public const float MOOD_TO_WATER = -3.0f;
        public const float MOOD_TO_ENERGY = -3.0f;
        public const float MOOD_TO_MOOD = 10.0f;
        public const float MOOD_TO_MONEY = 0.0f;

        public const float MONEY_TO_FOOD = -2.0f;
        public const float MONEY_TO_WATER = -2.0f;
        public const float MONEY_TO_ENERGY = -2.0f;
        public const float MONEY_TO_MOOD = -10.0f;
        public const float MONEY_TO_MONEY = 20.0f;
    }
}
