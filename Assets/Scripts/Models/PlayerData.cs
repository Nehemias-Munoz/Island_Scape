namespace Models
{
    public static class PlayerData
    {
        static int level = 0;
        static int lives = 3;

        public static int Level
        {
            get => level;
            set
            {
                level = value;
                UIManager.instance.UpdateLevelUI(level);
            }
        }
        public static int Lives
        {
            get => lives;
            set
            {
                lives = value;
                UIManager.instance.UpdateHealtUI(lives);
            }
        }
    }
}