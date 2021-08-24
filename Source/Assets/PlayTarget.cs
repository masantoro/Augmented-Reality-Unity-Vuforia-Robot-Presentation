using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class PlayTarget : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    public Animator animatorController;
    public Avatar avatarAnimation;
    public GameObject Cylinder;

    void Awake()
    {
        if (!animatorController)
            animatorController = GetComponent<Animator>();
    }

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

        Cylinder = GameObject.Find("Cylinder");

    }

    void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            animatorController.SetBool("Iniciar", false);
            animatorController.Play("Starting");
            //animatorController.Rebind();
        }

        //Cylinder.transform.Rotate(new Vector3(0,Time.deltaTime * 50,0));

        //transform.Rotate(new Vector3(0, Time.deltaTime + 50, 0));

    }


    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {

            if (!animatorController.GetBool("Iniciar"))
            {
                animatorController.transform.localPosition = new Vector3(-0.459f, 0.357f, -0.661f);
                animatorController.SetBool("Iniciar", true);
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            // Stop audio when target is lost
            //animatorController.SetBool("Iniciar", false);
        }
    }
}