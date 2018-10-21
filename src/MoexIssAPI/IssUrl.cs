using System;

namespace MoexIssAPI
{
    /// <summary>
    /// Класс для формирования url запросов к iss
    /// </summary>
    public class IssUrl
    {
        #region Fields

        /// <summary>
        /// Базовый url сервиса
        /// </summary>
        private const string _baseUrl = "https://iss.moex.com/iss/";

        /// <summary>
        /// Конечный url
        /// </summary>
        private string _url;

        #endregion

        #region .ctor

        public IssUrl()
        {

        }

        #endregion

        #region Operators

        /// <summary>
        /// Оператор неявного преобразования из IssUrl в строку
        /// </summary>
        /// <param name="issUrl"></param>
        public static implicit operator string(IssUrl issUrl)
        {
            return issUrl.ToString();
        }

        #endregion

        #region Public methods

        /// <inheritdoc />
        public override string ToString()
        {
            return _url;
        }

        #endregion
    }
}
