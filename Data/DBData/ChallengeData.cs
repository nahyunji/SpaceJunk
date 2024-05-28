using System.Collections.Generic;
using Sirenix.Serialization;

namespace Universe.DB
{
    public class ChallengeData
    {
        [OdinSerialize] public PiratesInfo PiratesInfo { get; set; } = new();
        [OdinSerialize] public List<BlackholeMeter> blackholeMeter { get; set; } = new();
        [OdinSerialize] public List<BlackholeRankReward> blackholeReward { get; set; } = new();
        [OdinSerialize] public List<OrePlanetInfo> orePlanet { get; set; } = new();
        [OdinSerialize] public int limitTime { get; set; }

        public int MaxStage;

        public ChallengeData()
        {
            LoadData();
        }

        private void LoadData()
        {
            MaxStage = m우주해적.CountEntities;
            limitTime = m우주해적.GetEntity(0).f제한시간;
            for (int i = 0; i < m우주해적.CountEntities; i++)
            {
                var newItem = new PiratesStage
                {
                    stage = m우주해적.GetEntity(i).f스테이지,
                    power = m우주해적.GetEntity(i).f적공격력,
                    health = m우주해적.GetEntity(i).f적체력,
                    bossPower = m우주해적.GetEntity(i).f보스공격력,
                    bossHealth = m우주해적.GetEntity(i).f보스체력,
                    perGold = m우주해적.GetEntity(i).f한마리_골드,
                    clearGem = m우주해적.GetEntity(i).f클리어_보석,
                    clearGraxyCoin = m우주해적.GetEntity(i).f은하주화,
                    enemyBulletDelay = m우주해적.GetEntity(i).f적_BulletDelay,
                    enemyBulletSpeed = m우주해적.GetEntity(i).f적_BulletSpeed,
                    waveSpeed = m우주해적.GetEntity(i).fwaveSpeed,
                    wavetimeBetween = m우주해적.GetEntity(i).ftimeBetween,
                    enemyCount = new(),
                    bulletPercent = m우주해적.GetEntity(i).f총알확률
                };

                newItem.enemyCount.Add(m우주해적.GetEntity(i).f웨이브1);
                newItem.enemyCount.Add(m우주해적.GetEntity(i).f웨이브2);
                newItem.enemyCount.Add(m우주해적.GetEntity(i).f웨이브3);
                newItem.enemyCount.Add(m우주해적.GetEntity(i).f웨이브4);
                newItem.enemyCount.Add(m우주해적.GetEntity(i).f웨이브5);
                PiratesInfo.stages.Add(newItem);
            }

            for (int i = 0; i < m블랙홀.CountEntities; i++)
            {
                var newItem = new BlackholeMeter
                {
                    meter = m블랙홀.GetEntity(i).f미터,
                    minSize = m블랙홀.GetEntity(i).fMinSize,
                    maxSize = m블랙홀.GetEntity(i).fMaxSize,
                    minLength = m블랙홀.GetEntity(i).fMinLength,
                    maxLength = m블랙홀.GetEntity(i).fMaxLength,
                    speed = m블랙홀.GetEntity(i).fSpeed,
                };
                blackholeMeter.Add(newItem);
            }

            for (int i = 0; i < m블랙홀.GetEntity(0).f순위개수; i++)
            {
                blackholeReward.Add(new BlackholeRankReward()
                {
                    min = m블랙홀.GetEntity(i).f순위Min,
                    max = m블랙홀.GetEntity(i).f순위Max,
                    money = LocalUtil.StringToEnum<EMoney>(m블랙홀.GetEntity(i).f보상재화),
                    value = m블랙홀.GetEntity(i).f보상값,
                });
            }

            for (int i = 0; i < m광석채굴.CountEntities; i++)
            {
                var newItem = new OrePlanetInfo
                {
                    index = m광석채굴.GetEntity(i).f번호,
                    orePlanet = LocalUtil.StringToEnum<EOrePlanet>(m광석채굴.GetEntity(i).f행성키),
                    time = m광석채굴.GetEntity(i).f시간,
                    reward = new(),
                    minReward = m광석채굴.GetEntity(i).f보상최소,
                    maxReward = m광석채굴.GetEntity(i).f보상최대,
                };
                var rewardStr = m광석채굴.GetEntity(i).f보상.Split('-');
                var minNum = int.Parse(rewardStr[0]);
                var maxNum = int.Parse(rewardStr[1]);
                for (int j = minNum; j <= maxNum; j++)
                {
                    newItem.reward.Add(j);
                }
                orePlanet.Add(newItem);
            }
        }
    }
}