using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 dir;
    [SerializeField] private float speed;
    [SerializeField] private int apple;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private Text appleScore;
    [SerializeField] private Text ballsScore;
    private int bestScore;
    private bool isImmortal;
    private int lineToMove = 1;
    public float lineDistance = 4;
    private AudioSource eatBall;
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("GoodBalls");
        ballsScore.text = bestScore.ToString();
        Time.timeScale = 1;
        controller = GetComponent<CharacterController>();
        isImmortal = false;
        eatBall = GetComponent<AudioSource>();
    }

    private void Update()
    {
        StartCoroutine(BoostTime());

        if (SwipeController.swipeRight)
        {
            if (lineToMove < 2)
            {
                lineToMove++;
            }
        }
        if (SwipeController.swipeLeft)
        {
            if (lineToMove > 0)
            {
                lineToMove--;
            }
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lineToMove == 0)
        {
            targetPosition += Vector3.left * lineDistance;
        }
        else if (lineToMove == 2)
        {
            targetPosition += Vector3.right * lineDistance;
        }
        if (transform.position == targetPosition)
        {
            return;
        }
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
        {
            controller.Move(moveDir);
        }
        else
        {
            controller.Move(diff);
        }

    }
    private void FixedUpdate()
    {
        dir.z = speed;
        controller.Move(dir * Time.fixedDeltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            if (isImmortal == true)
            {
                Destroy(hit.gameObject);
            }
            else
            {
                GameOverPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
        if (hit.gameObject.tag == "BadBalls")
        {
            if (isImmortal == true)
            {
                Destroy(hit.gameObject);
            }
            else
            {
                GameOverPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Apple")
        {
            apple++;
            appleScore.text = apple.ToString();
            Destroy(other.gameObject);
            eatBall.Play();
        }
        if (other.gameObject.tag == "GoodBalls")
        {
            bestScore++;
            PlayerPrefs.SetInt("GoodBalls", bestScore);
            ballsScore.text = bestScore.ToString();
            Destroy(other.gameObject);
            eatBall.Play();
        }
    }
    private IEnumerator BoostTime()
    {
        if (apple == 3)
        {
            isImmortal = true;
            speed *= 3;
            apple = 0;
            yield return new WaitForSeconds(5);
            speed /= 3;
            isImmortal = false;
        }
    }
}
