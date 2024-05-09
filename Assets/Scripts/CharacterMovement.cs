using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
	private Rigidbody2D body;
	[SerializeField] private float speed;
	private Animator anim;
	private bool grounded;
	private int score;

	private void Awake() {
		body = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	private void Update() {
		//Horizonal movement input
		float hInput = Input.GetAxis("Horizontal");

		//Movement and sprite flipping
		body.velocity = new Vector2(hInput * speed, body.velocity.y);
		if(hInput > 0)
			transform.localScale = new Vector3(-80, 80, 80);
		else if (hInput < 0)
			transform.localScale = new Vector3(80, 80, 80);
		
		//Jumping + safegaurds against infinite jumps
		if (Input.GetKey(KeyCode.Space) && grounded) {
			body.velocity = new Vector2(body.velocity.x, speed);
			grounded = false;
		}

		anim.SetBool("Run", (hInput > 0.9 || hInput < -0.9));
	}

	private void OnCollisionEnter2D(Collision2D collision) {
	
		if (collision.gameObject.tag == "Ground")
			grounded = true;
			transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
		if (collision.gameObject.tag == "Orb") {
			score += 100;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);		
		}
	}
}
