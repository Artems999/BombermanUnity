public class GameSet
{
    public static GameSet Default { get; } = new GameSet();

    public int FieldSizeX { get; } = 15;


    public int FieldSizeZ { get; } = 15;

    public float TileSizeX { get; } = 2.0f;

    public float TileSizeZ { get; } = 2.0f;


}