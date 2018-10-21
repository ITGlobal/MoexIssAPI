using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace MoexIssAPI
{
    /// <summary>
    /// Базовый класс для чтения блока data ответов iss
    /// </summary>
    public abstract class PayloadDataBase
    {
        /// <summary>
        /// Инициализация из JArray, нужна для десереализации из json
        /// </summary>
        /// <param name="array"></param>
        public abstract void ReadFromJAray(JArray array);
    }
}
