namespace Secondary_Queen
{
    /* These are all possible patterning tracking a 
    player can choose from.*/
    // A player decides which one of the twenty one ways of tracking to use.
    public enum Secondary_Trace_Type
    {
        /*********************************************Beginning of One Trace****************************************/
        POINT_TRACE, DIRECTION_TRACE, LETTER_TRACE, EASY_LETTER_TRACE, HARD_LETTER_TRACE, KING_TRACE, THREE_VECTORS_TRACE, FOUR_VECTORS_TRACE, FIVE_VECTORS_TRACE,
        TWO_PARABOLAS_PARABOLA_NUMBER_TRACE, FOUR_PARABOLAS_PARABOLA_NUMBER_TRACE, EIGHT_PARABOLAS_PARABOLA_NUMBER_TRACE, TWO_PARABOLAS_PARABOLA_EQUATION_TRACE,
        FOUR_PARABOLAS_PARABOLA_EQUATION_TRACE, EIGHT_PARABOLAS_PARABOLA_EQUATION_TRACE,

        /*********************************************End of One Trace****************************************/

        /*********************************************Beginning of Two Traces****************************************/
        DIRECITON_POINT_TRACE, LETTER_POINT_TRACE, EASY_LETTER_POINT_TRACE, HARD_LETTER_POINT_TRACE, KING_POINT_TRACE, THREE_VECTORS_POINT_TRACE, FOUR_VECTORS_POINT_TRACE,
        FIVE_VECTORS_POINT_TRACE, TWO_PARABOLAS_PARABOLA_NUMBER_POINT_TRACE, FOUR_PARABOLAS_PARABOLA_NUMBER_POINT_TRACE, EIGHT_PARABOLAS_PARABOLA_NUMBER_POINT_TRACE,
        TWO_PARABOLAS_PARABOLA_EQUATION_POINT_TRACE, FOUR_PARABOLAS_PARABOLA_EQUATION_POINT_TRACE, EIGHT_PARABOLAS_PARABOLA_EQUATION_POINT_TRACE,

        LETTER_DIRECTION_TRACE, EASY_LETTER_DIRECTION_TRACE, HARD_LETTER_DIRECTION_TRACE, KING_DIRECTION_TRACE, THREE_VECTORS_DIRECTION_TRACE, FOUR_VECTORS_DIRECTION_TRACE,
        FIVE_VECTORS_DIRECTION_TRACE, TWO_PARABOLAS_PARABOLA_NUMBER_DIRECTION_TRACE, FOUR_PARABOLAS_PARABOLA_NUMBER_DIRECTION_TRACE, EIGHT_PARABOLAS_PARABOLA_NUMBER_DIRECTION_TRACE,
        TWO_PARABOLAS_PARABOLA_EQUATION_DIRECTION_TRACE, FOUR_PARABOLAS_PARABOLA_EQUATION_DIRECTION_TRACE, EIGHT_PARABOLAS_PARABOLA_EQUATION_DIRECTION_TRACE,

        EASY_LETTER_LETTER_TRACE, HARD_LETTER_LETTER_TRACE, KING_LETTER_TRACE, THREE_VECTORS_LETTER_TRACE, FOUR_VECTORS_LETTER_TRACE, FIVE_VECTORS_LETTER_TRACE,
        TWO_PARABOLAS_PARABOLA_NUMBER_LETTER_TRACE, FOUR_PARABOLAS_PARABOLA_NUMBER_LETTER_TRACE, EIGHT_PARABOLAS_PARABOLA_NUMBER_LETTER_TRACE,
        TWO_PARABOLAS_PARABOLA_EQUATION_LETTER_TRACE, FOUR_PARABOLAS_PARABOLA_EQUATION_LETTER_TRACE, EIGHT_PARABOLAS_PARABOLA_EQUATION_LETTER_TRACE,

        HARD_LETTER_EASY_LETTER_TRACE, KING_EASY_LETTER_TRACE, THREE_VECTORS_EASY_LETTER_TRACE, FOUR_VECTORS_EASY_LETTER_TRACE, FIVE_VECTORS_EASY_LETTER_TRACE,
        TWO_PARABOLAS_PARABOLA_NUMBER_EASY_LETTER_TRACE, FOUR_PARABOLAS_PARABOLA_NUMBER_EASY_LETTER_TRACE, EIGHT_PARABOLAS_PARABOLA_NUMBER_EASY_LETTER_TRACE,
        TWO_PARABOLAS_PARABOLA_EQUATION_EASY_LETTER_TRACE, FOUR_PARABOLAS_PARABOLA_EQUATION_EASY_LETTER_TRACE, EIGHT_PARABOLAS_PARABOLA_EQUATION_EASY_LETTER_TRACE,

