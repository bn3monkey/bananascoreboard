﻿using BananaScoreBoard.View.MainView.SubView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BananaScoreBoard.Model;
using System.Windows;
using System.Windows.Input;
using BananaScoreBoard.Auxiliary;

namespace BananaScoreBoard.ViewModel.MainViewModel.SubViewModel
{
    class FolderPathViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyUpdate(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
            //if (PropertyChanged != null)
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }


        private MainViewModel parent;
        public FolderPathViewModel(MainViewModel parent, FolderPathView view)
        {
            this.parent = parent;
            view.DataContext = this;


            Repository.Instance.record.loadPath();
        }

        private ICommand findFolderPathCommand;
        public ICommand FindFolderPathCommand
        {
            get
            {
                return this.findFolderPathCommand ?? (this.findFolderPathCommand = new DelegateCommand(FindFolderPath));
            }
        }

        private ICommand readFolderPathCommand;
        public ICommand ReadFolderPathCommand
        {
            get
            {
                return this.readFolderPathCommand ?? (this.readFolderPathCommand = new DelegateCommand(ReadFolderPath));
            }
        }


        void FindFolderPath()
        {
            FolderPath = Repository.Instance.record.FindPath();
            Repository.Instance.record.savePath();
        }

        void ReadFolderPath()
        {
            Task task = new Task(() =>
                {
                    Repository.Instance.record.InitializePath();
                    parent.scoreViewModel.Name1P = Repository.Instance.record.ReadString(Record.Name.Name1P);
                    parent.scoreViewModel.Name2P = Repository.Instance.record.ReadString(Record.Name.Name2P);
                    parent.scoreViewModel.Score1P = Repository.Instance.record.ReadInt(Record.Name.Score1P);
                    parent.scoreViewModel.Score2P = Repository.Instance.record.ReadInt(Record.Name.Score2P);
                    parent.miscViewModel.Label = Repository.Instance.record.ReadString(Record.Name.Label);
                    parent.miscViewModel.MISC1 = Repository.Instance.record.ReadString(Record.Name.MISC1);
                    parent.miscViewModel.MISC2 = Repository.Instance.record.ReadString(Record.Name.MISC2);
                    parent.miscViewModel.MISC3 = Repository.Instance.record.ReadString(Record.Name.MISC3);
                    parent.miscViewModel.MISC4 = Repository.Instance.record.ReadString(Record.Name.MISC4);
                }
            );
            task.Start();
        }

        public string FolderPath
        {
            get
            {
                return Repository.Instance.record.folder_path;
            }
            set
            {
                Repository.Instance.record.folder_path = value;
                OnPropertyUpdate("FolderPath");
            }
        }
    }
}
