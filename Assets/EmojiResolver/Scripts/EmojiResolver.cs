using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTLTMPro;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;

public class EmojiResolver : MonoBehaviour {

    [SerializeField]
    private TMP_SpriteAsset spriteAsset;

    private bool isChangingRTLInputFieldValue;
    private bool isChangingInputFieldValue;
    
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
    }

    private bool IsLegalUnicode(string str) {
        for (int i = 0; i < str.Length; i++) {
            var uc = char.GetUnicodeCategory(str, i);

            if (uc == UnicodeCategory.Surrogate) {
                // Unpaired surrogate
                return false;
            }

            // Correct high-low surrogate, we must skip the low surrogate
            // (it is correct because otherwise it would have been a 
            // UnicodeCategory.Surrogate)
            if (char.IsHighSurrogate(str, i)) {
                i++;
            }
        }

        return true;
    }

    #region RTLTMP

    public void OnInputFieldValueChanged(RTLTMP_InputFieldWithEmoji inputField, string value) {
        // Emoji has two chars so check it when is unpair
        if (!IsLegalUnicode(value))
            return;

        if (!isChangingRTLInputFieldValue) {
            isChangingRTLInputFieldValue = true;

            ChangeEmojiUnicodeToTag(inputField);

            isChangingRTLInputFieldValue = false;
        }
    }

    // Search for emoji chars and change the to Sprite tags for RTLTextMeshPro
    public void ChangeEmojiUnicodeToTag(RTLTextMeshPro rtlText) {
        string originalTextUnicode = rtlText.OriginalText;

        for (int i = 0; i < originalTextUnicode.Length; i += char.IsSurrogatePair(originalTextUnicode, i) ? 2 : 1) {
            if (char.IsSurrogatePair(originalTextUnicode, i)) {
                int x = char.ConvertToUtf32(originalTextUnicode, i);

                string code = string.Format("{0:X4}", x).ToLower();

                if (code.StartsWith("1f") || code.StartsWith("2") || code.StartsWith("3")) {
                    string spriteTag = "<sprite=\"" + spriteAsset.name + "\" name=\"" + code + "\">";

                    originalTextUnicode = originalTextUnicode.Remove(i, 2).Insert(i, spriteTag);
                }
            }
        }

        rtlText.text = originalTextUnicode;

        string originalTextUnescape = Regex.Unescape(originalTextUnicode);

        rtlText.text = originalTextUnescape;
    }

    // Search for emoji chars and change the to Sprite tags for RTLTMP_InputField
    private void ChangeEmojiUnicodeToTag(RTLTMP_InputFieldWithEmoji inputfieldText) {
        string originalTextUnicode = inputfieldText.text;

        for (int i = 0; i < originalTextUnicode.Length; i += char.IsSurrogatePair(originalTextUnicode, i) ? 2 : 1) {
            if (char.IsSurrogatePair(originalTextUnicode, i)) {
                int x = char.ConvertToUtf32(originalTextUnicode, i);

                string code = string.Format("{0:X4}", x).ToLower();

                if (code.StartsWith("1f") || code.StartsWith("2") || code.StartsWith("3")) {
                    string spriteTag = "<sprite=\"" + spriteAsset.name + "\" name=\"" + code + "\">";

                    originalTextUnicode = originalTextUnicode.Remove(i, 2).Insert(i, spriteTag);
                }
            }
        }

        inputfieldText.GetVisibleText().text = originalTextUnicode;
    }

    #endregion

    #region TMP

    public void OnInputFieldValueChanged(TMP_InputFieldWithEmoji inputField, string value) {
        // Emoji has two chars so check it when is unpair
        if (!IsLegalUnicode(value))
            return;

        if (!isChangingInputFieldValue) {
            isChangingInputFieldValue = true;

            ChangeEmojiUnicodeToTag(inputField);

            isChangingInputFieldValue = false;
        }
    }

    // Search for emoji chars and change the to Sprite tags for TextMeshPro
    public void ChangeEmojiUnicodeToTag(TMP_Text textComponent) {
        string originalTextUnicode = textComponent.text;

        for (int i = 0; i < originalTextUnicode.Length; i += char.IsSurrogatePair(originalTextUnicode, i) ? 2 : 1) {
            if (char.IsSurrogatePair(originalTextUnicode, i)) {
                int x = char.ConvertToUtf32(originalTextUnicode, i);

                string code = string.Format("{0:X4}", x).ToLower();

                if (code.StartsWith("1f") || code.StartsWith("2") || code.StartsWith("3")) {
                    string spriteTag = "<sprite=\"" + spriteAsset.name + "\" name=\"" + code + "\">";

                    originalTextUnicode = originalTextUnicode.Remove(i, 2).Insert(i, spriteTag);
                }
            }
        }

        textComponent.text = originalTextUnicode;

        string originalTextUnescape = Regex.Unescape(originalTextUnicode);

        textComponent.text = originalTextUnescape;
    }

    // Search for emoji chars and change the to Sprite tags for TMP_InputField
    private void ChangeEmojiUnicodeToTag(TMP_InputFieldWithEmoji inputfieldText) {
        string originalTextUnicode = inputfieldText.text;

        for (int i = 0; i < originalTextUnicode.Length; i += char.IsSurrogatePair(originalTextUnicode, i) ? 2 : 1) {
            if (char.IsSurrogatePair(originalTextUnicode, i)) {
                int x = char.ConvertToUtf32(originalTextUnicode, i);

                string code = string.Format("{0:X4}", x).ToLower();

                if (code.StartsWith("1f") || code.StartsWith("2") || code.StartsWith("3")) {
                    string spriteTag = "<sprite=\"" + spriteAsset.name + "\" name=\"" + code + "\">";

                    originalTextUnicode = originalTextUnicode.Remove(i, 2).Insert(i, spriteTag);
                }
            }
        }

        inputfieldText.GetVisibleText().text = originalTextUnicode;
    }

    #endregion
}
