namespace VirtualPool.Manager
{
    /// <summary>
    /// IActions interface
    /// </summary>
    public interface IPoolManager
    {
        /// <summary>
        /// Return the logged in user Id if log-in was successfull, null otherwise
        /// </summary>
        string Login(string userId, string password);

        /// <summary>
        /// If the corresponding user is permitted to lock the corresponding article and the 
        /// article is not already blocked or active, then the article and all related articles are blocked 
        /// by this user. In such case, the method return true. Otherwise the method returns falls.
        /// </summary>
        bool BlockArticle(string userId, string articleId);

        /// <summary>
        /// If the corresponding user is locking the corresponding article and the 
        /// then the article and all related articles are released. 
        /// In such case, the method return true. Otherwise the method returns falls.
        /// </summary>
        bool ReleaseArticle(string userId, string articleId);

        /// <summary>
        /// All blocked articles by the corresponding user are realeased
        /// </summary>
        void Logout(string userId);
    }
}
