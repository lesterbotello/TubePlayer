using Microsoft.UI.Text;

namespace TubePlayer.Presentation;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.DataContext<BindableMainModel>((page, vm) => page
            .NavigationCacheMode(NavigationCacheMode.Required)
                .Background(Theme.Brushes.Background.Default)
                .Content(
                    new Grid()
                        .SafeArea(SafeArea.InsetMask.All)
                        .RowDefinitions("Auto, *")
                        .Children(
                            new TextBox()
                                .Text(x => x
                                    .Bind(() => vm.SearchTerm)
                                    .Mode(BindingMode.TwoWay)
                                    .UpdateSourceTrigger(UpdateSourceTrigger.PropertyChanged))
                                .PlaceholderText("Search term"),
                            new ListView()
                                .Grid(row: 1)
                                .ItemsSource(() => vm.VideoSearchResults)
                                .ItemTemplate<YoutubeVideo>(ytv =>
                                new StackPanel()
                                    .Children(
                                        new TextBlock()
                                            .FontWeight(FontWeights.Bold)
                                            .Text(() =>
                                                ytv.Details.Snippet?.ChannelTitle),
                                        new TextBlock()
                                            .Text(() =>
                                                ytv.Details.Snippet?.Title))))));

        //this.DataContext<BindableMainModel>((page, vm) => page
        //    .NavigationCacheMode(NavigationCacheMode.Required)
        //    .Background(Theme.Brushes.Background.Default)
        //    .Content(new Grid()
        //        .SafeArea(SafeArea.InsetMask.All)
        //        .RowDefinitions("Auto,*")
        //        .Children(
        //            new NavigationBar().Content(() => vm.Title),
        //            new StackPanel()
        //                .Grid(row: 1)
        //                .HorizontalAlignment(HorizontalAlignment.Center)
        //                .VerticalAlignment(VerticalAlignment.Center)
        //                .Spacing(16)
        //                .Children(
        //                    new TextBox()
        //                        .Text(x => x.Bind(() => vm.Name).Mode(BindingMode.TwoWay))
        //                        .PlaceholderText("Enter your name:"),
        //                    new Button()
        //                        .Content("Go to Second Page")
        //                        .AutomationProperties(automationId: "SecondPageButton")
        //                        .Command(() => vm.GoToSecond)
        //                        ))));
    }
}
