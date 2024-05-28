using System;

public class DebugCommandBase
{
    private string _commandId;

    public string CommandId
    { get { return _commandId; } }

    public DebugCommandBase(string id)
    {
        _commandId = id;
    }
}

public class DebugCommand : DebugCommandBase
{
    private Action command;

    public DebugCommand(string id, Action command) : base(id)
    {
        this.command = command;
    }

    public void Invoke()
    {
        command.Invoke();
    }
}

public class DebugCommand<T1> : DebugCommandBase
{
    private Action<T1> command;

    public DebugCommand(string id, Action<T1> command) : base(id)
    {
        this.command = command;
    }

    public void Invoke(T1 value)
    {
        command.Invoke(value);
    }
}

public class DebugCommand<T1, T2> : DebugCommandBase
{
    private Action<T1, T2> command;

    public DebugCommand(string id, Action<T1, T2> command) : base(id)
    {
        this.command = command;
    }

    public void Invoke(T1 value, T2 value2)
    {
        command.Invoke(value, value2);
    }
}

public class DebugCommand<T1, T2, T3> : DebugCommandBase
{
    private Action<T1, T2, T3> command;

    public DebugCommand(string id, Action<T1, T2, T3> command) : base(id)
    {
        this.command = command;
    }

    public void Invoke(T1 value, T2 value2, T3 value3)
    {
        command.Invoke(value, value2, value3);
    }
}