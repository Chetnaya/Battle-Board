using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingDice : MonoBehaviour
{
    [SerializeField] int numberGot;
    [SerializeField] SpriteRenderer numberedSpHolder;
    [SerializeField] Sprite[] numberedSprites;

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            numberGot = Random.Range(0, 6);
            numberedSpHolder.sprite = numberedSprites[numberGot];
        }
    }


}
