using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Universe.Server;
using Sirenix.Serialization;
using Local.Localization;

namespace Universe
{
    public class UserDataSet
    {
        public static event Action OnResetData = delegate { };

        [OdinSerialize] public UserData.LoginData login = new();
        [OdinSerialize] public UserData.TimeData time = new();
        [OdinSerialize] public UserData.PlayerData player = new();
        [OdinSerialize] public UserData.MoneyData money = new();
        [OdinSerialize] public UserData.UserPlanet planet = new();
        [OdinSerialize] public UserData.Trash trash = new();
        [OdinSerialize] public UserData.StaffData staff = new();
        [OdinSerialize] public UserData.ShipData ship = new();
        [OdinSerialize] public UserData.CollectionData collection = new();
        [OdinSerialize] public Server.MailData mail = new();
        [OdinSerialize] public UserData.ShopData shop = new();
        [OdinSerialize] public UserData.ChallengeData challenge = new();
        [OdinSerialize] public UserData.PassData pass = new();
        [OdinSerialize] public UserData.RouletteData roulette = new();
        [OdinSerialize] public UserData.QuestData quest = new();
        [OdinSerialize] public UserData.RepeatQuestData repeatQuest = new();
        [OdinSerialize] public UserData.EventData events = new();

        public DataManager DataManager => DataManager.Instance;
        public ServerManager ServerManager => ServerManager.Instance;

        public class LoadStr
        {
            public string time = "";
            public string player = "";
            public string money = "";
            public string planet = "";
            public string trash = "";
            public string staff = "";
            public string ship = "";
            public string collection = "";
            public string mail = "";
            public string shop = "";
            public string challenge = "";
            public string pass = "";
            public string roulette = "";
            public string quest = "";
            public string repeatQuest = "";
            public string events = "";
        }

        public UserDataSet()
        {
            Log.Print("[UserDataset]", $"AccountType:{ServerManager.AccountType}", global::ELog.DataLog);

            switch (ServerManager.AccountType)
            {
                case EAccount.NewPlayer:
                    InitData(new LoadStr());
                    login = ServerManager.loginData;
                    login.backup = ServerManager.NowTime;
                    login.join = ServerManager.NowTime;
                    //player.language = SystemLanguage.Korean;
                    if (Application.systemLanguage == SystemLanguage.Korean)
                        player.language = SystemLanguage.Korean;
                    else
                        player.language = SystemLanguage.English;

                    ServerManager.ChangedAllData();
                    break;

                case EAccount.LoadServer:
                    LoadServerData(ServerManager.UserServerData);
                    ServerManager.ChangeData(ESave.Login);
                    break;

                case EAccount.UseDevice:
                    LoadDeviceData();
                    login.nick = ServerManager.loginData.nick;
                    ServerManager.ChangeData(ESave.Login);
                    break;
            }
            //LocalizationManager.Instance.UpdateLanguage(SystemLanguage.Korean);
            LocalizationManager.Instance.UpdateLanguage(player.language);
            var saveLang = player.language == SystemLanguage.Korean ? "KOR" : "ENG";
            PlayerPrefs.SetString("Lang", saveLang);
        }

        public void ResetUserData()
        {
            Debug.Log($"리셋 유저 데이터");
            login = new();
            time = new();
            player = new();
            money = new();
            planet = new();
            trash = new();
            staff = new();
            ship = new();
            collection = new();
            mail = new();
            shop = new();
            challenge = new();
            pass = new();
            roulette = new();
            quest = new();
            repeatQuest = new();
            events = new();

            ServerManager.Instance.DataReset();
            InitData(new LoadStr());
            login = ServerManager.loginData;
            login.backup = ServerManager.NowTime;
            login.join = ServerManager.NowTime;
            player.language = SystemLanguage.Korean;
            ServerManager.ChangedAllData();
            OnResetData?.Invoke();
        }

        private void LoadServerData(UserServerData userData)
        {
            Log.Print("[UserDataset]", $"LoadServerData", global::ELog.DataLog);
            login = userData.accountData.login;
            time = userData.accountData.time;
            player = userData.playData.player;
            money = userData.economyData.money;
            planet = userData.playData.planet;
            trash = userData.collectData.trash;
            staff = userData.collectData.staff;
            ship = userData.playData.ship;
            collection = userData.playData.collection;
            mail = userData.mail;
            shop = userData.economyData.shop;
            challenge = userData.playData.challenge;
            pass = userData.economyData.pass;
            roulette = userData.playData.roulette;
            quest = userData.playData.quest;
            repeatQuest = userData.playData.repeatQuest;
            events = userData.playData.events;
        }