        KING_HARD_LETTER_TRACE, THREE_VECTORS_HARD_LETTER_TRACE, FOUR_VECTORS_HARD_LETTER_TRACE, FIVE_VECTORS_HARD_LETTER_TRACE, TWO_PARABOLAS_PARABOLA_NUMBER_HARD_LETTER_TRACE,
        FOUR_PARABOLAS_PARABOLA_NUMBER_HARD_LETTER_TRACE, EIGHT_PARABOLAS_PARABOLA_NUMBER_HARD_LETTER_TRACE, TWO_PARABOLAS_PARABOLA_EQUATION_HARD_LETTER_TRACE,
        FOUR_PARABOLAS_PARABOLA_EQUATION_HARD_LETTER_TRACE, EIGHT_PARABOLAS_PARABOLA_EQUATION_HARD_LETTER_TRACE,

        THREE_VECTORS_KING_TRACE, FOUR_VECTORS_KING_TRACE, FIVE_VECTORS_KING_TRACE, TWO_PARABOLAS_PARABOLA_NUMBER_KING_TRACE, FOUR_PARABOLAS_PARABOLA_NUMBER_KING_TRACE,
        EIGHT_PARABOLAS_PARABOLA_NUMBER_KING_TRACE, TWO_PARABOLAS_PARABOLA_EQUATION_KING_TRACE, FOUR_PARABOLAS_PARABOLA_EQUATION_KING_TRACE, EIGHT_PARABOLAS_PARABOLA_EQUATION_KING_TRACE,

        FOUR_VECTORS_THREE_VECTORS_TRACE, FIVE_VECTORS_THREE_VECTORS_TRACE, TWO_PARABOLAS_PARABOLA_NUMBER_THREE_VECTORS_TRACE, FOUR_PARABOLAS_PARABOLA_NUMBER_THREE_VECTORS_TRACE,
        EIGHT_PARABOLAS_PARABOLA_NUMBER_THREE_VECTORS_TRACE, TWO_PARABOLAS_PARABOLA_EQUATION_THREE_VECTORS_TRACE, FOUR_PARABOLAS_PARABOLA_EQUATION_THREE_VECTORS_TRACE,
        EIGHT_PARABOLAS_PARABOLA_EQUATION_THREE_VECTORS_TRACE,

        FIVE_VECTORS_FOUR_VECTORS_TRACE, TWO_PARABOLAS_PARABOLA_NUMBER_FOUR_VECTORS_TRACE, FOUR_PARABOLAS_PARABOLA_NUMBER_FOUR_VECTORS_TRACE, EIGHT_PARABOLAS_PARABOLA_NUMBER_FOUR_VECTORS_TRACE,
        TWO_PARABOLAS_PARABOLA_EQUATION_FOUR_VECTORS_TRACE, FOUR_PARABOLAS_PARABOLA_EQUATION_FOUR_VECTORS_TRACE, EIGHT_PARABOLAS_PARABOLA_EQUATION_FOUR_VECTORS_TRACE,

        TWO_PARABOLAS_PARABOLA_NUMBER_FIVE_VECTORS_TRACE, FOUR_PARABOLAS_PARABOLA_NUMBER_FIVE_VECTORS_TRACE, EIGHT_PARABOLAS_PARABOLA_NUMBER_FIVE_VECTORS_TRACE,
        TWO_PARABOLAS_PARABOLA_EQUATION_FIVE_VECTORS_TRACE, FOUR_PARABOLAS_PARABOLA_EQUATION_FIVE_VECTORS_TRACE, EIGHT_PARABOLAS_PARABOLA_EQUATION_FIVE_VECTORS_TRACE,

        FOUR_PARABOLAS_PARABOLA_NUMBER_TWO_PARABOLAS_PARABOLA_NUMBER_TRACE, EIGHT_PARABOLAS_PARABOLA_NUMBER_TWO_PARABOLAS_PARABOLA_NUMBER_TRACE, TWO_PARABOLAS_PARABOLA_EQUATION_TWO_PARABOLAS_PARABOLA_NUMBER_TRACE,
        FOUR_PARABOLAS_PARABOLA_EQUATION_TWO_PARABOLAS_PARABOLA_NUMBER_TRACE, EIGHT_PARABOLAS_PARABOLA_EQUATION_TWO_PARABOLAS_PARABOLA_NUMBER_TRACE,

