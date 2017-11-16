using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace xapps
{
    public partial class DetailPage : ContentPage , CustomTabInterface
    {
        private DetailPageViewModel viewModel;
        private string mRequestId;

        public DetailPage(String reqId)
        {
            InitializeComponent();

            mRequestId = reqId;
            printLog("reqServerData reqId : " + mRequestId);

            BindingContext = viewModel = new DetailPageViewModel(mRequestId);
            initView();
        }

        private void initView() {
            // TAB
            string[] tabs = {"평점", "포토/트레일러" , "감독/배우"};
            setTabBar(mdpTab, tabs);
        }

        private void setTabBar(StackLayout layout, string[] tabs) {
            const string SelColor = "#F7D358";
            const string NorColor = "#F5ECCE";
            const bool IsUseImage = false;

            List<CustomTabData> arrTabs = new List<CustomTabData>();
            CustomTabData tab;
            int nCnt = 0;

            foreach (string item in tabs) {
                nCnt++;
                tab = new CustomTabData();
                tab.tabText = item;
                tab.isUseImage = IsUseImage;
                tab.selColor = SelColor;
                tab.norColor = NorColor;
                tab.tag = nCnt.ToString();

                arrTabs.Add(tab); // Add
            }

            CustomTabView tabView = new CustomTabView();
            tabView.Listener = this;
            tabView.makeTabLayout(arrTabs);
            layout.Children.Add(tabView);
        }

        async void onClickFullMoviePage(object sender, System.EventArgs e)
        {
            var url = DependencyService.Get<IMovieUrl>();
            if (url != null)
            {
                url.MovieUrl("http://sites.google.com/site/ubiaccessmobile/sample_video.mp4");
            }
            await Navigation.PushAsync(new PreviewPage());
        }

        void onClickMovieStoryMore(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            bool btnVisible = btn.IsVisible;

            mdpMovieInfoBtnMore.IsVisible = false;
            mdpMovieInfoTvStory.LineBreakMode = LineBreakMode.WordWrap;
        }

        private void printLog(string msg)
        {
            Debug.WriteLine("################### " + msg);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.DetailItem == null)
                viewModel.LoadItemsCommand.Execute(mRequestId);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        public void onClickTabButton(object index)
        {
            // Event
            printLog("onClickTabButton() index : " + index);
        }
    }
}
