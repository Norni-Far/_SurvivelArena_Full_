using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class S_HeroMove : MonoBehaviour
{
    [SerializeField] private Animator HeroAnimator;
    [SerializeField] private GameObject ImageGameObject;
    [SerializeField] private RectTransform HanglePoint;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float VelocityOfHero;

    private float Move_x;
    private float Move_y;
    private bool flip;

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        Move_x = HanglePoint.localPosition.normalized.x;
        Move_y = HanglePoint.localPosition.normalized.y;

        if (Move_x != 0 || Move_y != 0)
        {
            rb.velocity = new Vector2(Move_x * VelocityOfHero, Move_y * VelocityOfHero);
            // HeroAnimator.SetBool("Run", true);
            CheckAnim();
        }
        else
        {
            OffAnim();
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
        //gameObject.GetComponent<SpriteRenderer>().sortingOrder = Convert.ToInt32(Math.Ceiling(gameObject.transform.position.y) * -1);
        //gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.y); // уровень с деревьями (заходить за них)
        HeroAnimator.SetFloat("Hungle_X", Move_x);
        HeroAnimator.SetFloat("Hungle_Y", Move_y);
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
