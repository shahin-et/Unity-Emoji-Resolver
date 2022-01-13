using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTLInputFieldEmojiResolver : MonoBehaviour {

    [SerializeField] 
    private EmojiResolver emojiResolver;
    private RTLTMP_InputFieldWithEmoji inputfieldComponent;

    // Start is called before the first frame update
    void Start() {
        inputfieldComponent = GetComponent<RTLTMP_InputFieldWithEmoji>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OnInputFieldValueChanged(string value) {
        emojiResolver.OnInputFieldValueChanged(inputfieldComponent, value);
    }
}
