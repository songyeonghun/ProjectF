using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBtn : MonoBehaviour
{
    TutorialManager tm;
        private void Start()
    {
         tm= GetComponent<TutorialManager>();
    }
   public void NextText()
    {
        tm.TutorialText();
    }
}
