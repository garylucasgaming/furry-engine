using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Money : MonoBehaviour
{
    [SerializeField] Player player;
    private void Update()
    {
        GetComponent<TMPro.TMP_Text>().text = $"Money: {player.money}";
    }
}
