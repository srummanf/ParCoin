using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public static string deviceUniqueIdentifier;        // This has the system unique ID which will be displayed in console
    public float speed;
    public TextMeshProUGUI countText, winText, goal;
    public AudioClip coinSound;
    private Rigidbody rb;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        print(SystemInfo.deviceUniqueIdentifier);
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement*speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("coin"))
        {
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            other.gameObject.SetActive(false);
            count ++;
            countText.text = "Count - "+ count.ToString();
            if(count>=18)
                winText.gameObject.SetActive(true);
            
        }
        
    }
}
