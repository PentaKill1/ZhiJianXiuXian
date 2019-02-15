using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour {

    protected GameFacade facade;
    public BaseManager() { }
    public BaseManager(GameFacade facade)
    {
        this.facade = facade;
    }
    public virtual void OnInit() { }
    public virtual void Update() { }
    public virtual void OnDestroy() { }
}
