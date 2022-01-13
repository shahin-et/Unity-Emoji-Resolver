using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine.TextCore;
using TMPro.SpriteAssetUtilities;

public class SpriteAssetGeneratorEditorWindow : EditorWindow {

    private string creationFeedback;
    private TextAsset texturePackerJsonFile;
    private string saveDirectoryName;
    private TextAsset emojiNamesFile;

    [MenuItem("Window/TextMeshPro/Extract Emoji Names")]
    public static void ShowWindow() {
        GetWindow<SpriteAssetGeneratorEditorWindow>("Emoji Names Extractor");
    }

    // Update is called once per frame
    void OnGUI() {
        GUILayout.Label("Import Settings", EditorStyles.boldLabel);

        GUILayout.Space(5);

        EditorGUI.BeginChangeCheck();

        texturePackerJsonFile = EditorGUILayout.ObjectField("Sprite Data Source", texturePackerJsonFile, typeof(TextAsset), false) as TextAsset;

        if (EditorGUI.EndChangeCheck()) {
            creationFeedback = string.Empty;
        }

        GUILayout.Space(10);

        GUI.enabled = texturePackerJsonFile != null;

        if (GUILayout.Button("Create Emoji Names Text Asset")) {
            string emojiNames = "";

            JSONObject frames = new JSONObject(texturePackerJsonFile.text)["frames"];
            for (int i = 0; i < frames.list.Count; i++) {
                if (i == 0) {
                    emojiNames += Path.GetFileNameWithoutExtension(frames.list[i]["filename"].str);
                } else {
                    emojiNames += "+" + Path.GetFileNameWithoutExtension(frames.list[i]["filename"].str);
                }
            }

            emojiNamesFile = new TextAsset(emojiNames);

            saveDirectoryName = new FileInfo(AssetDatabase.GetAssetPath(texturePackerJsonFile)).DirectoryName;

            // Update import results
            creationFeedback = "<b>Creation Results</b>\n--------------------\n";
            creationFeedback += "<color=#C0ffff><b>" + frames.list.Count + "</b></color> Emoji names were extracted from file.";
        }

        if (emojiNamesFile == null)
            return;

        GUI.enabled = true;

        // Creation Feedback
        GUILayout.Space(5);
        GUILayout.BeginVertical(EditorStyles.helpBox, GUILayout.Height(60));
        {
            EditorGUILayout.TextArea(creationFeedback, TMP_UIStyleManager.label);
        }
        GUILayout.EndVertical();

        GUILayout.Space(5);

        GUI.enabled = emojiNamesFile != null;
        if (GUILayout.Button("Save Text Asset")) {
            string filePath = EditorUtility.SaveFilePanel("Save Emoji Names Text Asset File", saveDirectoryName, "emoji_names", "txt");

            if (filePath.Length == 0)
                return;

            SaveLiteJson(filePath);
        }
        GUI.enabled = true;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="filePath"></param>
    void SaveLiteJson(string filePath) {
        string dataPath = Application.dataPath;

        if (filePath.IndexOf(dataPath, System.StringComparison.InvariantCultureIgnoreCase) == -1) {
            Debug.LogError("You're saving the text in a directory outside of this project folder. This is not supported. Please select a directory under \"" + dataPath + "\"");
            return;
        }

        string relativeAssetPath = filePath.Substring(dataPath.Length - 6);
        string dirName = Path.GetDirectoryName(relativeAssetPath);
        string fileName = Path.GetFileNameWithoutExtension(relativeAssetPath);
        string pathNoExt = dirName + "/" + fileName;

        StreamWriter writer = new StreamWriter(pathNoExt + ".txt", true);
        writer.WriteLine(emojiNamesFile.text);
        writer.Close();

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
