using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class S_HeroMove : MonoBehaviour
{
    [SerializeField] private Animator HeroAnimator;
    [SerializeField] private GameObject ImageGameObject;
    public RectTransform HanglePoint;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] public float VelocityOfHero;

    private float Move_x;
    private float Move_y;
    private bool flip;

    private void FixedUpdate()
    {
        Move_x = HanglePoint.localPosition.normalized.x;
        Move_y = HanglePoint.localPosition.normalized.y;

        if (Move_x != 0 || Move_y != 0)
        {
            rb.velocity = new Vector2(Move_x * VelocityOfHero, Move_y * VelocityOfHero);
            // HeroAnimator.SetBool("Run", true);
            if (HeroAnimator) CheckAnim();
        }
        else
        {
            if (HeroAnimator) OffAnim();
            rb.velocity = Vector2.zero;
        }

        if (Move_x < 0)
            flip = true;

        if (Move_x > 0)
            flip = false;

        if (flip)
            ImageGameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        else
            ImageGameObject.transform.eulerAngles = Vector3.zero;

    }

    private void Update()
    {
        // передача данных в аниматор
        if (HeroAnimator) HeroAnimator.SetFloat("Hungle_X", Move_x);
        if (HeroAnimator) HeroAnimator.SetFloat("Hungle_Y", Move_y);
    }


    #region Animation
    private void CheckAnim()
    {
        if ((Move_x < -0.1f && Move_y > 0.4f) || (Move_x > 0.1f && Move_y > 0.4f)) // вверх диагональ
        {
            HeroAnimator.SetBool("RunDiogonal", true);
            HeroAnimator.SetBool("Run", false);
            HeroAnimator.SetBool("RunDown", false);
            HeroAnimator.SetBool("RunUp", false);
            return;
        }

        //if ((Move_x > 0.2f || Move_x < -0.2f) && Move_y > 0) // вверх диагональ
        //{
        //    HeroAnimator.SetBool("RunDiogonal", true);
        //    HeroAnimator.SetBool("Run", false);
        //    HeroAnimator.SetBool("RunDown", false);
        //    HeroAnimator.SetBool("RunUp", false);
        //    return;
        //}

        if (Move_x > -0.1f && Move_x < 0.1f && Move_y < 0) // вниз
        {
            HeroAnimator.SetBool("RunDown", true);
            HeroAnimator.SetBool("Run", false);
            HeroAnimator.SetBool("RunDiogonal", false);
            HeroAnimator.SetBool("RunUp", false);
            return;
        }

        if (Move_x > -0.1f && Move_x < 0.1f && Move_y > 0) // вверх        
        {
            HeroAnimator.SetBool("RunUp", true);
            HeroAnimator.SetBool("RunDown", false);
            HeroAnimator.SetBool("Run", false);
            HeroAnimator.SetBool("RunDiogonal", false);
            return;
        }

        if ((Move_x < -0.1f && Move_y < 0.4f) || (Move_x > 0.1f && Move_y < 0.4f))  // право лево ( + низ диагональ)
        {
            HeroAnimator.SetBool("Run", true);
            HeroAnimator.SetBool("RunDiogonal", false);
            HeroAnimator.SetBool("RunDown", false);
            HeroAnimator.SetBool("RunUp", false);
            return;
        }

    }

    private void OffAnim()
    {
        HeroAnimator.SetBool("RunDown", false);
        HeroAnimator.SetBool("Run", false);
        HeroAnimator.SetBool("RunDiogonal", false);
        HeroAnimator.SetBool("RunUp", false);
    }

    #endregion

}
