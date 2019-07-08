namespace Primary_Queen
{
    /* These are all possible patterning tracking a 
    player can choose from.*/
    // A player decides which one of the six ways of tracking to use.
    public enum Primary_Trace_Type
    {
        POINT_TRACE,
        DIRECTION_TRACE,
        KING_TRACE,

        DIRECTION_POINT_TRACE,
        KING_POINT_TRACE,


        KING_DIRECTION_TRACE,

        ALL_TRACE
    }

    /* These are all possible answers a player can choose 
    from if he/she decided to track a king.*/
    public enum Primary_King_Direction
    {
        FACING_FRONT,
        FACING_BACK
    }

    /* These are all possible answers a player can choose 
    from if he/she decided to track a queen's current direction.*/
    public enum Primary_Direction
    {
        LEFT,
        RIGHT

    }
}