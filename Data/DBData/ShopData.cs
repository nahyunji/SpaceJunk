using Sirenix.Serialization;

namespace Universe.DB
{
    public class ShopData
    {
        [OdinSerialize] public ShopGalileo Galileo { get; set; }
        [OdinSerialize] public ShopStar Star { get; set; }
        [OdinSerialize] public ChargeShop Charge { get; set; }
        [OdinSerialize] public MemberShip MemberShip { get; set; }
        [OdinSerialize] public GemShop GemShop { get; set; }

        public ShopData()
        {
            LoadData();
        }

        private void LoadData()
        {
            Galileo = new();
            Star = new();
            Charge = new();
            MemberShip = new();
            GemShop = new();

            Galileo.Info = new();
            Star.Info = new();
            Charge.Info = new();
            GemShop.Info = new();

            SetGalileo();
            SetStar();
            SetCharge();
            SetMemberShip();
            SetGemShop();
        }

        private void SetGalileo()
        {
            for (int i = 0; i < m상점.FindEntity(x => x.f상점키 == "GALILEO").f개수; i++)
            {
                var index = GetPackageIndex($"{(EGalileoPack)i}");
                var newGalileo = new GalileoInfo
                {
                    pack = LocalUtil.StringToEnum<EGalileoPack>(m상점.GetEntity(index).f패키지키),
                    googleKey = m상점.GetEntity(index).fGoogleKey,
                    doller = m상점.GetEntity(index).f달러,
                    krw = m상점.GetEntity(index).f원화,
                    reward = new(),
                    period = (LocalUtil.StringToEnum<EPeriod>(m상점.GetEntity(index).f기간제한), m상점.GetEntity(index).f횟수제한)
                };

                var moneys = m상점.GetEntity(index).f재화.Split("+");
                var pays = m상점.GetEntity(index).fPay.Split("+");
                for (int j = 0; j < moneys.Length; j++)
                {
                    newGalileo.reward[LocalUtil.StringToEnum<EMoney>(moneys[j])] = int.Parse(pays[j]);
                }

                Galileo.Info.Add(newGalileo);
            }
        }

        private void SetStar()
        {
            var startIndex = m상점.FindEntity(x => x.f상점키 == "STAR_EXPLORATION").Index;
            for (int i = 0; i < m상점.GetEntity(startIndex).f개수; i++)
            {
                var index = startIndex + i;
                var newItem = new StarInfo
                {
                    pack = LocalUtil.StringToEnum<EShopStarPack>(m상점.GetEntity(index).f패키지키),
                    googleKey = m상점.GetEntity(index).fGoogleKey,
                    doller = m상점.GetEntity(index).f달러,
                    krw = m상점.GetEntity(index).f원화,
                    period = (LocalUtil.StringToEnum<EPeriod>(m상점.GetEntity(index).f기간제한), m상점.GetEntity(index).f횟수제한),
                    reward = new(),
                };

                if (newItem.pack == EShopStarPack.REMOVE_ADS)
                {
                    newItem.reward[LocalUtil.StringToEnum<EMoney>(m상점.GetEntity(index).f재화)] = int.Parse(m상점.GetEntity(index).fPay);
                }
                if (newItem.pack == EShopStarPack.BLESSING)
                {
                    newItem.zodiac = int.Parse(m상점.GetEntity(index).fPay);
                }

                Star.Info.Add(newItem);
            }
        }

        private void SetCharge()
        {
            var startIndex = m상점.FindEntity(x => x.f상점키 == "CHARGE").Index;
            for (int i = 0; i < m상점.GetEntity(startIndex).f개수; i++)
            {
                var index = startIndex + i;
                var newItem = new ChargeInfo
                {
                    pack = LocalUtil.StringToEnum<EShopChargePack>(m상점.GetEntity(index).f패키지키),
                    googleKey = m상점.GetEntity(index).fGoogleKey,
                    doller = m상점.GetEntity(index).f달러,
                    krw = m상점.GetEntity(index).f원화,
                    money = LocalUtil.StringToEnum<EMoney>(m상점.GetEntity(index).f재화),
                    reward = int.Parse(m상점.GetEntity(index).fPay)
                };

                Charge.Info.Add(newItem);
            }
        }

        private void SetMemberShip()
        {
            MemberShip.googleKey = m상점.FindEntity(x => x.f구독_Menu == "GoogleKey").f구독_Info;
            MemberShip.doller = float.Parse(m상점.FindEntity(x => x.f구독_Menu == "달러").f구독_Info);
            MemberShip.krw = int.Parse(m상점.FindEntity(x => x.f구독_Menu == "원화").f구독_Info);

            MemberShip.discount_googleKey = m상점.FindEntity(x => x.f구독_Menu == "GoogleKey").f구독할인;
            MemberShip.discount_doller = float.Parse(m상점.FindEntity(x => x.f구독_Menu == "달러").f구독할인);
            MemberShip.discount_krw = int.Parse(m상점.FindEntity(x => x.f구독_Menu == "원화").f구독할인);

            MemberShip.startReward = (LocalUtil.StringToEnum<EMoney>(m상점.GetEntity(0).f구독시지급), m상점.GetEntity(0).f구독시_Reward);
            MemberShip.reward = (LocalUtil.StringToEnum<EMoney>(m상점.GetEntity(0).f구독지급), m상점.GetEntity(0).f구독_Reward);

            MemberShip.MemberShipReward = (LocalUtil.StringToEnum<EMoney>(m상점.GetEntity(0).f구독시지급)
               , m상점.GetEntity(0).f구독시_Reward);

            MemberShip.MemberShipDailyReward = (LocalUtil.StringToEnum<EMoney>(m상점.GetEntity(0).f구독지급)
                , m상점.GetEntity(0).f구독_Reward);

            MemberShip.MemberShipOfflineTime = m상점.GetEntity(0).f구독_오프라인시간;
            MemberShip.MemberShipLimitMult = m상점.GetEntity(0).f구독_기간제횟수;
        }

        private int GetPackageIndex(string key) => m상점.FindEntity(x => x.f패키지키 == key).Index;

        private void SetGemShop()
        {
            for (int i = 0; i < m보석상점.CountEntities; i++)
            {
                var newItem = new GemShopInfo()
                {
                    money = LocalUtil.StringToEnum<EMoney>(m보석상점.GetEntity(i).f재화),
                    reward = m보석상점.GetEntity(i).fReward,
                    price = m보석상점.GetEntity(i).f보석비용,
                    dayLimit = m보석상점.GetEntity(i).f매일한정,
                };

                GemShop.Info.Add(newItem);
            }
        }
    }
}