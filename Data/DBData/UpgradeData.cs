using Sirenix.Serialization;
using System;
using System.Collections.Generic;

namespace Universe.DB
{
    public class UpgradeData
    {
        [OdinSerialize] public List<UpgradeInfo> Info { get; set; }

        public UpgradeData()
        {
            LoadData();
        }

        private void LoadData()
        {
            Info = new()
            {
                AttackList(),
                DefenseList(),
                SpeedList(),
                MissileList(),
                LaserList()
            };
        }

        private UpgradeInfo AttackList()
        {
            var newInfo = new UpgradeInfo()
            {
                shipUpgrade = (EShipUpgrade)Enum.Parse(typeof(EShipUpgrade), m업그레이드.GetEntity(0).fAbility_A),
                maxLevel = m업그레이드.GetEntity(0).fMax_A,
                levelData = new()
            };
            for (int i = 0; i < newInfo.maxLevel + 1; i++)
            {
                var newLevel = new UpgradeLevel()
                {
                    level = m업그레이드.GetEntity(i).f레벨_A,
                    price = m업그레이드.GetEntity(i).f비용_A,
                    value = m업그레이드.GetEntity(i).fvalue_A,
                };
                newInfo.levelData.Add(newLevel);
            }

            return newInfo;
        }

        private UpgradeInfo DefenseList()
        {
            var newInfo = new UpgradeInfo()
            {
                shipUpgrade = (EShipUpgrade)Enum.Parse(typeof(EShipUpgrade), m업그레이드.GetEntity(0).fAbility_D),
                maxLevel = m업그레이드.GetEntity(0).fMax_D,
                levelData = new()
            };
            for (int i = 0; i < newInfo.maxLevel + 1; i++)
            {
                var newLevel = new UpgradeLevel()
                {
                    level = m업그레이드.GetEntity(i).f레벨_D,
                    price = m업그레이드.GetEntity(i).f비용_D,
                    value = m업그레이드.GetEntity(i).fvalue_D,
                };
                newInfo.levelData.Add(newLevel);
            }

            return newInfo;
        }

        private UpgradeInfo SpeedList()
        {
            var newInfo = new UpgradeInfo()
            {
                shipUpgrade = (EShipUpgrade)Enum.Parse(typeof(EShipUpgrade), m업그레이드.GetEntity(0).fAbility_S),
                maxLevel = m업그레이드.GetEntity(0).fMax_S,
                levelData = new()
            };
            for (int i = 0; i < newInfo.maxLevel + 1; i++)
            {
                var newLevel = new UpgradeLevel()
                {
                    level = m업그레이드.GetEntity(i).f레벨_S,
                    price = m업그레이드.GetEntity(i).f비용_S,
                    value = m업그레이드.GetEntity(i).fvalue_S,
                };
                newInfo.levelData.Add(newLevel);
            }
            return newInfo;
        }

        private UpgradeInfo MissileList()
        {
            var newInfo = new UpgradeInfo()
            {
                shipUpgrade = (EShipUpgrade)Enum.Parse(typeof(EShipUpgrade), m업그레이드.GetEntity(0).fAbility_M),
                maxLevel = m업그레이드.GetEntity(0).fMax_M,
                levelData = new()
            };
            for (int i = 0; i < newInfo.maxLevel + 1; i++)
            {
                var newLevel = new UpgradeLevel()
                {
                    level = m업그레이드.GetEntity(i).f레벨_M,
                    price = m업그레이드.GetEntity(i).f비용_M,
                    value = m업그레이드.GetEntity(i).fvalue_M,
                };
                newInfo.levelData.Add(newLevel);
            }
            return newInfo;
        }

        private UpgradeInfo LaserList()
        {
            var newInfo = new UpgradeInfo()
            {
                shipUpgrade = (EShipUpgrade)Enum.Parse(typeof(EShipUpgrade), m업그레이드.GetEntity(0).fAbility_L),
                maxLevel = m업그레이드.GetEntity(0).fMax_L,
                levelData = new()
            };
            for (int i = 0; i < newInfo.maxLevel + 1; i++)
            {
                var newLevel = new UpgradeLevel()
                {
                    level = m업그레이드.GetEntity(i).f레벨_L,
                    price = m업그레이드.GetEntity(i).f비용_L,
                    value = m업그레이드.GetEntity(i).fvalue_L,
                };
                newInfo.levelData.Add(newLevel);
            }
            return newInfo;
        }
    }
}