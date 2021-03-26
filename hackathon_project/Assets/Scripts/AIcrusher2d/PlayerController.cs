using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AICrusher
{
        public class PlayerController : MonoBehaviour
    {
        public bool isMine;

        public float speed=5.0f;

        private bool inverseX;
        private bool rotateToggle=false;
        private Rigidbody2D rb;
        private SpriteRenderer sprite;

        // Start is called before the first frame update
        void Start()
        {
            rb=GetComponent<Rigidbody2D>();
            sprite=GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            int horizontalkey=0;
            if(Input.GetKey(KeyCode.A)){
                horizontalkey--;
            }
            if(Input.GetKey(KeyCode.D)){
                horizontalkey++;
            }
            if(horizontalkey<0){
                inverseX=true;
            }else if(horizontalkey>0){
                inverseX=false;
            }
            sprite.flipX=inverseX;
            rb.velocity=new Vector2(horizontalkey*speed,rb.velocity.y);
            rb.freezeRotation=!rotateToggle;
        }
    }
}
