using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}
