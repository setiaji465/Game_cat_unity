using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CnControls;

public class playermove : MonoBehaviour
{
    public float kecepatan;
    public float score;
    public Text scoreUI;
    public AudioSource suarapoint;
    Animator anima;
    public Transform rotationCat;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anima = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Move();

    }
    void Move()
    {
        float gerak = CnInputManager.GetAxisRaw("Horizontal");
        rb.velocity = Vector3.right * gerak * kecepatan;
        anima.SetFloat("kecepatan", Mathf.Abs(gerak), 0.1f, Time.deltaTime);
        rotationCat.localEulerAngles = new Vector3(-90, gerak * 90, 0); 
    }
    void Move2()
    {
        float gerak = CnInputManager.GetAxisRaw("Vertical");
        rb.velocity = Vector3.right * gerak * kecepatan;
        anima.SetFloat("kecepatan", Mathf.Abs(gerak), 0.1f, Time.deltaTime);
        rotationCat.localEulerAngles = new Vector3(-90, gerak * 90, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("musuh"))
        {
            Time.timeScale = 0;
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("point"))
        {
            suarapoint.Play();
            collision.gameObject.SetActive(false);
            score += 10;
            scoreUI.text = "Score : " + score.ToString();
            Destroy(collision.collider.gameObject);
        }
    }

}