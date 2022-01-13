using UnityEngine;
using TMPro;

public class TMP_InputFieldWithEmoji : TMP_InputField {

    private TMP_Text visibleText;

    protected override void Start() {
        base.Start();

        textComponent.color = new Color(255, 255, 255, 0);
        visibleText = transform.Find("Text Area/VisibleText").GetComponent<TMP_Text>();
    }

    public TMP_Text GetVisibleText() {
        return visibleText;
    }
}
