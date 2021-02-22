using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
 
 
  public float speed;
  public TextMeshProUGUI countText;
  public GameObject winTextObject;
  

  private float movementX;
  private float movementY;

  private Rigidbody rb;
  private int count;

  // At the start of the game..
  void Start()
  {

    rb = GetComponent<Rigidbody>();


    count = 0;

    SetCountText();

    winTextObject.SetActive(false);




  }

  void FixedUpdate()
  {
    // Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
    Vector3 movement = new Vector3(movementX, 0.0f, movementY);

    rb.AddForce(movement * speed);
  }

  void OnTriggerEnter(Collider other)
  {
    // ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
    if (other.gameObject.CompareTag("Pickup"))
    {
      other.gameObject.SetActive(false);

      // Add one to the score variable 'count'
      count = count + 1;

      // Run the 'SetCountText()' function (see below)
      SetCountText();
    }
  }

  void OnMove(InputValue value)
  {
    Vector2 v = value.Get<Vector2>();

    movementX = v.x;
    movementY = v.y;
  }

  void SetCountText()
  {
    countText.text = "Count: " + count.ToString();
    if (count >= 12)
    {
      winTextObject.SetActive(true);

    }

  }

}