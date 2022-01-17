namespace ChromeControl.TestApp.ViewModel.Commands
{
    public class GetWindowCommandViewModel : CommandBase
    {
        public override string CommandDescription
        {
            get => "Get the Window Ids of all open Chrome Windows";
        }

        public override string CommandName
        {
            get => "Get Window Ids";
        }

        public override void Execute()
        {
            if (ChromeCommands.GetWindowIds(out int[] ids))
            {
                OutputText = string.Join(", ", ids);
            }
            else
            {
                OutputText = "Command failed";
            }
        }
    }
}
