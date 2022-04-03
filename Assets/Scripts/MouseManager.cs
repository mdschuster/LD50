using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseManager : MonoBehaviour
{
    public GameObject innerGizmo;
    public GameObject outerGizmo;

    [Header("Mouse Weapons")]
    public GameObject rest;
    public GameObject[] lightningPrefabs;
    public float lightningCooldown;
    public Slider lightningCooldownSlider;
    private float lTime;
    private float lNormalizedTime;
    private bool lOnCooldown;

    public GameObject meteor;
    public float meteorCooldown;
    public Slider meteorCooldownSlider;
    private float mTime;
    private float mNormalizedTime;
    private bool mOnCooldown;

    private float tol;


    // Start is called before the first frame update
    void Start()
    {
        tol = 0.02f;
        lTime = lightningCooldown;
        lNormalizedTime = lTime / lightningCooldown;
        lOnCooldown = true;

        mTime = meteorCooldown;
        mNormalizedTime = mTime / meteorCooldown;
        mOnCooldown = true;

    }

    // Update is called once per frame
    void Update()
    {

        checkLightning();
        checkMeteor();


    }

    private void checkLightning() {
        if (lOnCooldown) {
            lNormalizedTime = lTime / lightningCooldown;
            lOnCooldown=doCooldown(lightningCooldownSlider, lNormalizedTime);
        }
        lTime -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && lTime <= 0f) {

            Vector2 mousePos = GameManager.Instance().mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 vec = Utility.getNormVectorFromCenter(mousePos) * WorldManager.Instance().radius;
            int randomIndex=Random.Range(0,lightningPrefabs.Length);
            GameObject go = Instantiate(lightningPrefabs[randomIndex], vec, Utility.getQuaternionAlignment(vec));

            lTime = lightningCooldown;
            lightningCooldownSlider.gameObject.SetActive(true);
            lOnCooldown = true;
        }
    }

    private void checkMeteor() {
        if (mOnCooldown) {
            mNormalizedTime = mTime / meteorCooldown;
            mOnCooldown=doCooldown(meteorCooldownSlider, mNormalizedTime);
        }
        mTime -= Time.deltaTime;
        if (Input.GetMouseButtonDown(1) && mTime <= 0f) {

            Vector2 mousePos = GameManager.Instance().mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 vec = Utility.getNormVectorFromCenter(mousePos) * WorldManager.Instance().radius;
            GameObject go = Instantiate(meteor, vec, Utility.getQuaternionAlignment(vec));

            mTime = meteorCooldown;
            meteorCooldownSlider.gameObject.SetActive(true);
            mOnCooldown = true;
        }
    }

    private bool doCooldown(Slider slider, float time) {
        slider.value = time;
        bool onCooldown = true;
        if (Mathf.Abs(slider.value - tol) < 0.02f) {
            onCooldown = false;
            slider.gameObject.SetActive(false);
        }
        return onCooldown;
    }
}
