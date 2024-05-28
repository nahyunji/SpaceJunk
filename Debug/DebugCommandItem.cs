using Local;
using System;
using TMPro;
using UnityEngine;
using Universe;

public class DebugCommandItem : ConfiguredMonoBehaviour
{
    public static event Action<DebugCommands> OnClickCommand;

    [SerializeField] private TMP_Text text;
    private UIButton uibutton;
    private DebugCommands debugCommands;

    private void Awake()
    {
        uibutton = GetComponent<UIButton>();
        uibutton.OnClickAction = ClickCommand;
    }

    public void Init(DebugCommands debugCommands)
    {
        this.debugCommands = debugCommands;
        text.text = $"<color=#{SpriteUtil.Color(EColor.Yellow).hex}>{debugCommands.format}</color> : {debugCommands.description}";
    }

    private void ClickCommand()
    {
        OnClickCommand?.Invoke(debugCommands);
    }
}