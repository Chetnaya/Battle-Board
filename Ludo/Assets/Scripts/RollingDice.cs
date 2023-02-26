using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingDice : MonoBehaviour
{
    [SerializeField] int numberGot;
    [SerializeField] GameObject rollingDiceAnimation;
    [SerializeField] SpriteRenderer numberedSpHolder;
    [SerializeField] Sprite[] numberedSprites;

    bool canDiceRoll = true;

    Coroutine generateRanNOnDice_Coroutine;

    private void OnMouseDown()
    {
        generateRanNOnDice_Coroutine = StartCoroutine(GenerateRandomNOnDice_Enum());
    }
    IEnumerator GenerateRandomNOnDice_Enum()
    {
        yield return new WaitForEndOfFrame();
        if(canDiceRoll)
        {
            canDiceRoll = false;
            numberedSpHolder.gameObject.SetActive(false);
            rollingDiceAnimation.SetActive(true);
            yield return new WaitForSeconds(1f);
            numberGot = Random.Range(0, 6);
            numberedSpHolder.sprite = numberedSprites[numberGot];
            numberGot += 1;

            GameManager.gm.numOfStepsToMove = numberGot; 
            GameManager.gm.rolledDice = this;


            numberedSpHolder.gameObject.SetActive(true);
            rollingDiceAnimation.SetActive(false);
            yield return new WaitForEndOfFrame();

            canDiceRoll = true;
            if(generateRanNOnDice_Coroutine != null)
            {
                StopCoroutine(generateRanNOnDice_Coroutine);    
            }
        }
    }


}
