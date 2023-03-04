using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingDice : MonoBehaviour
{
    [SerializeField] int numberGot;
    [SerializeField] GameObject rollingDiceAnimation;
    [SerializeField] SpriteRenderer numberedSpHolder;
    [SerializeField] Sprite[] numberedSprites;

    [SerializeField] AudioClip diceRollSound;

    // bool canDiceRoll = true;

    Coroutine generateRanNOnDice_Coroutine;
    public int outPieces;

    private void OnMouseDown()
    {
        AudioSource.PlayClipAtPoint(diceRollSound, transform.position);
        generateRanNOnDice_Coroutine = StartCoroutine(GenerateRandomNOnDice_Enum());
    }
    IEnumerator GenerateRandomNOnDice_Enum()
    {
        yield return new WaitForEndOfFrame();
        if(GameManager.gm.canDiceRoll)
        {
            GameManager.gm.canDiceRoll = false;
            numberedSpHolder.gameObject.SetActive(false);
            rollingDiceAnimation.SetActive(true);
            yield return new WaitForSeconds(1f);
            numberGot = Random.Range(0, 6); //Should be 0 - 6
            numberedSpHolder.sprite = numberedSprites[numberGot];
            numberGot += 1;

            GameManager.gm.numOfStepsToMove = numberGot; 
            GameManager.gm.rolledDice = this;


            numberedSpHolder.gameObject.SetActive(true);
            rollingDiceAnimation.SetActive(false);
            yield return new WaitForEndOfFrame();

            if(GameManager.gm.rolledDice == GameManager.gm.ManageRollingDice[0])
            {
                outPieces = GameManager.gm.blueOutPlayers;
            }
            else if(GameManager.gm.rolledDice == GameManager.gm.ManageRollingDice[1])
            {
                outPieces = GameManager.gm.redOutPlayers;
            }
            else if(GameManager.gm.rolledDice == GameManager.gm.ManageRollingDice[2])
            {
                outPieces = GameManager.gm.greenOutPlayers;
            }
            else if(GameManager.gm.rolledDice == GameManager.gm.ManageRollingDice[3])
            {
                outPieces = GameManager.gm.yellowOutPlayers;
            }

//________________________________________________________________________________________________________

            if(GameManager.gm.numOfStepsToMove != 6 && outPieces==0)
            {
                GameManager.gm.canDiceRoll = true;
                GameManager.gm.SelfDice = false;
                GameManager.gm.trasferDice = true;
                
                yield return new WaitForSeconds(0.5f);
                GameManager.gm.RollingDiceManager();

            }

            // GameManager.gm.RollingDiceManager();

           
            if(generateRanNOnDice_Coroutine != null)
            {
                StopCoroutine(generateRanNOnDice_Coroutine);    
            }
        }
    }


}
