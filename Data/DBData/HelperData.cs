using Sirenix.Serialization;
using System.Collections.Generic;
using UnityEngine;

namespace Universe.DB
{
    public class HelperData
    {
        [OdinSerialize] public List<HelpInfo> Info { get; set; } = new();

        public HelperData()
        {
            LoadData();
        }

        private void LoadData()
        {
            for (int i = 0; i < m도움말.CountEntities; i++)
            {
                var newHelp = new HelpInfo()
                {
                    ehelp = LocalUtil.StringToEnum<EHelp>(m도움말.GetEntity(i).fKey),
                };
                newHelp.helps.Add(new HelpLang()
                {
                    lang = SystemLanguage.Korean,
                    title = m도움말.GetEntity(i).fKRTItle,
                    explain = m도움말.GetEntity(i).fKR
                });
                newHelp.helps.Add(new HelpLang()
                {
                    lang = SystemLanguage.English,
                    title = m도움말.GetEntity(i).fENGTitle,
                    explain = m도움말.GetEntity(i).fENG
                });
                Info.Add(newHelp);
            }

            var serverData = ServerManager.Instance.ServerContentData.langData.help.data;
            for (int i = 0; i < serverData.Count; i++)
            {
                var helpData = Info.Find(x => serverData[i].Key.Equals($"{x.ehelp}"));
                foreach (var item in helpData.helps)
                {
                    if (item.lang == SystemLanguage.Korean)
                    {
                        item.title = serverData[i].KRTitle;
                        item.explain = serverData[i].KR;
                    }
                    else if (item.lang == SystemLanguage.English)
                    {
                        item.title = serverData[i].ENGTitle;
                        item.explain = serverData[i].ENG;
                    }
                }
            }
        }

        public HelpLang GetHelpData(EHelp eHelp)
        {
            return Info.Find(x => x.ehelp == eHelp).helps.Find(x => x.lang == SystemManager.Instance.curLanguage);
        }
    }
}