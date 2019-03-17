using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public enum State
    {
        InTitle = 0,
        HowToPlay,
        WhatsThis,
        UseAssets,
        CountDown,
        GamePlaying,
        FinishCountDown,
        GameEnd,
        ResultMovie,
        Result,

        itemNum
    }

    public class StateChangedEventArgs : System.EventArgs
    {
        public State newState;

        public StateChangedEventArgs(State _state)
        {
            newState = _state;
        }
    }

    public System.EventHandler<StateChangedEventArgs> stateChanged;

    State stateNow = 0;
    public State StateNow {
        get { return stateNow; }
        set {
            stateNow = value;
            stateChanged?.Invoke(this, new StateChangedEventArgs(stateNow));
        }
    }


}
