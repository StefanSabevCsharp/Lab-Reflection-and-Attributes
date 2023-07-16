


namespace AuthorProblem
{
    [Author("Stefan")]
    public class StartUp
    {
        [Author("Again Stefan")]
        public static void Main()
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();

        }
    }
}