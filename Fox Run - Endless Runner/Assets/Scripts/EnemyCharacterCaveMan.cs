using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterCaveMan : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject menuGO;
    private MainMenu menu;

    [SerializeField] private float upperEnemyOffsetY;
    [SerializeField] private float lowerEnemyOffsetY;

    [SerializeField] private float startAttackSpeed = 3f;
    [SerializeField] private float returnSpeed = 3f;
    [SerializeField] private float deathAttackSpeed = 2f;

    [SerializeField] private float goBackXPoint = -4f;
    [SerializeField] private float backPointXValue = -18f;
    [SerializeField] private bool enemyLessThanReturnVal = true;

    [SerializeField] private Vector3 enemyStartPosition = new Vector3(-18f, -0.66f, 0);

    private Animator enemyAnimator;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        menu = menuGO.GetComponent<MainMenu>();
        transform.position = enemyStartPosition;
    }

    void Update()
    {
        if (menu.gameOnOff == 1)
        {
            if (!menu.restarting)
            {
                if (enemyAnimator.GetBool("isRunning") == false)
                {
                    enemyAnimator.SetBool("isRunning", true);
                }

                // start movement for enemy
                EnemyStartMovementX(goBackXPoint);

                // move to correct y value
                CheckMoveEnemy(player.transform);
            }
            else
            {
                // go to side of screen
                if (transform.position != enemyStartPosition)
                {
                    transform.position = enemyStartPosition;
                }
            }
        }
        else if (menu.gameOnOff == 0)
        {
            if (!menu.restarting)
            {
                // enemy run to player
                if (transform.position.x < player.transform.position.x)
                {
                    transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.right, deathAttackSpeed * Time.deltaTime);
                }
                else
                {
                    if (enemyAnimator.GetBool("isRunning") == true)
                    {
                        enemyAnimator.SetBool("isRunning", false);
                    }
                }
            }
            else
            {
                // enemy go to side of screen
                if (transform.position != enemyStartPosition)
                {
                    transform.position = enemyStartPosition;
                }
                enemyLessThanReturnVal = true;
            }
        }
    }

    private void CheckMoveEnemy(Transform playerPosition)
    {
        if (playerPosition.position.y > 4)
        {
            MoveEnemyY(upperEnemyOffsetY);
        }
        else
        {
            MoveEnemyY(lowerEnemyOffsetY);
        }
    }

    private void MoveEnemyY(float correctOffset)
    {
        Vector3 enemyPosition = transform.position;
        enemyPosition.y = correctOffset;
        transform.position = enemyPosition;
    }

    private void EnemyStartMovementX(float _returnXvalue)
    {
        //increase x pos
        // if enemyLessThanReturnVal
        if (enemyLessThanReturnVal)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.right, startAttackSpeed * Time.deltaTime);
        }
        else//decrease x value till at correct place
        {
            //Debug.Log("why is this not working"); // nevermind
            if (transform.position.x > backPointXValue)
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position - (Vector3.right), returnSpeed * Time.deltaTime);
            }
        }

        //  if x > returnValue
        //  set enemyLessThanReturnVal = false
        if (transform.position.x > _returnXvalue)
        {
            enemyLessThanReturnVal = false;
        }
    }
}
