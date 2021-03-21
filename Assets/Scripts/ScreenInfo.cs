public static class ScreenInfo
{
    static bool restart = false;
    public static bool isRestarted
    {
        get { return restart; }
        set { restart = value; }
    }

}
