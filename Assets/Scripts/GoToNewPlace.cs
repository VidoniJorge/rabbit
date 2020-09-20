using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewPlace : MonoBehaviour
{
    public string newPlaceName = "New Place Name Here";
    public string goToPlaceName;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame  
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(Const.TAG_PLAYER))
        {
            FindObjectOfType<PlayerController>().nextPlaceName = this.goToPlaceName;
            SceneManager.LoadScene(this.newPlaceName);
        }
    }
}
