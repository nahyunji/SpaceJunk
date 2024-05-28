using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

namespace Local
{
    public class DebugCommandController : MonoBehaviour
    {
        [SerializeField] private DebugCommandCollection collection;
        [SerializeField] private UIButton excuteBtn;
        [SerializeField] private TMP_InputField TMPinput;
        [SerializeField] private Transform scrollViewContent;
        [SerializeField] private DebugCommandItem baseItem;
        [SerializeField] private UIButton bgBtn;
        private DebugCommandFunction debugCommandFunction;
        private List<DebugCommandItem> items = new();

        private void Awake()
        {
            bgBtn.OnClickAction = CloseCommand;
            debugCommandFunction = GetComponent<DebugCommandFunction>();
            excuteBtn.OnClickAction = Excute;
            TMPinput.onValueChanged.AddListener(SerchCommand);

            for (int i = 0; i < collection.commands.Count; i++)
            {
                var newObj = Instantiate(baseItem, scrollViewContent);
                items.Add(newObj.GetComponent<DebugCommandItem>());
            }
        }

        private void OnEnable()
        {
            SerchCommand("");
            DebugCommandItem.OnClickCommand += ClickCommand;
        }

        private void OnDisable()
        {
            DebugCommandItem.OnClickCommand -= ClickCommand;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Excute();
            }
        }

        private void ClickCommand(DebugCommands command)
        {
            TMPinput.text = command.command;
            TMPinput.ActivateInputField();
        }

        private void SerchCommand(string text)
        {
            string[] properties = text.Split(' ');
            var containList = collection.commands.FindAll(x => x.command.Contains(properties[0])).ToList();
            if (containList.Count > 0)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (containList.Count > i)
                    {
                        items[i].gameObject.SetActive(true);
                        items[i].Init(containList[i]);
                    }
                    else
                    {
                        items[i].gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                items.ForEach(x => x.gameObject.SetActive(true));
                for (int i = 0; i < items.Count; i++)
                {
                    items[i].Init(collection.commands[i]);
                }
            }
        }

        private void Excute()
        {
            debugCommandFunction.Excute(TMPinput.text);
        }

        private void CloseCommand()
        {
            gameObject.SetActive(false);
        }
    }
}