        EIGHT_PARABOLAS_PARABOLA_NUMBER_FOUR_PARABOLAS_PARABOLA_NUMBER_TRACE, TWO_PARABOLAS_PARABOLA_EQUATION_FOUR_PARABOLAS_PARABOLA_NUMBER_TRACE,
        FOUR_PARABOLAS_PARABOLA_EQUATION_FOUR_PARABOLAS_PARABOLA_NUMBER_TRACE, EIGHT_PARABOLAS_PARABOLA_EQUATION_FOUR_PARABOLAS_PARABOLA_NUMBER_TRACE,

        TWO_PARABOLAS_PARABOLA_EQUATION_EIGHT_PARABOLAS_PARABOLA_NUMBER_TRACE,
        FOUR_PARABOLAS_PARABOLA_EQUATION_EIGHT_PARABOLAS_PARABOLA_NUMBER_TRACE,
        EIGHT_PARABOLAS_PARABOLA_EQUATION_EIGHT_PARABOLAS_PARABOLA_NUMBER_TRACE,

        FOUR_PARABOLAS_PARABOLA_EQUATION_TWO_PARABOLAS_PARABOLA_EQUATION_TRACE,
        EIGHT_PARABOLAS_PARABOLA_EQUATION_TWO_PARABOLAS_PARABOLA_EQUATION_TRACE,

        EIGHT_PARABOLAS_PARABOLA_EQUATION_FOUR_PARABOLAS_PARABOLA_EQUATION_TRACE,

        /*********************************************End of Two Traces****************************************/

        ALL_TRACE
    }

    // Used if a player is tracking a king.
    // A player picks one of the four directions a king can face.
    public enum Secondary_King_Direction
    {
        FACING_FRONT,
        FACING_BACK,
        FACING_LEFT,
        FACING_RIGHT
    }

    // Used if a player is tracking a queen's current direction.
    // A player picks one of the eight directions as a queen's current direction as an answer.
    public enum Secondary_Direction
    {
        Direction_One,
        Direction_Two,
        Direction_Three,
        Direction_Four,
        Direction_Five,
        Direction_Six,
        Direction_Seven,
        Direction_Eight
    }

    /* Used if a player is tracking a queen's moving strategy 
    that uses letters.*/
    // Used if a player is tracking a queen's current letter.
    // A player picks one of the 68 letters with their directions as answer.
    public enum Secondary_Easy_Letter
    {
        Letter_C1, Letter_C2, Letter_C3, Letter_C4, Letter_C5, Letter_C6, Letter_C7, Letter_C8,

        Letter_L1, Letter_L2, Letter_L3, Letter_L4, Letter_L5, Letter_L6, Letter_L7, Letter_L8,

        Letter_M1, Letter_M2, Letter_M3, Letter_M4, Letter_M5, Letter_M6, Letter_M7, Letter_M8,

        Letter_N1, Letter_N2, Letter_N3, Letter_N4, Letter_N5, Letter_N6, Letter_N7, Letter_N8,

        Letter_O1, Letter_O2, Letter_O3, Letter_O4, Letter_O5, Letter_O6, Letter_O7, Letter_O8,

        Letter_R1, Letter_R2, Letter_R3, Letter_R4, Letter_R5, Letter_R6, Letter_R7, Letter_R8,

        Letter_S1, Letter_S2, Letter_S3, Letter_S4, Letter_S5, Letter_S6, Letter_S7, Letter_S8,

        Letter_W1, Letter_W2, Letter_W3, Letter_W4, Letter_W5, Letter_W6, Letter_W7, Letter_W8,
    }

    /* Used if a player is tracking a queen's moving strategy 
    that uses letters.*/
    // Used if a player is tracking a queen's current letter.
    /* A player picks a letter with it direction and a property 
    that determines whether it's a first letter or second letter.*/
    // There are 136 possible answers a player can choose from.
    public enum Secondary_Hard_Letter
    {
        Letter_First_C1, Letter_First_C2, Letter_First_C3, Letter_First_C4, Letter_First_C5, Letter_First_C6, Letter_First_C7, Letter_First_C8,
        Letter_Second_C1, Letter_Second_C2, Letter_Second_C3, Letter_Second_C4, Letter_Second_C5, Letter_Second_C6, Letter_Second_C7, Letter_Second_C8,

