using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StoneOpponent : MonoBehaviour
{
    public route currentRoute;

    int routePosition;

    public int steps;

    private bool isMoving;

    public Text RedText , BlueText;

    void Start()
    {
        routePosition = currentRoute.childNodes.Count - 1; // Start from the last node
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            steps = Random.Range(1, 4);
            Debug.Log("Dice rolled: " + steps);

            if (routePosition - steps >= 0 && !GameManager.Instance.isPlayerTurn)
            {
                StartCoroutine(Move());
                //Debug.Log(GameManager.Instance.isPlayerTurn);
            }
            else
            {
                Debug.Log("Rolled Number is too high");
            }
        }
    }

    IEnumerator Move()
    {
        DiceNumber.diceNumber = steps;
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

        while (steps > 0)
        {
            Vector3 nextPos = currentRoute.childNodes[routePosition - 1].position;
            while (MoveToNextNode(nextPos))
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
            steps--;
            routePosition--;
        }

        isMoving = false;
        GameManager.Instance.EndTurnOpponent();
        BlueText.gameObject.SetActive(false);
        RedText.gameObject.SetActive(true);
    }

    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 2f * Time.deltaTime));
    }
}
