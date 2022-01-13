using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RTLTMPro;

public class RTLTMP_InputFieldWithEmoji : TMP_InputField {

    private RTLTextMeshPro visibleText;

    protected override void Start() {
        base.Start();

        textComponent.color = new Color(255, 255, 255, 0);
        visibleText = transform.Find("Text Area/VisibleText").GetComponent<RTLTextMeshPro>();
    }

    public RTLTextMeshPro GetVisibleText() {
        return visibleText;
    }
}
