using UnityEngine;

public sealed class SoundTestSceneController : MonoBehaviour {

    private SoundManager _manager = null;

    private void Start() {
        _manager = SoundManager.Instance;
    }

    private void OnGUI() {
        
        GUILayout.BeginHorizontal("box");

        GUILayout.BeginVertical("box");
        for (int i = 0; i < _manager.MusicTracks.Length; i++) {
            if(GUILayout.Button(_manager.MusicTracks[i].title)) {
                _manager.PlayMusicCrossFaded(_manager.MusicTracks[i]._musicOption, 5f);
            }
        }
        GUILayout.EndVertical();

        GUILayout.BeginVertical("box");
        for (int i = 0; i < _manager.SoundEffects.Length; i++) {
            if (GUILayout.Button(_manager.SoundEffects[i].title)) {
                _manager.PlaySound(_manager.SoundEffects[i]._soundOption);
            }
        }
        GUILayout.EndVertical();

        GUILayout.EndHorizontal();
    }
}
