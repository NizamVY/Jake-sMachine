using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeteorFalling : MonoBehaviour
{

    public GameObject target;
    public float speed = 5.0f;
    public GameObject cam;
    public SpriteRenderer spRenderer;
    public Sprite newSprite;
    public float duration = 0.5f;
    public Animator animator;
    public GameObject player;
    public GameObject dialogueTouch;

    public GameObject makine;

    public int codeNumber;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        spRenderer=gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        float distance = Vector2.Distance(transform.position,target.transform.position);

        if (distance<=0.15f)
        {
            animator.enabled = false;
            spRenderer.sprite = newSprite;
            StartCoroutine(Wait());
            codeNumber = 11;
        }
    }

    IEnumerator Wait()
    {
        Vector3 startPosition = cam.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime <= duration)
        {
            elapsedTime += Time.deltaTime;
            cam.transform.position = startPosition + Random.insideUnitSphere * 0.25f;

            yield return null;
        }
        makine.SetActive(true);
        cam.transform.position = startPosition;
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    { 
        yield return new WaitForSeconds(2f);
        dialogueTouch.SetActive(true);
        codeNumber = 12;
        Destroy(gameObject);
    }
}