        Letter_First_L1, Letter_First_L2, Letter_First_L3, Letter_First_L4, Letter_First_L5, Letter_First_L6, Letter_First_L7, Letter_First_L8,
        Letter_Second_L1, Letter_Second_L2, Letter_Second_L3, Letter_Second_L4, Letter_Second_L5, Letter_Second_L6, Letter_Second_L7, Letter_Second_L8,

        Metter_First_M1, Metter_First_M2, Metter_First_M3, Metter_First_M4, Metter_First_M5, Metter_First_M6, Metter_First_M7, Metter_First_M8,
        Metter_Second_M1, Metter_Second_M2, Metter_Second_M3, Metter_Second_M4, Metter_Second_M5, Metter_Second_M6, Metter_Second_M7, Metter_Second_M8,

        Letter_First_N1, Letter_First_N2, Letter_First_N3, Letter_First_N4, Letter_First_N5, Letter_First_N6, Letter_First_N7, Letter_First_N8,
        Letter_Second_N1, Letter_Second_N2, Letter_Second_N3, Letter_Second_N4, Letter_Second_N5, Letter_Second_N6, Letter_Second_N7, Letter_Second_N8,

        Letter_First_O1, Letter_First_O2, Letter_First_O3, Letter_First_O4, Letter_First_O5, Letter_First_O6, Letter_First_O7, Letter_First_O8,
        Letter_Second_O1, Letter_Second_O2, Letter_Second_O3, Letter_Second_O4, Letter_Second_O5, Letter_Second_O6, Letter_Second_O7, Letter_Second_O8,

        Letter_First_R1, Letter_First_R2, Letter_First_R3, Letter_First_R4, Letter_First_R5, Letter_First_R6, Letter_First_R7, Letter_First_R8,
        Letter_Second_R1, Letter_Second_R2, Letter_Second_R3, Letter_Second_R4, Letter_Second_R5, Letter_Second_R6, Letter_Second_R7, Letter_Second_R8,

        Letter_First_S1, Letter_First_S2, Letter_First_S3, Letter_First_S4, Letter_First_S5, Letter_First_S6, Letter_First_S7, Letter_First_S8,
        Letter_Second_S1, Letter_Second_S2, Letter_Second_S3, Letter_Second_S4, Letter_Second_S5, Letter_Second_S6, Letter_Second_S7, Letter_Second_S8,

        Letter_First_W1, Letter_First_W2, Letter_First_W3, Letter_First_W4, Letter_First_W5, Letter_First_W6, Letter_First_W7, Letter_First_W8,
        Letter_Second_W1, Letter_Second_W2, Letter_Second_W3, Letter_Second_W4, Letter_Second_W5, Letter_Second_W6, Letter_Second_W7, Letter_Second_W8,
    }

    /* Used if a player is tracking a queen's 
    shooting strategy that uses three vectors.*/
    // A player picks three directions as an answer.
    public enum Secondary_Three_Directions
    {
        D_1_2_3, D_1_2_4, D_1_2_5, D_1_2_6, D_1_2_7, D_1_2_8,
        D_1_3_4, D_1_3_5, D_1_3_6, D_1_3_7, D_1_3_8,
        D_1_4_5, D_1_4_6, D_1_4_7, D_1_4_8,
        D_1_5_6, D_1_5_7, D_1_5_8,
        D_1_6_7, D_1_6_8,
        D_1_7_8,

        D_2_3_4, D_2_3_5, D_2_3_6, D_2_3_7, D_2_3_8,
        D_2_4_5, D_2_4_6, D_2_4_7, D_2_4_8,
        D_2_5_6, D_2_5_7, D_2_5_8,
        D_2_6_7, D_2_6_8,
        D_2_7_8,

        D_3_4_5, D_3_4_6, D_3_4_7, D_3_4_8,
        D_3_5_6, D_3_5_7, D_3_5_8,
        D_3_6_7, D_3_6_8,
        D_3_7_8,

        D_4_5_6, D_4_5_7, D_4_5_8,
        D_4_6_7, D_4_6_8,
        D_4_7_8,

        D_5_6_7, D_5_6_8,
        D_5_7_8,

        D_6_7_8,
    }

    /* Used if a player is tracking a queen's 
    shooting strategy that uses four vectors.*/
    // A player picks four directions as an answer.
    public enum Secondary_Four_Directions
    {
        D_1_2_3_4, D_1_2_3_5, D_1_2_3_6, D_1_2_3_7, D_1_2_3_8,
        D_1_2_4_5, D_1_2_4_6, D_1_2_4_7, D_1_2_4_8,
        D_1_2_5_6, D_1_2_5_7, D_1_2_5_8,
        D_1_2_6_7, D_1_2_6_8,
        D_1_2_7_8,

