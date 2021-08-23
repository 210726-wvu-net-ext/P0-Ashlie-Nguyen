namespace UI
{
    public interface IMenu
    {
        void Start();
        void Login();
        void AddUser();
        void Menu();
        void SearchRestaurant();
        void GetRestaurantDetails();
        void AddReview(string restaurant);
        void SearchRestaurantsByRating();
        void SearchRestaurantsByZip();
        void AddRestaurant();
        void SearchUser();
    }
}