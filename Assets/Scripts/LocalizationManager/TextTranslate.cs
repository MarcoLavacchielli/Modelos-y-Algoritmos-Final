using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextTranslate : MonoBehaviour
{
    [SerializeField] private string key;

    private TextMeshProUGUI component;

    private void Awake()
    {
        component = GetComponent<TextMeshProUGUI>();

        OnLocalizationChanged();

        LocalizationManager.Instance.OnLocalizationChanged += OnLocalizationChanged;
    }

    private void OnDestroy()
    {
        LocalizationManager.Instance.OnLocalizationChanged -= OnLocalizationChanged;
    }

    private void OnLocalizationChanged()
    {
        component.text = LocalizationManager.Instance.TranslateText(key);
    }
}
