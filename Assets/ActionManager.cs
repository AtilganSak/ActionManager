using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionManager : MonoBehaviour
{
    static ActionManager _instance;
    public static ActionManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<ActionManager>();
                if(_instance == null)
                {
                    _instance = new GameObject("ActionManager").AddComponent<ActionManager>();
                }
            }
            return _instance;
        }
    }

    public bool m_DontDestroy;

    ADictionary<string,Delegate> actions = new ADictionary<string, Delegate>();

    private void OnEnable()
    {
        if(m_DontDestroy)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddListener(string _actionName, Action _action)
    {
        if(_actionName == "" || _action == null)
            throw new NullReferenceException();
        CheckAndAddListener(_actionName, _action);
    }
    public void AddListener<T1>(string _actionName, Action<T1> _action)
    {
        if(_actionName == "" || _action == null)
            throw new NullReferenceException();
        CheckAndAddListener(_actionName, _action);
    }
    public void AddListener<T1,T2>(string _actionName, Action<T1, T2> _action)
    {
        if(_actionName == "" || _action == null)
            throw new NullReferenceException();
        CheckAndAddListener(_actionName, _action);
    }
    public void AddListener<T1, T2, T3>(string _actionName, Action<T1, T2, T3> _action)
    {        
        if (_actionName == "" || _action == null)
            throw new NullReferenceException();

        CheckAndAddListener(_actionName, _action);
    }
    public void AddListener<T1, T2, T3, T4>(string _actionName, Action<T1, T2, T3, T4> _action)
    {
        if(_actionName == "" || _action == null)
            throw new NullReferenceException();

        CheckAndAddListener(_actionName, _action);
    }
    public void AddListener<T1, T2, T3, T4, T5>(string _actionName, Action<T1, T2, T3, T4, T5> _action)
    {
        if(_actionName == "" || _action == null)
            throw new NullReferenceException();

        CheckAndAddListener(_actionName, _action);
    }

    public void RemoveListener(string _actionName, Action _action)
    {
        if(_actionName == "")
            throw new NullReferenceException();

        CheckAndRemoveListener(_actionName, _action);
    }
    public void RemoveListener<T1>(string _actionName, Action<T1> _action)
    {
        if(_actionName == "")
            throw new NullReferenceException();

        CheckAndRemoveListener(_actionName, _action);
    }
    public void RemoveListener<T1, T2>(string _actionName, Action<T1, T2> _action)
    {
        if(_actionName == "")
            throw new NullReferenceException();

        CheckAndRemoveListener(_actionName, _action);
    }
    public void RemoveListener<T1, T2, T3>(string _actionName, Action<T1, T2, T3> _action)
    {
        if(_actionName == "")
            throw new NullReferenceException();

        CheckAndRemoveListener(_actionName, _action);
    }
    public void RemoveListener<T1, T2, T3, T4>(string _actionName, Action<T1, T2, T3, T4> _action)
    {
        if(_actionName == "")
            throw new NullReferenceException();

        CheckAndRemoveListener(_actionName, _action);
    }
    public void RemoveListener<T1, T2, T3, T4, T5>(string _actionName, Action<T1, T2, T3, T4, T5> _action)
    {
        if(_actionName == "")
            throw new NullReferenceException();

        CheckAndRemoveListener(_actionName, _action);
    }

    public void RemoveAction(string _actionName)
    {
        if(_actionName == "")
            throw new NullReferenceException();
        if(actions.ContainsKey(_actionName))
        {
            actions.RemoveKey(_actionName);
        }
        else
        {
#if UNITY_EDITOR
            Debug.LogWarning("Not found " + _actionName + " Action!!.");
#endif
        }
    }

    public void Fire(string _actionName, params object[] _params)
    {
        if (_actionName == "" || _params == null)
            throw new NullReferenceException();

        bool isFound = false;
        foreach (AKeyValuePair<string,Delegate> item in actions)
        {
            if (item.Key == _actionName)
            {
                for (int i = 0; i < item.Values.Count; i++)
                {
                    if(item.Values[i] != null)
                    {
                        if(item.Values[i].Method.GetParameters().Length == _params.Length)
                            item.Values[i].DynamicInvoke(_params);
                        else
                        {
#if UNITY_EDITOR
                            Debug.LogError("The number of parameters sent and the number of parameters of the procedure are not the same. " + "\n" +
                                "Click to details!!" + "\n" +
                                "\n Method Name: " + item.Values[i].Method.Name + "\n " +
                                "Target method parameters count: " + item.Values[i].Method.GetParameters().Length.ToString() + "\n" +
                                "Want to sent parameters count: " + _params.Length.ToString());
#endif
                        }
                    }
                }
                isFound = true;
            }
        }
        try
        {       
            if (!isFound)
            {
#if UNITY_EDITOR
                Debug.LogWarning("Not found " + _actionName + " Action!!.");
#endif
            }
        }
        catch (Exception ee)
        {
#if UNITY_EDITOR
            Debug.LogError(ee.Message + "\n Fire Method \n " + _actionName);
#endif            
        }
    }

    void CheckAndAddListener(string _actionName, Delegate _del)
    {
        if(!actions.ContainsKey(_actionName))
        {
            actions.AddKey(_actionName, _del);
        }
        else
        {
            if(!actions.ContainsValue(_actionName, _del))
                actions.AddValue(_actionName, _del);
            else
            {
#if UNITY_EDITOR
                Debug.LogWarning(_del.Method.Name + " Listener is already exists!!. \n => Action: " + _actionName);
#endif
            }
        }
    }
    void CheckAndRemoveListener(string _actionName, Delegate _del)
    {
        if(actions.ContainsKey(_actionName))
        {
            actions.RemoveValue(_actionName, _del);
        }
    }
}