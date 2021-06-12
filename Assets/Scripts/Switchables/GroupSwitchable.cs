using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupSwitchable : Switchable
{
    [SerializeField]
    private Sprite[] switchableSprites;
    [SerializeField]
    private SwitchWaypoint[] switches;

    private Image image;
    private int current = 0;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public override void Switch()
    {
        SwitchSprite();

        foreach (SwitchWaypoint currentSwitch in switches)
        {
            currentSwitch.SwitchRoute();
        }
    }

    private void SwitchSprite()
    {
        current++;
        current %= switchableSprites.Length;

        image.sprite = switchableSprites[current];
    }
}
