using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
    
    public Music _sceneMusic;
    public bool _crossFade = false;

    private void Start() {
        if(_crossFade) {
            SoundManager.Instance.PlayMusicCrossFaded(_sceneMusic, 1f);
        } else {
            SoundManager.Instance.PlayMusic(_sceneMusic);
        }
    }
}
