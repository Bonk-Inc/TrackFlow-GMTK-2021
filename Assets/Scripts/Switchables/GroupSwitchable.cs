using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupSwitchable : Switchable
{
    [SerializeField]
    private SwitchWaypoint[] switches;

    public override void Switch()
    {
        foreach (SwitchWaypoint currentSwitch in switches)
        {
            currentSwitch.SwitchRoute();
        }
    }
}
