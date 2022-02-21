using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScenario : MonoBehaviour
{
    [SerializeField]
    SpeechBubble sb;
    private void Start()
    {
        if(DataStorage.INSTANCE != null)
        {
            sb.issue = DataStorage.INSTANCE.battleScenario.BattleTopic;
        }
    }
}
