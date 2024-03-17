using CollectedPassionApp_A2D2.MVVM.Models;
using CollectedPassionApp_A2D2.Repositories;

namespace CollectedPassionApp_A2D2
{
    public partial class App : Application
    {

        public static int CurrentUserId { get; set; }
        public static BaseRepository<User>? UserRepo { get; private set; }
        public static BaseRepository<Category>? CategoRepo { get; private set; } 
        //public static BaseRepository<Brand>? BrandRepo { get; private set; }
        public static BaseRepository<Collectable>? CollectionRepo { get; private set; }
        public App(BaseRepository<User> userRepo,  BaseRepository<Collectable> collectrepo,BaseRepository<Category> categorepo)
        //BaseRepository<Brand>? brandRepo)

        {
            InitializeComponent();
            UserRepo = userRepo;
            CategoRepo = categorepo;
            CollectionRepo = collectrepo;


            User Manager = new User() { username = "admin",  email = "ad@min", password = "ad", role = "manager" };
            List<User> Managers = App.UserRepo.GetEntities().Where(a => a.role == "manager").ToList();
            if (Managers.Count < 1)
            {
                UserRepo.SaveEntity(Manager);
            }

            MainPage = new AppShell();
        }
    }
}
