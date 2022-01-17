using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChromeControl.TestApp.ViewModel;
using ChromeControl.TestApp.ViewModel.Commands;

namespace ChromeControl.TestApp.ViewModel
{
    public class MainWindowViewModel : WindowViewModelBase
    {

        private ObservableCollection<CommandBase> _commands;
        public ObservableCollection<CommandBase> Commands
        {
            get => _commands;
            set
            {
                if (Equals(_commands, value))
                {
                    return;
                }

                _commands = value;

                NotifyPropertyChanged();
            }
        }

        private CommandBase _selectedCommand;
        public CommandBase SelectedCommand
        {
            get => _selectedCommand;
            set
            {
                if (Equals(_selectedCommand, value))
                {
                    return;
                }

                _selectedCommand = value;

                NotifyPropertyChanged();
            }
        }
        
        private string _displayText;
        public string DisplayText
        {
            get => _displayText;
            set
            {
                if (Equals(_displayText, value))
                {
                    return;
                }

                _displayText = value;

                NotifyPropertyChanged();
            }
        }


        public MainWindowViewModel()
        {
            LoadCommands();
        }

        private void LoadCommands()
        {
            ObservableCollection<CommandBase> commands = new ObservableCollection<CommandBase>();
            commands.Add(new GetWindowCommandViewModel());
            commands.Add(new GetTabIdsCommandViewModel());
            commands.Add(new GetTabIdsInWindowCommandViewModel());
            commands.Add(new OpenWindowCommand());
            commands.Add(new OpenTabCommandViewModel());
            commands.Add(new ChangeTabUrlCommandViewModel());
            commands.Add(new GetUrlInTabCommandViewModel());
            commands.Add(new CloseWindowCommandViewModel());
            commands.Add(new CloseTabCommandViewModel());
            commands.Add(new FocusWindowCommandViewModel());
            commands.Add(new MoveWindowCommand());
            commands.Add(new WindowStateCommandViewModel());
            commands.Add(new GetWindowPositionCommandViewModel());
            Commands = commands;

            foreach (var command in commands)
            {
                command.PropertyChanged += Command_PropertyChanged;
            }

            SelectedCommand = Commands.First();
        }

        private void Command_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "OutputText")
            {
                DisplayText += ((CommandBase) sender).OutputText;
                DisplayText += Environment.NewLine;
            }
        }
    }
}
