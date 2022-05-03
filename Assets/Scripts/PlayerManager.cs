using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    public Animator animator;
    private AnimatorClipInfo[] animatorClipInfo;
    public bool enemyCollision = false;

    public bool punchCollision = false;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setAnimation(string nombreAnimacion)
    {
        animator.Play(nombreAnimacion);
        if (nombreAnimacion == "Saltar")
        {
            AudioManager.Instance.PlaySound("Jump");
        }
    }

    private string getAnimation()
    {
        animatorClipInfo = animator.GetCurrentAnimatorClipInfo(0);
        string nombreAnimacion = animatorClipInfo[0].clip.name;
        return nombreAnimacion;
    }
  
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            //La primera es que golpeaste al enemigo
            if (getAnimation()=="Golpear")
            {
                punchCollision = true;
                Destroy(collider.gameObject);
                
            }
            //La segunda es que no golpeaste al enemigo
            else
            {
                enemyCollision = true;
                GetComponent<BoxCollider2D>().enabled = false;
                AudioManager.Instance.PlaySound("Die");
            }
            
        }


    }
}
