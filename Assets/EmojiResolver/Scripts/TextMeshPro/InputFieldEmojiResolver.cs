using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFieldEmojiResolver : MonoBehaviour {

    [SerializeField] 
    private EmojiResolver emojiResolver;
    private TMP_InputFieldWithEmoji inputfieldComponent;

    // Start is called before the first frame update
    void Start() {
        inputfieldComponent = GetComponent<TMP_InputFieldWithEmoji>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OnInputFieldValueChanged(string value) {
        emojiResolver.OnInputFieldValueChanged(inputfieldComponent, value);
    }
}
