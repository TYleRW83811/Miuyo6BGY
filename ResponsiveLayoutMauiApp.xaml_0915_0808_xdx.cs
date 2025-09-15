// 代码生成时间: 2025-09-15 08:08:13
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ResponsiveLayoutMauiApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            /*
             * 使用响应式布局的主界面
             */
            MainPage = new MainPage();
        }
    }
}

/*
 * 文件名：MainPage.xaml
 * 功能：定义响应式布局的XAML界面
 */

<ContentPage xmlns="http://schemas.microsoft.com/winfx/2009/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             mc:Ignorable="d"
             x:Class="ResponsiveLayoutMauiApp.MainPage">
    <StackLayout>
        <Label Text="响应式布局示例" FontSize="Large" HorizontalOptions="Center" />
        <BoxView Color="Blue" />
        <Grid ColumnDefinitions="Auto, *" RowDefinitions="Auto, Auto">
            <Label Grid.Row="0" Grid.Column="0" Text="姓名：" />
            <Entry Grid.Row="0" Grid.Column="1" x:Name="NameEntry" WidthRequest="200" />
            <Label Grid.Row="1" Grid.Column="0" Text="年龄：" />
            <Entry Grid.Row="1" Grid.Column="1" x:Name="AgeEntry" WidthRequest="200" />
            <Button Grid.Row="2" Grid.ColumnSpan="2" Text="提交" Clicked="OnSubmitClicked" />
        </Grid>
    </StackLayout>
</ContentPage>

/*
 * 文件名：MainPage.xaml.cs
 * 功能：响应式布局的页面逻辑
 */

using Microsoft.Maui.Controls;

namespace ResponsiveLayoutMauiApp
{    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(NameEntry.Text) || string.IsNullOrWhiteSpace(AgeEntry.Text))
                {
                    await DisplayAlert("错误", "姓名和年龄不能为空", "确定");
                    return;
                }

                // 处理提交逻辑
                await DisplayAlert("提交成功", $"姓名：{NameEntry.Text}, 年龄：{AgeEntry.Text}", "确定");
            }
            catch (Exception ex)
            {
                // 错误处理
                await DisplayAlert("错误", ex.Message, "确定");
            }
        }
    }
}