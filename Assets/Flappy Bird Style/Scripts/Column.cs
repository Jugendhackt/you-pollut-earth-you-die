using UnityEngine;
using System.Collections;

public class Column : MonoBehaviour
{

    [SerializeField]
    Animator anim;
    SpriteRenderer rend;

    public Texture2D[] textures;
    public Texture2DArray textures2;

    private string[] textureNames = new string[] { "Assets/Resources/Erdol.png", "Assets/Resources/Nuclear.png", "Assets/Resources/Battery.png" };

    private void Start()
    {

        rend = GetComponentsInChildren<SpriteRenderer>()[0];

        Texture2D text = textures[Random.Range(0, textures.Length)];

        rend.sprite = Sprite.Create(text, new Rect(0,0,text.width,text.height), new Vector2(0.5f, 0.5f));

    }

    void OnTriggerEnter2D(Collider2D other)
	{

        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("onTouch", true);
            GameControl.instance.PlayerHitEnemy();
            Destroy(this.gameObject);
        }

	}

    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }

}
