namespace ChromeControl.TestApp.ViewModel.Commands
{
    public class GetTabIdsCommandViewModel : CommandBase
    {
        public override string CommandDescription
        {
            get => "Get the Ids of all Tabs";
        }

        public override string CommandName
        {
            get => "Get Tab Ids";
        }

        public override void Execute()
        {
            if (ChromeCommands.GetTabIds(out int[] ids))
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
