using System;
using UnityEngine;

namespace Local
{
    [Serializable]
    public class DebugCommands
    {
        public string name;
        public string command;
        public string format;
        private Action action;

        [TextArea]
        public string description;
    }
}