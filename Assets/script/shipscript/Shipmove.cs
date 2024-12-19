using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shipmove : MonoBehaviour
{
    public AudioSource yurumesesi;
    public Animator animator;
    public bool isNearSteeringWheel = false;
    private bool isSteering = false;
    Vector3 dümenPos;
    public GameObject player;
    public GameObject ship, shipPivot;
    public GameObject dümenKamera, playerKamera;
    public float tiltAmount = 15f; // Geminin eðilme açýsý
    public float tiltSpeed = 50f; // Geminin eðilme hýzýnýn yumuþaklýðý
    public static Shipmove instance;
    Collider c;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        c = GetComponent<Collider>();
    }
    private void Update()
    {
        if (isNearSteeringWheel && Input.GetKeyDown(KeyCode.E))
        {
            isSteering = !isSteering;
            if (isSteering)
            {
                yurumesesi.Stop();
                Movepirates.sesacik = false;
                animator.Play("dümen tut");
                dümenKamera.SetActive(true);
                playerKamera.SetActive(false);
                dümenPos = new(c.transform.position.x, c.transform.position.y - 1.35f, c.transform.position.z - .45f);
                player.transform.position = dümenPos;
                player.transform.rotation = transform.rotation;
                player.GetComponent<Movepirates>().enabled = false;
                player.GetComponent<mausemovepirates>().enabled = false;
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
            else
            {
                animator.Play("durma");
                playerKamera.SetActive(true);
                dümenKamera.SetActive(false);
                player.GetComponent<Movepirates>().enabled = true;
                player.GetComponent<mausemovepirates>().enabled = true;
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            }
        }

        if (isSteering)
        {
            if (Input.GetKey(KeyCode.D))
            {
                shipPivot.transform.Rotate(Vector3.up, Time.deltaTime * 15);
                TiltShip(-tiltAmount);// Sola eðil
            }
            if (Input.GetKey(KeyCode.A))
            {
                shipPivot.transform.Rotate(Vector3.down, Time.deltaTime * 15);
                TiltShip(tiltAmount); // Saða eðil
            }
            else
            {
                TiltShip(0); // Normal duruþ
            }
        }
    }

    void TiltShip(float targetTilt)
    {
       
            // Mevcut eðim açýsýný al
            Vector3 currentEulerAngles = ship.transform.rotation.eulerAngles;
            float currentTilt = currentEulerAngles.z;

            // Hedef eðim açýsýna yumuþak geçiþ
            float newTilt = Mathf.LerpAngle(currentTilt, targetTilt, Time.deltaTime * tiltSpeed);

            // Yeni rotasyonu ayarla
            ship.transform.rotation = Quaternion.Euler(currentEulerAngles.x, currentEulerAngles.y, newTilt);
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isNearSteeringWheel = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isNearSteeringWheel = false;
        }
    }
}
