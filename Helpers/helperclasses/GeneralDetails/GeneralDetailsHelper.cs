namespace Helpers.helperclasses.GeneralDetails
{
    public class GeneralDetailsHelper
    {
        public List<string> Notes { get; }
        public GeneralDetailsHelper()
        {
            Notes = new List<string>()
            {
                EntitiesDetails(),
            };
        }
        private string EntitiesDetails()
        {
            return "\n\nRegular Todo List:\n\n";
        }
    }
}
