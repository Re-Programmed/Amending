using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable

namespace Tutorial
{
    public class StartTutorial : MonoBehaviour
    {
        bool started = false;

        [SerializeField]
        GameObject mainCam;

        [SerializeField]
        GameObject tutorialStart;

        private void Update()
        {
            if (started) { return; }

            if(mainCam.activeInHierarchy)
            {
                tutorialStart.SetActive(true);
                started = true;
            }
        }
    }
}