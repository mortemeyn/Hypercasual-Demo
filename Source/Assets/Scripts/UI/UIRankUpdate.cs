using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRankUpdate : MonoBehaviour
{
    [SerializeField] Text rankText;

    private PlayerRank playerRanking;

    void Start()
    {
        playerRanking = FindObjectOfType<PlayerRank>();
    }

    void Update()
    {
        UpdateRankText();
    }

    private void UpdateRankText()
    {
        rankText.text = "RANK: " + playerRanking.GetCurrentRank();
    }
}
