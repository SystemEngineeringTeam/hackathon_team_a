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

        // private bool onFloor=false;
        private Rigidbody2D rb;
        // public SpriteRenderer sprite;

        // Start is called before the first frame update
        void Start()
        {
            rb=GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            int horizontalkey=0;
            int verticalkey=0;
            
            if(Input.GetKey(KeyCode.A)){
                horizontalkey--;
            }
            if(Input.GetKey(KeyCode.D)){
                horizontalkey++;
            }
            if(Input.GetKey(KeyCode.W)){
                verticalkey++;
            }
            if(Input.GetKey(KeyCode.S)){
                verticalkey--;
            }
            if(horizontalkey<0){
                inverseX=true;
            }else if(horizontalkey>0){
                inverseX=false;
            }
            // sprite.flipX=inverseX;
            // transform.rotation
            rb.velocity=new Vector2(horizontalkey*speed,rb.velocity.y);

            if(rb.velocity.y<speed&&verticalkey>0){
                rb.velocity+=new Vector2(0,Time.deltaTime*30*speed);
            }
            rb.freezeRotation=!rotateToggle;
        }
    }
}
