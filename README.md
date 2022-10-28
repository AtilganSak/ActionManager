# ActionManager
Action Manager is like an event manager. It allows you to create and fire multi-parameter listeners.

# **EXAMPLE**

```
private void OnEnable()
    {
        ActionManager.Instance.AddListener(EventNames.Event1, Event1Method);
        ActionManager.Instance.AddListener<string>(EventNames.Event2, Event2Method);
        ActionManager.Instance.AddListener<int,int>(EventNames.Event3, Event3Method);
    }
    private void OnDisable()
    {
        ActionManager.Instance.RemoveListener(EventNames.Event1, Event1Method);
        ActionManager.Instance.RemoveListener<string>(EventNames.Event2, Event2Method);
        ActionManager.Instance.RemoveListener<int, int>(EventNames.Event3, Event3Method);
    }
    private void Start()
    {
        ActionManager.Instance.Fire(EventNames.Event1);
        ActionManager.Instance.Fire(EventNames.Event2, "Hello C#");
        ActionManager.Instance.Fire(EventNames.Event3, 5, 5);
    }
