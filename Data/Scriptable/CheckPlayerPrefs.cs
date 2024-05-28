using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using Sirenix.Serialization;

namespace Universe
{
    [CreateAssetMenu(menuName = "Scriptables/Debug/CheckPlayerPrefs")]
    public class CheckPlayerPrefs : ScriptableObject
    {
        [TextArea(5, 10)] public string serverSaveList;
        [TextArea(5, 10)] public string logStream;

        [TextArea(5, 1)] public string time;
        [TextArea(5, 5)] public string login;
        [TextArea(5, 5)] public string player;
        [TextArea(5, 5)] public string planet;

        [TextArea(5, 5)] public string staff;

        [TextArea(5, 10)] public string money;

        [TextArea(5, 20)] public string ship;
        [TextArea(5, 20)] public string collection;
        [TextArea(5, 20)] public string mail;
        [TextArea(5, 20)] public string shop;

        [TextArea(5, 20)] public string challenge;
        [TextArea(5, 20)] public string pass;
        [TextArea(5, 20)] public string roulette;
        [TextArea(5, 20)] public string quest;
        [TextArea(5, 20)] public string repeatQuest;
        [TextArea(5, 20)] public string events;

        [TextArea(5, 30)] public string trash;
    }
}