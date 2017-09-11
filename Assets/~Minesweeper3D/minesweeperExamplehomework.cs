using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minesweeperExamplehomework : MonoBehaviour
{

    public LayerMask block;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BlockDelete();

    }

    void BlockDelete()
    {
        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit, 10000, block))
            {
                hit.transform.gameObject.SetActive(false);
            }
        }
    }
}
