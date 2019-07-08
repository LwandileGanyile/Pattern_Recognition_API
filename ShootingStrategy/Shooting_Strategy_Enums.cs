namespace ShootingStrategy
{

    public enum Shoot
    {
        FIRST_SHOOT,
        SECOND_SHOOT,
        THIRD_SHOOT
    }

    public enum VectorsTraceType
    {
        Three_Vectors, Four_Vectors, Five_Vectors
    }

    public enum VectorShootType
    {
        CLOCKWISE_SHOOT,
        COUNTER_CLOCKWISE_SHOOT,
        INCREMENTAL_SHOOT,
        DECREMENTAL_SHOOT,
        NONE
    }

    public enum FunctionShootType
    {
        CLOCKWISE_SHOOT,
        COUNTER_CLOCKWISE_SHOOT,
        NONE
    }

    public enum PlaneShootType
    {
        INCREMENTAL_SHOOT_ON_XY_PLANE,
        DECREMENTAL_SHOOT_ON_XY_PLANE,
        CLOCKWISE_SHOOT_ON_XY_PLANE,
        COUNTER_CLOCKWISE_SHOOT_ON_XY_PLANE,

        INCREMENTAL_SHOOT_ON_XZ_PLANE,
        DECREMENTAL_SHOOT_ON_XZ_PLANE,
        CLOCKWISE_SHOOT_ON_XZ_PLANE,
        COUNTER_CLOCKWISE_SHOOT_ON_XZ_PLANE,

        INCREMENTAL_SHOOT_ON_YZ_PLANE,
        DECREMENTAL_SHOOT_ON_YZ_PLANE,
        CLOCKWISE_SHOOT_ON_YZ_PLANE,
        COUNTER_CLOCKWISE_SHOOT_ON_YZ_PLANE,


        NONE

    }
}