        private void LoadDeviceData()
        {
            Log.Print("[UserDataset]", $"LoadDeviceData", global::ELog.DataLog);

            var loadStr = new LoadStr
            {
                time = ES3.Load($"{ESave.Time}", $"{ESave.Time}.es3", new string(""), ServerManager.dataSetting),
                player = ES3.Load($"{ESave.Player}", $"{ESave.Player}.es3", new string(""), ServerManager.dataSetting),
                money = ES3.Load($"{ESave.Money}", $"{ESave.Money}.es3", new string(""), ServerManager.dataSetting),
                planet = ES3.Load($"{ESave.Planet}", $"{ESave.Planet}.es3", new string(""), ServerManager.dataSetting),
                trash = ES3.Load($"{ESave.Trash}", $"{ESave.Trash}.es3", new string(""), ServerManager.dataSetting),
                staff = ES3.Load($"{ESave.Staff}", $"{ESave.Staff}.es3", new string(""), ServerManager.dataSetting),
                ship = ES3.Load($"{ESave.Ship}", $"{ESave.Ship}.es3", new string(""), ServerManager.dataSetting),
                collection = ES3.Load($"{ESave.Collection}", $"{ESave.Collection}.es3", new string(""), ServerManager.dataSetting),
                mail = ES3.Load($"{ESave.Mail}", $"{ESave.Mail}.es3", new string(""), ServerManager.dataSetting),
                shop = ES3.Load($"{ESave.Shop}", $"{ESave.Shop}.es3", new string(""), ServerManager.dataSetting),
                challenge = ES3.Load($"{ESave.Challenge}", $"{ESave.Challenge}.es3", new string(""), ServerManager.dataSetting),
                pass = ES3.Load($"{ESave.Pass}", $"{ESave.Pass}.es3", new string(""), ServerManager.dataSetting),
                roulette = ES3.Load($"{ESave.Roulette}", $"{ESave.Roulette}.es3", new string(""), ServerManager.dataSetting),
                quest = ES3.Load($"{ESave.Quest}", $"{ESave.Quest}.es3", new string(""), ServerManager.dataSetting),
                repeatQuest = ES3.Load($"{ESave.RepeatQuest}", $"{ESave.RepeatQuest}.es3", new string(""), ServerManager.dataSetting),
                events = ES3.Load($"{ESave.Event}", $"{ESave.Event}.es3", new string(""), ServerManager.dataSetting),
            };

            InitData(loadStr);
        }

        private void InitData(LoadStr data)
        {
            login = ServerManager.Instance.DeviceLoginData;

            if (HasData(data.time)) time = DataConvert<UserData.TimeData>(data.time);
            else time.time = ServerManager.Instance.NowTime;

            if (HasData(data.player)) player = DataConvert<UserData.PlayerData>(data.player);
            else NewPlayer();

            if (HasData(data.planet)) planet = DataConvert<UserData.UserPlanet>(data.planet);
            else NewPlanet();

            if (HasData(data.money)) money = JsonConvert.DeserializeObject<UserData.MoneyData>(data.money);

            if (HasData(data.trash)) trash = DataConvert<UserData.Trash>(data.trash);
            else NewTrash();

            if (HasData(data.staff)) staff = DataConvert<UserData.StaffData>(data.staff);
            else NewStaff();

            if (HasData(data.ship)) ship = DataConvert<UserData.ShipData>(data.ship);
            else NewShip();

            if (HasData(data.collection)) collection = DataConvert<UserData.CollectionData>(data.collection);
            else NewCollection();

            if (HasData(data.shop)) shop = DataConvert<UserData.ShopData>(data.shop);

            if (HasData(data.challenge)) challenge = DataConvert<UserData.ChallengeData>(data.challenge);
            else NewChallenge();

            if (HasData(data.pass)) pass = DataConvert<UserData.PassData>(data.pass);
            else NewPass();

            if (HasData(data.roulette)) roulette = DataConvert<UserData.RouletteData>(data.roulette);

            if (HasData(data.quest)) quest = DataConvert<UserData.QuestData>(data.quest);
            else NewQuest();

            if (HasData(data.repeatQuest)) repeatQuest = DataConvert<UserData.RepeatQuestData>(data.repeatQuest);
            else NewRepeatQuest();

            if (HasData(data.events)) events = DataConvert<UserData.EventData>(data.events);

            if (HasData(data.mail)) mail = DataConvert<MailData>(data.mail);
        }

        private bool HasData(string dataStr) => dataStr.Length > 0;

