using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : NewMonoBehaviour
{
    [SerializeField] protected UIController uIController;
    [SerializeField] protected PointFailCounterManager pointFailCounterManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIController();
        this.LoadPointFailCounterManager();
    }

    protected virtual void LoadUIController()
    {
        if(this.uIController != null) return;
        this.uIController = FindAnyObjectByType<UIController>();
        Debug.Log(transform.name + ": LoadUIController()", gameObject);
    }

    protected virtual void LoadPointFailCounterManager()
    {
        if(this.pointFailCounterManager != null) return;
        this.pointFailCounterManager = FindAnyObjectByType<PointFailCounterManager>();
        Debug.Log(transform.name + ": LoadPointFailCounterManager()", gameObject);
    }

}
