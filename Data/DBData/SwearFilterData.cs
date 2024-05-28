using Sirenix.Serialization;
using System.Collections.Generic;

namespace Universe.DB
{
    public class SwearFilterData
    {
        [OdinSerialize] public List<string> SwearFilters { get; set; } = new();

        public SwearFilterData()
        {
            LoadData();
        }

        private void LoadData()
        {
            for (int i = 0; i < m닉네임.CountEntities; i++)
            {
                SwearFilters.Add(m닉네임.GetEntity(i).fFilter);
            }
        }
    }
}