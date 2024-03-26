using CollectedPassionApp_A2D2.MVVM.Models;
using CollectedPassionApp_A2D2.Repositories;

namespace CollectedPassionApp_A2D2
{
    public partial class App : Application
    {
        

        public static int CurrentUserId { get; set; }
        public static BaseRepository<Appuser>? UserRepo { get; private set; }
        public static BaseRepository<Category>? CategoRepo { get; private set; } 
        
        public static BaseRepository<Collectable>? CollectionRepo { get; private set; }
        public static BaseRepository<Collectable4Sale>? Market { get; private set; }
        public App(BaseRepository<Appuser> userRepo,  BaseRepository<Collectable> collectrepo,BaseRepository<Category> categorepo,
        BaseRepository<Collectable4Sale> marketing)

        {
            InitializeComponent();
            UserRepo = userRepo;
            CategoRepo = categorepo;
            CollectionRepo = collectrepo;
            Market = marketing;
            new Category {  Catname = "Coins" }; new Category {  Catname = "Money" }; new Category {  Catname = "Movies" };

            new Category {  Catname = "Music" }; new Category {  Catname = "Stamps" }; new Category { Catname = "Comics" }; new Category { Catname = "Books" }; new Category { Catname = "PostMail Cards" };

            new Category { Catname = "Trading Cards" }; new Category { Catname = "Vinyl Records" }; new Category { Catname = "Lighters" };

            


            Appuser Manager = new Appuser() { username = "admin",  email = "ad@min", password = "ad", role = "manager" }; Appuser Collie = new Appuser() { username = "user", email = "cd@min", password = "us", role = "collector" };
            UserRepo.SaveEntity(Manager); UserRepo.SaveEntity(Collie);

            
            MainPage = new AppShell();
        }  
        
    }
}
