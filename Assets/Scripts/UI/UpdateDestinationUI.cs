using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDestinationUI : MonoBehaviour
{
    [SerializeField]
    private ArrivalTime arrivalTime;

    [SerializeField]
    private TextMeshProUGUI destinationTag;

    [SerializeField]
    private Image destinationImage;

    private void Awake()
    {
        arrivalTime.onDestinationUpdated += UpdateUI;
    }

    private void UpdateUI(Station station)
    {
        destinationTag.text = station.Name;
        destinationImage.color = station.Color;
        destinationImage.sprite = station.Symbol;
    }
}