        D_1_3_4_5, D_1_3_4_6, D_1_3_4_7, D_1_3_4_8,
        D_1_3_5_6, D_1_3_5_7, D_1_3_5_8,
        D_1_3_6_7, D_1_3_6_8,
        D_1_3_7_8,

        D_1_4_5_6, D_1_4_5_7, D_1_4_5_8,
        D_1_4_6_7, D_1_4_6_8,
        D_1_4_7_8,

        D_1_5_6_7, D_1_5_6_8,
        D_1_5_7_8,

        D_1_6_7_8,

        D_2_3_4_5, D_2_3_4_6, D_2_3_4_7, D_2_3_4_8,
        D_2_3_5_6, D_2_3_5_7, D_2_3_5_8,
        D_2_3_6_7, D_2_3_6_8,
        D_2_3_7_8,

        D_2_4_5_6, D_2_4_5_7, D_2_4_5_8,
        D_2_4_6_7, D_2_4_6_8,
        D_2_4_7_8,

        D_2_5_6_7, D_2_5_6_8,
        D_2_5_7_8,

        D_2_6_7_8,

        D_3_4_5_6, D_3_4_5_7, D_3_4_5_8,
        D_3_4_6_7, D_3_4_6_8,
        D_3_4_7_8,

        D_3_5_6_7, D_3_5_6_8,
        D_3_5_7_8,

        D_3_6_7_8,

        D_4_5_6_7, D_4_5_6_8,
        D_4_5_7_8,

        D_4_6_7_8,

        D_5_6_7_8
    }

    /* Used if a player is tracking a queen's 
    shooting strategy that uses five vectors.*/
    // A player picks five directions as an answer.
    public enum Secondary_Five_Directions
    {
        D_1_2_3_4_5, D_1_2_3_4_6, D_1_2_3_4_7, D_1_2_3_4_8,
        D_1_2_3_5_6, D_1_2_3_5_7, D_1_2_3_5_8,
        D_1_2_3_6_7, D_1_2_3_6_8,
        D_1_2_3_7_8,

        D_1_2_4_5_6, D_1_2_4_5_7, D_1_2_4_5_8,
        D_1_2_4_6_7, D_1_2_4_6_8,
        D_1_2_4_7_8,

        D_1_2_5_6_7, D_1_2_5_6_8,
        D_1_2_5_7_8,

        D_1_2_6_7_8,

        D_1_3_4_5_6, D_1_3_4_5_7, D_1_3_4_5_8,
        D_1_3_4_6_7, D_1_3_4_6_8,
        D_1_3_4_7_8,

        D_1_3_5_6_7, D_1_3_5_6_8,
        D_1_3_5_7_8,

        D_1_3_6_7_8,

        D_1_4_5_6_7, D_1_4_5_6_8,
        D_1_4_5_7_8,

        D_1_4_6_7_8,

        D_1_5_6_7_8,

        D_2_3_4_5_6, D_2_3_4_5_7, D_2_3_4_5_8,
        D_2_3_4_6_7, D_2_3_4_6_8,
        D_2_3_4_7_8,

        D_2_3_5_6_7, D_2_3_5_6_8,
        D_2_3_5_7_8,

        D_2_3_6_7_8,

        D_3_4_5_6_7, D_3_4_5_6_8,
        D_3_4_5_7_8,

        D_3_4_6_7_8,

        D_4_5_6_7_8
    }

    /*Used if a player is tracking a queen's shooting strategy
     that uses a parabola function as it gun*/
    // A player picks a parabola number as an answer.
    public enum Secondary_Parabola_Number
    {
        Parabola_Number_One,
        Parabola_Number_Two,
        Parabola_Number_Three,
        Parabola_Number_Four,
        Parabola_Number_Five,
        Parabola_Number_Six,
        Parabola_Number_Seven,
        Parabola_Number_Eight
    }

    /*Used if a player is tracking a queen's shooting strategy
     that uses a parabola function as it gun*/
    // Incomplete, some parabola equations aren't included.
    // A player picks a plane equation as an answer.
    public enum Secondary_Parabola_Equation
    {
        XEQUALSYSQUARED,
        XEQUALSMINUSYSQUARED,

        YEQUALSXSQUARED,
        YEQUALSMINUSXSQUARED,
    }
}