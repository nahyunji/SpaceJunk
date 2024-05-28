using System.Collections.Generic;
using UnityEngine;
using Universe;

namespace Local
{
    public class DebugCommandFunction : ConfiguredMonoBehaviour
    {
        [SerializeField] private DebugCommandCollection collection;
        public List<object> commandList;
        private DebugCommand<float> ADD_MONEY_ALL;

        private void Start()
        {
            SetFunction();
        }

        private void SetFunction()
        {
            commandList = new List<object>();
            var ADD_MONEY = new DebugCommand<EMoney, float>("add_money", (money, value) =>
            {
                MoneyUtil.Add(money, value, false);
            });

            ADD_MONEY_ALL = new DebugCommand<float>("add_money_all", (x) =>
            {
                MoneyUtil.DebugAddAll(x);
            });

            var SET_TIMESCALE = new DebugCommand<float>("set_timescale", (x) =>
            {
                Time.timeScale = x;
            });

            var ADD_EXP = new DebugCommand<int>("add_exp", (x) =>
            {
                PlayerUtil.AddExp(x);
            });

            var ADD_LEVEL = new DebugCommand<int>("add_level", (x) =>
            {
                PlayerUtil.AddLevel(x);
            });

            var SET_BLACKHOLE = new DebugCommand<int, double>("set_blackhole", (x, time) =>
            {
                ChallengeUtil.DebugBlackholeRecord(x, time);
            });
            var ADD_ADAPTATION_ALL = new DebugCommand<int>("add_adaptation_all", (x) =>
            {
                EventUtil.DebugAddAlAdaptation(x);
            });

            var ADD_PASSLEVEL = new DebugCommand<int>("add_passlevel", (x) =>
            {
                PassUtil.AddLevel(x);
            });

            var ADD_PASSExp = new DebugCommand<int>("add_passexp", (x) =>
            {
                PassUtil.AddExp(x);
            });

            var ADD_TIME = new DebugCommand<string, float>("add_time", (a, b) =>
            {
                if (a.Contains("sec"))
                {
                    TimeManager.DebugAddSec(b);
                }
                else if (a.Contains("min"))
                {
                    TimeManager.DebugAddSec(b * 60);
                }
                else if (a.Contains("hour"))
                {
                    TimeManager.DebugAddHour(b);
                }
                else if (a.Contains("day"))
                {
                    TimeManager.DebugAddHour(b * 24);
                }
            });

            var RESETTIME = new DebugCommand("reset_time", () =>
            {
                TimeManager.DebugResetTime();
            });
            var RESET_ALL = new DebugCommand("reset_all", () =>
            {
                DataManager.user.ResetUserData();
            });

            var SET_PiratesClear = new DebugCommand<int>("set_pirates", (x) =>
            {
                ChallengeUtil.DebugSetPirates(x);
            });

            var Open_AllPlanet = new DebugCommand("open_allplanet", () =>
            {
                PlanetUtil.DebugOpenAllPlanet();
            });
            var Open_Profile = new DebugCommand<int>("open_profile", (x) =>
            {
                PlayerUtil.OpenProfile(x);
            });
            var Get_Offline = new DebugCommand<int>("get_offline", (x) =>
            {
                OfflineUtil.DebugOfflineReward(x);
            });

            var Add_CardPeice = new DebugCommand<int, int>("add_cardpeice", (a, b) =>
            {
                CollectionUtil.AddCardPeice((ECollection)a, b);
            });

            var Add_CardPeice_All = new DebugCommand<int>("add_cardpeice_all", (x) =>
            {
                CollectionUtil.DebugAddAllCardPeice(x);
            });

            var Add_Staff = new DebugCommand<int, int, int>("add_satff", (a, b, c) =>
            {
                StaffUtil.DebugAddStaff((EStaffRank)a, b, c);
            });

            var Add_Quest = new DebugCommand<int, int>("add_quest", (a, b) =>
            {
                QuestUtil.CountQuest((EQuest)a, b);
            });

            var Add_RepeatQuest = new DebugCommand<int, int>("add_repeatQuest", (a, b) =>
            {
                RepeatQuestUtil.CountQuest((ERepeatQuest)a, b);
            });

            var Add_QuestALL = new DebugCommand("add_quest_all", () =>
            {
                for (int i = 0; i < LocalUtil.EnumCount<EQuest>(); i++)
                {
                    var max = QuestUtil.DBQuestData.Info.Find(x => x.quest == (EQuest)i).count;
                    QuestUtil.CountQuest((EQuest)i, max);
                }
            });

            commandList = new List<object>
            {
                ADD_MONEY,ADD_MONEY_ALL,SET_TIMESCALE,SET_TIMESCALE,ADD_EXP
                ,ADD_LEVEL,SET_BLACKHOLE,ADD_ADAPTATION_ALL,ADD_PASSLEVEL,ADD_PASSExp,ADD_TIME,RESETTIME,
                RESET_ALL,SET_PiratesClear,Open_AllPlanet,Open_Profile,Get_Offline,Add_CardPeice,Add_CardPeice_All,
                Add_Staff,Add_Quest,Add_RepeatQuest,Add_QuestALL
            };
        }

