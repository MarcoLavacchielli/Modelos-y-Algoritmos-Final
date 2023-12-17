using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.WSA;

public class LocalizationManager : MonoBehaviour
{
    
    public static LocalizationManager Instance { get; private set; }

    [SerializeField] private string defaultLanguageFolder;

    [SerializeField] private string localizationFolders;

    [SerializeField] private string localizationFile;

    public event Action OnLocalizationChanged;

    //[SerializeField] private Languages[] langs;

    private readonly Dictionary<string, LocalizationTable> localizationTables = new();
    private LocalizationTable currentLocalizationTable;
    private string currentLocalizationFolder;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log($"Can only have one {nameof(LocalizationManager)}.");
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);

        SetLanguageAs(defaultLanguageFolder);
    }

    public void SetLanguageAs(string languageFolder)
    {

        if(currentLocalizationFolder == languageFolder)
        {
            return;
        }
        if(!localizationTables.TryGetValue(languageFolder, out LocalizationTable table))
        {
            table = new(localizationFolders, localizationFile, languageFolder);
            localizationTables.Add(languageFolder, table);
        }

        currentLocalizationFolder = languageFolder;
        currentLocalizationTable = table;

        OnLocalizationChanged?.Invoke();

    }

    public string TranslateText(string key) => currentLocalizationTable.TranslateText(key);

    public T Translate<T>(string key)
    {
        throw new NotImplementedException();
    }

    /*[Serializable]
    private struct Languages
    {

        [SerializeField]
        public string name;

        [SerializeField]
        public Translations[] trans;
    }

    [Serializable]
    private struct Translations
    {
        [SerializeField] private string key;

        [SerializeField] private string value;
    }*/

    private class LocalizationTable
    {

        private readonly string folder;

        private readonly Dictionary<string, string> textTable = new();

        public LocalizationTable(string localizationFolders, string localizationFile, string languageFolder)
        {
            folder = languageFolder;

            TextAsset asset = Resources.Load<TextAsset>($"{localizationFolders}{languageFolder}/{localizationFile}");

            //
            string[] lines = asset.text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // 1 porque van los titulos y salteamos eso
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(';');
                //Debug.Log($"Key {parts[0]} value {parts[1]}"); // printea
                textTable.Add(parts[0], parts[1]); // Mucho muy importante no borrar, porque sin esto no funca esto
            }
        }

        public string TranslateText(string key)
        {
            if(textTable.TryGetValue(key, out string value))
            {
                return value;
            }
            else
            {
                Debug.LogError($"Key {key} not found in language at folder {folder}.");
                return key;
            }
        }
    }

    public void ChangeToSp()
    {
        SetLanguageAs("ES_LA");
    }

    public void ChangeToEn()
    {
        SetLanguageAs("EN_US");
    }

}
