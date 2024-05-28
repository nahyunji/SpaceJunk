using Sirenix.Serialization;
using System.Collections.Generic;

namespace Universe.DB
{
    public class EventData
    {
        [OdinSerialize] public List<Event_NewLogin> NewLogin { get; set; } = new();
        [OdinSerialize] public List<Event_Level> Level { get; set; } = new();
        [OdinSerialize] public string LevelComplete { get; set; }
        [OdinSerialize] public int LevelCompleteValue { get; set; }
        [OdinSerialize] public List<Event_BlackHole> BlackHole { get; set; } = new();
        [OdinSerialize] public List<Event_Adaptation> Adaptation { get; set; } = new();

        public EventData()
        {
            LoadData();
        }

        private void LoadData()
        {
            for (int i = 0; i < m이벤트.GetEntity(0).f신규_개수; i++)
            {
                NewLogin.Add(new Event_NewLogin()
                {
                    login = m이벤트.GetEntity(i).f신규로그인,
                    money = LocalUtil.StringToEnum<EMoney>(m이벤트.GetEntity(i).f신규_재화),
                    reward = m이벤트.GetEntity(i).f신규_보상
                });
            }

            var complete = m이벤트.GetEntity(0).f레벨완료_보상.Split('+');
            LevelComplete = complete[0];
            LevelCompleteValue = int.Parse(complete[1]);

            for (int i = 0; i < m이벤트.GetEntity(0).f레벨_개수; i++)
            {
                var newItem = new Event_Level
                {
                    level = m이벤트.GetEntity(i).f레벨선물,
                    moneys = new(),
                };
                var moneys = m이벤트.GetEntity(i).f레벨_재화.Split('+');
                var values = m이벤트.GetEntity(i).f레벨_보상.Split('+');

                for (int j = 0; j < moneys.Length; j++)
                {
                    var newMoney = new Event_Money
                    {
                        money = LocalUtil.StringToEnum<EMoney>(moneys[j]),
                        value = int.Parse(values[j])
                    };
                    newItem.moneys.Add(newMoney);
                }
                Level.Add(newItem);
            }

            for (int i = 0; i < m이벤트.GetEntity(0).f블랙홀_개수; i++)
            {
                var newItem = new Event_BlackHole()
                {
                    meter = m이벤트.GetEntity(i).f블랙홀탐험,
                    moneys = new(),
                };
                var moneys = m이벤트.GetEntity(i).f블랙홀_재화.Split("+");
                var values = m이벤트.GetEntity(i).f블랙홀_보상.Split("+");

                for (int j = 0; j < moneys.Length; j++)
                {
                    var newMoney = new Event_Money
                    {
                        money = LocalUtil.StringToEnum<EMoney>(moneys[j]),
                        value = int.Parse(values[j])
                    };
                    newItem.moneys.Add(newMoney);
                }
                BlackHole.Add(newItem);
            }

            for (int i = 0; i < m이벤트.GetEntity(0).f적응_개수; i++)
            {
                var newItem = new Event_Adaptation()
                {
                    adaptation = LocalUtil.StringToEnum<EEvent_Adaptation>(m이벤트.GetEntity(i).f우주적응Key),
                    condition = m이벤트.GetEntity(i).f적응조건,
                    titleKey = m이벤트.GetEntity(i).f우주적응_TitleKey,
                    moneys = new()
                };
                var moneys = m이벤트.GetEntity(i).f적응_재화.Split("+");
                var values = m이벤트.GetEntity(i).f적응_보상.Split("+");
                for (int j = 0; j < moneys.Length; j++)
                {
                    var newMoney = new Event_Money
                    {
                        money = LocalUtil.StringToEnum<EMoney>(moneys[j]),
                        value = int.Parse(values[j])
                    };
                    newItem.moneys.Add(newMoney);
                }
                Adaptation.Add(newItem);
            }
        }
    }
}