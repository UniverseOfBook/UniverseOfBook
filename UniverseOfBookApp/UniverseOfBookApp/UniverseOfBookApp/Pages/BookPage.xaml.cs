using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseOfBookApp.DataAccess;
using UniverseOfBookApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookPage : ContentPage {
        BookDataAccess BookDataAccess = new BookDataAccess();
        AuthorDataAccess author = new AuthorDataAccess();
        UserBookDataAccess UserBookDataAccess = new UserBookDataAccess();
        private static string nameOfPage;

        public BookPage() {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#efefef");
        }

        public BookPage(string name) {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#efefef");
            Book book = BookDataAccess.GetBookByName(name);
            Bookphoto.Source = book.BookPhoto;
            Bookname.Text = book.BookName;
            BookDescription.Text = book.Description;
            AuthorName.Text = book.AuthorName;
            Author authorClass = author.GetAuthorbyName(book.AuthorName);
            AuthorPhoto.Source = authorClass.AuthorPhoto;
            nameOfPage = name;

            CommentDataAccess commentDataAccess = new CommentDataAccess();
            List<Comment> comments = commentDataAccess.GetCommentOfBook(name);
            foreach(Comment comment in comments) {
                AddCommentToPage(comment);
            }
        }

        private void AddCommentToPage(Comment comment) {
            noCommentLabel.IsVisible = false;
            UserDataAccess userDataAccess = new UserDataAccess();
            StackLayout stackLayoutUpper = new StackLayout() {
                Orientation = StackOrientation.Horizontal
            };
            User user = userDataAccess.GetUserByEmail(comment.UserEmail);
            if (user.UserPhoto == null)
                user.UserPhoto = "@drawable/defaultuser";
            ImageCircle.Forms.Plugin.Abstractions.CircleImage image = new ImageCircle.Forms.Plugin.Abstractions.CircleImage {
                Source = user.UserPhoto,
                HeightRequest = 20
            };
            Label userLabel = new Label {
                Text = user.UserName,
                FontAttributes = FontAttributes.Bold,
                FontSize = 17
            };
            stackLayoutUpper.Children.Add(image);
            stackLayoutUpper.Children.Add(userLabel);

            StackLayout stackLayoutLower = new StackLayout();
            Label commentLabel = new Label() {
                Text = comment.CommentOfBook,
                FontSize = 13
            };
            stackLayoutLower.Children.Add(commentLabel);

            StackLayout stackLayoutOuter = new StackLayout();
            stackLayoutOuter.Children.Add(stackLayoutUpper);
            stackLayoutOuter.Children.Add(stackLayoutLower);
            Frame frame = new Frame {
                Content = stackLayoutOuter,
                CornerRadius = 20,
                BorderColor = Color.FromHex("#6d6d6d")
            };
            CommentStackLayout.Children.Add(frame);
        }

        private async void AuthorTapped(object sender, EventArgs e) {
            await Navigation.PushAsync(new AuthorPage(AuthorName.Text));
        }

        private void WantReadButtonClicked(object sender, EventArgs e) {
            Button button = (Button)sender;
            BookDataAccess bookDataAccess = new BookDataAccess();
            Book bookClass = bookDataAccess.GetBookBySource(Bookphoto.Source.ToString().Replace("Uri: ", ""));
            List<UserBook> userBooks = UserBookDataAccess.GetBookByEmailAndBookName(App.UserEmail, bookClass.BookName);

            if (userBooks.Count != 0) {
                if (userBooks[0].ReadWant == ReadWantEnum.Want) {
                    if (button.Text == "Read") {
                        userBooks[0].ReadWant = ReadWantEnum.Read;
                        userBooks[0].DateTime = DateTime.Now;
                        UserBookDataAccess.BookUserUpdateReadOrWant(userBooks[0]);
                        DisplayAlert("Read Book", "You added this book to Read List", "Ok");
                    }
                    else {
                        DisplayAlert("Warning", "You already add this book in your Want List", "Ok");
                    }
                }
                else {
                    if (button.Text == "Want") {
                        userBooks[0].ReadWant = ReadWantEnum.Want;
                        userBooks[0].DateTime = DateTime.Now;
                        UserBookDataAccess.BookUserUpdateReadOrWant(userBooks[0]);
                        DisplayAlert("Want Book", "You added this book to Want List", "Ok");
                    }
                    else {
                        DisplayAlert("Warning", "You already add this book in your Read List", "Ok");
                    }
                }
            }
            else {
                UserBook userBook = new UserBook {
                    BookName = Bookname.Text,
                    Email = App.UserEmail,
                    DateTime = DateTime.Now
                };
                if (button.Text == "Want") {
                    DisplayAlert("Want Book", "You added this book to Want List", "Ok");
                    userBook.ReadWant = ReadWantEnum.Want;
                }
                else {
                    DisplayAlert("Read Book", "You added this book to Read List", "Ok");
                    userBook.ReadWant = ReadWantEnum.Read;
                }
                UserBookDataAccess.UserInsert(userBook);
            }
        }

        private void SubmitButtonClicked(object sender, EventArgs e) {
            CommentDataAccess commentDataAccess = new CommentDataAccess();
            Comment comment = new Comment() {
                Bookname = nameOfPage,
                Date = DateTime.Now,
                CommentOfBook = commentEditor.Text,
                UserEmail = App.UserEmail
            };
            commentDataAccess.AddComment(comment);
            DisplayAlert("New Comment", "Comment sent.", "OK");
            AddCommentToPage(comment);
            commentEditor.Text = "";
        }
    }
}