using Sirenix.Serialization;
using System;
using System.Collections.Generic;

namespace Universe.DB
{
    public class TutorialData
    {
        [OdinSerialize] public List<TutorialInfo> Tutorials { get; set; } = new();

        public TutorialData() => LoadData();

        private void LoadData()
        {
            foreach (ETutorial item in Enum.GetValues(typeof(ETutorial)))
            {
                var newInfo = new TutorialInfo();
                var startIndex = m튜토리얼.FindEntity(x => x.fwhen == $"{item}").Index;
                var itemCount = m튜토리얼.GetEntity(startIndex).fcount;
                newInfo.tutorial = item;
                newInfo.npc = LocalUtil.StringToEnum<ENPC>(m튜토리얼.GetEntity(startIndex).fwho);
                newInfo.quest = LocalUtil.StringToEnum<ETutorialQuest>(m튜토리얼.GetEntity(startIndex).fQuest);
                newInfo.reward = (LocalUtil.StringToEnum<EMoney>(m튜토리얼.GetEntity(startIndex).f재화)
                    , m튜토리얼.GetEntity(startIndex).fReward);
                newInfo.condition = m튜토리얼.GetEntity(startIndex).fcondition;
                for (int i = 0; i < itemCount; i++)
                {
                    newInfo.msg.Add(new TutorialMsg
                    {
                        index = i + 1,
                        key = m튜토리얼.GetEntity(startIndex + i).fKey
                    });
                }
                Tutorials.Add(newInfo);
            }
        }
    }
}