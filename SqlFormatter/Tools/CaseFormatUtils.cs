using System;
using SqlFormatter.Config;

namespace SqlFormatter.Tools
{
    static class CaseFormatUtils
    {
        public static string Convert(CaseType type, string value)
        {
            string aliasStr = string.Empty;
            int aliasIdx = value.LastIndexOf(".", StringComparison.Ordinal);
            if (aliasIdx >= 0)
            {
                aliasStr = value.Substring(0, aliasIdx + 1);
                value = value.Substring(aliasIdx + 1);
            }
            switch (type)
            {
                case CaseType.LowerCase:
                    return aliasStr + value.ToLower();
                case CaseType.UpperCase:
                    return aliasStr + value.ToUpper();
                case CaseType.IniCap:
                    return aliasStr + value[0].ToString().ToUpper() + value.Substring(1).ToLower();
                default:
                    return value;
            }
        }

    }
}
