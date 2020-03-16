using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneManageControllor 
{
    private ISceneStateBase curState;
    public void SetState(ISceneStateBase state, string sceneName)
    {
        if(curState != null)
        {
            curState.Exit();
        }
        LoadScene(sceneName);
        curState = state;
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
