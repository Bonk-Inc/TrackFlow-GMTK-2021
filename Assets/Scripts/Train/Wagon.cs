using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagon : MonoBehaviour
{
    [SerializeField]
    private Wagon prevWagon, nextWagon;

    void Start()
    {
        //TODO: uncomment when wagons get generated automatically
        //CoupleWagon();
    }

    private void Update()
    {
        
    }

    [ContextMenu("Couples wagon")]
    private void CoupleWagon()
    {
        if (null != prevWagon)
        {
            transform.position = new Vector3(prevWagon.transform.position.x - 5,
                prevWagon.transform.position.y, prevWagon.transform.position.z);
        }
    }
}