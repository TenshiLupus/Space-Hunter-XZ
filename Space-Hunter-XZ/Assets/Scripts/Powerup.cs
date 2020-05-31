using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Powerup
{
    [SerializeField]
    public string name;

    [SerializeField]
    public float duration;

    // used to apply the Powerup of the Powerup
    [SerializeField]
    public UnityEvent startAction;

    // used to remove the Powerup of the Powerup
    [SerializeField]
    public UnityEvent endAction;

    public void End()
    {
        if (endAction != null)
            endAction.Invoke();
    }

    public void Start()
    {
        if (startAction != null)
            startAction.Invoke();
    }
    public override bool Equals(System.Object obj)
    {
        if (obj == null)
            return false;
        Powerup p = obj as Powerup;
        if ((System.Object)p == null)
            return false;
        return name == p.name;
    }
    public bool Equals(Powerup p)
    {
        if ((object)p == null)
            return false;
        return name == p.name;
    }


    public override int GetHashCode()
    {
        return name.GetHashCode();
    }
}