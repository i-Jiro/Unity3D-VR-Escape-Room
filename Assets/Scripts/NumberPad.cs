using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberPad : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _combinationText;
    [SerializeField] private List<TouchButton> _keyPadButtons;
    public int[] CorrectCombination;
    [SerializeField] private int[] _enteredCombination;
    private int _totalKeyPress;

    private void Awake()
    {
        _enteredCombination = new int[CorrectCombination.Length];
        Debug.Log(_enteredCombination.Length);
        foreach (TouchButton button in _keyPadButtons)
        {
            button.OnButtonPress += AddDigit;
        }
    }
    
    private void AddDigit(int digit)
    {
        _enteredCombination[_totalKeyPress] = digit;
        _totalKeyPress++;
        if (_enteredCombination.Length <= _totalKeyPress)
        {
            _totalKeyPress = 0;
        }
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        string combination = "";
        foreach (var digit in _enteredCombination)
        {
            combination += digit.ToString() + " ";
        }
        _combinationText.SetText(combination);
    }
}
