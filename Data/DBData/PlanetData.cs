using Sirenix.Serialization;
using System;
using System.Collections.Generic;

namespace Universe.DB
{
    public class PlanetData
    {
        [OdinSerialize] public List<PlanetSet> List { get; set; }
        [OdinSerialize] public List<PlanetInfo> Info { get; set; }
        [OdinSerialize] public List<ResourceLevel> Levels { get; set; }
        [OdinSerialize] public List<TrashInfo> TrashInfos { get; set; }
        [OdinSerialize] public List<RewardGrp> Rewards { get; set; }
        [OdinSerialize] public List<MergeInfo> MergeInfos { get; set; }
        [OdinSerialize] public RecycleSlotInfo RecycleSlot { get; set; }

        public int TrashMaxLevel;

        public PlanetData()
        {
            LoadData();
        }

        private void LoadData()
        {
            TrashMaxLevel = m자원레벨.CountEntities;
            //행성
            List = new List<PlanetSet>();

            for (int i = 0; i < m행성.CountEntities; i++)
            {
                PlanetSet planetSet = new()
                {
                    index = m행성.GetEntity(i).f번호,
                    bg = m행성.GetEntity(i).f배경,
                    planet = (EPlanet)Enum.Parse(typeof(EPlanet), m행성.GetEntity(i).fKey),
                    openLevel = m행성.GetEntity(i).f해금레벨,
                    openCondition = m행성.GetEntity(i).f해금조건,
                };
                List.Add(planetSet);
            }

            //행성정보
            Info = new List<PlanetInfo>();

            for (int i = 0; i < m행성정보.GetEntity(0).f행성개수; i++)
            {
                var planetInfo = new PlanetInfo
                {
                    planet = (EPlanet)Enum.Parse(typeof(EPlanet), m행성정보.GetEntity(i * 10).f행성키),
                    bgNum = m행성정보.GetEntity(i * 10).f배경,
                    list = new List<ResourceInfo>()
                };

                for (int j = 0; j < m행성정보.GetEntity(0).f자원개수; j++)
                {
                    int entityNum = j + (i * 10);
                    ResourceInfo item = new()
                    {
                        num = j + 1,
                        trash = new(),
                        gold_mult = m행성정보.GetEntity(entityNum).f골드_곱,
                        oepnGold = m행성정보.GetEntity(entityNum).f해금골드
                    };

                    var trashs = m행성정보.GetEntity(entityNum).fTrash.Split("/");
                    for (int t = 0; t < trashs.Length; t++)
                    {
                        item.trash.Add((ETrash)int.Parse(trashs[t]));
                    }

                    planetInfo.list.Add(item);
                }

                Info.Add(planetInfo);
            }

            //자원레벨
            Levels = new List<ResourceLevel>();

            for (int i = 0; i < m자원레벨.CountEntities; i++)
            {
                ResourceLevel item = new ResourceLevel
                {
                    level = m자원레벨.GetEntity(i).f레벨,
                    speed = m자원레벨.GetEntity(i).f우주선속도,
                    amountTransport = m자원레벨.GetEntity(i).f적재량,
                    collectionRate = m자원레벨.GetEntity(i).f수집속도,
                    price = m자원레벨.GetEntity(i).f레벨업_골드
                };
                Levels.Add(item);
            }

            //쓰레기
            TrashInfos = new List<TrashInfo>();

            for (int i = 0; i < m쓰레기.CountEntities; i++)
            {
                TrashInfo item = new()
                {
                    index = m쓰레기.GetEntity(i).f번호,
                    trash = (ETrash)Enum.Parse(typeof(ETrash), m쓰레기.GetEntity(i).fKey),
                    count = m쓰레기.GetEntity(i).f개수,
                    trashPrice = m쓰레기.GetEntity(i).f판매,
                    recyclePrice = m쓰레기.GetEntity(i).f재활용판매,
                    recycleCount = m쓰레기.GetEntity(i).f재활용개수,
                    recycleTime = m쓰레기.GetEntity(i).f재활용시간
                };
                TrashInfos.Add(item);
            }

            //합성
            MergeInfos = new List<MergeInfo>();

            for (int i = 0; i < m합성.CountEntities; i++)
            {
                MergeInfo item = new()
                {
                    index = m합성.GetEntity(i).f번호,
                    grade = (EMergeGrade)Enum.Parse(typeof(EMergeGrade), m합성.GetEntity(i).f등급),
                    merge = (EMerge)Enum.Parse(typeof(EMerge), m합성.GetEntity(i).fName),
                    price = m합성.GetEntity(i).f판매,
                    recycleTime = m합성.GetEntity(i).f합성시간,
                    mergeList = new List<MergeRecycleInfo>()
                };

                string[] mergeTrash = m합성.GetEntity(i).f합성.Split("/");
                string[] mergeCount = m합성.GetEntity(i).f합성개수.Split("/");

                for (int m = 0; m < mergeTrash.Length; m++)
                {
                    item.mergeList.Add(new MergeRecycleInfo
                    {
                        trash = (ETrash)int.Parse(mergeTrash[m]),
                        recycleCount = int.Parse(mergeCount[m])
                    });
                }

                MergeInfos.Add(item);
            }

            // 재활용 슬롯
            RecycleSlot = new RecycleSlotInfo();
            RecycleSlot.recycle = new List<RecycleSlotPrice>();
            RecycleSlot.merge = new List<RecycleSlotPrice>();

            for (int i = 0; i < m재활용슬롯.CountEntities; i++)
            {
                RecycleSlot.recycle.Add(new RecycleSlotPrice
                {
                    slot = i + 1,
                    openPrice = m재활용슬롯.GetEntity(i).f재활용_해금비용
                });

                RecycleSlot.merge.Add(new RecycleSlotPrice
                {
                    slot = i + 1,
                    openPrice = m재활용슬롯.GetEntity(i).f합성_해금비용
                });
            }

            //자원레벨보상
            Rewards = new List<RewardGrp>();

            for (int i = 0; i < m자원레벨보상.GetEntity(0).f자원개수; i++)
            {
                var group = new RewardGrp
                {
                    trashNum = i + 1,
                    infos = new List<RewardInfo>()
                };

                var datas = m자원레벨보상.FindEntities(x => x.f자원번호 == group.trashNum);

                for (int j = 0; j < datas.Count; j++)
                {
                    var item = new RewardInfo
                    {
                        level = datas[j].f레벨,
                        count = datas[j].f개수,
                        money = (EMoney)Enum.Parse(typeof(EMoney), datas[j].f보상키)
                    };

                    group.infos.Add(item);
                }

                Rewards.Add(group);
            }
        }
    }
}