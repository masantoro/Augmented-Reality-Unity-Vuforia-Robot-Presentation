using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarComponente : MonoBehaviour {
    bool gatilho;
    bool pulando;
    public Animator animatorController;

    void Awake()
    {
        if (!animatorController)
            animatorController = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.P))
        {
            pulando = !pulando;
            animatorController.SetBool("Iniciar", pulando);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            gatilho = !gatilho;
            animatorController.SetBool("Gatilho", gatilho);
        }
	}



}
