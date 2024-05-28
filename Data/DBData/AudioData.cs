using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Universe
{
    [CreateAssetMenu(menuName = "Scriptables/SpriteData/AudioData")]
    public class AudioData : ScriptableObject
    {
        [SerializeField] public AudioInfo[] Clips;

        public AudioClip GetClip(ESound sound) => Clips.FirstOrDefault(x => x.sound == sound).clip;

        public AudioInfo GetInfo(ESound sound) => Clips.First(x => x.sound == sound);
    }

    [Serializable]
    public class AudioInfo
    {
        public ETargetAudio targetAudio;
        public ESound sound;
        public AudioClip clip;
        public bool use;
        [Range(0, 1f)] public float volumeScale = 1;
    }

    public enum ETargetAudio
    {
        BGM,
        SFX,
    }

    public enum ESound
    {
        BGM_Awkward,
        BGM_Harp,
        BGM_Upbeat,
        BGM_ship_ItemStore,
        BGM_Boss,
        BGM_combat_Pirate,
        BGM_jungle_Blackhole,
        fx_roulette,
        fx_close,
        scfi_btn1,
        fx_click1,
        click_pot,
        scfi_btn3,
        BGM_Loading,
        fx_tab,
        fx_harvest,
        fx_seed,
        click_card,
        fx_buff,
        fx_data,
        fx_levelup,
        fx_machine,
        fx_negative,
        fx_success,
        fx_bonus_rich,
        fx_coin,
        fx_chestopen,
        fx_explosion1,
        fx_explosion2,
        fx_shoot1,
        fx_shoot2,
        fx_hit_metal,
        fx_bubble,
        fx_pop,
        fx_moter,
        fx_success2,
        fx_Collect_bright,
    }
}