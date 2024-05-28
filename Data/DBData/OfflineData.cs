using Sirenix.Serialization;

namespace Universe.DB
{
    public class OfflineData
    {
        [OdinSerialize] public int MinTime { get; set; }
        [OdinSerialize] public int MaxTime { get; set; }
        [OdinSerialize] public float getPercent { get; set; }
        [OdinSerialize] public int adCount { get; set; }

        public OfflineData()
        {
            LoadData();
        }

        private void LoadData()
        {
            MinTime = m오프라인보상.GetEntity(0).f최소시간;
            MaxTime = m오프라인보상.GetEntity(0).f최대시간;
            getPercent = m오프라인보상.GetEntity(0).f획득;
            adCount = m오프라인보상.GetEntity(0).f광고횟수;
        }
    }
}