﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    public class Card : ScriptableObject
    {
        public string Title;
        [TextArea(2, 4)]
        public string Desc;

        public DialogueSequence dialogue;

        public DialogueSequence retaliation;

        public StageType boostedStage;
        public int boostedPower;
    }
}
