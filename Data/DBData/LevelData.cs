using Sirenix.Serialization;
using System.Collections.Generic;

namespace Universe.DB
{
    public class LevelData
    {
        [OdinSerialize] public List<LevelInfo> LevelInfo { get; set; }
        public List<ExpInfo> ExpInfo { get; set; }
        public int Maxlevel;
        public int MaxRank;

        public LevelData()
        {
            LoadData();
        }

        private void LoadData()
        {
            LevelInfo = new();
            for (int i = 0; i < m레벨.CountEntities; i++)
            {
                LevelInfo newItem = new()
                {
                    level = m레벨.GetEntity(i).f레벨,
                    needExp = m레벨.GetEntity(i).f필요경험치,
                    addExp = m레벨.GetEntity(i).f경험치증가
                };
                LevelInfo.Add(newItem);
            }
            Maxlevel = m레벨.GetEntity(0).fLevelCount;
            MaxRank = m레벨.GetEntity(0).fRankCount;
            ExpInfo = new();
            for (int i = 0; i < m레벨.GetEntity(0).f획득개수; i++)
            {
                ExpInfo.Add(new DB.ExpInfo()
                {
                    expType = LocalUtil.StringToEnum<EGainExp>(m레벨.GetEntity(i).fExpKey),
                    exp = m레벨.GetEntity(i).f획득경험치
                });
            }
        }
    }
}