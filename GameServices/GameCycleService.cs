using System;

namespace GameServices
{

    class GameCycleService
    {
        public event Action _onDefeat;
        public event Action _onRespawn;
        private GameStance stance = GameStance.InMenu;

        public void TriggerDefeat()
        {
            ValidateEvent(GameStance.PausedAfterDefeat);
            _onDefeat.Invoke();
            stance = GameStance.PausedAfterDefeat;
        }

        public void TriggerRespawn()
        {
            ValidateEvent(GameStance.Playing);
            _onRespawn.Invoke();
            stance = GameStance.Playing;
        }

        private void ValidateEvent(GameStance unexpectedStance)
        {
            if(this.stance == unexpectedStance)
            {
                throw new InvalidOperationException("Event already triggered");
            }
        }

    }

    enum GameStance
    {
        PausedByPlayer,
        Playing,
        PausedAfterDefeat,
        InMenu
    }
}