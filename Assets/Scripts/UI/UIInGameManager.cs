using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using TMPro;

public class UIInGameManager : Singleton<UIInGameManager>
{
    public TextMeshProUGUI coinsText;

    public static void UpdateCoinsText(string s)
    {
        Instance.coinsText.text = s;
    }
}
