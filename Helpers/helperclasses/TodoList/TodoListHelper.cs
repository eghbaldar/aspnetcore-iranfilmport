namespace Helpers.helperclasses.TodoList
{
    public class TodoListHelper
    {
        public List<string> Notes { get; }
        public TodoListHelper()
        {
            Notes = new List<string>()
            {
                Urgent(),
                ImprovementPlans(),
                AfterLaunchWebsiteForTheFirstTime(),
            };
        }
        private string ImprovementPlans()
        {
            return "\n\nRegular Todo List:\n\n";
        }
        private string Urgent()
        {
            return "\n\n Regular Todo List:\n\n" +
                "----- 1) check the OLD Project CONSTANTS with new projecte constants \r\n" +
                "----- 1) \r\n" +
                "----- 2) \r\n"+
                "----- 3) \r\n"+
                "----- 4) \r\n"+
                "----- 5) \r\n";
        }
        private string AfterLaunchWebsiteForTheFirstTime()
        {
            return "\n\nImmediately Assignments:\n\n" +
                "----- 0) change the defualt scheme of database tables to (.dbo) \r\n" +
                "----- 2) set the admins roles as ADMIN \r\n" +
                "----- 4) set WRITE premission for 'wwwroot/sitemaps' & 'wwwroot/UploadedStuff' folders \r\n" +
                "----- 5) set the special setting in web.config to enable PUT AJAX METHOD (https://blog.eghbaldar.ir/showthread.php?tid=214) \r\n";
        }
    }
}
