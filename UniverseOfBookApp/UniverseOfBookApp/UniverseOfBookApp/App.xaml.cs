using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
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

            UserDataAccess userDataAccess = new UserDataAccess();
            User user = userDataAccess.GetUserByEmail("admin@gmail.com");
            if(user == null) {
                user = new User {
                    Email = "admin@gmail.com",
                    Password = "123456",
                    UserName = "admin",
                    UserType = UserAdmin.Admin
                };
                userDataAccess.AddUser(user);
            }

            try {
                //InsertAuthorToDatabase();
                InsertBookToDatabase();
            }
            catch {

            }
            //MainPage = new NavigationPage(new LoginPage());
        }

        public void InsertBookToDatabase() {
            BookDataAccess bookDataAccess = new BookDataAccess();

            Book book = new Book {
                BookName = "Değiştirilmiş Karbon",
                AuthorName = "Richard K. Morgan",
                PageNumber = 496,
                Category = CategoryEnum.ScienceFiction,
                Publishers = PublishersEnum.Ithaki,
                BookPhoto = "https://i.dr.com.tr/cache/600x600-0/originals/0001740861001-1.jpg",
                Description =
@"1. yüzyıl bilimkurgu edebiyatının en önemli eserlerinden biri olan Değiştirilmiş Karbon’dan uyarlanan ve Netflix’in yayımlayacağı distopik dizi Altered Carbon, 2018’in en çok seyredilecek projelerinden biri olmaya aday!

Phılıp K. Dıck En İyi Roman Ödülü

25. yüzyıl. İnsanlık BM’nin gözetimi altında tüm galakside hüküm sürmekte. Irk, inanç ve sınıf farklılıklarının hâlâ devam ettiği bu dönemde teknolojideki yükseliş hayatı âdeta baştan tanımladı. Bir insanın bilinci depolanarak yeni bir bedene (ya da “kılıf”a) kolayca indirilebilir hale geldi ve ölüm olgusu, ekrandaki bir bip sesine indirgendi.

Eski bir asker ve BM elçisi olan Takeshi Kovacs daha önce de öldürülmesine rağmen son ölümü bilhassa acı vericiydi. Evinden 180 ışık yılı uzakta, eski adıyla San Francisco, yeni adıyla Bay City’de yeni bir bedende uyanan Kovacs kendini, “varoluş”u alınıp satılır şeyler olarak gören bir topluma göre bile karanlık ve büyük ölçekli bir komplonun tam merkezinde buldu. Dünyanın en güçlü insanlarından biri olan Laurens Bancroft bir ölümün sırrını açığa çıkarmak için Kovacs’ı tutmuştu: Kendi ölümünün.

Blade Runner ve Neuromancer gibi eserlerin izinden giden siberpunk türündeki Değiştirilmiş Karbon, son zamanların en dikkat çeken bilimkurgu-distopya romanlarından biri.

“Değiştirilmiş Karbon’un evreni özgün ve çarpıcı. Muazzam karakterler ve eşsiz bir gizem barındırıyor.”
- Patrick Rothfuss -

“Şahane bir iş. Mükemmel bir bilimkurgu. Değiştirilmiş Karbon, çok iyi bir giriş yapıyor ve hızını gittikçe arttırıyor. Eşit derecede merak uyandırıcı ve özgün bir eser; son sayfaya kadar elinizden düşüremiyorsunuz.”
- Peter F. Hamilton -

“Zekâ dolu bir kara noir, eşsiz bir kurgu ve hikâyesini dört gözle öğrenmek isteyeceğiniz bir karakter.”
- Ken McLeod -

“Bu hızlı okunan, etkileyici roman William Gibson’ın Neuromancer’ı ve Norman Spinrad’ın Deus X’inin merak uyandırıcı bir karışımı.”
- Publishers Weekly –
"
            };
            bookDataAccess.BookInsert(book);
        }

        public void InsertAuthorToDatabase() {
            Author author1 = new Author {
                AuthorName = "Ray Bradbury",
                AuthorDescription = "1920'de Waukegan, Illinois'de doğdu. 1934'te ailesiyle Los Angeles'a taşındı. 1947'de Marguerite McClure'la evlendi. Şimdi yetişkin olan dört kızları var ve halen Los Angeles'ta yaşıyorlar. Bugün Dünya'nın en büyük bilimkurgu ve fantezi yazarlarından biri olan Ray Bradbury, yirmi yaşındayken Weird Tales'de yayımlanan ilk öyküsünden bu yana, 500'e yakın öykü, roman, oyun ve şiir kaleme aldı. John Huston'un 1956 yapımı Moby Dick'inin televizyon senaryosunu yazdı. Sonraları, Alfred Hitchcock Şov ve Rod Sterling'in Alacakaranlık Kuşağı için senaryolar yazdı. Apollo astronot grubundan biri Ay'a indiğinde, Bradbury'nin romanı Dandelion Wine onuruna, bir kratere Dandelion Crater adını verdiler. Bradbury'den, Tokyo yakınlarında bir 21. yüzyıl kentinin tasarımı konusunda yardımcı olması istendi. Fahrenheit 451 operası 1988 sonbaharında sergilendi. Film versiyonu da, 1966 yılında François Truffaut tarafından yönetilmişti. Yapıtları Fahrenheit 451 Mars Yıllıkları Uğursuz Bir Şey",
                AuthorPhoto = "https://i.idefix.com/pimages/Content/Uploads/ArtistImages/artist_102619.jpg"
            };

            Author author2 = new Author {
                AuthorName = "Neil Gaiman",
                AuthorDescription = "Ödüllü çizgi roman dizisi The Sandman'i ve Terry Pratchett ile birlikte ödüllü romanı The Good Omens'ı yazdı. Çocuklar için yazdığı ilk kitap, The Day I Swapped My Dad for Two Goldfish Newsweek'in 1997'nin En İyi Çocuk Kitapları listesine girdi. İngiltere'de doğmuş olan yazar bugünlerde Amerika'daki evinde, yeri belirsiz koca, kara bir evde, egzotik balkabakları yetiştirip bilgisayarlarla kediler biriktirerek yaşamaktadır.",
                AuthorPhoto = "https://pixel.nymag.com/imgs/daily/vulture/2017/04/26/26-neil-gaiman-1.w512.h600.2x.jpg"
            };

            Author author3 = new Author {
                AuthorName = "Richard K. Morgan",
                AuthorDescription = "Richard is also the author of the dark fantasy A Land Fit For Heroes series: The Steel Remains, The Cold Commands, and The Dark Defiles – and the Takeshi Kovacs novels: Altered Carbon (now a major Netflix series), Broken Angels, and Woken Furies, the stand-alone novels Market Forces and Black Man / Thirteen, two volumes of Black Widow comics for Marvel, and the Crysis 2 and Syndicate computer games.",
                AuthorPhoto = "https://i1.wp.com/www.sub-cultured.com/wp-content/uploads/2015/10/443.jpg"
            };

            Author author4 = new Author {
                AuthorName = "Aldous Huxley",
                AuthorDescription = "Aldous Huxley, 1894'te İngiltere'nin Sussex bölgesindeki Godalming'de doğdu. Birçok ünlü bilim adamı ve sanatçı yetiştirmiş olan Huxley ailesinden geliyordu. Oxford'daki Eton College'da okuduğu sıralar gözlerindeki bir rahatsızlık yüzünden kör olma tehlikesiyle karşılaşınca öğrenimine ara vermek zorunda kaldı. Sonradan Balliol College'ı bitirdi. Edebî inceliğini ve zekâsını olduğu kadar, insan ilişkilerine duyduğu ilgiyi de ortaya koyan Ses Sese Karşı adlı romanıyla başarı kazandı. 1932'de yayınlanan Cesur Yeni Dünya adlı romanı, ütopya klasikleri arasına girdi. 1937'de ABD'ye yerleşen Huxley, roman ve denemelerinin yanı sıra Hollywood'da senaryo çalışmaları da yaptı. 1950'ler ve 1960'larda yayınlanan Algı Kapıları ve Ada gibi yapıtlarında, 1960'ların gençlik altkültürlerine de esin sağlayacak bazı temalar ağırlık kazandı. Deneme ve incelemelerini Denemeler, Edebiyat ve Bilim, Ekoloji Politikası gibi kitaplarda toplayan Huxley, 1963'te Los Angeles'ta öldü",
                AuthorPhoto = "https://i0.wp.com/www.izdiham.com/wp-content/uploads/2016/03/aldous-huxley.jpg?resize=770%2C360"
            };

            Author author5 = new Author {
                AuthorName = "Oğuz Atay",
                AuthorDescription = "Ülkemizde çok okunan ve sevilen büyük yazarlarımızdan Oğuz Atay, 12 Ekim 1934 tarihinde Kastamonu’da doğdu. Nitelikli bir eğitim hayatı geçiren yazarımız, İTÜ İnşaat Fakültesi’nden mezun olduktan sonra İstanbul Devlet Mühendislik ve Mimarlık Akademisi’nde (Yıldız Teknik Üniversitesi) öğretim üyeliği yapmaya başladı. 1975’te doçent unvanını kazandı ve Topografya adlı mesleki kitabını yazdı",
                AuthorPhoto = "http://i.dr.com.tr/pimages/Content/Uploads/ArtistImages/artist_96793.jpg"
            };

            Author author6 = new Author {
                AuthorName = "Yaşar Kemal",
                AuthorDescription = "Yaşar Kemal İnce Memed romanını 1954 yılında tamamlayarak yayımlamıştır. Yazar bu kitabı ile 1956 yılında Varlık Roman Armağanı Ödülü’nü kazanmıştır. Yaşar Kemal; Türk Edebiyatında öykü, roman, deneme, şiir, çocuk romanı ve çevirileriyle katkı sağlamıştır. Yazarın eserleri kırk dile çevrilmiştir. Ülkemizde ve dünya çapında yüzlerce ödül kazanmıştır ve eserleri beyazperdeye ve tiyatroya uyarlanmıştır. Yazarın en büyük başarılarıdan birtanesi de Nobel Edebiyat Ödülü’ne aday olmasıdır. ",
                AuthorPhoto = "http://i.dr.com.tr/pimages/Content/Uploads/ArtistImages/artist_104697.jpg"
            };

            AuthorDataAccess authorDataAccess = new AuthorDataAccess();
            List<Author> authors = new List<Author> {
                author1, author2, author3, author4, author5, author6
            };

            foreach(Author author in authors) {
                authorDataAccess.AuthorInsert(author);
            }
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
