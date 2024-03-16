using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SeasonObject : MonoBehaviour
{
    public abstract void SeasonChanged(Seasons season);

    protected virtual void Start()
    {
        SeasonManager.instance.allObjects.Add(this);
    }
}
