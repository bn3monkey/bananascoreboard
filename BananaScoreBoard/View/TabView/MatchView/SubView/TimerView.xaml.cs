﻿using BananaScoreBoard.ViewModel.TabViewModel.MatchViewModel.SubViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BananaScoreBoard.View.TabView.MatchView.SubView
{
    /// <summary>
    /// TimerView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TimerView : Page
    {
        private TimerViewModel viewModel;
        public TimerView()
        {
            InitializeComponent();
            this.DataContext = viewModel = new TimerViewModel(this);
        }
    }
}
