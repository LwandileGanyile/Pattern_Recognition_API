namespace Recognition
{
    public enum StageChange
    {
        CHANGE_MULTIPLE,
        CHANGE_RHYTHM,
        CHANGE_MOVING_STRATEGY,
        CHANGE_SHOOTING_STRATEGY,
        CHANGE_ROTATION_OR_REPEATATION,
        CHANGE_MUSIC,

    }

    public enum MusicChange
    {
        NEXT_MUSIC_CHANGE,
        PREVIOUS_MUSIC_CHANGE,
        RANDOM_MUSIC_CHANGE
    }

    public enum RhythmChange
    {
        NEXT_RHYHTM_CHANGE,
        PREVIOUS_RHYTHM_CHANGE,
        RANDOM_RHYTHM_CHANGE
    }

    public enum MultipleChange
    {
        NEXT_MULTIPLE_CHANGE,
        PREVIOUS_MULTIPLE_CHANGE,
        RANDOM_MULTIPLE_CHANGE
    }

    public enum MovingStrategyChange
    {
        NEXT_MOVING_STRATEGY_CHANGE,
        PREVIOUS_MOVING_STRATEGY_CHANGE,
        RANDOM_MOVING_STRATEGY_CHANGE
    }

    public enum ShootingStrategyChange
    {
        NEXT_SHOOTING_STRATEGY_CHANGE,
        PREVIOUS_SHOOTING_STRATEGY_CHANGE,
        RANDOM_SHOOTING_STRATEGY_CHANGE
    }

}