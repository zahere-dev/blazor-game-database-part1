namespace BlazorGameDatabase.Services
{
    public class NotifierService
    {
        public NotifierService()
        {

        }

        string searchKey;
        public string SearchKey
        {
            get => searchKey;
            set
            {
                if (searchKey != value)
                {
                    searchKey = value;

                    if (Notify != null)
                    {
                        Notify?.Invoke();
                    }
                }
            }
        }
        public event Func<Task> Notify;
    }
}

