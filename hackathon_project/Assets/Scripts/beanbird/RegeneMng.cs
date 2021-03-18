using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegeneMng : MonoBehaviour
{
    public GameObject Block;
    Block blockscript;
    Vector3[] tmp = new Vector3[28];
    int i = 0;
    public int flag = 0;
    void Start()
    {
        blockscript = Block.GetComponent<Block>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void AddFlag(){
        flag++;
    }

    public void DecFlag(){
        flag--;
    }

    public void Keeptmp(Vector3 blocktmp){
        tmp[i] = blocktmp;
        Debug.Log(tmp[i]);
        i++;
    }
    public void Regene(){
        Vector3 blockpos = transform.position;
        blockpos = tmp[i-1];
        GameObject block = Instantiate(Block, blockpos, Quaternion.identity);
        i--;
    }
}
