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
    [SerializeField] private GameObject _keyCard;

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
            if (CheckCombination())
            {
                _keyCard.gameObject.SetActive(true);
            }
            Reset();
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

    private bool CheckCombination()
    {
        for (int i = 0; i < CorrectCombination.Length; i++)
        {
            if (_enteredCombination[i] != CorrectCombination[i])
            {
                return false;
            }
        }
        return true;
    }

    private void Reset()
    {
        for (int i = 0; i < _enteredCombination.Length; i++)
        {
            _enteredCombination[i] = 0;
        }

        _totalKeyPress = 0;
    }
}
