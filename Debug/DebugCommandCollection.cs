using System.Collections.Generic;
using UnityEngine;

namespace Local
{
    [CreateAssetMenu(menuName = "Scriptables/Debug/CommandCollection")]
    public class DebugCommandCollection : ScriptableObject
    {
        public List<DebugCommands> commands = new();
    }
}