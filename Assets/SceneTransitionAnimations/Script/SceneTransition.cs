using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    [Header("�V�[���J�ڃI�u�W�F�N�g")] public SceneTransitionObject[] sceneTransitionObjects;
    [Header("�A�j���[�V�����t�F�[�Y")] public TransitionPhase transitionPhase = TransitionPhase.In;
    [Header("�A�j���[�V�����^�C�v")] public TransitionType transitionType = TransitionType.Bar_Slide;

    // Bar_Slide, Bar_Flip, Tile_Slide
    [HideInInspector] [Header("�т̃A�j���[�V�����Ԋu")] public float sceneTransitionStartInterval;
    [HideInInspector] [Header("�т̃A�j���[�V��������")] public float sceneTransitionSpeed;

    // Tile_Rotate
    [HideInInspector] [Header("")] public float sceneTransitionRadian;

    // Sprite
    [HideInInspector] [Header("�J�ڗp�X�v���C�g")] public Sprite sceneTransitionSprite;
    [HideInInspector] [Header("�X�v���C�g�J���[")] public Color sceneTransitionSpriteColor;
    [HideInInspector] [Header("�X�v���C�g�̍ő�X�P�[��")] public Vector3 sceneTransitionMaxScale;
    [HideInInspector] [Header("�X�v���C�g�̊g�厞��")] public float sceneTransitionSpriteSpeed;

    [Header("�V�[���J�ڂ܂ł̎���")] public float timeUpToSceneTransition;

    private string transitionSceneName;
    private bool sceneTransitionFlag = false;
    private GameObject sceneTransitionImages;
    private float sceneTransitionTime = 0;
    private int lastStartedTransitionObjectIndex = -1;

    public enum TransitionPhase { In, Out }
    public enum TransitionType { 
        Bar_Slide,
        Bar_Flip,    
        Tile_Slide,
        Tile_Flip,
        Tile_Rotate,
        Sprite 
    }

    [Serializable]
    public class SceneTransitionObject
    {
        public GameObject transitionObject;
        public Vector3 targetPoint;
        public int order;
    }

    private void Start()
    {
        DOTween.SetTweensCapacity(200, 200);
        if (transitionPhase == TransitionPhase.Out)
        {
            sceneTransitionFlag = true;
        }

        foreach (Transform child in transform)
        {
            if (child.gameObject.name == "Scene Transition Images")
            {
                sceneTransitionImages = child.gameObject;
            }
        }
        sceneTransitionImages.SetActive(true);
        sceneTransitionTime = 0;
    }

    public void FixedUpdate()
    {
        if (sceneTransitionFlag)
        {
            switch (transitionType) {
                case TransitionType.Bar_Slide:
                    sceneTransitionTime += Time.deltaTime;
                    if (lastStartedTransitionObjectIndex < sceneTransitionObjects.Length - 1) {
                        if (sceneTransitionTime > (lastStartedTransitionObjectIndex + 1) * sceneTransitionStartInterval) {
                            sceneTransitionObjects[lastStartedTransitionObjectIndex + 1].transitionObject.transform.DOLocalMove(sceneTransitionObjects[lastStartedTransitionObjectIndex + 1].targetPoint, sceneTransitionSpeed);
                            lastStartedTransitionObjectIndex++;
                        }
                    }
                    if (timeUpToSceneTransition < sceneTransitionTime) {
                        if (transitionPhase == TransitionPhase.In) {
                            SceneManager.LoadScene(transitionSceneName);
                        }
                        else if (transitionPhase == TransitionPhase.Out) {
                            sceneTransitionImages.SetActive(false);
                            sceneTransitionFlag = false;
                        }
                    }
                    break;

                case TransitionType.Bar_Flip:
                    sceneTransitionTime += Time.deltaTime;
                    if (lastStartedTransitionObjectIndex < sceneTransitionObjects.Length - 1) {
                        if (sceneTransitionTime > (lastStartedTransitionObjectIndex + 1) * sceneTransitionStartInterval) {
                            sceneTransitionObjects[lastStartedTransitionObjectIndex + 1].transitionObject.transform.DOLocalRotate(sceneTransitionObjects[lastStartedTransitionObjectIndex + 1].targetPoint, sceneTransitionSpeed);
                            lastStartedTransitionObjectIndex++;
                        }
                    }
                    if (timeUpToSceneTransition < sceneTransitionTime) {
                        if (transitionPhase == TransitionPhase.In) {
                            SceneManager.LoadScene(transitionSceneName);
                        }
                        else if (transitionPhase == TransitionPhase.Out) {
                            sceneTransitionImages.SetActive(false);
                            sceneTransitionFlag = false;
                        }
                    }
                    break;

                case TransitionType.Sprite:
                    if (sceneTransitionTime == 0) {
                        sceneTransitionObjects[0].transitionObject.transform.DOScale(sceneTransitionMaxScale, sceneTransitionSpriteSpeed);
                        foreach (Transform child in transform) {
                            if (child.gameObject.name == "Square") {
                                child.gameObject.GetComponent<SpriteRenderer>().color = sceneTransitionSpriteColor;
                            }
                        }

                    }
                    sceneTransitionTime += Time.deltaTime;

                    if (timeUpToSceneTransition < sceneTransitionTime) {
                        if (transitionPhase == TransitionPhase.In) {
                            SceneManager.LoadScene(transitionSceneName);
                        }
                        else if (transitionPhase == TransitionPhase.Out) {
                            sceneTransitionImages.SetActive(false);
                            sceneTransitionFlag = false;
                        }
                    }
                    break;

                case TransitionType.Tile_Slide:
                    sceneTransitionTime += Time.deltaTime;
                    if (lastStartedTransitionObjectIndex < sceneTransitionObjects.Length - 1) {
                        if (sceneTransitionTime > (lastStartedTransitionObjectIndex + 1) * sceneTransitionStartInterval) {
                            foreach(SceneTransitionObject sceneTransitionObject in sceneTransitionObjects) {
                                if(sceneTransitionObject.order == lastStartedTransitionObjectIndex + 1) {
                                    sceneTransitionObject.transitionObject.transform.DOLocalMove(sceneTransitionObject.targetPoint, sceneTransitionSpeed);
                                }
                            }
                            lastStartedTransitionObjectIndex++;
                        }
                    }
                    if (timeUpToSceneTransition < sceneTransitionTime) {
                        if (transitionPhase == TransitionPhase.In) {
                            SceneManager.LoadScene(transitionSceneName);
                        }
                        else if (transitionPhase == TransitionPhase.Out) {
                            sceneTransitionImages.SetActive(false);
                            sceneTransitionFlag = false;
                        }
                    }
                    break;

                case TransitionType.Tile_Flip:
                    sceneTransitionTime += Time.deltaTime;
                    if (lastStartedTransitionObjectIndex < sceneTransitionObjects.Length - 1) {
                        if (sceneTransitionTime > (lastStartedTransitionObjectIndex + 1) * sceneTransitionStartInterval) {
                            foreach (SceneTransitionObject sceneTransitionObject in sceneTransitionObjects) {
                                if (sceneTransitionObject.order == lastStartedTransitionObjectIndex + 1) {
                                    sceneTransitionObject.transitionObject.transform.DOLocalRotate(sceneTransitionObject.targetPoint, sceneTransitionSpeed);
                                }
                            }
                            lastStartedTransitionObjectIndex++;
                        }
                    }
                    if (timeUpToSceneTransition < sceneTransitionTime) {
                        if (transitionPhase == TransitionPhase.In) {
                            SceneManager.LoadScene(transitionSceneName);
                        }
                        else if (transitionPhase == TransitionPhase.Out) {
                            sceneTransitionImages.SetActive(false);
                            sceneTransitionFlag = false;
                        }
                    }
                    break;

                case TransitionType.Tile_Rotate:
                    sceneTransitionTime += Time.deltaTime;
                    if (lastStartedTransitionObjectIndex < sceneTransitionObjects.Length - 1) {
                        if (sceneTransitionTime > (lastStartedTransitionObjectIndex + 1) * sceneTransitionStartInterval) {
                            foreach (SceneTransitionObject sceneTransitionObject in sceneTransitionObjects) {
                                if (sceneTransitionObject.order == lastStartedTransitionObjectIndex + 1) {
                                    Sequence sequence = DOTween.Sequence();
                                    sequence.Append(sceneTransitionObject.transitionObject.transform.DOScale(sceneTransitionObject.targetPoint, sceneTransitionSpeed).SetEase(Ease.Linear));
                                    sequence.Join(sceneTransitionObject.transitionObject.transform.DOLocalRotate(new Vector3(0, 0, sceneTransitionRadian), sceneTransitionSpeed, RotateMode.FastBeyond360).SetEase(Ease.Linear));
                                }
                            }
                            lastStartedTransitionObjectIndex++;
                        }
                    }
                    if (timeUpToSceneTransition < sceneTransitionTime) {
                        if (transitionPhase == TransitionPhase.In) {
                            SceneManager.LoadScene(transitionSceneName);
                        }
                        else if (transitionPhase == TransitionPhase.Out) {
                            sceneTransitionImages.SetActive(false);
                            sceneTransitionFlag = false;
                        }
                    }
                    break;
            }
        }
    }

    /// <summary>
    /// �A�j���[�V������Đ������̂��w�肵���V�[���ɑJ��
    /// </summary>
    public void StartSceneTransition(string sceneName)
    {
        transitionSceneName = sceneName;
        sceneTransitionFlag = true;
    }
}
