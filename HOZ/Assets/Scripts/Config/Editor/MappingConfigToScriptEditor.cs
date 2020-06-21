using UnityEditor;
using UnityEngine;

namespace Config.Editor
{
    public class MappingConfigToScriptEditor : EditorWindow
    {
        private string nameFileConfig;
        private string nameClassConfig;
        private MappingConfigToScript script;
    
        [MenuItem("HOZ Tools/GameConfig/Mapping Scripts")]
        private static void MappingConfigMenu()
        {
            var menuEditor = GetWindow<MappingConfigToScriptEditor>("Mapping Config");
            menuEditor.position = new Rect(500, 500, 500, 500);
        }

        private void OnEnable()
        {
            script = Resources.Load("ScriptObject/MappingGameConfig") as MappingConfigToScript;
        }

        private void OnGUI()
        {
            var guiLabel = GUILayout.Width(100);
            var guiButton = GUILayout.Width(130);
        
            EditorGUILayout.HelpBox("This is box config file", MessageType.Info);
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            {
                EditorGUILayout.BeginHorizontal("box");
                GUILayout.Label("File Config", guiLabel);
                nameFileConfig = EditorGUILayout.TextField(nameFileConfig);
                EditorGUILayout.EndHorizontal();
            }

            {
                EditorGUILayout.BeginHorizontal("box");
                GUILayout.Label("Class Config", guiLabel);
                nameClassConfig = EditorGUILayout.TextField(nameClassConfig);
                EditorGUILayout.EndHorizontal();
            }

            if (GUILayout.Button("Add/Update") && nameClassConfig != "" && nameFileConfig != "")
            {
                script.AddFileConfig(nameFileConfig);
                script.dataClass[script.dataClass.Count - 1] = (nameClassConfig);
                nameClassConfig = string.Empty;
                nameFileConfig = string.Empty;
            }

            EditorGUILayout.EndVertical();
        
            EditorGUILayout.BeginVertical();
            if (script.fileConfigs.Count > 0)
            {
                var width35 = GUILayout.Width(55);
                var width50 = GUILayout.Width(50);
                var width100 = GUILayout.Width(150);
            
                for (int i = 0; i < script.fileConfigs.Count; i++)
                {
                    EditorGUILayout.BeginHorizontal("box");
                    {
                        EditorGUILayout.BeginVertical();
                    
                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.LabelField("File:" ,width50);
                        EditorGUILayout.LabelField(script.fileConfigs[i], width100);
                        EditorGUILayout.EndHorizontal();
                
                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.LabelField("Class:" ,width50);
                        EditorGUILayout.LabelField(script.dataClass[i], width100);
                        EditorGUILayout.EndHorizontal();
                
                        EditorGUILayout.EndVertical();
                    }

                    {
                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.BeginVertical();
                        EditorGUILayout.LabelField("Editor", width35);
                        script.configModes[i].initWithEditor = EditorGUILayout.Toggle(script.configModes[i].initWithEditor);
                        EditorGUILayout.EndVertical();
                        EditorGUILayout.EndHorizontal();
                
                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.BeginVertical();
                        EditorGUILayout.LabelField("Device", width35);
                        script.configModes[i].initWithDevice = EditorGUILayout.Toggle(script.configModes[i].initWithDevice);
                        EditorGUILayout.EndVertical();
                        EditorGUILayout.EndHorizontal();
                
                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.BeginVertical();
                        EditorGUILayout.LabelField("Firebase", width35);
                        script.configModes[i].allowDownload = EditorGUILayout.Toggle(script.configModes[i].allowDownload);
                        EditorGUILayout.EndVertical();
                        EditorGUILayout.EndHorizontal();
                    }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.Space(5);
                }
            }
            EditorGUILayout.EndVertical();
        }
    }
}