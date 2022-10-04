using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateMainMenuPlayer: MonoBehaviour
{
    [SerializeField]
    private GameObject m_rightFlame;
    [SerializeField]
    private GameObject m_leftFlame;
    private float m_flameOriginalSize;
    private float m_originalPlayerSize = 0.8f;

    private Animator m_animator;

    private void Start()
    {
        m_flameOriginalSize = m_rightFlame.transform.localScale.x;
        m_animator = GetComponent<Animator>();
        StartCoroutine(PlayerAnimation());
        InvokeRepeating("JetpackParticleSize", 0f, 0.3f);
    }

    private IEnumerator PlayerAnimation()
    {
        while (true)
        {
            int rnd = Random.Range(0,m_animator.runtimeAnimatorController.animationClips.Length);
            m_animator.SetInteger("AnimationIndex", rnd);
            m_animator.SetTrigger("Animate");
            yield return new WaitForSeconds(m_animator.runtimeAnimatorController.animationClips[rnd].length + 0.5f);
        }
    }
    private void JetpackParticleSize()
    {
        float getScale = (m_flameOriginalSize * transform.localScale.x) / m_originalPlayerSize;
        Vector3 newScale = new Vector3(getScale, getScale, getScale);
        m_rightFlame.transform.localScale = newScale;
        m_leftFlame.transform.localScale = newScale;
    }
}
