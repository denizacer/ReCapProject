using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //bana iş kurallarını gönder
        public static IResult Run(params IResult[] logics)
        {
            //params motorun içine istediğin kadar şart koymanı sağlıyor
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;//error resul döndürcek
                }

            }
            return null;

        }
    }
}
