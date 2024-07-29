using System;
using UnityEngine;

public class Movepirates : MonoBehaviour
{
    public static bool sesacik;
    AudioSource yurumeses;
    Animator animator;
    public static bool murettebatYanýnda;
    public Transform shipTransform;
    public float moveSpeed = 5f; // Hareket hýzý
    public float jumpForce = 4f; // Zýplama kuvveti
    private Rigidbody rb;
    int hareketDurumu = 0; // 0=duruyor, 1= yürüyor, 2=koþuyor
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

            if (Input.GetKey(KeyCode.LeftShift)) // Koþma 
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
            else // Yürüme
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

        if (Input.GetKey(KeyCode.E) && murettebatYanýnda) // El Salla
        {
            animator.Play("el salla");
        }

        if (Input.GetKeyDown(KeyCode.Space) && dusmeSuresi > 1) // Zýplama
        {
            yurumeses.Stop();
            sesacik = false;
            if (hareketDurumu == 2) // koþuyorsa
            {
                animator.SetBool("yuru", false);
                animator.SetBool("kos", true);
                jumpForce = 5;
                animator.Play("kosarken zipla");
            }
            else if (hareketDurumu == 1) // yürüyorsa
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
