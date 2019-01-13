using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.IO;
using UniverseOfBookApp.DataAccess;
using UniverseOfBookApp.Model;
using UniverseOfBookApp.Pages;
using UniverseOfBookApp.Pages.AdminPages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace UniverseOfBookApp {
    public partial class App : Application {

        private static ISettings AppSettings => CrossSettings.Current;

        public static string UserEmail {
            get => AppSettings.GetValueOrDefault(nameof(UserEmail), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(UserEmail), value);
        }

        public App() {
            Console.WriteLine("Started");
            InitializeComponent();

            if (UserEmail == "") {
                MainPage = new NavigationPage(new LoginPage()) {
                    BarBackgroundColor = Color.FromHex("#efefef"),
                    BarTextColor = Color.FromHex("#1b1b1b")
                };
            }
            else {
                MainPage = new NavigationPage(new MainTabbedPage()) {
                    BarBackgroundColor = Color.FromHex("#efefef"),
                    BarTextColor = Color.FromHex("#1b1b1b")
                };
            }

            //insertBookToDatabase();
            //insertAuthorToDatabase();
            //MainPage = new NavigationPage(new LoginPage());
        }

        public void insertBookToDatabase() {
            BookDataAccess bookDataAccess = new BookDataAccess();
            BookClass book = new BookClass();

            string bookName = "Değiştirilmiş Karbon";
            string authorName = "Richard K. Morgan";
            int pageNumber = 496;
            CategoryEnum categoryEnum = CategoryEnum.ScienceFiction;
            Publishers publishers = Publishers.Ithaki;
            string bookUrl = "https://i.dr.com.tr/cache/600x600-0/originals/0001740861001-1.jpg";

            book.BookName = bookName;
            book.AuthorName = authorName;
            book.PageNumber = pageNumber;
            book.Category = categoryEnum;
            book.Publishers = publishers;
            book.bookphoto = bookUrl;
            int addingbook = bookDataAccess.BookInsert(book);
            if (addingbook > 0)
                Console.WriteLine("Book added: " + bookName);
            else
                Console.WriteLine("Book didn't added!");
        }

        public void insertAuthorToDatabase() {
            AuthorClass author1 = new AuthorClass();
            author1.AuthorName = "Ray Bradbury";
            author1.AuthorDescription = "1920'de Waukegan, Illinois'de doğdu. 1934'te ailesiyle Los Angeles'a taşındı. 1947'de Marguerite McClure'la evlendi. Şimdi yetişkin olan dört kızları var ve halen Los Angeles'ta yaşıyorlar. Bugün Dünya'nın en büyük bilimkurgu ve fantezi yazarlarından biri olan Ray Bradbury, yirmi yaşındayken Weird Tales'de yayımlanan ilk öyküsünden bu yana, 500'e yakın öykü, roman, oyun ve şiir kaleme aldı. John Huston'un 1956 yapımı Moby Dick'inin televizyon senaryosunu yazdı. Sonraları, Alfred Hitchcock Şov ve Rod Sterling'in Alacakaranlık Kuşağı için senaryolar yazdı. Apollo astronot grubundan biri Ay'a indiğinde, Bradbury'nin romanı Dandelion Wine onuruna, bir kratere Dandelion Crater adını verdiler. Bradbury'den, Tokyo yakınlarında bir 21. yüzyıl kentinin tasarımı konusunda yardımcı olması istendi. Fahrenheit 451 operası 1988 sonbaharında sergilendi. Film versiyonu da, 1966 yılında François Truffaut tarafından yönetilmişti. Yapıtları Fahrenheit 451 Mars Yıllıkları Uğursuz Bir Şey";
            author1.AuthorPhoto = "https://i.idefix.com/pimages/Content/Uploads/ArtistImages/artist_102619.jpg";


            AuthorClass author2 = new AuthorClass();
            author2.AuthorName = "Neil Gaiman";
            author2.AuthorDescription = "Ödüllü çizgi roman dizisi The Sandman'i ve Terry Pratchett ile birlikte ödüllü romanı The Good Omens'ı yazdı. Çocuklar için yazdığı ilk kitap, The Day I Swapped My Dad for Two Goldfish Newsweek'in 1997'nin En İyi Çocuk Kitapları listesine girdi. İngiltere'de doğmuş olan yazar bugünlerde Amerika'daki evinde, yeri belirsiz koca, kara bir evde, egzotik balkabakları yetiştirip bilgisayarlarla kediler biriktirerek yaşamaktadır.";
            author2.AuthorPhoto = "https://pixel.nymag.com/imgs/daily/vulture/2017/04/26/26-neil-gaiman-1.w512.h600.2x.jpg";



            AuthorClass author3 = new AuthorClass();
            author3.AuthorName = "Richard K. Morgan";
            author3.AuthorDescription = "Richard is also the author of the dark fantasy A Land Fit For Heroes series: The Steel Remains, The Cold Commands, and The Dark Defiles – and the Takeshi Kovacs novels: Altered Carbon (now a major Netflix series), Broken Angels, and Woken Furies, the stand-alone novels Market Forces and Black Man / Thirteen, two volumes of Black Widow comics for Marvel, and the Crysis 2 and Syndicate computer games.";
            author3.AuthorPhoto = "https://i1.wp.com/www.sub-cultured.com/wp-content/uploads/2015/10/443.jpg";


            AuthorClass author4 = new AuthorClass();
            author4.AuthorName = "Aldous Huxley";
            author4.AuthorDescription = "Aldous Huxley, 1894'te İngiltere'nin Sussex bölgesindeki Godalming'de doğdu. Birçok ünlü bilim adamı ve sanatçı yetiştirmiş olan Huxley ailesinden geliyordu. Oxford'daki Eton College'da okuduğu sıralar gözlerindeki bir rahatsızlık yüzünden kör olma tehlikesiyle karşılaşınca öğrenimine ara vermek zorunda kaldı. Sonradan Balliol College'ı bitirdi. Edebî inceliğini ve zekâsını olduğu kadar, insan ilişkilerine duyduğu ilgiyi de ortaya koyan Ses Sese Karşı adlı romanıyla başarı kazandı. 1932'de yayınlanan Cesur Yeni Dünya adlı romanı, ütopya klasikleri arasına girdi. 1937'de ABD'ye yerleşen Huxley, roman ve denemelerinin yanı sıra Hollywood'da senaryo çalışmaları da yaptı. 1950'ler ve 1960'larda yayınlanan Algı Kapıları ve Ada gibi yapıtlarında, 1960'ların gençlik altkültürlerine de esin sağlayacak bazı temalar ağırlık kazandı. Deneme ve incelemelerini Denemeler, Edebiyat ve Bilim, Ekoloji Politikası gibi kitaplarda toplayan Huxley, 1963'te Los Angeles'ta öldü";
            author4.AuthorPhoto = "https://i0.wp.com/www.izdiham.com/wp-content/uploads/2016/03/aldous-huxley.jpg?resize=770%2C360";



            AuthorClass author5 = new AuthorClass();
            author5.AuthorName = "Oğuz Atay";
            author5.AuthorDescription = "Ülkemizde çok okunan ve sevilen büyük yazarlarımızdan Oğuz Atay, 12 Ekim 1934 tarihinde Kastamonu’da doğdu. Nitelikli bir eğitim hayatı geçiren yazarımız, İTÜ İnşaat Fakültesi’nden mezun olduktan sonra İstanbul Devlet Mühendislik ve Mimarlık Akademisi’nde (Yıldız Teknik Üniversitesi) öğretim üyeliği yapmaya başladı. 1975’te doçent unvanını kazandı ve Topografya adlı mesleki kitabını yazdı";
            author5.AuthorPhoto = "http://i.dr.com.tr/pimages/Content/Uploads/ArtistImages/artist_96793.jpg";

            AuthorClass author = new AuthorClass();
            author.AuthorName = "Yaşar Kemal";
            author.AuthorDescription = "Yaşar Kemal İnce Memed romanını 1954 yılında tamamlayarak yayımlamıştır. Yazar bu kitabı ile 1956 yılında Varlık Roman Armağanı Ödülü’nü kazanmıştır. Yaşar Kemal; Türk Edebiyatında öykü, roman, deneme, şiir, çocuk romanı ve çevirileriyle katkı sağlamıştır. Yazarın eserleri kırk dile çevrilmiştir. Ülkemizde ve dünya çapında yüzlerce ödül kazanmıştır ve eserleri beyazperdeye ve tiyatroya uyarlanmıştır. Yazarın en büyük başarılarıdan birtanesi de Nobel Edebiyat Ödülü’ne aday olmasıdır. ";
            author.AuthorPhoto = "http://i.dr.com.tr/pimages/Content/Uploads/ArtistImages/artist_104697.jpg";

            AuthorDataAccess authorDataAccess = new AuthorDataAccess();

            int addingAuthor = authorDataAccess.AuthorInsert(author5);
            if (addingAuthor > 0)
                Console.WriteLine("Author added: ");
            else
                Console.WriteLine("Author didn't added!");
        }


        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
