using System.Collections.Generic;
using System.Linq;
using Sirenix.Serialization;

namespace Universe.DB
{
    public class CollectionData
    {
        [OdinSerialize] public List<CollectionInfo> Info { get; set; }
        [OdinSerialize] public EMoney collectMoney { get; set; }
        [OdinSerialize] public int collectReward { get; set; }
        [OdinSerialize] public int adsCount { get; set; }

        public CollectionData()
        {
            LoadData();
        }

        private void LoadData()
        {
            Info = new();
            collectMoney = LocalUtil.StringToEnum<EMoney>(m수집.GetEntity(0).f수집재화);
            collectReward = m수집.GetEntity(0).f수집Reward;
            adsCount = m수집.GetEntity(0).f광고횟수;
            for (int i = 0; i < m수집.CountEntities; i++)
            {
                var newItem = new CollectionInfo
                {
                    collection = LocalUtil.StringToEnum<ECollection>(m수집.GetEntity(i).f일지키),
                    count = m수집.GetEntity(i).f개수,
                    bonus = LocalUtil.StringToEnum<EMoney>(m수집.GetEntity(i).f보너스재화),
                    bonusCount = new(),
                    bonusReward = new(),
                    cardPiece = m수집.GetEntity(i).f카드조각,
                    cardPack = m수집.GetEntity(i).f카드팩,
                    percent = m수집.GetEntity(i).f확률,
                    adsPiece = m수집.GetEntity(i).f광고조각,
                };

                var bonusCountStr = m수집.GetEntity(i).f보너스개수.Split("/").ToList();
                bonusCountStr.ForEach(x => newItem.bonusCount.Add(int.Parse(x)));
                var bonusRewardStr = m수집.GetEntity(i).f보너스Reward.Split("/").ToList();
                bonusRewardStr.ForEach(x => newItem.bonusReward.Add(int.Parse(x)));

                Info.Add(newItem);
            }
        }
    }
}