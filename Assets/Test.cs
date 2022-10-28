using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
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

    void Event1Method()
    {
        Debug.Log("Worked Event 1 Method");
    }
    void Event2Method(string _message)
    {
        Debug.Log(_message);
    }
    void Event3Method(int _arg1, int _arg2)
    {
        int result = _arg1 + _arg2;
        Debug.Log("Result: " + result);
    }
}
