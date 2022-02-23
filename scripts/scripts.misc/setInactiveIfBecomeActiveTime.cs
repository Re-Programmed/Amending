using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setInactiveIfBecomeActiveTime : MonoBehaviour
{
    [SerializeField]
    GameObject maincam;

    private void Update()
    {
        if(!maincam.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }
}
