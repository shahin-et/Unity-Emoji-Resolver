# Unity-Emoji-Resolver
It allows you to use emojis with RTLTextMeshPro or TextMeshPro.

## How to use

- First of all you should make a SpriteAsset that have emoji's sprites with name of it's char unicode and put in "Resources/Sprite Assets" path.
Or you can use my SpriteAsset in the "Resources/Sprite Assets" path.
- Drag EmojiResolver prefab from "EmojiResolver/Prefabs" path into your scene.
- Assign spriteAsset variable from step 1 in EmojiResolver GameObject.
- Add TextEmojiResolver or RTLTextEmojiResolver to the Text GameObject. In the Start you can see emojiResolver.ChangeEmojiUnicodeToTag() called.

If you need InputField you can use InputField (TMP) With Emoji or InputField - RTLTMP With Emoji from "EmojiResolver/Prefabs" path.

For more details you can check Sample from EmojiResolver/Scenes/RTLTMPScene

Cheers :)
