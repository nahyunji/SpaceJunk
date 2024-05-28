using Sirenix.Serialization;
using System.Collections.Generic;
using UnityEngine;

namespace Universe.DB
{
    public class QuestData
    {
        [OdinSerialize] public List<QuestInfo> Info { get; set; }
        [OdinSerialize] public List<RepeatQuestInfo> RepeatInfo { get; set; }

        public QuestData()
        {
            LoadData();
        }

        private void LoadData()
        {
            Info = new();
            for (int i = 0; i < m퀘스트.CountEntities; i++)
            {
                var newQuest = new QuestInfo
                {
                    quest = LocalUtil.StringToEnum<EQuest>(m퀘스트.GetEntity(i).fTitleKey),
                    count = m퀘스트.GetEntity(i).f횟수,
                    money = LocalUtil.StringToEnum<EMoney>(m퀘스트.GetEntity(i).f재화),
                    reward = m퀘스트.GetEntity(i).fReward
                };
                Info.Add(newQuest);
            }

            RepeatInfo = new();
            for (int i = 0; i < m반복퀘스트.CountEntities; i++)
            {
                var newQuest = new RepeatQuestInfo
                {
                    quest = LocalUtil.StringToEnum<ERepeatQuest>(m반복퀘스트.GetEntity(i).fQuestKey),
                    count = m반복퀘스트.GetEntity(i).fValue,
                    add = m반복퀘스트.GetEntity(i).f증가,
                    max = m반복퀘스트.GetEntity(i).fmaxValue,
                    reward = (LocalUtil.StringToEnum<EMoney>(m반복퀘스트.GetEntity(i).fReward), m반복퀘스트.GetEntity(i).fRewardValue)
                };
                RepeatInfo.Add(newQuest);
            }
        }
    }
}