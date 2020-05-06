using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorGUI : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator _animator;

     string m_ClipName;
    AnimatorClipInfo[] m_CurrentClipInfo;

    float m_CurrentClipLength;

    void Start()
    {
        //Get them_Animator, which you attach to the GameObject you intend to animate.
        //_animator = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        //Fetch the current Animation clip information for the base layer
        m_CurrentClipInfo = this._animator.GetCurrentAnimatorClipInfo(0);
        //Access the current length of the clip
        m_CurrentClipLength = m_CurrentClipInfo[0].clip.length;
        //Access the Animation clip name
        m_ClipName = m_CurrentClipInfo[0].clip.name;
 
    }
    void OnGUI()
    {
        //Output the current Animation name and length to the screen
        GUI.Label(new Rect(0, 0, 200, 20), "Clip Name : " + m_ClipName);
        GUI.Label(new Rect(0, 30, 200, 20), "Clip Length : " + m_CurrentClipLength);
    }
}
