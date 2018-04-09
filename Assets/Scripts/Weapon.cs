using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float fireRate = 0;
	public float Damage = 10;
	public LayerMask whatToHit;
	
	public Transform BulletTrailPrefab;
	float timeToSpawnEffect = 0;
	public float effectSpawnRate = 10;
    [SerializeField]
    private Animator myAnimation;


    float timeToFire = 0;
	Transform firePoint;

	// Use this for initialization
	void Awake () {
		firePoint = transform.Find("FirePoint");
		if (firePoint == null) {
			Debug.LogError ("No firePoint? WHAT?!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (fireRate == 0) {
			if (Input.GetKey(KeyCode.Space)) {
                myAnimation.SetBool("Shooting", true);
                Shoot();
			}
            else
                myAnimation.SetBool("Shooting", false);
        }
		else {
			if (Input.GetKey(KeyCode.Space) && Time.time > timeToFire) {
                myAnimation.SetBool("Shooting", true);
                timeToFire = Time.time + 1/fireRate;
				Shoot();
			}
            else
                myAnimation.SetBool("Shooting", false);
        }
	}
	
	void Shoot () {
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition-firePointPosition, 100, whatToHit);
		if (Time.time >= timeToSpawnEffect) {
			Effect ();
			timeToSpawnEffect = Time.time + 1/effectSpawnRate;
		}
		Debug.DrawLine (firePointPosition, (mousePosition-firePointPosition)*100, Color.cyan);
		if (hit.collider != null) {
			Debug.DrawLine (firePointPosition, hit.point, Color.red);
			Debug.Log ("We hit " + hit.collider.name + " and did " + Damage + " damage.");
		}
	}
	
	void Effect () {
        //Vector3 mousePosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, Camera.main.ScreenToWorldPoint(Input.mousePosition).z);
        //Vector3 firePointPosition = new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z);
        //firePoint.rotation.SetFromToRotation(firePointPosition, mousePosition);
		Instantiate (BulletTrailPrefab, firePoint.position, firePoint.rotation);
	}
}
