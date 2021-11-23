using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngerBar : MonoBehaviour
{
    private float status = 0;
    public float Status {get {return (status);} private set {status = value;}}
    private bool isRaging = false;
    public bool IsRaging {get {return (isRaging);} private set {isRaging = value;}}
    public float decreaseSpeed = 1;
    private Slider slider;
    private List<Action> calmEventActions = new List<Action>();
    private List<Action> angryEventActions = new List<Action>();
    private List<Action<float>> changeEventActions = new List<Action<float>>();

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRaging == true) {
            ChangeStatusCalm(Time.deltaTime * decreaseSpeed);
        }
        slider.value = status;
    }

    public void ChangeStatus(float _value, bool _calming) {
        if (_calming) {
            status -= _value;
            if (status <= 0) {
                status = 0;
                isRaging = false;
                ExecuteActions(calmEventActions);
            }
        } else {
            status += _value;
            if (status >= 100) {
                status = 100;
                isRaging = true;
                ExecuteActions(angryEventActions);
            }
        }
        ExecuteActionsFloat(changeEventActions);
    }
    
    public void ChangeStatusCalm(float _value) {
        ChangeStatus(_value, true);
    }
    public void ChangeStatusAngry(float _value) {
        ChangeStatus(_value, false);
    }
    private void ExecuteActions(List<Action> actions) {
        foreach (Action action in actions) {
            action();
        }
    }
    private void ExecuteActionsFloat(List<Action<float>> actions) {
        foreach (Action<float> action in actions) {
            action(status / 100);
        }
    }
    public void AddCalmEvent(Action _action) {
        calmEventActions.Add(_action);
    }
    public void AddAngryEvent(Action _action) {
        angryEventActions.Add(_action);
    }
    public void AddChangeEvent(Action<float> _action) {
        changeEventActions.Add(_action);
    }
}