        public void Excute(string inputTex)
        {
            string[] properties = inputTex.Split(' ');
            bool excuted = false;
            for (int i = 0; i < commandList.Count; i++)
            {
                DebugCommandBase commandBase = commandList[i] as DebugCommandBase;
                if (properties[0].Equals(commandBase.CommandId))
                {
                    if (commandList[i] as DebugCommand != null)
                    {
                        (commandList[i] as DebugCommand).Invoke();
                        Debug.Log($"[DebugFunction] {properties[0]} 실행!");
                    }
                    else if (commandList[i] as DebugCommand<EMoney, float> != null)
                    {
                        (commandList[i] as DebugCommand<EMoney, float>).Invoke((EMoney)int.Parse(properties[1]), float.Parse(properties[2]));
                        Debug.Log($"[DebugFunction] {properties[0]} 실행!");
                    }
                    else if (commandList[i] as DebugCommand<float> != null)
                    {
                        (commandList[i] as DebugCommand<float>).Invoke(float.Parse(properties[1]));
                        Debug.Log($"[DebugFunction] {properties[0]} 실행!");
                    }
                    else if (commandList[i] as DebugCommand<int> != null)
                    {
                        (commandList[i] as DebugCommand<int>).Invoke(int.Parse(properties[1]));
                        Debug.Log($"[DebugFunction] {properties[0]} 실행!");
                    }
                    else if (commandList[i] as DebugCommand<string, float> != null)
                    {
                        (commandList[i] as DebugCommand<string, float>).Invoke(properties[1], float.Parse(properties[2]));
                        Debug.Log($"[DebugFunction] {properties[0]} 실행!");
                    }
                    else if (commandList[i] as DebugCommand<int, int> != null)
                    {
                        (commandList[i] as DebugCommand<int, int>).Invoke(int.Parse(properties[1]), int.Parse(properties[2]));
                        Debug.Log($"[DebugFunction] {properties[0]} 실행!");
                    }
                    else if (commandList[i] as DebugCommand<int, double> != null)
                    {
                        (commandList[i] as DebugCommand<int, double>).Invoke(int.Parse(properties[1]), double.Parse(properties[2]));
                        Debug.Log($"[DebugFunction] {properties[0]} 실행!");
                    }
                    else if (commandList[i] as DebugCommand<int, int, int> != null)
                    {
                        (commandList[i] as DebugCommand<int, int, int>).Invoke(int.Parse(properties[1]), int.Parse(properties[2]), int.Parse(properties[3]));
                        Debug.Log($"[DebugFunction] {properties[0]} 실행!");
                    }
                    excuted = true;
                }
            }
            if (!excuted)
                Debug.Log($"[DebugFunction] 잘못된 Command 입니다.");
        }
    }
}