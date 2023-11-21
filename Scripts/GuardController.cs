using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GuardController : MonoBehaviour
{
    public float speed = 5f; // Hareket hýzý
    public float targetDistance = 10f; // Hedeflenen mesafe

    private Vector2 initialPosition;
    public bool hareketedebilirlik = true;
    private Vector2 direction;
    private Vector2 PlayerPosition;
    private bool movingPositive;
    bool StopVolta = true;
    public int codeNumber;

    public GameObject wantedDialogue;

    void Start()
    {
        initialPosition = transform.position;
        movingPositive = true;

        if (codeNumber == 1)
        { 
            direction = Vector2.up;
        }

        if (codeNumber == 2)
        { 
            direction = Vector2.right;
        }

        if(codeNumber == 3) 
        {
            direction = Vector2.left;
        }

    }

    void Update()
    {
        if (StopVolta)
        {
            MoveGuard();
        }
        else
        {
            FollowGuard();
        }

    }

    void MoveGuard()
    {


        transform.Translate(direction * speed * Time.deltaTime * (movingPositive ? 1 : -1));
        if (Vector2.Distance(initialPosition, transform.position) >= targetDistance)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, 180));
        }
    }
    void FollowGuard()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, PlayerPosition, 1.5f * Time.deltaTime );
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().StopMovement();
            collision.GetComponent<PlayerMovement>().enabled = false;
            StopVolta = false;
            PlayerPosition = collision.transform.position;
            wantedDialogue.SetActive(true);
            StartCoroutine(NextScene());


        }
    }
    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(6.1f);
        SceneManager.LoadScene("SecondGame");
    }


}