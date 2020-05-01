using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{

    public AudioClip clip;
    //[SerializeField]
    private float speed = 1.0f;

    [SerializeField]
    private int foodID;
    [SerializeField]
    private UIController uiController;

    // Start is called before the first frame update
    void Start()
    {
        uiController = GameObject.Find("Canvas").GetComponent<UIController>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position .y < -5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D (Collider2D other) 
    {
        //Debug.Log(other.tag);
        if (other.tag == "squirrel")
        {
            PlayerController squirrel = other.GetComponent<PlayerController>();

            if (squirrel != null)
            {
                 if (foodID == 1)
                 {
                    if (uiController != null)
                    {
                        uiController.DecreaseHealth();
                        //if (PlayerPrefs.GetInt("SFXToggle") == 1)
                        //{
                            AudioSource.PlayClipAtPoint(clip, new Vector3(5, 1, 2));
                        //}
                    }
                  }

                if (foodID == 0)
                {
                    if (uiController != null)
                    {
                        uiController.UpdateAcorn();
                        //if (PlayerPrefs.GetInt("SFXToggle") == 1)
                        //{
                        AudioSource.PlayClipAtPoint(clip, new Vector3(5, 1, 2));
                        //}
                    }
                }
                if (foodID == 2 || foodID == 3)
                {
                    uiController.UpdateAcorn();
                    uiController.IncreaseHealth();
                    //if (PlayerPrefs.GetInt("SFXToggle") == 1)
                        //{
                            AudioSource.PlayClipAtPoint(clip, new Vector3(5, 1, 2));
                        //}
                }
            }
            Destroy(this.gameObject);
        }
    }
}
