using System;
using UnityEngine;

public class Movepirates : MonoBehaviour
{
    public static bool sesacik;
    AudioSource yurumeses;
    Animator animator;
    public static bool murettebatYan�nda;
    public Transform shipTransform;
    public float moveSpeed = 5f; // Hareket h�z�
    public float jumpForce = 4f; // Z�plama kuvveti
    private Rigidbody rb;
    int hareketDurumu = 0; // 0=duruyor, 1= y�r�yor, 2=ko�uyor
    private Vector3 move, newPosition;
    float dusmeSuresi = 2;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        yurumeses= GetComponent<AudioSource>();
    }
    
    void Update()
    {
        // Hareket girdilerini al
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        move = transform.right * moveX + transform.forward * moveZ;
        newPosition = rb.position + move * moveSpeed * Time.deltaTime;
        rb.MovePosition(newPosition);

        if (moveX != 0 || moveZ != 0) // Hareket Ediyorsak
        {
            if (!sesacik)
            {
                yurumeses.Play();
                sesacik = true;
            }

            if (Input.GetKey(KeyCode.LeftShift)) // Ko�ma 
            {
                if (dusmeSuresi > 1)
                {
                    animator.Play("kosma");
                }
                animator.SetBool("yuru", false);
                animator.SetBool("kos", true);
                hareketDurumu = 2;
                moveSpeed = 7;
            }
            else // Y�r�me
            {
                animator.SetBool("yuru", true);
                animator.SetBool("kos", false);
                if (dusmeSuresi > 1)
                {
                    animator.Play("yurume");
                }
                hareketDurumu = 1;
                moveSpeed = 3;
            }
        }
        else // Duruyorsak
        {
            if (hareketDurumu != 0)
            {
                yurumeses.Stop();
                sesacik = false; 
                hareketDurumu = 0;
                animator.SetBool("yuru", false);
                animator.SetBool("kos", false);
                animator.Play("durma");
            }
        }

        if (Input.GetKey(KeyCode.E) && murettebatYan�nda) // El Salla
        {
            animator.Play("el salla");
        }

        if (Input.GetKeyDown(KeyCode.Space) && dusmeSuresi > 1) // Z�plama
        {
            yurumeses.Stop();
            sesacik = false;
            if (hareketDurumu == 2) // ko�uyorsa
            {
                animator.SetBool("yuru", false);
                animator.SetBool("kos", true);
                jumpForce = 5;
                animator.Play("kosarken zipla");
            }
            else if (hareketDurumu == 1) // y�r�yorsa
            {
                animator.SetBool("yuru", true);
                animator.SetBool("kos", false);
                jumpForce = 5;
                animator.Play("yururken zipla");
            }
            else
            {
                animator.SetBool("yuru", false);
                animator.SetBool("kos", false);
                animator.Play("yururken zipla");
            }
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            dusmeSuresi = 0;
        }
        if (dusmeSuresi < 2)
        {
            dusmeSuresi += Time.deltaTime;
        }
    }
}
