using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    
    public static LocalizationManager Instance { get; private set; }

    [SerializeField] private string defaultLanguage;

    public event Action OnLocalizationChanged;

    [SerializeField] private Langauges[] langs;

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

        SetLanguageAs(defaultLanguage);
    }

    public void SetLanguageAs(string language)
    {

        //...

        OnLocalizationChanged?.Invoke();

    }

    public string TranslateText(string key)
    {
        throw new NotImplementedException();
    }

    public T Translate<T>(string key)
    {
        throw new NotImplementedException();
    }

    [SerializeField]
    private class

}
