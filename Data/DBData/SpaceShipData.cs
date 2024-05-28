using Sirenix.Serialization;
using System.Collections.Generic;

namespace Universe.DB
{
    public class SpaceShipData
    {
        [OdinSerialize] public List<SpaceShipInfo> Info { get; set; }

        public SpaceShipData()
        {
            LoadData();
        }

        private void LoadData()
        {
            Info = new();

            for (int i = 0; i < m우주선.GetEntity(0).f우주선개수; i++)
            {
                var newItem = new SpaceShipInfo
                {
                    index = i + 1,
                    buildtime = m우주선.GetEntity(i).f건조시간,
                    price = m우주선.GetEntity(i).f비용,
                    abilities = new(),
                    resources = new(),
                };

                newItem.abilities.Add(
                    new SpaceShipAbility
                    {
                        shipAbility = EShipAbility.MOVE_SPEED,
                        abilityValue = m우주선.GetEntity(i).f우주선속도
                    });

                newItem.abilities.Add(
                    new SpaceShipAbility
                    {
                        shipAbility = EShipAbility.ATTACK_POWER,
                        abilityValue = m우주선.GetEntity(i).f공격력
                    });

                newItem.abilities.Add(
                  new SpaceShipAbility
                  {
                      shipAbility = EShipAbility.DEFENSE,
                      abilityValue = m우주선.GetEntity(i).f방어력
                  });

                newItem.abilities.Add(
                  new SpaceShipAbility
                  {
                      shipAbility = EShipAbility.LASER_POWER,
                      abilityValue = m우주선.GetEntity(i).f레이져
                  });

                newItem.abilities.Add(
                  new SpaceShipAbility
                  {
                      shipAbility = EShipAbility.MISSLIE_POWER,
                      abilityValue = m우주선.GetEntity(i).f미사일
                  });

                Info.Add(newItem);

                var countStr = m우주선.GetEntity(i).f재료개수.Split('/');
                var recycleStr = m우주선.GetEntity(i).f재활용.Split('/');

                newItem.resources.Add(new SpaceShipResource
                {
                    eResource = EResource.TRASH,
                    eTrash = (ETrash)m우주선.GetEntity(i).f쓰레기,
                    resourceCount = int.Parse(countStr[0])
                });

                newItem.resources.Add(new SpaceShipResource
                {
                    eResource = EResource.RECYCLE,
                    eTrash = (ETrash)int.Parse(recycleStr[0]),
                    resourceCount = int.Parse(countStr[1])
                });

                newItem.resources.Add(new SpaceShipResource
                {
                    eResource = EResource.RECYCLE,
                    eTrash = (ETrash)int.Parse(recycleStr[1]),
                    resourceCount = int.Parse(countStr[2])
                });

                newItem.resources.Add(new SpaceShipResource
                {
                    eResource = EResource.MERGE,
                    eMerge = (EMerge)m우주선.GetEntity(i).f합성,
                    resourceCount = int.Parse(countStr[3])
                });
            }
        }
    }
}