using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class ColorSetter : MonoBehaviour {

    public static NumOptions selected;

    public static List<Delegate> methods = new List<Delegate>();

    private List<string> options = new List<string>
    {"Random","Cool","Warm","Dark","Light","Fabulous", "Classic Black", "Classic White"};
    public enum NumOptions
    {RANDOM, COOL, WARM, DARK, LIGHT, FABULOUS, CLASSICBLACK, CLASSICWHITE}

    private Dropdown dropdown;

    private void Awake()
    {
        selected = (NumOptions)PlayerPrefsManager.GetTheme();
    }

    void Start () {
        dropdown = GetComponent<Dropdown>();
        dropdown.ClearOptions();
        dropdown.AddOptions(options);

        //Adds listener for value change in dropdown
        dropdown.onValueChanged.AddListener(delegate {
            OnDropdownChanged(dropdown);
        });

    }

    void OnDropdownChanged(Dropdown dropdown)
    {
        selected = (NumOptions)dropdown.value;
    }
}
