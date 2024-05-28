using Sirenix.Serialization;
using System.Collections.Generic;

namespace Universe.DB
{
    public class StationQuestData
    {
        [OdinSerialize] public List<StationQuestInfo> Info { get; set; }
        [OdinSerialize] public List<StationQuestReward> Rewards { get; set; }

        public StationQuestData()
        {
            LoadData();
        }

        private void LoadData()
        {
            Info = new();
            for (int i = 0; i < m의뢰게시판.GetEntity(0).f퀘스트개수; i++)
            {
                var newQuest = new StationQuestInfo
                {
                    quest = LocalUtil.StringToEnum<EStationQuest>(m의뢰게시판.GetEntity(i).fTitle_Key),
                    contentKey = m의뢰게시판.GetEntity(i).fContent_Key,
                    min = m의뢰게시판.GetEntity(i).fCount_Min,
                    max = m의뢰게시판.GetEntity(i).fCount_Max,
                };
                Info.Add(newQuest);
            }

            Rewards = new();
            for (int i = 0; i < m의뢰게시판.GetEntity(0).f재화개수; i++)
            {
                var newReward = new StationQuestReward
                {
                    payMoney = LocalUtil.StringToEnum<EMoney>(m의뢰게시판.GetEntity(i).f재화),
                    payCount = m의뢰게시판.GetEntity(i).fPay,
                };
                Rewards.Add(newReward);
            }
        }
    }
}