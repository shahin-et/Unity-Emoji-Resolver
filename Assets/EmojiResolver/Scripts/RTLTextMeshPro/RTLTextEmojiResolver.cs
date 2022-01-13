using RTLTMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTLTextEmojiResolver : MonoBehaviour {

    [SerializeField]
    private EmojiResolver emojiResolver;
    private RTLTextMeshPro textComponent;

    // Start is called before the first frame update
    void Start() {
        textComponent = GetComponent<RTLTextMeshPro>();

        emojiResolver.ChangeEmojiUnicodeToTag(textComponent);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
