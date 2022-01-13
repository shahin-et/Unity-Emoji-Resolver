using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextEmojiResolver : MonoBehaviour {

    [SerializeField]
    private EmojiResolver emojiResolver;
    private TMP_Text textComponent;

    // Start is called before the first frame update
    void Start() {
        textComponent = GetComponent<TMP_Text>();

        emojiResolver.ChangeEmojiUnicodeToTag(textComponent);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
