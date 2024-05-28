using Sirenix.Serialization;
using System.Collections.Generic;

namespace Universe.DB
{
    public class PassData
    {
        [OdinSerialize] public List<PassInfo> Info { get; set; }
        [OdinSerialize] public List<PassQuestInfo> PassQuest { get; set; }
        [OdinSerialize] public List<PassShopInfo> PassShop { get; set; }

        public string googleKey;
        public float dollor;
        public int krw;

        public PassData()
        {
            LoadData();
        }

        private void LoadData()
        {
            Info = new();
            PassShop = new();
            PassQuest = new();
            for (int i = 0; i < m패스.CountEntities; i++)
            {
                var newItem = new PassInfo
                {
                    level = m패스.GetEntity(i).f레벨,
                    levelup = m패스.GetEntity(i).f레벌업경험치,

                    freePass = new()
                    {
                        money = LocalUtil.StringToEnum<EMoney>(m패스.GetEntity(i).f프리패스),
                        value = m패스.GetEntity(i).f프리_보상
                    }
                };

                if (m패스.GetEntity(i).f골드패스.Equals("PROFILE"))
                {
                    newItem.goldPass = new()
                    {
                        money = EMoney.NONE,
                        profile = true,
                        value = m패스.GetEntity(i).f골드_보상
                    };
                }
                else
                {
                    newItem.goldPass = new()
                    {
                        money = LocalUtil.StringToEnum<EMoney>(m패스.GetEntity(i).f골드패스),
                        value = m패스.GetEntity(i).f골드_보상,
                    };
                }

                Info.Add(newItem);
            }

            googleKey = m패스.GetEntity(0).fGoogleKey;
            dollor = m패스.GetEntity(0).f달러;
            krw = m패스.GetEntity(0).f원화;

            for (int i = 0; i < m패스퀘스트.CountEntities; i++)
            {
                var newItem = new PassQuestInfo
                {
                    passQuest = LocalUtil.StringToEnum<EPassQuest>(m패스퀘스트.GetEntity(i).fTitleKey),
                    condition = m패스퀘스트.GetEntity(i).f조건,
                    count = m패스퀘스트.GetEntity(i).f횟수,
                    exp = m패스퀘스트.GetEntity(i).fEXP
                };
                PassQuest.Add(newItem);
            }

            for (int i = 0; i < m패스상점.CountEntities; i++)
            {
                var newItem = new PassShopInfo
                {
                    money = LocalUtil.StringToEnum<EMoney>(m패스상점.GetEntity(i).f재화),
                    reward = m패스상점.GetEntity(i).fReward,
                    passCoin = m패스상점.GetEntity(i).f패스코인
                };
                PassShop.Add(newItem);
            }
        }
    }
}