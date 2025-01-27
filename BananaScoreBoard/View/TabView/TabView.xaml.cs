﻿using BananaScoreBoard.ViewModel.TabViewModel;
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

namespace BananaScoreBoard.View.TabView
{
    /// <summary>
    /// TabView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TabView : Page
    {
        private TabViewModel viewModel;
        public TabView()
        {
            InitializeComponent();
            this.DataContext = viewModel = new TabViewModel(this);
            this.MatchView.Content = new MatchView.MatchView();
            this.TournamentView.Content = new TournamentView.TournamentView();
            this.InfoView.Content = new InfoView.InfoView();
        }
    }
}
