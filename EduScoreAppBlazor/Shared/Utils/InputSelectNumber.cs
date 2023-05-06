using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduScoreAppBlazor.Shared.Utils
{
    public class InputSelectNumber<Generics> : InputSelect<Generics>
    {
        protected override bool TryParseValueFromString(string value, out Generics result, out string validationMessage)
        {
            if (typeof(Generics) == typeof(int))
            {
                if (int.TryParse(value, out var resultInt))
                {
                    result = (Generics)(object)resultInt;
                    validationMessage = null;
                    return true;
                }
                else
                {
                    result = default;
                    validationMessage = "Valor inválido";
                    return false;
                }
            }
            else
            {
                return base.TryParseValueFromString(value, out result, out validationMessage);
            }
        }
    }
}
