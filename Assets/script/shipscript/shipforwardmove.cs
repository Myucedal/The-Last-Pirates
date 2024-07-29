using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shipforwardmove : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject player;
    public float speed = 5000; // Geminin h�z�
    public bool yelkenlerFora = false, CapaAtili = true; // Yelkenler A��k m�?
    public GameObject yelkenler1, yelkenler2, capa, zincirlerCapasiz;
    int yelkenSayisi = 0;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) // �apa atma-kald�rma kodu
        {
            if (CapaAtili)
            {
                CapaKaldir();
            }
            else
            {
                CapaAt();
            }
        }
        if (Input.GetKeyDown(KeyCode.V)) // yelken a�ma-kapatma kodu
        {
            switch (yelkenSayisi)
            {
                case 0:
                    yelkenlerFora = true;
                    speed = 5000;
                    yelkenler1.SetActive(true);
                    yelkenSayisi++;
                    break;
                case 1:
                    speed = 25000;
                    yelkenler2.SetActive(true);
                    yelkenSayisi++;
                    break;
                case 2:
                    yelkenlerFora = false;
                    yelkenler1.SetActive(false);
                    yelkenler2.SetActive(false);
                    yelkenSayisi = 0;
                    break;
            }
        }
    }
    private void FixedUpdate()
    {
        if (yelkenlerFora)
        {
            MoveForward();
        }
    }
    void MoveForward()
    {
        rb.AddForce(transform.forward * speed);
    }
    public void CapaAt()
    {
        CapaAtili = true;
        capa.SetActive(false);
        rb.drag = 150;
        capa.SetActive(false);
        zincirlerCapasiz.SetActive(true);
    }
    public void CapaKaldir()
    {
        CapaAtili = false;
        capa.SetActive(true);
        rb.drag = 3;
        capa.SetActive(true);
        zincirlerCapasiz.SetActive(false);
    }
}