        private T DataConvert<T>(string dataStr)
        {
            return JsonConvert.DeserializeObject<T>(dataStr);
        }

        #region NewInit

        private void NewStaff()
        {
            staff.slot = m직원.GetEntity(0).f시작슬롯개수;
        }

        private void NewPlayer()
        {
            player.openProfile.Add(1);
            for (int i = 0; i < m버프.CountEntities; i++)
            {
                player.buff.Add(new UserData.BuffInfo()
                {
                    zodiac = LocalUtil.StringToEnum<EZodiac>(m버프.GetEntity(i).fkey)
                });
            }
            player.volume.Bgm = 1;
            player.volume.Sfx = 1;
            player.language = UnityEngine.Application.systemLanguage;
        }

        private void NewChallenge()
        {
            var DBOreData = DataManager.challenge.orePlanet;
            for (int i = 0; i < DBOreData.Count; i++)
            {
                challenge.oreData.Add(new UserData.OreData()
                {
                    orePlanet = DBOreData[i].orePlanet,
                    working = false,
                    complete = false,
                    staffuniq = ""
                });
            }
        }

        private void NewCollection()
        {
            for (int i = 0; i < m수집.CountEntities; i++)
            {
                collection.collect.Add(new UserData.CollectionInfo()
                {
                    collect = (ECollection)i
                });
            }
        }

        private void NewShip()
        {
            ship.spaceShipInfos.Add(new UserData.SpaceShipInfo() { index = 1, open = true });

            for (int i = 0; i < 5; i++)
            {
                var newItem = new UserData.UpgradeInfo()
                {
                    upgrade = (EShipUpgrade)i,
                    level = 0,
                };
                ship.upgrades.Add(newItem);
            }

            ship.greenHouse.veges.Add(new UserData.VegetableInfo()
            {
                vege = EVegetable.TOMATO,
                count = 0
            });
        }

        private void NewPlanet()
        {
            planet.list = new List<UserData.PlanetData>
            {
                new UserData.PlanetData { planet = planet.cur, resource = NewResourceSet() }
            };
        }

        private List<UserData.PlanetResource> NewResourceSet()
        {
            var list = new List<UserData.PlanetResource>();
            for (int i = 0; i < 10; i++)
            {
                var item = new UserData.PlanetResource
                {
                    index = i + 1,
                    level = 1,
                    open = false,
                    loadingShip = 1,
                };
                list.Add(item);
            }

            list[0].open = true;
            return list;
        }

        private void NewTrash()
        {
            for (int i = 0; i < m쓰레기.CountEntities; i++)
            {
                trash.trash.Add(new UserData.TrashSet { trash = (ETrash)i + 1 });
                trash.recycle.Add(new UserData.TrashSet { trash = (ETrash)i + 1 });
            }
            trash.trash[0].count += 10;

            for (int i = 0; i < m합성.CountEntities; i++)
            {
                trash.merge.Add(new UserData.MergeSet { merge = (EMerge)i + 1 });
            }

            for (int i = 0; i < m재활용슬롯.GetEntity(0).f재활용_시작개수; i++)
            {
                trash.recycleSlots.Add(new UserData.ConvertRecycle { open = true, slot = i + 1, trash = ETrash.NONE });
            }

            for (int i = 0; i < m재활용슬롯.GetEntity(0).f합성_시작개수; i++)
            {
                trash.mergeSlots.Add(new UserData.ConvertMerge { open = true, slot = i + 1, merge = EMerge.NONE });
            }
        }

        private void NewPass()
        {
            for (int i = 0; i < m패스퀘스트.CountEntities; i++)
            {
                pass.quest.Add(new UserData.PassQuest
                {
                    quest = (EPassQuest)i,
                    cur = 0,
                    clear = 0,
                });
            }
        }

        private void NewQuest()
        {
            for (int i = 0; i < m퀘스트.CountEntities; i++)
            {
                var newQuest = new UserData.QuestInfo
                {
                    quest = LocalUtil.StringToEnum<EQuest>(m퀘스트.GetEntity(i).fTitleKey),
                };
                quest.quests.Add(newQuest);
            }
        }

        private void NewRepeatQuest()
        {
            for (int i = 0; i < m반복퀘스트.CountEntities; i++)
            {
                var newQuest = new UserData.RepeatQuestInfo
                {
                    quest = LocalUtil.StringToEnum<ERepeatQuest>(m반복퀘스트.GetEntity(i).fQuestKey),
                    goal = m반복퀘스트.GetEntity(i).fValue,
                };
                repeatQuest.repeatQuest.Add(newQuest);
            }
        }

        #endregion NewInit
    }
}